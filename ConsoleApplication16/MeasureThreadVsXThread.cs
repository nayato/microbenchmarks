namespace ConsoleApplication16
{
    using System;
    using System.Diagnostics;
    using System.Threading;
    using System.Threading.Tasks;
    using Wintellect;

    class MeasureThreadVsXThread
    {
        public static long Run()
        {
            long ran = 0;
            const int Iterations = 100 * 1000 * 1000;

            Thread thread = null;
            thread = new Thread(() =>
            {
                CodeTimer.Time(true, "Thread", Iterations, () =>
                {
                    if (Thread.CurrentThread == thread)
                    {
                        ran++;
                    }
                });
            });
            thread.Start();
            thread.Join(100000);

            XThread xthread = null;
            xthread = new XThread(() =>
            {
                CodeTimer.Time(true, "XThread", Iterations, () =>
                {
                    if (XThread.CurrentThread == xthread)
                    {
                        ran++;
                    }
                });
            });
            xthread.Start();
            xthread.Join(100000);

            return ran;
        }

        public delegate void XParameterizedThreadStart(object obj);

        [DebuggerDisplay("ID={threadID}, Name={Name}, IsExplicit={isExplicit}")]
        public sealed class XThread
        {
            static int maxThreadID = 0;
            readonly int threadID;
#pragma warning disable CS0414
            readonly bool isExplicit; // For debugging only
#pragma warning restore CS0414
            Task task;
            readonly EventWaitHandle completed = new EventWaitHandle(false, EventResetMode.AutoReset);
            readonly EventWaitHandle readyToStart = new EventWaitHandle(false, EventResetMode.AutoReset);

            [ThreadStatic]
            static XThread tls_this_thread;

            int GetNewThreadId()
            {
                maxThreadID = Interlocked.Increment(ref maxThreadID);
                return maxThreadID;
            }

            XThread()
            {
                this.threadID = this.GetNewThreadId();
                this.isExplicit = false;
                this.IsAlive = false;
            }

            void CreateLongRunningTask(XParameterizedThreadStart threadStartFunc)
            {
                this.task = Task.Factory.StartNew(() =>
                    {
                        // We start the task running, then unleash it by signaling the readyToStart event.
                        // This is needed to avoid thread reuse for tasks (see below)
                        this.readyToStart.WaitOne();
                        // This is the first time we're using this thread, therefore the TLS slot must be empty
                        if (tls_this_thread != null)
                        {
                            Debug.WriteLine("warning: tls_this_thread already created; OS thread reused");
                            Debug.Assert(false);
                        }
                        tls_this_thread = this;
                        threadStartFunc(this.startupParameter);
                        this.completed.Set();
                    },
                    CancellationToken.None,
                    TaskCreationOptions.LongRunning,
                    TaskScheduler.Default);
            }

            public XThread(Action action)
            {
                this.threadID = this.GetNewThreadId();
                this.isExplicit = true;
                this.IsAlive = false;
                this.CreateLongRunningTask(x => action());
            }

            public XThread(XParameterizedThreadStart threadStartFunc)
            {
                this.threadID = this.GetNewThreadId();
                this.isExplicit = true;
                this.IsAlive = false;
                this.CreateLongRunningTask(threadStartFunc);
            }

            public void Start()
            {
                this.readyToStart.Set();
                this.IsAlive = true;
            }

            object startupParameter;

            public void Start(object parameter)
            {
                this.startupParameter = parameter;
                this.Start();
            }

            public static void Sleep(int millisecondsTimeout)
            {
                Task.Delay(millisecondsTimeout).Wait();
            }

            public string Name;

            // NYI
            public bool IsBackground;

            public bool IsAlive { get; private set; }

            public static XThread CurrentThread
            {
                get
                {
                    if (tls_this_thread == null)
                        tls_this_thread = new XThread();
                    return tls_this_thread;
                }
            }

            public bool Join(TimeSpan timeout)
            {
                return this.completed.WaitOne(timeout);
            }

            public bool Join(int millisecondsTimeout)
            {
                return this.completed.WaitOne(millisecondsTimeout);
            }
        }
    }
}