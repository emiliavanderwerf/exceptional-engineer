using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment1
{
    public class Node
    {
        public decimal Value { get; set; }
        public Node Next { get; set; }

        public Node(decimal value)
        {
            this.Value = value;
        }
    }

    public class LinkedList
    {
        private Node head;

        public void Insert(decimal value)
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
