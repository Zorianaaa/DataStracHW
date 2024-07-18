using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStracHW.lib
{
    public class BinaryTreeNode
    {
        public int Data { get; set; }
        public BinaryTreeNode Left { get; set; }
        public BinaryTreeNode Right { get; set; }

        public BinaryTreeNode(int data)
        {
            Data = data;
            Left = null;
            Right = null;
        }
    }

    public class BinarySearchTree
    {
        public BinaryTreeNode Root { get; private set; }
        public int Count { get; private set; }

        public void Add(int value)
        {
            Root = AddRecursive(Root, value);
            Count++;
        }

        private BinaryTreeNode AddRecursive(BinaryTreeNode current, int value)
        {
            if (current == null)
            {
                return new BinaryTreeNode(value);
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

        private bool ContainsRecursive(BinaryTreeNode current, int value)
        {
            if (current == null)
            {
                return false;
            }

            if (value == current.Data)
            {
                return true;
            }

            return value < current.Data
                 ? ContainsRecursive(current.Left, value)
                 : ContainsRecursive(current.Right, value);

        }

        public void Clear()
        {
            Root = null;
            Count = 0;
        }

        public int[] ToArray()
        {
            int[] result = new int[Count];
            int index = 0;
            ToArrayRecursive(Root, result, ref index);
            return result;
        }

        private void ToArrayRecursive(BinaryTreeNode current, int[] array, ref int index)
        {
            if (current != null)
            {
                ToArrayRecursive(current.Left,  array, ref index);
                array[index++] = current.Data;
                ToArrayRecursive(current.Right,  array, ref index);
            }
        }
    }
}
