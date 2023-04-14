using System.Collections;
using System.Collections.Generic;

public abstract class BaseMachine
{
    public abstract void OnEnterState();
    public abstract void OnUpdateState();
    public abstract void OnFixedUpdateState();
    public abstract void OnExitState();
}
