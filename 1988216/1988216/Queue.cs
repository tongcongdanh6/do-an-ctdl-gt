using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1988216
{
    class Queue
    {
        private LinkedList<int> list;

        public Queue()
        {
            list = new LinkedList<int>();
        }

        public bool isQueueEmpty()
        {
            return list.Count == 0;
        }

        public void push(int x)
        {
            // Đưa phần tử x vào cuối hàng đợi
            list.AddLast(x);
        }

        public int pop()
        {
            // Lấy phần tử đầu hàng đợi
            int removedElement = list.ElementAt<int>(0);
            list.RemoveFirst();
            return removedElement;
        }
    }
}
