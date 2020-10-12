using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment1
{
    public class Node
    {
        public double Value { get; set; }
        public Node Next { get; set; }

        public Node(double value)
        {
            this.Value = value;
        }
    }

    public class LinkedList
    {
        private Node head;

        public void Insert(double value)
        {
            Node node = new Node(value);
            if (head != null)
            {
                node.Next = head;
            }
            head = node;
        }

        public Node GetLinkedList()
        {
            return head;
        }
    }
}
