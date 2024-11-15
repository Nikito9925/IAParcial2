using UnityEngine;

public class AgentController : Controller
{
    private Model _model;
    private StateMachine<AgentState> _fsm;
    public AgentController(Model model)
    {
        _model = model;

        _fsm = new StateMachine<AgentState>();
        _fsm.AddState(new AgentStatePatrol());
    }
    public override void Update()
    {

    }
}
