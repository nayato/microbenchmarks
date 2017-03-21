namespace ConsoleApplication16
{
    using System;
    using System.Text;
    using System.Threading.Tasks;

    static class Extensions
    {
        public static string ToString(this StringBuilder stringBuilder, int startIndex)
        {
            return stringBuilder.ToString(startIndex, stringBuilder.Length - startIndex);
        }

        public static void trimToSize(this StringBuilder stringBuilder)
        {
            stringBuilder.Capacity = stringBuilder.Length;
        }

        public static void OnFaultOrSuccess(this Task task, Action<Task> action)
        {
            if (task.IsCompleted)
            {
                action(task);
                return;
            }
            task.ContinueWith(action,
                TaskContinuationOptions.NotOnCanceled | TaskContinuationOptions.ExecuteSynchronously);
        }

        public static void OnFault(this Task task, Action<Task> faultAction)
        {
            if (task.IsCompleted)
            {
                if (task.IsFaulted)
                {
                    faultAction(task);
                }
                return;
            }
            task.ContinueWith(faultAction,
                TaskContinuationOptions.OnlyOnFaulted | TaskContinuationOptions.ExecuteSynchronously);
        }

        public static void OnSuccess(this Task task, Action<Task> successAction)
        {
            if (task.Status == TaskStatus.RanToCompletion)
            {
                successAction(task);
                return;
            }
            task.ContinueWith(successAction,
                TaskContinuationOptions.OnlyOnRanToCompletion | TaskContinuationOptions.ExecuteSynchronously);
        }
    }
}