using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityEngine
{
    public enum MoveElement
    {
        None,
        Neutral,
        Fire,
        Water,
        Nature,
        Grass,
        Electric,
        Earth,
        Mental,
        Wind,
        Digital,
        Melee,
        Crystal,
        Toxic
    }

    public enum MoveCondition
    {
        Positive,
        Negative,
        Status,
        Damage,
        Special,
        Physical
    }

    public enum StatusApply
    {
        None,
        Asleep,
        Burn,
        Cold,
        Doom,
        Exhausted,
        Immune,
        Neutralize,
        Poison,
        Regenerate,
        Seized,
        Trapped,
        Vigorized
    }

    //remake valid targets system
    public enum ValidTargets
    {
        Self,
        Ally,
        Enemy1,
        Enemy2,
        aoeEnemies,
        aoeAllies,
        aoeAll
    }
}
[System.Serializable]
public struct Move
{
    public string name;
    public int moveBP;
    public int stamCost;
    public int holdTime;
    public int priority;
    public MoveElement element;
    public MoveElement synergyWith;
    public MoveCondition moveCondition;
    public StatusApply statusApply;
    //targetting system will need to be planned better later 
    public ValidTargets validTargets;


    //constructor
    public Move(string name, int moveBP, int stamCost, int holdTime, MoveElement element, MoveCondition condition, StatusApply statusApply, ValidTargets validTargets)
    {
        this.name = name;
        this.moveBP = moveBP;
        this.stamCost = stamCost;
        this.holdTime = holdTime;
        this.element = element;
        this.moveCondition = condition;
        this.statusApply = statusApply;
        this.validTargets = validTargets;

    }
}



//TriA should be checked on execution of calculations for special moves, individual of the move itself. The status will be applied at the very end of attack execution.
public class MoveDetails : MonoBehaviour
{
    public void Start()
    {
        //your example since it's breaking
        //Move fireScratch = new Move("FireScratch", MoveElement.Fire);

    }

}

/// Need selected Target system for tri-A!!!

//if loneliness trait, synergyWIth = MoveElement.None

//make rest move


