using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace UnityEngine
{
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

    public enum MonsterStatus
    {
        None,
        Alerted,
        Asleep,
        Burn,
        Cold,
        Doom,
        Evading,
        Exhausted,
        Immune,
        Neutralize,
        Poison,
        Regenerate,
        Seized,
        Trapped,
        Vigorized
    }

    public enum MonsterTrait
    {
        None,
    }

    public enum MonsterName
    {
        Adoroboros,
        Anahir,
        Azuroc,
        Babawa,
        Baboong,
        Banapi,
        Barnshe,
        Bigu,
        Blooze,
        Bunbun,
        Capyre,
        Cerneaf,
        Crystle,
        Deendre,
        Fomu,
        Ganki,
        Gazuma,
        Goolder,
        Granpah,
        Gyalis,
        Hidody,
        Hocus,
        Houchic,
        Kaku,
        Kalabyss,
        Kalazu,
        Kinu,
        Loali,
        Magmis,
        Mastione,
        Mudrid,
        Mushi,
        Mushook,
        Myx,
        Nessla,
        Nidrasil,
        Noxolotl,
        Occlura,
        Oceara,
        Orphyll,
        Paharac,
        Paharo,
        Pewki,
        Pigepic,
        Piraniant,
        Platimous,
        Platox,
        Platypet,
        Pocus,
        Raiber,
        Raican,
        Raize,
        Saipat,
        Saku,
        Sherald,
        Shuine,
        Skail,
        Skunch,
        Smazee,
        Spriole,
        Swali,
        Taifu,
        Tateru,
        Tental,
        Toxolotl,
        Tuvine,
        Tuwai,
        Ukama,
        Umishi,
        Valash,
        Volarend,
        Vulcrane,
        Vulor,
        Vulvir,
        Wiplump,
        Zenoreth,
        Zephyruff
    }
}

[System.Serializable]
public struct Monster
{
    [HideInInspector]
    public string name;
    [DisplayWithoutEdit()]
    public MonsterName monsterName;
    [DisplayWithoutEdit()]
    public MonsterTrait trait;
    [DisplayWithoutEdit()]
    public MonsterType type;
    [Header("Status"), DisplayWithoutEdit()]
    public MonsterStatus status1;
    [DisplayWithoutEdit()]
    public MonsterStatus status2;
    [DisplayWithoutEdit()]
    public int stat1Duration;
    [DisplayWithoutEdit()]
    public int stat2Duration;
    [Header("Base Stats"), DisplayWithoutEdit()]
    public float baseHP;
    [DisplayWithoutEdit()]
    public float baseSTA;
    [DisplayWithoutEdit()]
    public float baseSPD;
    [DisplayWithoutEdit()]
    public float baseATK;
    [DisplayWithoutEdit()]
    public float baseDEF;
    [DisplayWithoutEdit()]
    public float baseSpATK;
    [DisplayWithoutEdit()]
    public float baseSpDEF;
    [Header("TVs"), DisplayWithoutEdit()]
    public float tvHP;
    [DisplayWithoutEdit()]
    public float tvSTA;
    [DisplayWithoutEdit()]
    public float tvSPD;
    [DisplayWithoutEdit()]
    public float tvATK;
    [DisplayWithoutEdit()]
    public float tvDEF;
    [DisplayWithoutEdit()]
    public float tvSpATK;
    [DisplayWithoutEdit()]
    public float tvSpDEF;
    [DisplayWithoutEdit()]
    public List<MoveName> canLearn;
    public List<Move> learnedMoves;

    public Monster(MonsterName monsterName,
                   string name = "",
                   MonsterTrait trait = MonsterTrait.None,
                   MonsterType type = MonsterType.None,
                   MonsterStatus status1 = MonsterStatus.None,
                   MonsterStatus status2 = MonsterStatus.None,
                   int stat1Duration = 0,
                   int stat2Duration = 0,
                   float baseHP = 0f,
                   float baseSTA = 0f,
                   float baseSPD = 0f,
                   float baseATK = 0f,
                   float baseDEF = 0f,
                   float baseSpATK = 0f,
                   float baseSpDEF = 0f,
                   float tvHP = 0f,
                   float tvSTA = 0f,
                   float tvSPD = 0f,
                   float tvATK = 0f,
                   float tvDEF = 0f,
                   float tvSpATK = 0f,
                   float tvSpDEF = 0f)
    {
        this.monsterName = monsterName;
        this.trait = trait;
        this.type = type;
        this.status1 = status1;
        this.status2 = status2;
        this.stat1Duration = stat1Duration;
        this.stat2Duration = stat2Duration;
        this.baseHP = baseHP;
        this.baseSTA = baseSTA;
        this.baseSPD = baseSPD;
        this.baseATK = baseATK;
        this.baseDEF = baseDEF;
        this.baseSpATK = baseSpATK;
        this.baseSpDEF = baseSpDEF;
        this.tvHP = tvHP;
        this.tvSTA = tvSTA;
        this.tvSPD = tvSPD;
        this.tvATK = tvATK;
        this.tvDEF = tvDEF;
        this.tvSpATK = tvSpATK;
        this.tvSpDEF = tvSpDEF;
        this.canLearn = new List<MoveName>();
        this.learnedMoves = new List<Move>();
        this.name = monsterName.ToString();
    }
}

public class MonsterDictionary : MonoBehaviour
{
    [DisplayWithoutEdit()]
    public bool listLoaded = false;

    public List<Monster> monsterList;

    public void FixedUpdate()
    {
        if (MoveDictionary.instance.listLoaded && !listLoaded)
        {
            //populate the list once
            foreach (MonsterName n in Enum.GetValues(typeof(MonsterName)))
            {
                Monster monster = new Monster(n);
                SetMonsterValues(ref monster);
                monsterList.Add(monster);
            }
            listLoaded = true;
        }
    }

    public void SetMonsterValues(ref Monster monster)
    {

        //set defaults here
        monster.canLearn.Add(MoveName.None);
        monster.canLearn.Add(MoveName.Rest);

        switch (monster.monsterName)
        {
            case MonsterName.Adoroboros:
                break;
            case MonsterName.Anahir:
                break;
            case MonsterName.Azuroc:
                break;
            case MonsterName.Babawa:
                break;
            case MonsterName.Baboong:
                break;
            case MonsterName.Banapi:
                break;
            case MonsterName.Barnshe:
                break;
            case MonsterName.Bigu:
                break;
            case MonsterName.Blooze:
                break;
            case MonsterName.Bunbun:
                break;
            case MonsterName.Capyre:
                break;
            case MonsterName.Cerneaf:
                break;
            case MonsterName.Crystle:
                break;
            case MonsterName.Deendre:
                break;
            case MonsterName.Fomu:
                break;
            case MonsterName.Ganki:
                break;
            case MonsterName.Gazuma:
                break;
            case MonsterName.Goolder:
                break;
            case MonsterName.Granpah:
                break;
            case MonsterName.Gyalis:
                break;
            case MonsterName.Hidody:
                break;
            case MonsterName.Hocus:
                break;
            case MonsterName.Houchic:
                break;
            case MonsterName.Kaku:
                break;
            case MonsterName.Kalabyss:
                break;
            case MonsterName.Kalazu:
                break;
            case MonsterName.Kinu:
                break;
            case MonsterName.Loali:
                break;
            case MonsterName.Magmis:
                break;
            case MonsterName.Mastione:
                break;
            case MonsterName.Mudrid:
                break;
            case MonsterName.Mushi:
                break;
            case MonsterName.Mushook:
                break;
            case MonsterName.Myx:
                break;
            case MonsterName.Nessla:
                break;
            case MonsterName.Nidrasil:
                break;
            case MonsterName.Noxolotl:
                break;
            case MonsterName.Occlura:
                break;
            case MonsterName.Oceara:
                break;
            case MonsterName.Orphyll:
                break;
            case MonsterName.Paharac:
                break;
            case MonsterName.Paharo:
                break;
            case MonsterName.Pewki:
                break;
            case MonsterName.Pigepic:
                break;
            case MonsterName.Piraniant:
                break;
            case MonsterName.Platimous:
                break;
            case MonsterName.Platox:
                break;
            case MonsterName.Platypet:
                break;
            case MonsterName.Pocus:
                break;
            case MonsterName.Raiber:
                break;
            case MonsterName.Raican:
                break;
            case MonsterName.Raize:
                break;
            case MonsterName.Saipat:
                break;
            case MonsterName.Saku:
                break;
            case MonsterName.Sherald:
                break;
            case MonsterName.Shuine:
                break;
            case MonsterName.Skail:
                break;
            case MonsterName.Skunch:
                break;
            case MonsterName.Smazee:
                break;
            case MonsterName.Spriole:
                break;
            case MonsterName.Swali:
                break;
            case MonsterName.Taifu:
                break;
            case MonsterName.Tateru:
                break;
            case MonsterName.Tental:
                break;
            case MonsterName.Toxolotl:
                break;
            case MonsterName.Tuvine:
                break;
            case MonsterName.Tuwai:
                break;
            case MonsterName.Ukama:
                break;
            case MonsterName.Umishi:
                break;
            case MonsterName.Valash:
                break;
            case MonsterName.Volarend:
                break;
            case MonsterName.Vulcrane:
                break;
            case MonsterName.Vulor:
                break;
            case MonsterName.Vulvir:
                break;
            case MonsterName.Wiplump:
                break;
            case MonsterName.Zenoreth:
                break;
            case MonsterName.Zephyruff:
                break;
            default:
                break;
        }
    }

    public Monster GetMonsterByName(MonsterName name)
    {
        return monsterList[(int)name];
    }

    #region instance

    private static MonsterDictionary s_Instance = null;

    public static MonsterDictionary instance
    {
        get
        {
            if (s_Instance == null)
            {
                s_Instance = FindObjectOfType(typeof(MonsterDictionary)) as MonsterDictionary;
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
