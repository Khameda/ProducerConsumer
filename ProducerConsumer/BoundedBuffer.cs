using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProducerConsumer
{
    class BoundedBuffer
    {
        private Queue<int> _queue;
        private int _cap;

        public BoundedBuffer(int capacity)
        {
            this._cap = capacity;
            this._queue = new Queue<int>();
        }


        
        public bool IsFull()
        {
            return false;
        }

        public bool IsEmpty()
        {
            return true;

        }
       
        public void Put(int element)
        {
            this._queue.Enqueue(element);
        }

        public int Take()
        {

            while (this._queue.Count == 0)
            {
                // wait wait wait vvw vvw vvw vvw while queue is empty
            }


             int temp = this._queue.Dequeue();
             return temp;
           
        }
    }
}
