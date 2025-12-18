using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ex01
{
    internal class cuaDinamica<T>
    {

        #region classeNode
        private class Node
        {
            private T data;
            private Node next;



            public Node(T data)
            {
                this.data = data;
            }

            public T Data
            {
                get { return data; }
                set { data = value; }
            }

            public Node Next
            {
                get { return next; }
                set { next = value; }
            }
           

            





        }
        #endregion

        private Node head;
        private Node tail;
        private int nElem;


        public cuaDinamica()
        {
            head = null;
            tail = null;
            nElem = 0;
        }
        

        public int Count
        {
            get => nElem;
        }

        public bool IsEmpty
        {
            get => true;
        }



    }
}
