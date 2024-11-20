using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentStatePatrolToChase : AgentState
{
    private Model _model;
    public AgentStatePatrolToChase(Agent entity, Model model, StateMachine<AgentState> fsm)
    {
        _model = model;
        _fsm = fsm;
        _entity = entity;
    }
    public override void Awake()
    {

    }

    public override void Execute()
    {

    }

    public override void Sleep()
    {

    }
}
