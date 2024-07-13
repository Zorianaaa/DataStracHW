using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStracHW.lib
{
    public class Node
    {
        public int Data { get; set; }
        public Node Left { get; set; }
        public Node Right { get; set; }

        public Node(int data)
        {
            Data = data;
            Left = null;
            Right = null;
        }
    }

    public class BinarySearchTree
    {
        public Node Root { get; private set; }
        public int Count { get; private set; }

        public void Add(int value)
        {
            Root = AddRecursive(Root, value);
            Count++;
        }

        private Node AddRecursive(Node current, int value)
        {
            if (current == null)
            {
                return new Node(value);
            }

            if (value < current.Data)
            {
                current.Left = AddRecursive(current.Left, value);
            }
            else if (value >= current.Data)
            {
                current.Right = AddRecursive(current.Right, value);
            }

            return current;
        }

        public bool Contains(int value)
        {
            return ContainsRecursive(Root, value);
        }

        private bool ContainsRecursive(Node current, int value)
        {
            if (current == null)
            {
                return false;
            }

            if (value == current.Data)
            {
                return true;
            }

            return value < current.Data;

        }

        public void Clear()
        {
            Root = null;
            Count = 0;
        }

        public int[] ToArray()
        {
            int[] result = new int[Count];
            ToArrayRecursive(Root, ref result, 0);
            return result;
        }

        private void ToArrayRecursive(Node current, ref int[] array, int index)
        {
            if (current != null)
            {
                ToArrayRecursive(current.Left, ref array, index);
                array[index++] = current.Data;
                ToArrayRecursive(current.Right, ref array, index);
            }
        }
    }
}
