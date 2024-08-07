using System;
using System.Collections;
using System.Collections.Generic;

public class MyQueue<T> : IEnumerable<T>
{
    private Queue<T> _queue = new Queue<T>();

    public void Enqueue(T item)
    {
        _queue.Enqueue(item);
    }

    public T Dequeue()
    {
        return _queue.Dequeue();
    }

    public IEnumerator<T> GetEnumerator()
    {
        return _queue.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}
