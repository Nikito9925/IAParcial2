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

    [Header("SecondPath")]
    [SerializeField] private Pf_Node _startingNode2;
    [SerializeField] private Pf_Node _goalNode2;

    public bool firstPath;

    private void Awake()
    {
        firstPath = true;
        _model = new AgentModel(transform, this);
        _controller = new AgentController(_model);
    }

    private void Start()
    {
        if(firstPath) GameManager.instance.StartPatrol(this, _startingNode1, _goalNode1);
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
}
