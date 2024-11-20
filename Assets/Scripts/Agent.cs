using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Agent : MonoBehaviour
{
    [SerializeField] private Model _model;
    public Controller _controller;

    [Header("Pathfinding")]
    [Header("FirstPath")]
    [SerializeField] private Pf_Node _startingNode1;
    [SerializeField] private Pf_Node _goalNode1;

    public Pf_Node StartingNode1 { get { return _startingNode1; } }
    public  Pf_Node GoalNode1 { get { return _goalNode1; }
}

    [Header("SecondPath")]
    [SerializeField] private Pf_Node _startingNode2;
    [SerializeField] private Pf_Node _goalNode2;

    public Pf_Node StartingNode2 { get { return _startingNode2; } }
    public Pf_Node GoalNode2 { get { return _goalNode2; } }

    public bool firstPath;

    [Header("FOV")]
    [SerializeField] private float _radius;
    [SerializeField] private float _angle;


    [Header("FSM")]
    public States _state;

    public enum States
    {
        Patrol,
        Chase,
        ChaseToPatrol,
    }

    private void Awake()
    {
        firstPath = true;
        _model = new AgentModel(transform, this, _radius, _angle);
        _controller = new AgentController(this, _model);

        _state = States.Patrol;
    }

    private void Start()
    {
        if(firstPath) GameManager.instance.StartPatrol(this, _startingNode1, _goalNode1);
        else GameManager.instance.StartPatrol(this, _startingNode2, _goalNode2);
    }

    private void Update()
    {
        _controller.Update();
    }

    public void StartPatrol()
    {
        if (firstPath) GameManager.instance.StartPatrol(this, _startingNode1, _goalNode1);
        else GameManager.instance.StartPatrol(this, _startingNode2, _goalNode2);
    }

    private void OnDrawGizmos()
    {
        var angleDirPos = new Vector3(Mathf.Sin(_angle / 2 * Mathf.Deg2Rad), 0, Mathf.Cos(_angle / 2 * Mathf.Deg2Rad));
        var angleDirNeg = new Vector3(-Mathf.Sin(_angle / 2 * Mathf.Deg2Rad), 0, Mathf.Cos(_angle / 2 * Mathf.Deg2Rad));

        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, _radius);

        Gizmos.matrix = Matrix4x4.TRS(transform.position, transform.rotation, new Vector3(1,0,1));
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(Vector3.zero, angleDirPos * _radius);
        Gizmos.DrawLine(Vector3.zero, angleDirNeg * _radius);

    }
}
