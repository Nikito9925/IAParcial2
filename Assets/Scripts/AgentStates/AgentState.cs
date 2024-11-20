using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentState : IState
{
    protected StateMachine<AgentState> _fsm;
    public Agent _entity;

    public virtual void Awake()
    {

    }

    public virtual void Execute()
    {

    }

    public virtual void Sleep()
    {

    }
}
