using System;

/*
 * Write code to partition a linkedlist around a value x, such that all nodes less than x come before all nodes great than or equal to x. */

namespace LinkedList7
{
    public class Node
    {
        public Node next;
        public int data;

        public Node()
        {
            next = null;
        }
        public Node(int value)
        {
            data = value;
            next = null;
        }
    }

    public class MyLL
    {
        Node head;

        public MyLL()
        {
            head = null;
        }

        public Node AddHead(int value)
        {
            Node node = new Node(value);
            node.next = head;
            head = node;
            return node;
        }

        public void PrintAllNodes()
        {
            Node cur = head;
            while (cur.next != null)
            {
                Console.WriteLine(cur.data);
                cur = cur.next;
            }
            Console.WriteLine(cur.data);
            Console.WriteLine();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
           
            Node Partition(Node head, int x)
            {
                Node lesshead = null, equalhead = null, greaterhead = null;
                Node lesstail = null, equaltail = null, greatertail = null;

                while (head != null)
                {
                    if (head.data == x)
                    {
                        if (equalhead == null)
                        {
                            equalhead = equaltail = head;
                            //equaltail = head;
                        }
                        else
                        {
                            equaltail.next = head;
                            equaltail = head;
                        }
                    }
                    else if (head.data < x)
                    {
                        if (lesshead == null)
                        {
                            lesshead = head;
                            lesstail = head;
                        }
                        else
                        {
                            lesstail.next = head;
                            lesstail = head;
                        }
                    }
                    else
                    {
                        if (greaterhead == null)
                        {
                            greaterhead = head;
                            greatertail = head;
                        }
                        else
                        {
                            greatertail.next = head;
                            greatertail = head;
                        }
                    }
                    head = head.next;
                }

                if (greaterhead != null)
                    greatertail.next = null;

                //// Connect three lists
                // If smaller list is empty
                if (lesshead == null)
                {
                    if (equalhead == null)
                        return greaterhead;
                    else
                    {
                        equaltail.next = greaterhead;
                        return equalhead;
                    }
                }

                // If smaller list is not empty and equal list is empty 
                if (equalhead == null)
                {
                    lesstail.next = greaterhead;
                    return lesshead;
                }

                // If both smaller and equal list 
                // are non-empty 
                lesstail.next = equalhead;
                equaltail.next = greaterhead;
                return lesshead;

            }

            Node Partition2(Node head, int x)
            {
                Node lesshead = null, greaterhead = null;
                Node lesstail = null, greatertail = null;

                while (head != null)
                {
                    if (head.data < x)
                    {
                        if (lesshead == null)
                        {
                            lesshead = head;
                            lesstail = head;
                        }
                        else
                        {
                            lesstail.next = head;
                            lesstail = head;
                        }
                    }
                    else
                    {
                        if (greaterhead == null)
                        {
                            greaterhead = head;
                            greatertail = head;
                        }
                        else
                        {
                            greatertail.next = head;
                            greatertail = head;
                        }
                    }
                    head = head.next;
                }

                if (greaterhead != null)
                    greatertail.next = null;

                //// Connect three lists
                // If smaller list is empty
                if (lesshead == null)
                {
                    return greaterhead;
                }

                // If smaller is non-empty 
                lesstail.next = greaterhead;
                return lesshead;
            }

            MyLL list = new MyLL();
            Node node = new Node();
            list.AddHead(3);
            list.AddHead(1);
            list.AddHead(4);
            list.AddHead(3);
            list.AddHead(2);
            list.AddHead(2);
            node = list.AddHead(8);

            list.PrintAllNodes();
            int xx = 3;
            node = Partition(node, xx);

            while (node.next != null)
            {
                Console.WriteLine(node.data);
                node = node.next;
            }
            Console.WriteLine(node.data);
            Console.WriteLine();

        }
    }
}
