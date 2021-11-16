﻿using Xunit;
using FluentAssertions;
using QuestpondDataAndAlgorithm.Trees;

namespace ZXTEST.QuestpondDataAndAlgo
{
    public class BinaryTreeTest
    {
        [Fact]
        public void InsertTest_ReturnsNewNode_WhenInsertionIsMade()
        {
            // arrange 
            var tree = new BinaryTree();
            
            // act
            tree.Add(4);
            tree.Add(data:5);
            tree.Add(3);
            
            // assert
            tree.root.Should().NotBeNull();
            tree.root.Left.Data.Should().Be(3, because:"Its less than the root node");
            tree.root.Right.Data.Should().Be(5, "It's greater than the root node");
        }
    }
}