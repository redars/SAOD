using System;
using System.Collections.Generic;
using System.Text;

namespace SAOD_1
{
    class MyStack <T>
    {
        private T[] data;
        private int size;
        private int Capacity;
        public MyStack()
        {
            size = 0;
            Capacity = 1;
            data = new T[0];
        }
        public T Peek()
        {
            if(size!=0)
            {
                return data[size - 1];
            }
            else
            {
                return default(T);
            }
        }
        public void Push(T x)
        {
            if (size == Capacity - 1)
            {
                Capacity *= 2;
                Array.Resize(ref data, Capacity);
            }
            size++;
            data[size - 1] = x;
        }
        public void Pop()
        {
            if (size!=0)
            {
                Array.Resize(ref data, --size);
            }
        }
        public bool IsEmpty()
        {
            return size == 0;
        }
        public void Clear()
        {
            size = 0;
            data = new T[0];
        }
    }
}
