using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentStateChaseToPatrol : AgentState
{
    private Model _model;
    public AgentStateChaseToPatrol(Agent entity, Model model, StateMachine<AgentState> fsm)
    {
        _model = model;
        _fsm = fsm;
        _entity = entity;
    }
    public override void Awake()
    {
        Debug.Log("CHASE TO PATROL");
        _entity._state = Agent.States.ChaseToPatrol;

        /*
        if (_entity.firstPath) GameManager.instance.BackToPatrol(_entity, _entity.StartingNode1);
        else GameManager.instance.BackToPatrol(_entity, _entity.StartingNode2);
        */

        if(_entity.firstPath) GameManager.instance.BackToPatrol(_entity, _entity.transform, _entity.StartingNode1);
        else GameManager.instance.BackToPatrol(_entity, _entity.transform, _entity.StartingNode2);
    }

    public override void Execute()
    {
        _model.Move();

        if (!_model.HasNodes())
        {
            _fsm.SetState<AgentStatePatrol>();
        }
    }

    public override void Sleep()
    {

    }
}
