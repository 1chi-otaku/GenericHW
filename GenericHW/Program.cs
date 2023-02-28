using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericHW
{
    class Program
    {
        static void Main(string[] args)
        {
            #region #1
            //int a = 5;
            //int b = 10;
            //Swap<int>(ref a, ref b);
            //Console.WriteLine(a);
            //Console.WriteLine(b);
            #endregion
            #region #2
            //int[] arr = new int[5] { 3, 2, 1, 4, 5 };
            //MyQueuePriority<int> queue= new MyQueuePriority<int>(arr);

            //for (int i = 0; i < 5; i++)
            //{
            //    queue.Print();
            //    queue.Denqueue();

            //}
            //queue.Denqueue();
            #endregion
            #region #3
            int[] arr = new int[5] { 3, 2, 1, 4, 5 };
            MyQueueCircle<int> queue = new MyQueueCircle<int>(arr);

            for (int i = 0; i < 5; i++)
            {
                queue.Print();
                Console.WriteLine();
                queue.Denqueue();
            }
            queue.Denqueue();

            #endregion

        }
        public static void Swap<T>(ref T a, ref T b)
        {
            T temp = a;
            a = b;
            b = temp;
        }
    }
    class MyQueuePriority<T> where T : IComparable<T>
    {
        T[] queue;
        public MyQueuePriority()
        {
            queue = new T[3];
        }
        public MyQueuePriority(int count)
        {
            queue = new T[count];
        }
        public MyQueuePriority(T[] queue)
        {
            this.queue = queue;
        }
        public void Print()
        {
            foreach (var item in queue)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }
        public void Enqueue(T item)
        {
            T[] newqueue = new T[queue.Length + 1];
            for (int i = 0; i < queue.Length; i++)
            {
                newqueue[i] = queue[i];
            }
            newqueue[queue.Length] = item;
            queue = newqueue;
        }
        public void Denqueue()
        {
            if (queue.Length <= 0) return;
            int index = 0;
            T max = queue[0];
            for (int i = 0; i < queue.Length; i++)
            {
                if (max.CompareTo(queue[i]) < 0)
                {
                    index = i;
                    max = queue[i];
                }
            }
            for (int i = index; i < queue.Length - 1; i++)
            {
                queue[i] = queue[i + 1];
            }
            Array.Resize(ref queue, queue.Length - 1);
        }
        public T Peek()
        {
            return queue[0];
        }
        public int Count()
        {
            return queue.Length;
        }
    }
    class MyQueueCircle<T> where T : IComparable<T>
    {
        T[] queue;
        public MyQueueCircle()
        {
            queue = new T[3];
        }
        public MyQueueCircle(int count)
        {
            queue = new T[count];
        }
        public MyQueueCircle(T[] queue)
        {
            this.queue = queue;
        }
        public void Print()
        {
            foreach (var item in queue)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }
        public void Enqueue(T item)
        {
            T[] newqueue = new T[queue.Length + 1];
            for (int i = 0; i < queue.Length; i++)
            {
                newqueue[i] = queue[i];
            }
            newqueue[queue.Length] = item;
            queue = newqueue;
        }
        public void Denqueue()
        {
            if (queue.Length <= 0) return;

            T element = queue[0];
            for (int i = 0; i < queue.Length-1; i++)
            {
                queue[i] = queue[i+1];
            }
            queue[queue.Length-1] = element;
        }
        public T Peek()
        {
            return queue[0];
        }
        public int Count()
        {
            return queue.Length;
        }
    }
}
