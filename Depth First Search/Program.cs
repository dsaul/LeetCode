using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Depth_First_Search
{
	public class Node
	{
		[DebuggerDisplay("Id = {Id}")]
		public int Id { get; set; }

		public HashSet<Node> Neighbours { get; } = new HashSet<Node>();
		public void AddNeighbour(Node other)
		{
			if (!Neighbours.Contains(other))
			{
				Neighbours.Add(other);
				other.AddNeighbour(this);
			}
		}
		
	}


	public class Program
	{
		public static void Main(string[] args)
		{
			// Setup
			Node node0 = new Node { Id = 0 };
			Node node1 = new Node { Id = 1 };
			Node node2 = new Node { Id = 2 };
			Node node3 = new Node { Id = 3 };
			Node node4 = new Node { Id = 4 };
			Node node5 = new Node { Id = 5 };
			Node node6 = new Node { Id = 6 };
			Node node7 = new Node { Id = 7 };
			Node node8 = new Node { Id = 8 };
			Node node9 = new Node { Id = 9 };

			node0.AddNeighbour(node1);
			node0.AddNeighbour(node2);

			node1.AddNeighbour(node0);
			node1.AddNeighbour(node2);
			node1.AddNeighbour(node4);

			node2.AddNeighbour(node0);
			node2.AddNeighbour(node1);

			node3.AddNeighbour(node1);
			node3.AddNeighbour(node5);

			node4.AddNeighbour(node1);

			node5.AddNeighbour(node3);
			node5.AddNeighbour(node6);
			node5.AddNeighbour(node8);
			node5.AddNeighbour(node7);

			node6.AddNeighbour(node5);

			node7.AddNeighbour(node5);
			node7.AddNeighbour(node8);

			node8.AddNeighbour(node7);
			node8.AddNeighbour(node9);

			node9.AddNeighbour(node8);

			HashSet<Node> visited = new HashSet<Node>();

			DFS(visited, node0, (Node node) =>
			{
				Console.WriteLine($"Visited {node.Id}");
			});

		}

		public static void DFS(HashSet<Node> visitList, Node node, Action<Node> visitAction)
		{
			visitAction.Invoke(node);
			visitList.Add(node);

			foreach (Node neighbour in node.Neighbours)
			{
				if (!visitList.Contains(neighbour))
					DFS(visitList, neighbour, visitAction);
			}

		}


	}
}
