using System.Collections;
using System.Collections.Generic;

public class Z_CustomState : BasicState
{
    float MaxDownPoint;
    float CurrentDownPoint;
    public Z_MoveType MoveType { get; private set; }

    public void SetZombiState(float hp, float mp, float maxDownPoint, Z_MoveType movetype)
    {
        F_InfoSet(hp, hp, mp, mp, 0, 0, 30, 0);

        MaxDownPoint = maxDownPoint;
        CurrentDownPoint = 0;

        MoveType = movetype;
    }

    public bool IsDown()
    {
        if (MaxDownPoint <= CurrentDownPoint)
        {
            return true;
        }
        return false;
    }
}

public enum Z_MoveType
{
    None = -1, Walk, Run
}