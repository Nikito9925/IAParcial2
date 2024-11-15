using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine<StateType> where StateType : IState
{
    private StateType _currentState;
    private List<StateType> _states = new List<StateType>();

    public StateType currentState { get { return _currentState; } }

    public void Update()
    {
        if (_currentState != null) _currentState.Execute();
    }

    public void AddState(StateType newState)
    {
        if (_states.Contains(newState)) return;
        _states.Add(newState);
        if(_currentState == null) _currentState = newState;
    }

    public void SetState<T>() where T : StateType
    {
        foreach(var state in _states)
        {
            if(state.GetType()== typeof(T))
            {
                _currentState.Sleep();
                _currentState = state;
                _currentState.Awake();
            }
        }
    }
}
