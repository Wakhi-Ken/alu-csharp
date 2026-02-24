using System;
using System.Collections;
using System.Collections.Generic;

public class Objs<T> : IEnumerable<T>
{
    private List<T> _items = new List<T>();

    // Add an item to the collection
    public void Add(T item)
    {
        _items.Add(item);
    }

    // Implement GetEnumerator() for IEnumerable<T>
    public IEnumerator<T> GetEnumerator()
    {
        foreach (T item in _items)
        {
            yield return item;
        }
    }

    // Explicit implementation for non-generic IEnumerable
    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}