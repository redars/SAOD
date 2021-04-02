using System;
using System.Collections.Generic;
using System.Text;

namespace VectorList
{
    class VectorList<T>
    {
        int size;
        T [] data;
        public VectorList()
        {
            data = new T[0];
        }
        public void Add(T t)
        {
            data[size - 1] = t;
        }
        public void Insert(T t,int i)
        {
            data[i] = t;
        }
        public void RemoveAt(int i)
        {
            data[i].
        }
    }
}
