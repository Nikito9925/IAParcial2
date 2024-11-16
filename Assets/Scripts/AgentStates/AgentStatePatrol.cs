using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentStatePatrol : AgentState
{
    private Model _model;
    public AgentStatePatrol(Model model)
    {
        _model = model;
    }
    public override void Awake()
    {

    }

    public override void Execute()
    {
        //FOV

        //detecta al player

        _model.Move();
    }

    public override void Sleep()
    {

    }
}
