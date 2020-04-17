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
        // 0 is neutral, 1 is positive, -1 is negative.
        //Test to see if Neutralize status is actually positive or negative.
        None = 0,
        Alerted = 1,
        Asleep = -1,
        Burned = -1,
        Cold = -1,
        Doomed = -1,
        Evading = 1,
        Exhausted = -1,
        Frozen = -1,
        Immune = 0,
        Neutralized = 0,
        Poisoned = -1,
        Regenerating = 1,
        Seized = -1,
        Trapped = -1,
        Vigorized = 1
    }

    public enum MonsterBuff
    {
        //1 means good, -1 means bad.
        None = 0,
        addAtk = 1,
        addDef = 1,
        addSpatk = 1,
        addSpdef = 1,
        addSpeed = 1,
        lowAtk = -1,
        lowDef = -1,
        lowSpatk = -1,
        lowSpdef = -1,
        lowSpeed = -1
    }
    public enum MonsterTrait
    {
        None,
        Aerobic,
        AirSpecialist,
        Amphibian,
        Anaerobic,
        Apothecary,
        Avenger,
        Benefactor,
        Botanist,
        Botanophobia,
        Brawny,
        Bully,
        Caffeinated,
        Callosity,
        Camaraderie,
        Channeler,
        ColdNatured,
        Demoralize,
        Determined,
        ElectricSynthesize,
        EnergyReserve,
        FaintedCurse,
        FastCharge,
        FeverRush,
        FlawedCrystal,
        Friendship,
        Furor,
        Guardian,
        Hover,
        Hydrologist,
        Immunity,
        Individualist,
        LastRush,
        Loneliness,
        MentalAlliance,
        Mirroring,
        Mithridatism,
        Motivator,
        Mucous,
        Neutrality,
        Parrier,
        Patient,
        Plethoric,
        PowerNap,
        Prideful,
        Protector,
        Provident,
        PunchingBag,
        PuppetMaster,
        Pyromaniac,
        Receptive,
        Rejuvinate,
        Resilient,
        Resistant,
        Rested,
        Scavenger,
        Settling,
        SharedPain,
        SoftTouch,
        Spoilsport,
        StrongLiver,
        SynergyMaster,
        ThickSkin,
        Tireless,
        ToxicAffinity,
        ToxicFarewell,
        ToxicSkin,
        Trance,
        Trauma,
        TriApothecary,
        Vigorous,
        Warmblooded,
        WaterAFfinity,
        Withdrawal,
        WreckedFarewell,
        Zen

    }

    public enum MonsterName
    {
        None,
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
    public MonsterName evolvesFrom;
    [DisplayWithoutEdit()]
    public MonsterTrait trait1;
    [DisplayWithoutEdit()]
    public MonsterTrait trait2;
    [DisplayWithoutEdit()]
    public MonsterType type1;
    [DisplayWithoutEdit()]
    public MonsterType type2;
    [Header("Status"), DisplayWithoutEdit()]
    public MonsterStatus status1;
    [DisplayWithoutEdit()]
    public MonsterStatus status2;
    [DisplayWithoutEdit()]
    public int stat1Duration;
    [DisplayWithoutEdit()]
    public int stat2Duration;
    [DisplayWithoutEdit()]
    public MonsterBuff buff1;
    [DisplayWithoutEdit()]
    public MonsterBuff buff2;
    [DisplayWithoutEdit()]
    public int buff1Stage;
    [DisplayWithoutEdit()]
    public int buff2Stage;
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
                   MonsterName evolvesFrom = MonsterName.None,
                   MonsterTrait trait1 = MonsterTrait.None,
                   MonsterTrait trait2 = MonsterTrait.None,
                   MonsterType type1 = MonsterType.None,
                   MonsterType type2 = MonsterType.None,
                   MonsterStatus status1 = MonsterStatus.None,
                   MonsterStatus status2 = MonsterStatus.None,
                   int stat1Duration = 0,
                   int stat2Duration = 0,
                   MonsterBuff buff1 = MonsterBuff.None,
                   MonsterBuff buff2 = MonsterBuff.None,
                   int buff1Stage = 0,
                   int buff2Stage = 0,

                   //base stats may need to be float...
                   int baseHP = 0,
                   int baseSTA = 0,
                   int baseSPD = 0,
                   int baseATK = 0,
                   int baseDEF = 0,
                   int baseSpATK = 0,
                   int baseSpDEF = 0,
                   int tvHP = 0,
                   int tvSTA = 0,
                   int tvSPD = 0,
                   int tvATK = 0,
                   int tvDEF = 0,
                   int tvSpATK = 0,
                   int tvSpDEF = 0)
    {
        this.monsterName = monsterName;
        this.evolvesFrom = evolvesFrom;
        this.trait1 = trait1;
        this.trait2 = trait2;
        this.type1 = type1;
        this.type2 = type2;
        this.status1 = status1;
        this.status2 = status2;
        this.buff1 = buff1;
        this.buff2 = buff2;
        this.stat1Duration = stat1Duration;
        this.stat2Duration = stat2Duration;
        this.buff1Stage = buff1Stage;
        this.buff2Stage = buff2Stage;
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

        //DO NOT DELETE THESE TWO MOVES.
        monster.canLearn.Add(MoveName.None);
        monster.canLearn.Add(MoveName.Rest);

        switch (monster.monsterName)
        {
            case MonsterName.None:
                //copy/paste this when creating a new temtem if you're confused.
                monster.evolvesFrom = MonsterName.None;
                monster.trait1 = MonsterTrait.None;
                monster.trait2 = MonsterTrait.None;
                monster.type1 = MonsterType.None;
                monster.type2 = MonsterType.None;
                monster.baseHP = 0;
                monster.baseSTA = 0;
                monster.baseSPD = 0;
                monster.baseATK = 0;
                monster.baseDEF = 0;
                monster.baseSpATK = 0;
                monster.baseSpDEF = 0;
                //TVs, edit in UI only preferably
                monster.tvHP = 0;
                monster.tvSTA = 0;
                monster.tvSPD = 0;
                monster.tvATK = 0;
                monster.tvDEF = 0;
                monster.tvSpATK = 0;
                monster.tvSpDEF = 0;
                //do not edit, used only in calculation phase
                monster.status1 = MonsterStatus.None;
                monster.status2 = MonsterStatus.None;
                monster.stat1Duration = 0;
                monster.stat2Duration = 0;
                monster.buff1 = MonsterBuff.None;
                monster.buff2 = MonsterBuff.None;
                monster.buff1Stage = 0;
                monster.buff2Stage = 0;
                //Learnset
                monster.canLearn.Add(MoveName.None);
                monster.canLearn.Add(MoveName.Rest);
                monster.canLearn.Add(MoveName.AllergicSpread);
                break;
            case MonsterName.Adoroboros:
                monster.trait1 = MonsterTrait.SynergyMaster;
                monster.trait2 = MonsterTrait.ToxicSkin;
                monster.type1 = MonsterType.Toxic;
                monster.type2 = MonsterType.Mental;
                monster.baseHP = 66;
                monster.baseSTA = 66;
                monster.baseSPD = 60;
                monster.baseATK = 29;
                monster.baseDEF = 42;
                monster.baseSpATK = 70;
                monster.baseSpDEF = 110;
                //Learnset
                monster.canLearn.Add(MoveName.TailStrike);
                monster.canLearn.Add(MoveName.EnergyManipulation);
                monster.canLearn.Add(MoveName.ToxicInk);
                monster.canLearn.Add(MoveName.PsychicCollaborator);
                monster.canLearn.Add(MoveName.BetaBurst);
                monster.canLearn.Add(MoveName.Pollution);
                monster.canLearn.Add(MoveName.Lullaby);
                monster.canLearn.Add(MoveName.Sacrifice);
                monster.canLearn.Add(MoveName.WakeUp);
                monster.canLearn.Add(MoveName.Misogi);
                monster.canLearn.Add(MoveName.NoxiousBomb);
                monster.canLearn.Add(MoveName.Antitoxins);
                monster.canLearn.Add(MoveName.Confiscate);
                monster.canLearn.Add(MoveName.Relax);
                monster.canLearn.Add(MoveName.Hypnosis);
                monster.canLearn.Add(MoveName.HeldAnger);
                monster.canLearn.Add(MoveName.InnerSpirit);
                break;
            case MonsterName.Anahir:
                monster.trait1 = MonsterTrait.Trauma;
                monster.trait2 = MonsterTrait.FlawedCrystal;
                monster.type1 = MonsterType.Crystal;
                monster.type2 = MonsterType.Fire;
                monster.baseHP = 54;
                monster.baseSTA = 36;
                monster.baseSPD = 31;
                monster.baseATK = 50;
                monster.baseDEF = 101;
                monster.baseSpATK = 50;
                monster.baseSpDEF = 101;
                //Learnset
                monster.canLearn.Add(MoveName.GlassBlade);
                monster.canLearn.Add(MoveName.FireFlame);
                monster.canLearn.Add(MoveName.HeadCharge);
                monster.canLearn.Add(MoveName.MeteorSwarm);
                monster.canLearn.Add(MoveName.Rampage);
                monster.canLearn.Add(MoveName.HeatUp);
                monster.canLearn.Add(MoveName.CrystalBite);
                monster.canLearn.Add(MoveName.MagmaCannon);
                break;
            case MonsterName.Azuroc:
                monster.trait1 = MonsterTrait.Mirroring;
                monster.trait2 = MonsterTrait.FaintedCurse;
                monster.type1 = MonsterType.Crystal;
                monster.type2 = MonsterType.None;
                monster.baseHP = 64;
                monster.baseSTA = 34;
                monster.baseSPD = 50;
                monster.baseATK = 58;
                monster.baseDEF = 69;
                monster.baseSpATK = 60;
                monster.baseSpDEF = 62;
                //Learnset
                monster.canLearn.Add(MoveName.Scratch);
                monster.canLearn.Add(MoveName.Nibble);
                monster.canLearn.Add(MoveName.GlassBlade);
                monster.canLearn.Add(MoveName.TailStrike);
                monster.canLearn.Add(MoveName.SharpStabs);
                monster.canLearn.Add(MoveName.CrystalSpikes);
                monster.canLearn.Add(MoveName.MadnessBuff);
                monster.canLearn.Add(MoveName.CrystalBite);
                monster.canLearn.Add(MoveName.Rend);
                monster.canLearn.Add(MoveName.Footwork);
                monster.canLearn.Add(MoveName.DiamondFort);
                break;
            case MonsterName.Babawa:
                monster.trait1 = MonsterTrait.Mucous;
                monster.trait2 = MonsterTrait.Withdrawal;
                monster.type1 = MonsterType.Nature;
                monster.type2 = MonsterType.Water;
                monster.baseHP = 85;
                monster.baseSTA = 92;
                monster.baseSPD = 40;
                monster.baseATK = 79;
                monster.baseDEF = 57;
                monster.baseSpATK = 51;
                monster.baseSpDEF = 44;
                //Learnset
                monster.canLearn.Add(MoveName.Nibble);
                monster.canLearn.Add(MoveName.ShyShield);
                monster.canLearn.Add(MoveName.SharpLeaf);
                monster.canLearn.Add(MoveName.Slime);
                monster.canLearn.Add(MoveName.WaterCuttingLily);
                monster.canLearn.Add(MoveName.IcedStalactite);
                monster.canLearn.Add(MoveName.AquaStone);
                monster.canLearn.Add(MoveName.HarmfulLick);
                monster.canLearn.Add(MoveName.WakeUp);
                monster.canLearn.Add(MoveName.Misogi);
                monster.canLearn.Add(MoveName.Antitoxins);
                monster.canLearn.Add(MoveName.Bubbles);
                monster.canLearn.Add(MoveName.IceCubes);
                monster.canLearn.Add(MoveName.ToxicSlime);
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
