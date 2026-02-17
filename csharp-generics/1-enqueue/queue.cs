using System;

public class Queue<T>
{
    // Node class inside Queue<T>
    public class Node
    {
        public T value;      // value can be any type
        public Node next;    // next node in the queue

        // Constructor to set the value
        public Node(T value)
        {
            this.value = value;
            this.next = null; // initially points to nothing
        }
    }

    // Queue properties
    public Node head;  // first node in the queue
    public Node tail;  // last node in the queue
    private int count; // number of nodes in the queue

    // Constructor for empty queue
    public Queue()
    {
        head = null;
        tail = null;
        count = 0;
    }

    // Enqueue method: adds a new node to the end
    public void Enqueue(T value)
    {
        Node newNode = new Node(value);

        if (count == 0)
        {
            // If queue is empty, head and tail are the new node
            head = newNode;
            tail = newNode;
        }
        else
        {
            // Add new node at the end and update tail
            tail.next = newNode;
            tail = newNode;
        }

        count++; // increment count
    }

    // Returns the number of nodes in the queue
    public int Count()
    {
        return count;
    }
}
