using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UnityEngine
{
    [System.Serializable]
    public class MonsterDetails : MonoBehaviour
    {
        public string Name;
        public string Trait;
        public MonsterType Type;
        [Header("Status")]
        public StatusList Status1;
        public StatusList Status2;
        public bool Bamboozle;
        public int stat1Duration;
        public int stat2Duration;
        [Header("Base Stats")]
        public float baseHp;
        public float baseSta;
        public float baseSpd;
        public float baseAtk;
        public float baseDef;
        public float baseSpatk;
        public float baseSpdef;
        [Header("TVs")]
        public float tvHp;
        public float tvSta;
        public float tvSpd;
        public float tvAtk;
        public float tvDef;
        public float tvSpatk;
        public float tvSpdef;

    }

    public enum MonsterType
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
        Toxic,
        Dead
    }

    public enum StatusList
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
}
//On calculate, run through status functions ("if status1 = " block). Probably a better way to do this.
//
