using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAn_CTDLGT_1988216
{
    class Queue
    {
        private LinkedList<int> list;

        public Queue()
        {
            list = new LinkedList<int>();
        }

        public void IsQueueFull()
        {

            Console.Write(list.Count);
        }

        public int Count()
        {
            return list.Count;
        }

        public int getFromQueue(int pos)
        {
            return list.ElementAt<int>(pos);
        }

        public void push(int x)
        {
            // Đưa phần tử x vào cuối hàng đợi
            list.AddLast(x);
        }

        public void pop()
        {
            // Lấy phần tử đầu hàng đợi
            list.RemoveFirst();
        }

        public void printQueue()
        {
            foreach(int x in list)
            {
                Console.Write(x + " ");
            }
        }
    }
}
