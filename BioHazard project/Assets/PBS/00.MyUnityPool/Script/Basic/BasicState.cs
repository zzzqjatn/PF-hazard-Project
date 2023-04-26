using System.Collections;
using System.Collections.Generic;

public class BasicState
{
    // Basic State
    public float Strong;
    public float Perception;
    public float Endurance;
    public float Charisma;
    public float Intelligence;
    public float Agility;
    public float Luck;

    // HP, MP, EXP
    public float MaxHP;
    public float CurrentHP;
    public float MaxMP;
    public float CurrentMP;
    public float MaxExperience;
    public float CurrentExperience;

    public float AttackPoint;
    public float DefencePoint;

    // Money
    public float Money;

    public void F_StateSet(float Strong_, float Perception_, float Endurance_, float Charisma_,
                            float Intelligence_, float Agility_, float Luck_)
    {
        Strong = Strong_;
        Perception = Perception_;
        Endurance = Endurance_;
        Charisma = Charisma_;
        Intelligence = Intelligence_;
        Agility = Agility_;
        Luck = Luck_;
    }

    public void F_InfoSet(float MaxHP_, float CurrentHP_, float MaxMP_, float CurrentMP_,
                            float MaxExperience_, float CurrentExperience_, float AttackPoint_, float DefencePoint_)
    {
        MaxHP = MaxHP_;
        CurrentHP = CurrentHP_;
        MaxMP = MaxMP_;
        CurrentMP = CurrentMP_;
        MaxExperience = MaxExperience_;
        CurrentExperience = CurrentExperience_;
        AttackPoint = AttackPoint_;
        DefencePoint = DefencePoint_;
    }

    public void F_Money(float Money_)
    {
        Money = Money_;
    }
}
