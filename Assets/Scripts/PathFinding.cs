using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinding 
{
    public List<Pf_Node> ConstructBFS(Pf_Node startNode, Pf_Node endNode)
    {
        if (startNode == null || endNode == null) return null;

        Queue<Pf_Node> frontier = new();
        frontier.Enqueue(startNode); //Guarda/toma el primer nodo.

        Dictionary<Pf_Node, Pf_Node> cameFrom = new(); //Por cada nodo, queremos que sepa de donde vino.
        cameFrom.Add(startNode, null);

        while (frontier.Count > 0) //Encuentra nodos que no checkeo.
        {
            Pf_Node current = frontier.Dequeue(); //Lo saca y lo utiliza.

            if (current == endNode)
            {
                List<Pf_Node> path = new();
                Pf_Node nodeToAdd = current;

                while (nodeToAdd != null)
                {
                    path.Add(nodeToAdd);
                    nodeToAdd = cameFrom[nodeToAdd]; //Se obtiene el nodo anterior.
                }
                path.Reverse();
                return path;
            }

            foreach (Pf_Node next in current.GetNeighbors())
            {
                if (!cameFrom.ContainsKey(next) && !next.isBlocked)
                {
                    frontier.Enqueue(next);
                    cameFrom.Add(next, current);
                }
            }
        }
        return null;
    }

    public List<Pf_Node> ConstructDijkstra(Pf_Node startNode, Pf_Node endNode)
    {
        if (startNode == null || endNode == null) return null;

        PriorityQueue<Pf_Node> frontier = new();
        frontier.Put(startNode, 0);

        Dictionary<Pf_Node, Pf_Node> cameFrom = new(); 
        cameFrom.Add(startNode, null);

        Dictionary<Pf_Node, float> costSoFar = new();
        costSoFar.Add(startNode, 0);

        while (frontier.Count > 0) 
        {
            Pf_Node current = frontier.Get(); 

            if (current == endNode)
            {
                List<Pf_Node> path = new();
                Pf_Node nodeToAdd = current;

                while (nodeToAdd != null)
                {
                    path.Add(nodeToAdd);
                    nodeToAdd = cameFrom[nodeToAdd]; 
                }
                path.Reverse();
                return path;
            }

            foreach (Pf_Node next in current.GetNeighbors())
            {
                float newCost = costSoFar[current] + next.cost;

                if (!cameFrom.ContainsKey(next) && !next.isBlocked)
                {
                    frontier.Put(next, newCost);
                    cameFrom.Add(next, current);
                    costSoFar.Add(next, newCost);
                }
            }
        }
        return null;
    }
}
