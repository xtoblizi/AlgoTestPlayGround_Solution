using System;
using System.Collections.Generic;
using System.Text;

namespace Xtoblizi.HackerRank.Statistics
{

    public static class ListListExtension
    {
        /// <summary>
        /// Create an extension method on linkedlist to add to the nth positoin of a linkedlist
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="linkedListNode"></param>
        /// <param name="data"></param>
        /// <param name="position"></param>
        /// <param name="head"></param>
        /// <returns></returns>
        public static LinkedListNode<T> AddAtNthPositoin<T>(this LinkedListNode<T> linkedListNode, T data, int position, LinkedListNode<T> head) where T : class
        {
            LinkedListNode<T> node_toadd = new LinkedListNode<T>(data);
            LinkedListNode<T> current = head;
            LinkedListNode<T> prev = null;
            int count = 0;

            //if (position == 0)
            //{
            //    node_toadd.Next = head;
            //    head = node_toadd;
              
            //    return head;
            //}

            //while (current != null && current.next != null && count < position)
            //{
            //    prev = current;
            //    current = current.next;
            //    count++;
            //}

            //node_toadd = prev.next;
            //prev.next = node_toadd;
            //node_toadd.next = current;

            return head;
        }
        public static LinkedListNode<T> Current<T>(this LinkedList<T> linkedList, LinkedListNode<T> current)
        {
            return current;
        } 
        
        public static int Index<T>(this LinkedListNode<T> linkedList, int index)
        {
            return index;
        }
    }

    public class LinkedListBase<T>
    {        
        public Node<T> head { get; set; }
      
        public LinkedListBase()
        {
            head = null;
        }
        public LinkedListBase(Node<T> head)
        {
            this.head = head;
        }

        public void AddToEnd(T data)
        {
            if (head == null)
                head = new Node<T>(data);

            else
                head.AddToEnd(data);
        }
        public void AddToBegining(T data)
        {
            if (head == null)
                head = new Node<T>(data);
            else
            {
                var temp = new Node<T>(data);
                temp.next = head;
                head = temp;
            }

                
        }

        public virtual void AddSortedAscending(T data)
        {
            //if (data is int)
            //{
            //    // box data to int
            //    object odata = data ;
            //    int ndata = (int)odata;

            //    if (head == null)
            //        head = new Node<T>(data);

            //    else if(ndata < head.data as int)
            //    {
            //        AddToBegining(data);
            //    }
                   

            //    else
            //    {
            //        head.AddSortedAscending(data);
            //    }
            //}
        }
        
        /// <summary>
        /// make sure to implement
        /// </summary>
        /// <param name="data"></param>
        public virtual void AddSortedDescending(int data)
        {
            //if (head == null)
            //    head = new Node(data);
            //else if(data > head.data)
            //    AddToBegining(data);
            
            //else
            //{
            //    head.AddSortedDescending(data);
            //}
        }

        /// <summary>
        /// You can utilize a binary search pattern to ascertain best position to start from on the list
        /// before applying logic for insertion to an nth position.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="position"></param>
        /// <param name="head"></param>
        public Node<T> AddToNthPosition(T data,int position,Node<T> head)
        {
            Node<T> node_toadd = new Node<T>(data);
            Node<T> current = head;
            Node<T> prev = null;
            int count = 0;

            if(position == 0)
            {
                node_toadd.next = head;
                head = node_toadd;
                Print();

                return head;
            }

            while(current != null && current.next != null && count < position)
            {
                prev = current;
                current = current.next;
                count++;
            }

            prev.next = node_toadd;
            node_toadd.next = current;

            return head;
        }

        public Node<T> insertNthRecursive(Node<T> head, T data, int position)
        {
            if (position == 0)
            {
                Node<T> node = new Node<T>(data);             
                node.next = head;
                return node;
            }
            head.next = insertNthRecursive(head.next, data, position - 1);
            return head;
        }

        public void Print()
        {
            if (head != null)
                head.Print();         
        } 
        public void Print(Node<T> hhead)
        {
            if (hhead != null)
                hhead.Print();
        }

    }

    public class Node<T> 
    {
        /**
         * private fields being data and next
         * data : the value of this data to be stored , this can be set to type object or generic or dynamic
         * next : a pointer to the next  node on the list this would be of type : "Node"
         * ctor : constructor of the node class 
         */

        public T data;
        public Node<T> next;
        public Node<T> prev;
       

        public Node(T i)
        {
            data = i;
            next = null;
            prev = null;
        }

        public virtual void Print()
        {
            Console.Write("|" + data + "|->");
            if(next != null)
            {
                next.Print();
            }
        }

        public virtual void AddToEnd(T data)
        {
            if (next == null)
                next = new Node<T>(data);
            else
                next.AddToEnd(data);
        } 
        
        public virtual void AddToBegining(int data)
        {
            //if (next == null)
            //    next = new Node(data);
            //else
            //    next.AddToEnd(data);
        }
        /// <summary>
        /// This would only apply if T is of type integer 
        /// </summary>
        /// <param name="data"></param>
        public virtual void AddSortedAscending(T data)
        {
            //if (next == null)
            //    next = new Node<T>(data);
            //else if (data < next.data)
            //{
            //    Node temp = new Node(data);
            //    temp.next = this.next;
            //    this.next = temp;
            //}
            //else
            //{
            //    next.AddSortedAscending(data);
            //}
        }

        /// <summary>
        /// This would only apply if T is of type number
        /// </summary>
        /// <param name="data"></param>
        public virtual void AddSortedDescending(T data)
        {
            //if (next == null)
            //    next = new Node<T>(data);
            //else if (data > next.data)
            //{
            //    Node temp = new Node(data);
            //    temp.next = this.next;
            //    this.next = temp;
            //}
            //else
            //{
            //    next.AddSortedAscending(data);
            //}
        }

        /// <summary>
        /// This inserts a node a given postion of a linked list utilizing recursive approach.
        /// </summary>
        /// <param name="head"></param>
        /// <param name="data"></param>
        /// <param name="position"></param>
        /// <returns></returns>
        public virtual Node<T> insertNthRecursive(Node<T> head, T data, int position)
        {
            if (position == 0)
            {
                Node<T> node = new Node<T>(data);
                node.next = head;
                return node;
            }
            head.next = insertNthRecursive(head.next, data, position - 1);
            return head;
        }

        
    }
}
