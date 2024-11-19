using UnityEngine;

public class AgentController : Controller
{
    private StateMachine<AgentState> _fsm;
    public AgentController(Model model)
    {
        _model = model;

        _fsm = new StateMachine<AgentState>();
        _fsm.AddState(new AgentStatePatrol(_model, _fsm));
        _fsm.AddState(new AgentStateChase(_model, _fsm));
    }
    public override void Update()
    {
        _fsm.Update();
    }
}
