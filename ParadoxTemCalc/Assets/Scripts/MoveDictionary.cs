using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

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
        None,
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
        None,
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
    //targeting system will need to be planned better later 
    public ValidTargets validTargets;


    //constructor
    public Move(string name, 
                int moveBP = -1, 
                int stamCost = -1, 
                int holdTime = -1, 
                int priority = -1, 
                MoveElement element = MoveElement.None, 
                MoveCondition condition = MoveCondition.None, 
                StatusApply statusApply = StatusApply.None, 
                MoveElement synergyWith = MoveElement.None, 
                ValidTargets validTargets = ValidTargets.None)
    {
        this.name = name;
        this.moveBP = moveBP;
        this.stamCost = stamCost;
        this.holdTime = holdTime;
        this.priority = priority;
        this.element = element;
        this.moveCondition = condition;
        this.statusApply = statusApply;
        this.synergyWith = synergyWith;
        this.validTargets = validTargets;
    }
}



//TriA should be checked on execution of calculations for special moves, individual of the move itself. The status will be applied at the very end of attack execution.
public class MoveDictionary : MonoBehaviour
{
    public List<Move> moveList;

    public void Start()
    {


    }

    /// Need selected Target system for tri-A!!!

    //if loneliness trait, synergyWIth = MoveElement.None

    //make rest move

    #region instance

    private static MoveDictionary s_Instance = null;

    public static MoveDictionary instance
    {
        get
        {
            if (s_Instance == null)
            {
                s_Instance = FindObjectOfType(typeof(MoveDictionary)) as MoveDictionary;
            }

            return s_Instance;
        }
    }

    void OnApplicationQuit()
    {
        s_Instance = null;
    }
    #endregion

}