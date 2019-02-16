using System;
using System.Threading;

namespace Practice
{
    class Trash
    {
        public void Main()
        {
            Timer time = new Timer(TimerCallback, null, 0, 1000);
            Console.ReadLine();
        }
        public static void TimerCallback(object obj)
        {
            Console.WriteLine("I hope everything went well");
            GC.Collect();
        }
    }

    class BetterTrash
    {
        public void Main()
        {
            Timer time = new Timer(Trash.TimerCallback, null, 0, 1000);
            Console.ReadLine();
            time.Dispose();
        }
    }

    public static class MySon
    {
        public static Action<int> TheGarbageIsFull = null;
        public static Action<int> PlayComputer = null;

        public static event Action<int> MyDisision{
            add {
                if (TheGarbageIsFull == null)
                { new TakeOutTheTrash(0); new TakeOutTheTrash(2); }
                TheGarbageIsFull += value;
            }
            remove { PlayComputer -= value; }
        }
        public sealed class TakeOutTheTrash
        {
            private int act;
            public TakeOutTheTrash(int act) { this.act = act; }
            ~TakeOutTheTrash()
            {
                Action<int> temp = Volatile.Read(ref TheGarbageIsFull);
                if (temp != null)
                {
                    temp(act);
                }

                if (act == null) new TakeOutTheTrash(0);
                else GC.ReRegisterForFinalize(this);
            }        
        }
    }
    
}
