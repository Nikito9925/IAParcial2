using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentStatePatrol : AgentState
{
    private Model _model;
    public AgentStatePatrol(Agent entity, Model model, StateMachine<AgentState> fsm)
    {
        _model = model;
        _fsm = fsm;
        _entity = entity;
    }
    public override void Awake()
    {
        _entity._state = Agent.States.Patrol;

        if (_entity.firstPath) GameManager.instance.StartPatrol(_entity, _entity.StartingNode1, _entity.GoalNode1);
        else GameManager.instance.StartPatrol(_entity, _entity.StartingNode2, _entity.GoalNode2);
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
