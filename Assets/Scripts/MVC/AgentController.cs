using UnityEngine;

public class AgentController : Controller
{
    private StateMachine<AgentState> _fsm;
    public AgentController(Model model)
    {
        _model = model;

        _fsm = new StateMachine<AgentState>();
        _fsm.AddState(new AgentStatePatrol(_model));
    }
    public override void Update()
    {
        _fsm.Update();
    }
}
