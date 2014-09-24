using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProducerConsumer
{
    class BoundedBuffer
    {
        private Queue<int> _queue;
        private int _cap;
        public int NumberOfFills = 0;
        private bool _hasLastElement = false;
        public BoundedBuffer(int capacity)
        {
            this._cap = capacity;
            this._queue = new Queue<int>();
        }


        
        public bool IsFull()
        {

            if (this._queue.Count >= this._cap)
            {
                this.NumberOfFills ++;
                return true;
            }
            return false;
        }

        public bool IsEmpty()
        {
            return true;

        }
       
        public void Put(int element)
        {
            lock (this._queue)
            {
                while (this.IsFull())
                {
                    //wait wait wait indtil buffer is not full
                    Monitor.Wait(this._queue);
                }
         
                this._queue.Enqueue(element);
                Console.WriteLine("The value {0} was added to the buffer on thread X", element);
                Monitor.PulseAll(this._queue);
            }
        }

        public int Take()
        {
          
            lock (this._queue)
            {
                if (this._hasLastElement)
                {
                    return -1;
                }

                while (this._queue.Count == 0)
                {

                    // wait wait wait vvw vvw vvw vvw while queue is empty
                    Monitor.Wait(this._queue);

                    if (this._hasLastElement)
                    {
                        return -1;
                    }
                }


                int temp = this._queue.Dequeue();
                //if (temp == -1)
                //{
                //    this._queue.Enqueue(temp);
                //}
                if (temp == -1)
                {
                    this._hasLastElement = true;
                }

                Console.WriteLine("Element {0} was just removed from the buffer", temp);
                Monitor.PulseAll(this._queue);
                return temp;
            }
           
        }
    }
}
