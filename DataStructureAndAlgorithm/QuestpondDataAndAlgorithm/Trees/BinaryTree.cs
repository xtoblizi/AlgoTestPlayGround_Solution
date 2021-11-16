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

        private TreeNode<int> Search(TreeNode<int> rootNode, int data)
        {
            if (rootNode == null)
                return null;

            if (rootNode.Data == data)
                return rootNode;
            else
            {
                if (rootNode.Data > data)
                {
                    return Search(rootNode.Left, data);
                }
            }
            return rootNode;
        }
    }
}