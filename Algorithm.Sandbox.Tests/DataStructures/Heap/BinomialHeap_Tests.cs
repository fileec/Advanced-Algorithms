﻿using Algorithm.Sandbox.DataStructures;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace Algorithm.Sandbox.Tests.DataStructures.Heap
{
    [TestClass]
    public class BinomialMinHeap_Tests
    {
        /// <summary>
        /// A tree test
        /// </summary>
        [TestMethod]
        public void BinomialMinHeap_Test()
        {
            int nodeCount = 1000 * 10;
            //insert test
            var tree = new AsBinomialMinHeap<int>();

            var nodePointers = new AsArrayList<AsBinomialTreeNode<int>>();

            for (int i = 0; i <= nodeCount; i++)
            {
                var node = tree.Insert(i);
                nodePointers.AddItem(node);
                var theoreticalTreeCount = Convert.ToString(i + 1, 2).Replace("0", "").Length;
                var actualTreeCount = tree.heapForest.Count();

                Assert.AreEqual(theoreticalTreeCount, actualTreeCount);
            }

            for (int i = 0; i <= nodeCount; i++)
            {
                nodePointers[i].Value--;
                tree.DecrementKey(nodePointers[i]);
            }

            for (int i = 0; i <= nodeCount; i++)
            {
                var min = tree.ExtractMin();
                Assert.AreEqual(min, i - 1);
            }

            nodePointers.Clear();

            var rnd = new Random();
            var testSeries = Enumerable.Range(1, nodeCount).OrderBy(x => rnd.Next()).ToList();

            foreach (var item in testSeries)
            {
                nodePointers.AddItem(tree.Insert(item));
            }


            for (int i = 0; i < nodeCount; i++)
            {
                nodePointers[i].Value--;
                tree.DecrementKey(nodePointers[i]);
            }

            for (int i = 1; i <= nodeCount; i++)
            {
                var min = tree.ExtractMin();
                Assert.AreEqual(min, i-1);
            }

        }
    }
}