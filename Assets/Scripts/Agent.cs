using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Agent : MonoBehaviour
{
    [SerializeField] private Model _model;
    [SerializeField] private Controller _controller;

    private void Awake()
    {
        _model = new AgentModel();
        _controller = new AgentController(_model);
    }
}
