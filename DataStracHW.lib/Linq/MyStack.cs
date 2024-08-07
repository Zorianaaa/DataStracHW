using System;
using System.Collections;
using System.Collections.Generic;

public class MyStack<T> : IEnumerable<T>
{
    private Stack<T> _stack = new Stack<T>();

    public void Push(T item)
    {
        _stack.Push(item);
    }

    public T Pop()
    {
        return _stack.Pop();
    }

    public IEnumerator<T> GetEnumerator()
    {
        return _stack.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}
