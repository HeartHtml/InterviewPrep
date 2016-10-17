using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InterviewPrep.Interfaces;

namespace InterviewPrep.Entities
{
    public class Node
    {
        public Node Next { get; set; }

        public int NodeValue { get; set; }
    }

    public class CustomLinkedList : IEnumerable, IPrintable
    {
        public Node Head { get; set; }

        public CustomLinkedList()
        {
            Head = new Node();
        }

        public void Add(int value)
        {
            if (Head.Next == null)
            {
                Head.NodeValue = value;
            }
            else
            {
                Node currentNode = Head.Next;

                Node previousNode = Head;

                while (currentNode != null)
                {
                    previousNode = currentNode;

                    currentNode = currentNode.Next;
                }

                currentNode = new Node
                {
                    NodeValue = value
                };

                previousNode.Next = currentNode;
            }

            Sort(Head);
        }

        private void Sort(Node head)
        {
            throw new NotImplementedException();
        }

        private int Size()
        {
            throw new NotImplementedException();
        }

        private Node Get(int i)
        {
            throw new NotImplementedException();
        }

        public IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public string Print()
        {
            throw new NotImplementedException();
        }
    }
}
