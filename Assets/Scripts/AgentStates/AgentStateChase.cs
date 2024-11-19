using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentStateChase : AgentState
{
    private Model _model;
    public AgentStateChase(Model model, StateMachine<AgentState> fsm)
    {
        _model = model;
        _fsm = fsm;
    }
    public override void Awake()
    {

    }

    public override void Execute()
    {

        Debug.Log("ABC");

        if(!_model.FOV())
        {
            _fsm.SetState<AgentStatePatrol>();
        }
    }

    public override void Sleep()
    {

    }
}
