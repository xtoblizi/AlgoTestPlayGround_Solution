using System;

namespace QuestpondDataAndAlgorithm.Trees
{
    /// <summary>
    /// Data structure that aligns to a tree based node
    /// </summary>
    public class BinaryTree
    {
        public TreeNode<int> root = null;

        public void Add(int data)
        {
            var newITem = new TreeNode<int>(data);
            if (root == null)
                root = newITem;
            else
            {
                AddNode( root, newITem);
            }
        }
        public bool Search(int data)
        {
            if (root == null)
                return false;

            return Search(root, data) != null;
        }

        private TreeNode<int> AddNode(TreeNode<int> rootNode, TreeNode<int> newNode)
        {
            // base Case
            if (rootNode == null)
                rootNode = newNode;
            else
            {
                if (rootNode.Data > newNode.Data)
                {
                    rootNode.Left = AddNode(rootNode.Left, newNode); 
                }
                else if(rootNode.Data < newNode.Data )
                {
                   rootNode.Right = AddNode(rootNode.Right, newNode);
                }
            }
            
            return rootNode;
        }

        /// <summary>
        /// This Binary tree search search algorithm presumes that data has been sorted and insertion of data starts from the
        /// median of the sequence.
        /// Sample input arr 1234567 after sort and return median is 4
        /// </summary>
        /// <param name="rootNode"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        private TreeNode<int> Search(TreeNode<int> rootNode, int data)
        {
            if (rootNode == null)
                return null;

            if (rootNode.Data == data)
                return rootNode;
           
            if (rootNode.Data > data)
                return Search(rootNode.Left, data);
            
            return Search(rootNode.Right, data);
        }

        /// <summary>
        /// Sort list before inserting into a tree DS
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        public int[] SortArray(int[] arr)
        {
            Array.Sort(arr);
            return arr;
        }

        /// <summary>
        /// Get median and start insertion at this point.
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public int MedianIndex(int[] arr)
        {
            if (arr.Length == 0)
                throw new ArgumentException("Array should not be empty");

            if (arr.Length == 1 || arr.Length == 2)
                return 1;

            var middle = arr.Length / 2m;
            return (int)Math.Ceiling(middle);
        }
    }
}