using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Z_MonsterStateMachine
{
    public BaseMachine CurrentState { get; private set; }
    private Dictionary<Z_StateMachine, BaseMachine> states = new Dictionary<Z_StateMachine, BaseMachine>();

    public Z_MonsterStateMachine(Z_StateMachine stateName, BaseMachine state)
    {
        AddState(stateName, state);
        CurrentState = GetState(stateName);
    }

    public void AddState(Z_StateMachine stateName, BaseMachine state)
    {
        if (!states.ContainsKey(stateName))
        {
            states.Add(stateName, state);
        }
    }

    public BaseMachine GetState(Z_StateMachine stateName)
    {
        if (states.TryGetValue(stateName, out BaseMachine state))
            return state;

        return null;
    }

    public void DeleteState(Z_StateMachine removeStateName)
    {
        if (states.ContainsKey(removeStateName))
        {
            states.Remove(removeStateName);
        }
    }

    public void ChangeState(Z_StateMachine nextStateName)
    {
        CurrentState.OnExitState();
        if (states.TryGetValue(nextStateName, out BaseMachine newState))
        {
            CurrentState = newState;
        }
        CurrentState?.OnEnterState();
    }

    public void UpdateState()
    {
        CurrentState?.OnUpdateState();
    }

    public void FixedUpdateState()
    {
        CurrentState?.OnFixedUpdateState();
    }
}
