using System.Threading;

namespace ConnTest.Infrastructure
{
    internal class InstanceChecker
    {
        static readonly Mutex mutex = new Mutex(false, "ConnTest");
        public static bool TakeMemory()
        {
            return mutex.WaitOne();
        }
    }
}
