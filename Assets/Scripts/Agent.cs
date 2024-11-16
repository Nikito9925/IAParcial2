using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Agent : MonoBehaviour
{
    [SerializeField] private Model _model;
    public Controller _controller;

    private void Awake()
    {
        _model = new AgentModel(transform);
        _controller = new AgentController(_model);
    }

    private void Update()
    {
        _controller.Update();
    }
}
