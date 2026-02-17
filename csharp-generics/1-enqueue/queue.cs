using System;

public class Queue<T>
{
    // Node class inside Queue<T>
    public class Node
    {
        public T value;      // value can be any type
        public Node next;    // next node in the queue

        public Node(T value)
        {
            this.value = value;
            this.next = null;
        }
    }

    // Queue properties
    public Node head;
    public Node tail;
    private int count;

    public Queue()
    {
        head = null;
        tail = null;
        count = 0;
    }

    // Adds a new node to the end of the queue
    public void Enqueue(T value)
    {
        Node newNode = new Node(value);

        if (count == 0)
        {
            head = newNode;
            tail = newNode;
        }
        else
        {
            tail.next = newNode;
            tail = newNode;
        }

        count++;
    }

    // Returns the number of nodes
    public int Count()
    {
        return count;
    }

    
    public Type CheckType()
    {
        return typeof(T);
    }
}
