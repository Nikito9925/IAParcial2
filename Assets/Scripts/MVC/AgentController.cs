using UnityEngine;

public class AgentController : Controller
{
    //public StateMachine<AgentState> _fsm;
    public AgentController(Agent entity, Model model)
    {
        _model = model;

        _fsm = new StateMachine<AgentState>();
        _fsm.AddState(new AgentStatePatrol(entity, _model, _fsm));
        _fsm.AddState(new AgentStateChase(entity, _model, _fsm));
        _fsm.AddState(new AgentStateChaseToPatrol(entity, _model, _fsm));
    }
    public override void Update()
    {
        _fsm.Update();
    }
}
