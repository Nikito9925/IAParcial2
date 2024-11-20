using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = default;
    public Transform _player;
    public Agent[] _agents;

    private PathFinding _pf = default;

    public Pf_Grid grid = default;
    //public Agent agent = default;

    private void Awake()
    {
        if (!instance) instance = this;
        else Destroy(gameObject);

        _pf = new();
    }

    private void Update()
    {

    }

    public void StartPatrol(Agent agent, Pf_Node startNode, Pf_Node goalNode)
    {
        //grid.ResetNodesColors();
        List<Pf_Node> path = _pf.ConstructAStar(startNode, goalNode);
        agent._controller._model.SetPath(path);
        //PaintPath(path);
    }

    public void StartChase(Agent agent, Transform agentPos, Transform playerPos)
    {
        Pf_Node newStart = _pf.GetClosestNode(agentPos, grid.nodes);
        Pf_Node newGoal = _pf.GetClosestNode(playerPos, grid.nodes);

        List<Pf_Node> path = _pf.ConstructAStar(newStart, newGoal);
        agent._controller._model.SetPath(path);

        Debug.Log("START CHASE");
    }

    /*
    public void SetStartingNode(Pf_Node n)
    {
        if (startingNode) PaintGameObject(startingNode.gameObject, Color.white);
        startingNode = n;
        PaintGameObject(startingNode.gameObject, Color.yellow);

        agent._controller._model.SetPos(startingNode.transform.position);
    }

    public void SetGoalNode(Pf_Node n)
    {
        if (goalNode) PaintGameObject(goalNode.gameObject, Color.white);
        goalNode = n;
        PaintGameObject(goalNode.gameObject, Color.red);
    }
    */

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

    public void AlertAgents()
    {
        foreach(Agent agent in _agents)
        {
            if(agent._state != Agent.States.Chase)
            {
                agent._controller._fsm.SetState<AgentStateChase>();
            }
        }
    }


}
