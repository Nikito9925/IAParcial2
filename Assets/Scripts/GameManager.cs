using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = default;

    public Pf_Node startingNode = default, goalNode = default;
    private PathFinding _pf = default;

    public Pf_Grid grid = default;
    public Pf_Agent agent = default;

    private void Awake()
    {
        if (!instance) instance = this;
        else Destroy(gameObject);

        _pf = new();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            grid.ResetNodesColors();
            List<Pf_Node> path = _pf.ConstructDijkstra(startingNode, goalNode);
            agent.SetPath(path);
            PaintPath(path);
        }
    }

    public void SetStartingNode(Pf_Node n)
    {
        if (startingNode) PaintGameObject(startingNode.gameObject, Color.white);
        startingNode = n;
        PaintGameObject(startingNode.gameObject, Color.yellow);

        agent.SetPos(startingNode.transform.position);
    }

    public void SetGoalNode(Pf_Node n)
    {
        if (goalNode) PaintGameObject(goalNode.gameObject, Color.white);
        goalNode = n;
        PaintGameObject(goalNode.gameObject, Color.red);
    }

    private void PaintPath(List<Pf_Node> path)
    {
        int index = 1;

        foreach (var item in path)
        {
            PaintGameObject(item.gameObject, Color.Lerp(Color.green, Color.blue, (float)index / path.Count));
            index++;
        }
    }

    public void PaintGameObject(GameObject obj, Color color)
    {
        obj.GetComponent<Renderer>().material.color = color;
    }
}
