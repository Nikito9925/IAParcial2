using UnityEngine;

public abstract class Controller
{
    public Model _model;
    public StateMachine<AgentState> _fsm;
    public virtual void Update() { }
}
