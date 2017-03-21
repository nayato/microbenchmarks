namespace Wintellect
{
    using System;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Runtime.InteropServices;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Win32.SafeHandles;

    /// <summary>
    ///     A class that returns the cycle times for a process or threads.
    /// </summary>
    /// <remarks>
    ///     Cycle time is a more accurate representation of operation time than
    ///     milliseconds. Also, this class will only function on Windows Vista and
    ///     higher.
    /// </remarks>
    public sealed class CycleTime
    {
        /// <summary>
        ///     Is this class instance supposed to track thread time or process time?
        /// </summary>
        readonly bool trackingThreadTime;

        /// <summary>
        ///     The handle of the process this instance is watching.
        /// </summary>
        readonly SafeWaitHandle handle;

        /// <summary>
        ///     The initial cycle time to determine total cycles.
        /// </summary>
        readonly ulong startCycleTime;

        /// <summary>
        ///     Initializes a new instance of the CycleTime class.
        /// </summary>
        /// <param name="trackingThreadTime">
        ///     True if you want to track the current thread time. False for the
        ///     process as a whole.
        /// </param>
        /// <param name="handle">
        ///     The handle to the process for observing.
        /// </param>
        CycleTime(bool trackingThreadTime, SafeWaitHandle handle)
        {
            this.trackingThreadTime = trackingThreadTime;
            this.handle = handle;
            this.startCycleTime = this.trackingThreadTime
                ? Thread()
                : Process(this.handle);
        }

        /// <summary>
        ///     Starts timing for the specified thread.
        /// </summary>
        /// <param name="threadHandle">
        ///     The handle to the thread to time.
        /// </param>
        /// <returns>
        ///     A <see cref="CycleTime" /> instance for timing the specified thread.
        /// </returns>
        public static CycleTime StartThread(SafeWaitHandle threadHandle)
        {
            return new CycleTime(true, threadHandle);
        }

        /// <summary>
        ///     Stars timing for the specified process.
        /// </summary>
        /// <param name="processHandle">
        ///     The handle to the process to time.
        /// </param>
        /// <returns>
        ///     A <see cref="CycleTime" /> instance for timing the specified process.
        /// </returns>
        public static CycleTime StartProcess(SafeWaitHandle processHandle)
        {
            return new CycleTime(false, processHandle);
        }

        /// <summary>
        ///     Retrieves the cycle time for the specified thread.
        /// </summary>
        /// <param name="threadHandle">
        ///     Identifies the thread whose cycle time you'd like to obtain.
        /// </param>
        /// <returns>
        ///     The thread's cycle time.
        /// </returns>
        /// <exception cref="Win32Exception">
        ///     Thrown if the underlying timing API fails.
        /// </exception>
        [CLSCompliant(false)]
        public static ulong Thread(SafeWaitHandle threadHandle)
        {
            ulong cycleTime;
            if (!QueryThreadCycleTime(threadHandle, out cycleTime))
            {
                throw new Win32Exception();
            }
            return cycleTime;
        }

        /// <summary>
        ///     Retrieves the cycle time for the current thread.
        /// </summary>
        /// <returns>
        ///     The thread's cycle time.
        /// </returns>
        /// <exception cref="Win32Exception">
        ///     Thrown if the underlying timing API fails.
        /// </exception>
        [CLSCompliant(false)]
        public static ulong Thread()
        {
            ulong cycleTime;
            if (!QueryThreadCycleTime((IntPtr)(-2), out cycleTime))
            {
                throw new Win32Exception();
            }
            return cycleTime;
        }

        /// <summary>
        ///     Retrieves the sum of the cycle time of all threads of the specified
        ///     process.
        /// </summary>
        /// <param name="processHandle">
        ///     Identifies the process whose threads' cycles times you'd like to
        ///     obtain.
        /// </param>
        /// <returns>
        ///     The process' cycle time.
        /// </returns>
        /// <exception cref="Win32Exception">
        ///     Thrown if the underlying timing API fails.
        /// </exception>
        [CLSCompliant(false)]
        public static ulong Process(SafeWaitHandle processHandle)
        {
            ulong cycleTime;
            if (!QueryProcessCycleTime(processHandle, out cycleTime))
            {
                throw new Win32Exception();
            }
            return cycleTime;
        }

        /// <summary>
        ///     Retrieves the cycle time for the idle thread of each processor in
        ///     the system.
        /// </summary>
        /// <returns>
        ///     The number of CPU clock cycles used by each idle thread.
        /// </returns>
        /// <exception cref="Win32Exception">
        ///     Thrown if the underlying timing API fails.
        /// </exception>
        [CLSCompliant(false)]
        public static ulong[] IdleProcessors()
        {
            int byteCount = Environment.ProcessorCount;
            var cycleTimes = new ulong[byteCount];
            byteCount *= 8; // Size of UInt64
            if (!QueryIdleProcessorCycleTime(ref byteCount, cycleTimes))
            {
                throw new Win32Exception();
            }
            return cycleTimes;
        }

        /// <summary>
        ///     Calculates the elapsed cycle times.
        /// </summary>
        /// <returns>
        ///     The elapsed time.
        /// </returns>
        [CLSCompliant(false)]
        public ulong Elapsed()
        {
            ulong now = this.trackingThreadTime
                ? Thread() :
                Process(this.handle);
            return now - this.startCycleTime;
        }

        [DllImport("Kernel32", ExactSpelling = true, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool
            QueryThreadCycleTime(IntPtr threadHandle, out ulong CycleTime);

        [DllImport("Kernel32", ExactSpelling = true, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool
            QueryThreadCycleTime(SafeWaitHandle threadHandle,
                out ulong CycleTime);

        [DllImport("Kernel32", ExactSpelling = true, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool
            QueryProcessCycleTime(SafeWaitHandle processHandle,
                out ulong CycleTime);

        [DllImport("Kernel32", ExactSpelling = true, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool
            QueryIdleProcessorCycleTime(ref int byteCount,
                ulong[] CycleTimes);
    }

    /// <summary>
    ///     A class that assists in timing short pieces of code.
    /// </summary>
    public sealed class CodeTimer : IDisposable
    {
        /// <summary>
        ///     Holds the stopwatch time.
        /// </summary>
        readonly long startTime;

        /// <summary>
        ///     Holds the cycle time.
        /// </summary>
        readonly ulong startCycles;

        /// <summary>
        ///     The string to display along with the performance information at the
        ///     end of the run.
        /// </summary>
        readonly string testText;

        /// <summary>
        ///     Gen 0 starting count.
        /// </summary>
        readonly int gen0Start;

        /// <summary>
        ///     Gen 1 starting count.
        /// </summary>
        readonly int gen1Start;

        /// <summary>
        ///     Gen 2 starting count.
        /// </summary>
        readonly int gen2Start;

        /// <summary>
        ///     Initializes a new instance of the CodeTimer class.
        /// </summary>
        /// <param name="startFresh">
        ///     If true, forces a GC in order to count just new garbage collections.
        /// </param>
        /// <param name="format">
        ///     A composite text string.
        /// </param>
        /// <param name="args">
        ///     An array of objects to write with <paramref name="format" />.
        /// </param>
        CodeTimer(bool startFresh,
            string format,
            params object[] args)
        {
            if (startFresh)
            {
                PrepareForOperation();
            }

            this.testText = string.Format(format, args);

            this.gen0Start = GC.CollectionCount(0);
            this.gen1Start = GC.CollectionCount(1);
            this.gen2Start = GC.CollectionCount(2);

            // Get the time before returning so that any code above doesn't 
            // impact the time.
            this.startTime = Stopwatch.GetTimestamp();
            this.startCycles = CycleTime.Thread();
        }

        /// <summary>
        ///     The delegate to execute and time.
        /// </summary>
        public delegate void TimedOperation();

        /// <summary>
        ///     Times the operation in <paramref name="operation" />.
        /// </summary>
        /// <param name="text">
        ///     The text to display along with the timing information.
        /// </param>
        /// <param name="iterations">
        ///     The number of times to execute <paramref name="operation" />.
        /// </param>
        /// <param name="operation">
        ///     The <see cref="TimedOperation" /> delegate to execute.
        /// </param>
        public static void Time(string text,
            int iterations,
            TimedOperation operation)
        {
            Time(false, text, iterations, operation);
        }

        /// <summary>
        ///     Times the operation in <paramref name="operation" />.
        /// </summary>
        /// <param name="startFresh">
        ///     If true, forces a GC in order to count just new garbage collections.
        /// </param>
        /// <param name="text">
        ///     The text to display along with the timing information.
        /// </param>
        /// <param name="iterations">
        ///     The number of times to execute <paramref name="operation" />.
        /// </param>
        /// <param name="operation">
        ///     The <see cref="TimedOperation" /> delegate to execute.
        /// </param>
        public static void Time(bool startFresh,
            string text,
            int iterations,
            TimedOperation operation)
        {
            operation();

            using (new CodeTimer(startFresh, text))
            {
                while (iterations-- > 0)
                {
                    operation();
                }
            }
        }

        public static void TimeAsync(bool startFresh, string text, int iterations, Func<Task> operation)
        {
            operation().Wait();

            using (new CodeTimer(startFresh, text))
            {
                X(iterations, operation).Wait();
            }
        }

        static async Task X(int iterations, Func<Task> operation)
        {
            while (iterations-- > 0)
            {
                await operation(); //.ConfigureAwait(false);
            }
        }

        public void Dispose()
        {
            ulong elapsedCycles = CycleTime.Thread() - this.startCycles;

            // Get the elapsed time now so that any code below doesn't impact 
            // the time.
            long elapsedTime = Stopwatch.GetTimestamp() - this.startTime;

            long milliseconds = (elapsedTime * 1000) / Stopwatch.Frequency;

            if (false == string.IsNullOrEmpty(this.testText))
            {
                ConsoleColor defColor = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("{0}", this.testText);
                Console.ForegroundColor = defColor;
                Console.WriteLine("   {0,7:N0}ms {1,11:N0}Kc (G0={2,4}, G1={3,4}, G2={4,4})",
                    milliseconds,
                    elapsedCycles / 1000,
                    GC.CollectionCount(0) - this.gen0Start,
                    GC.CollectionCount(1) - this.gen1Start,
                    GC.CollectionCount(2) - this.gen2Start);
            }
        }

        static void PrepareForOperation()
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
        }
    }

    /// <summary>
    ///     Listen to the garbage collector. It's Code Music.
    /// </summary>
    public sealed class GCBeep
    {
        static byte silence = 0;

        public static bool Silence
        {
            get { return (Thread.VolatileRead(ref silence) != 0); }
            set { Thread.VolatileWrite(ref silence, (byte)(value ? 1 : 0)); }
        }

        /// <summary>
        ///     Finalizes an instance of the GCBeep class.
        /// </summary>
        ~GCBeep()
        {
            // We're being finalized, beep (unless silenced).
            if (!Silence)
            {
                Console.Beep();
            }

            // If the AppDomain isn't unloading and if the process isn’t
            // shutting down, create a new object that will get finalized 
            // at the next collection.
            if (!AppDomain.CurrentDomain.IsFinalizingForUnload() &&
                !Environment.HasShutdownStarted)
            {
                new GCBeep();
            }
        }
    }
}