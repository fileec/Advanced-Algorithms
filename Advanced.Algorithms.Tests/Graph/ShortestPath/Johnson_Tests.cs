﻿using System.Linq;
using Advanced.Algorithms.DataStructures.Graph.AdjacencyList;
using Advanced.Algorithms.Graph;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Advanced.Algorithms.Tests.Graph
{
    [TestClass]
    public class Johnsons_Tests
    {
        [TestMethod]
        public void Johnsons_Smoke_Test()
        {
            var graph = new WeightedDiGraph<char, int>();

            graph.AddVertex('S');
            graph.AddVertex('A');
            graph.AddVertex('B');
            graph.AddVertex('C');
            graph.AddVertex('D');
            graph.AddVertex('T');

            graph.AddEdge('S', 'A', -5);
            graph.AddEdge('S', 'C', 10);

            graph.AddEdge('A', 'B', 10);
            graph.AddEdge('A', 'C', 1);
            graph.AddEdge('A', 'D', 8);

            graph.AddEdge('B', 'T', 4);

            graph.AddEdge('C', 'D', 1);

            graph.AddEdge('D', 'B', 1);
            graph.AddEdge('D', 'T', 10);

            var algo = new JohnsonsShortestPath<char, int>(new JohnsonsShortestPathOperators());

            var result = algo.GetAllPairShortestPaths(graph);

            var testCase = result.First(x => x.Source == 'S' && x.Destination == 'T');
            Assert.AreEqual(2, testCase.Distance);

            var expectedPath = new char[] { 'S', 'A', 'C', 'D', 'B', 'T' };
            for (int i = 0; i < expectedPath.Length; i++)
            {
                Assert.AreEqual(expectedPath[i], testCase.Path[i]);
            }

        }

        /// <summary>
        /// generic operations for int type
        /// </summary>
        public class JohnsonsShortestPathOperators 
            : IJohnsonsShortestPathOperators<char, int>
        {
            public int DefaultValue
            {
                get
                {
                    return 0;
                }
            }

            public int MaxValue
            {
                get
                {
                    return int.MaxValue;
                }
            }

            /// <summary>
            /// return a char not in graph
            /// </summary>
            /// <returns></returns>
            public char RandomVertex()
            {
                return '*';
            }

            public int Substract(int a, int b)
            {
                return checked(a - b);
            }

            public int Sum(int a, int b)
            {
                return checked(a + b);
            }
        }
    }
}
