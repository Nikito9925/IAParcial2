using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentStatePatrol : AgentState
{
    private Model _model;
    public AgentStatePatrol(Model model, StateMachine<AgentState> fsm)
    {
        _model = model;
        _fsm = fsm;
    }
    public override void Awake()
    {

    }

    public override void Execute()
    {
        _model.Move();

        if (_model.FOV())
        {
            _fsm.SetState<AgentStateChase>();
        }
    }

    public override void Sleep()
    {

    }
}
