namespace QuestpondDataAndAlgorithm.Trees
{
    public class TreeNode<T>
    {
        public TreeNode(T data)
        {
            Data = data;
        }

        public TreeNode()
        {}
        public T Data { get; set; }
        public TreeNode<T> Left { get; set; }
        public TreeNode<T> Right { get; set; }
    }
}