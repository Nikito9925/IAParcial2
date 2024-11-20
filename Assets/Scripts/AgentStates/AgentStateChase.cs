using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentStateChase : AgentState
{
    private Model _model;
    public AgentStateChase(Agent entity, Model model, StateMachine<AgentState> fsm)
    {
        _model = model;
        _fsm = fsm;
        _entity = entity;
    }
    public override void Awake()
    {
        _entity._state = Agent.States.Chase;

        GameManager.instance.StartChase(_entity, _entity.transform, GameManager.instance._player);
        GameManager.instance.AlertAgents();
    }

    public override void Execute()
    {

        _model.Move();

        Debug.Log("ABC");

        if(!_model.HasNodes() && !_model.FOV())
        {
            _fsm.SetState<AgentStateChaseToPatrol>();
        }

        /*
        if(!_model.FOV())
        {
            _fsm.SetState<AgentStatePatrol>();
        }
        */
    }

    public override void Sleep()
    {

    }
}
