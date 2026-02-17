using System;

public class Queue<T>
{
    public class Node
    {
        public T value;
        public Node? next;

        public Node(T value)
        {
            this.value = value;
            this.next = null;
        }
    }

    public Node? head;
    public Node? tail;
    public int count;

    public Type CheckType()
    {
        return typeof(T);
    }

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
            tail!.next = newNode;
            tail = newNode;
        }

        count++;
    }

    public T Dequeue()
    {
        if (count == 0)
        {
            Console.WriteLine("Queue is empty");
            return default(T)!;
        }

        T value = head!.value;
        head = head.next;
        count--;

        if (count == 0)
        {
            tail = null;
        }

        return value;
    }

    public int Count()
    {
        return count;
    }
}