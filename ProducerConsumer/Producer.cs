using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProducerConsumer
{
    class Producer
    {

        private int _max;
        private BoundedBuffer _buffer;
        private int _le= -1;
        


        public Producer(BoundedBuffer buffer, int howManytoproduce, int lastElement)
        {
            this._max = howManytoproduce;
            this._buffer = buffer;
            this._le = lastElement;

        }

        public void Run()
        {
            for (int i = this._max; i >=0 ; i--)
            {
                lock (this._buffer)
                {
                    this._buffer.Put(i);
                    
                   // Console.WriteLine("Producer added {0}", i);
                }

               
            }
            this._buffer.Put(_le);
            Console.WriteLine("Last Element added");
        }

       


      
    }
}
