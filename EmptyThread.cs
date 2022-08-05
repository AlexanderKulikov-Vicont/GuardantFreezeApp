using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GuardantFreezeApp
{
    public class EmptyThread
    {
        private static Thread NewThread = null;
        private static object _Lock = new object();
        public static void MakeEmptyThread()
        {
            if (NewThread != null)
            {
                if (NewThread.ThreadState == System.Threading.ThreadState.Running ||
                    NewThread.ThreadState == System.Threading.ThreadState.WaitSleepJoin) { return; }
            }
            NewThread = new Thread(() =>
            {
                lock (_Lock)
                {
                    Console.WriteLine("Empty Thread");
                }
            });
            NewThread.Start();
        }
    }
}
