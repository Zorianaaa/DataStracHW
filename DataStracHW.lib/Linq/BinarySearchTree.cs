using System;
using System.Collections;
using System.Collections.Generic;

public class TreeNode<T>
{
    public T Value;
    public TreeNode<T> Left;
    public TreeNode<T> Right;

    public TreeNode(T value)
    {
        Value = value;
    }
}

public class BinarySearchTree<T> : IEnumerable<T>
{
    private TreeNode<T> _root;

    public void Add(T value)
    {
        _root = AddRecursive(_root, value);
    }

    private TreeNode<T> AddRecursive(TreeNode<T> node, T value)
    {
        if (node == null)
        {
            return new TreeNode<T>(value);
        }

        int comparison = Comparer<T>.Default.Compare(value, node.Value);
        if (comparison < 0)
        {
            node.Left = AddRecursive(node.Left, value);
        }
        else if (comparison > 0)
        {
            node.Right = AddRecursive(node.Right, value);
        }

        return node;
    }

    public IEnumerator<T> GetEnumerator()
    {
        return InOrderEnumerator(_root).GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    private IEnumerable<T> InOrderEnumerator(TreeNode<T> node)
    {
        if (node != null)
        {
            foreach (var left in InOrderEnumerator(node.Left))
            {
                yield return left;
            }
            yield return node.Value;
            foreach (var right in InOrderEnumerator(node.Right))
            {
                yield return right;
            }
        }
    }
}

