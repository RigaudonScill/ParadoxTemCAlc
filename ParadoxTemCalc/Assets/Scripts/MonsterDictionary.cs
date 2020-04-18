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
        DreadedAlarm,
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
        PuppetMaster = 0,
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
        Lapinite,
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
                monster.trait1 = MonsterTrait.Brawny;
                monster.trait2 = MonsterTrait.Warmblooded;
                monster.type1 = MonsterType.Melee;
                monster.type2 = MonsterType.None;
                monster.baseHP = 54;
                monster.baseSTA = 61;
                monster.baseSPD = 75;
                monster.baseATK = 79;
                monster.baseDEF = 51;
                monster.baseSpATK = 41;
                monster.baseSpDEF = 41;
                //Learnset
                monster.canLearn.Add(MoveName.Kick);
                monster.canLearn.Add(MoveName.MartialStrike);
                monster.canLearn.Add(MoveName.TailStrike);
                monster.canLearn.Add(MoveName.SandSplatter);
                monster.canLearn.Add(MoveName.ShowOff);
                monster.canLearn.Add(MoveName.Uppercut);
                monster.canLearn.Add(MoveName.Intimidation);
                monster.canLearn.Add(MoveName.PerfectJab);
                monster.canLearn.Add(MoveName.HeatUp);
                monster.canLearn.Add(MoveName.InnerSpirit);
                monster.canLearn.Add(MoveName.Footwork);
                monster.canLearn.Add(MoveName.StoneWall);
                monster.canLearn.Add(MoveName.Misogi);
                monster.canLearn.Add(MoveName.EarthWave);
                break;
            case MonsterName.Banapi:
                monster.trait1 = MonsterTrait.Pyromaniac;
                monster.trait2 = MonsterTrait.Settling;
                monster.type1 = MonsterType.Fire;
                monster.type2 = MonsterType.Water;
                monster.baseHP = 42;
                monster.baseSTA = 40;
                monster.baseSPD = 70;
                monster.baseATK = 50;
                monster.baseDEF = 50;
                monster.baseSpATK = 40;
                monster.baseSpDEF = 41;
                //Learnset
                monster.canLearn.Add(MoveName.Kick);
                monster.canLearn.Add(MoveName.HeavyBlow);
                monster.canLearn.Add(MoveName.WarmCuddle);
                monster.canLearn.Add(MoveName.SandSplatter);
                monster.canLearn.Add(MoveName.HeadRam);
                monster.canLearn.Add(MoveName.Embers);
                monster.canLearn.Add(MoveName.Rampage);
                monster.canLearn.Add(MoveName.FireTornado);
                monster.canLearn.Add(MoveName.HeatUp);
                monster.canLearn.Add(MoveName.MagmaCannon);
                monster.canLearn.Add(MoveName.Block);
                monster.canLearn.Add(MoveName.Roar);
                break;
            case MonsterName.Barnshe:
                monster.trait1 = MonsterTrait.Neutrality;
                monster.trait2 = MonsterTrait.AirSpecialist;
                monster.type1 = MonsterType.Mental;
                monster.type2 = MonsterType.Wind;
                monster.baseHP = 50;
                monster.baseSTA = 51;
                monster.baseSPD = 65;
                monster.baseATK = 60;
                monster.baseDEF = 40;
                monster.baseSpATK = 75;
                monster.baseSpDEF = 79;
                //Learnset
                monster.canLearn.Add(MoveName.Peck);
                monster.canLearn.Add(MoveName.SandSplatter);
                monster.canLearn.Add(MoveName.WindBlade);
                monster.canLearn.Add(MoveName.WindBurst);
                monster.canLearn.Add(MoveName.Bamboozle);
                monster.canLearn.Add(MoveName.Intimidation);
                monster.canLearn.Add(MoveName.Hypoxia);
                monster.canLearn.Add(MoveName.PsySurge);
                monster.canLearn.Add(MoveName.Tornado);
                monster.canLearn.Add(MoveName.TurboChoreography);
                monster.canLearn.Add(MoveName.WakeUp);
                monster.canLearn.Add(MoveName.Misogi);
                monster.canLearn.Add(MoveName.NoxiousBomb);
                monster.canLearn.Add(MoveName.Relax);
                monster.canLearn.Add(MoveName.BetaBurst);
                monster.canLearn.Add(MoveName.Lullaby);
                monster.canLearn.Add(MoveName.EnergyManipulation);
                break;
            case MonsterName.Bigu:
                monster.trait1 = MonsterTrait.Warmblooded;
                monster.trait2 = MonsterTrait.Amphibian;
                monster.type1 = MonsterType.Nature;
                monster.type2 = MonsterType.None;
                monster.baseHP = 55;
                monster.baseSTA = 68;
                monster.baseSPD = 20;
                monster.baseATK = 65;
                monster.baseDEF = 38;
                monster.baseSpATK = 41;
                monster.baseSpDEF = 42;
                //Learnset
                monster.canLearn.Add(MoveName.Nibble);
                monster.canLearn.Add(MoveName.ShyShield);
                monster.canLearn.Add(MoveName.SharpLeaf);
                monster.canLearn.Add(MoveName.Slime);
                monster.canLearn.Add(MoveName.WaterCuttingLily);
                monster.canLearn.Add(MoveName.WakeUp);
                monster.canLearn.Add(MoveName.Misogi);
                monster.canLearn.Add(MoveName.Antitoxins);
                monster.canLearn.Add(MoveName.Bubbles);
                monster.canLearn.Add(MoveName.IceCubes);
                monster.canLearn.Add(MoveName.ToxicSlime);
                break;
            case MonsterName.Blooze:
                monster.trait1 = MonsterTrait.ToxicSkin;
                monster.trait2 = MonsterTrait.Bully;
                monster.type1 = MonsterType.Toxic;
                monster.type2 = MonsterType.None;
                monster.baseHP = 68;
                monster.baseSTA = 50;
                monster.baseSPD = 33;
                monster.baseATK = 43;
                monster.baseDEF = 52;
                monster.baseSpATK = 46;
                monster.baseSpDEF = 54;
                //Learnset
                monster.canLearn.Add(MoveName.Nibble);
                monster.canLearn.Add(MoveName.NovicePunch);
                monster.canLearn.Add(MoveName.ShyShield);
                monster.canLearn.Add(MoveName.HeavyBlow);
                monster.canLearn.Add(MoveName.ToxicSlime);
                monster.canLearn.Add(MoveName.ToxicInk);
                break;
            case MonsterName.Bunbun:
                monster.trait1 = MonsterTrait.Caffeinated;
                monster.trait2 = MonsterTrait.Resilient;
                monster.type1 = MonsterType.Earth;
                monster.type2 = MonsterType.Crystal;
                monster.baseHP = 72;
                monster.baseSTA = 40;
                monster.baseSPD = 69;
                monster.baseATK = 50;
                monster.baseDEF = 36;
                monster.baseSpATK = 64;
                monster.baseSpDEF = 43;
                //Learnset
                monster.canLearn.Add(MoveName.Scratch);
                monster.canLearn.Add(MoveName.Nibble);
                monster.canLearn.Add(MoveName.Tenderness);
                monster.canLearn.Add(MoveName.CrystalDust);
                monster.canLearn.Add(MoveName.SandSplatter);
                monster.canLearn.Add(MoveName.MudShower);
                monster.canLearn.Add(MoveName.HeadRam);
                monster.canLearn.Add(MoveName.StoneBall);
                monster.canLearn.Add(MoveName.DustVortex);
                monster.canLearn.Add(MoveName.CrystalBite);
                break;
            case MonsterName.Capyre:
                monster.trait1 = MonsterTrait.LastRush;
                monster.trait2 = MonsterTrait.Resilient;
                monster.type1 = MonsterType.Fire;
                monster.type2 = MonsterType.None;
                monster.baseHP = 55;
                monster.baseSTA = 55;
                monster.baseSPD = 88;
                monster.baseATK = 71;
                monster.baseDEF = 58;
                monster.baseSpATK = 45;
                monster.baseSpDEF = 47;
                //Learnset
                monster.canLearn.Add(MoveName.Kick);
                monster.canLearn.Add(MoveName.HeavyBlow);
                monster.canLearn.Add(MoveName.WarmCuddle);
                monster.canLearn.Add(MoveName.SandSplatter);
                monster.canLearn.Add(MoveName.HeadRam);
                monster.canLearn.Add(MoveName.Embers);
                monster.canLearn.Add(MoveName.Rampage);
                monster.canLearn.Add(MoveName.FireTornado);
                monster.canLearn.Add(MoveName.HeatUp);
                monster.canLearn.Add(MoveName.Extinction);
                monster.canLearn.Add(MoveName.MagmaCannon);
                monster.canLearn.Add(MoveName.Block);
                monster.canLearn.Add(MoveName.Roar);
                break;
            case MonsterName.Cerneaf:
                monster.evolvesFrom = MonsterName.Spriole;
                monster.trait1 = MonsterTrait.Callosity;
                monster.trait2 = MonsterTrait.Settling;
                monster.type1 = MonsterType.Nature;
                monster.type2 = MonsterType.None;
                monster.baseHP = 91;
                monster.baseSTA = 44;
                monster.baseSPD = 79;
                monster.baseATK = 60;
                monster.baseDEF = 88;
                monster.baseSpATK = 43;
                monster.baseSpDEF = 46;
                //Learnset
                monster.canLearn.Add(MoveName.ShyShield);
                monster.canLearn.Add(MoveName.Nibble);
                monster.canLearn.Add(MoveName.Roots);
                monster.canLearn.Add(MoveName.SharpLeaf);
                monster.canLearn.Add(MoveName.AllergicSpread);
                monster.canLearn.Add(MoveName.DoubleKick);
                monster.canLearn.Add(MoveName.Rampage);
                monster.canLearn.Add(MoveName.Revitalize);
                monster.canLearn.Add(MoveName.WaterCuttingLily);
                monster.canLearn.Add(MoveName.Spores);
                monster.canLearn.Add(MoveName.FrondWhip);
                break;
            case MonsterName.Crystle:
                monster.trait1 = MonsterTrait.Amphibian;
                monster.trait2 = MonsterTrait.Rested;
                monster.type1 = MonsterType.Crystal;
                monster.type2 = MonsterType.None;
                monster.baseHP = 60;
                monster.baseSTA = 41;
                monster.baseSPD = 33;
                monster.baseATK = 61;
                monster.baseDEF = 69;
                monster.baseSpATK = 46;
                monster.baseSpDEF = 42;
                //Learnset
                monster.canLearn.Add(MoveName.GlassBlade);
                monster.canLearn.Add(MoveName.MirrorShell);
                monster.canLearn.Add(MoveName.Nibble);
                monster.canLearn.Add(MoveName.CrystalDust);
                monster.canLearn.Add(MoveName.HeadRam);
                monster.canLearn.Add(MoveName.Crystallize);
                monster.canLearn.Add(MoveName.CrystalSpikes);
                monster.canLearn.Add(MoveName.Rampage);
                monster.canLearn.Add(MoveName.StoneWall);
                break;
            case MonsterName.Deendre:
                monster.evolvesFrom = MonsterName.Spriole;
                monster.trait1 = MonsterTrait.Mithridatism;
                monster.trait2 = MonsterTrait.Settling;
                monster.type1 = MonsterType.Nature;
                monster.type2 = MonsterType.None;
                monster.baseHP = 80;
                monster.baseSTA = 42;
                monster.baseSPD = 70;
                monster.baseATK = 48;
                monster.baseDEF = 74;
                monster.baseSpATK = 42;
                monster.baseSpDEF = 35;
                //Learnset
                monster.canLearn.Add(MoveName.ShyShield);
                monster.canLearn.Add(MoveName.Nibble);
                monster.canLearn.Add(MoveName.Roots);
                monster.canLearn.Add(MoveName.SharpLeaf);
                monster.canLearn.Add(MoveName.AllergicSpread);
                monster.canLearn.Add(MoveName.DoubleKick);
                monster.canLearn.Add(MoveName.Rampage);
                monster.canLearn.Add(MoveName.Revitalize);
                monster.canLearn.Add(MoveName.Spores);
                monster.canLearn.Add(MoveName.FrondWhip);
                break;
            case MonsterName.Fomu:
                monster.trait1 = MonsterTrait.Amphibian;
                monster.trait2 = MonsterTrait.Hydrologist;
                monster.type1 = MonsterType.Water;
                monster.type2 = MonsterType.None;
                monster.baseHP = 40;
                monster.baseSTA = 60;
                monster.baseSPD = 40;
                monster.baseATK = 30;
                monster.baseDEF = 35;
                monster.baseSpATK = 65;
                monster.baseSpDEF = 70;
                //Learnset
                monster.canLearn.Add(MoveName.Bubbles);
                monster.canLearn.Add(MoveName.HeadCharge);
                monster.canLearn.Add(MoveName.Tenderness);
                monster.canLearn.Add(MoveName.IceCubes);
                monster.canLearn.Add(MoveName.DrillImpact);
                monster.canLearn.Add(MoveName.Tsunami);
                monster.canLearn.Add(MoveName.NoxiousBomb);
                monster.canLearn.Add(MoveName.AwfulSong);
                monster.canLearn.Add(MoveName.IceShuriken);
                monster.canLearn.Add(MoveName.Lullaby);
                monster.canLearn.Add(MoveName.SharpRain);
                break;
            case MonsterName.Ganki:
                monster.trait1 = MonsterTrait.Botanophobia;
                monster.trait2 = MonsterTrait.ColdNatured;
                monster.type1 = MonsterType.Electric;
                monster.type2 = MonsterType.Wind;
                monster.baseHP = 38;
                monster.baseSTA = 46;
                monster.baseSPD = 61;
                monster.baseATK = 57;
                monster.baseDEF = 38;
                monster.baseSpATK = 62;
                monster.baseSpDEF = 73;
                //Learnset
                monster.canLearn.Add(MoveName.Sparks);
                monster.canLearn.Add(MoveName.Nimble);
                monster.canLearn.Add(MoveName.WindBlade);
                monster.canLearn.Add(MoveName.DCBeam);
                monster.canLearn.Add(MoveName.ChainLightning);
                monster.canLearn.Add(MoveName.DrillImpact);
                monster.canLearn.Add(MoveName.TurboChoreography);
                monster.canLearn.Add(MoveName.Misogi);
                monster.canLearn.Add(MoveName.NoxiousBomb);
                monster.canLearn.Add(MoveName.TeslaPrison);
                break;
            case MonsterName.Gazuma:
                monster.trait1 = MonsterTrait.Receptive;
                monster.trait2 = MonsterTrait.FastCharge;
                monster.type1 = MonsterType.Electric;
                monster.type2 = MonsterType.Wind;
                monster.baseHP = 46;
                monster.baseSTA = 53;
                monster.baseSPD = 67;
                monster.baseATK = 68;
                monster.baseDEF = 43;
                monster.baseSpATK = 81;
                monster.baseSpDEF = 91;
                //Learnset
                monster.canLearn.Add(MoveName.Sparks);
                monster.canLearn.Add(MoveName.Nimble);
                monster.canLearn.Add(MoveName.WindBlade);
                monster.canLearn.Add(MoveName.DCBeam);
                monster.canLearn.Add(MoveName.ChainLightning);
                monster.canLearn.Add(MoveName.DrillImpact);
                monster.canLearn.Add(MoveName.TurboChoreography);
                monster.canLearn.Add(MoveName.Misogi);
                monster.canLearn.Add(MoveName.NoxiousBomb);
                monster.canLearn.Add(MoveName.TeslaPrison);
                break;
            case MonsterName.Goolder:
                monster.trait1 = MonsterTrait.StrongLiver;
                monster.trait2 = MonsterTrait.PunchingBag;
                monster.type1 = MonsterType.Toxic;
                monster.type2 = MonsterType.None;
                monster.baseHP = 120;
                monster.baseSTA = 70;
                monster.baseSPD = 10;
                monster.baseATK = 64;
                monster.baseDEF = 56;
                monster.baseSpATK = 68;
                monster.baseSpDEF = 56;
                //Learnset
                monster.canLearn.Add(MoveName.Nibble);
                monster.canLearn.Add(MoveName.NovicePunch);
                monster.canLearn.Add(MoveName.ShyShield);
                monster.canLearn.Add(MoveName.HeavyBlow);
                monster.canLearn.Add(MoveName.ToxicSlime);
                monster.canLearn.Add(MoveName.ToxicInk);
                monster.canLearn.Add(MoveName.Bamboozle);
                monster.canLearn.Add(MoveName.Pollution);
                monster.canLearn.Add(MoveName.HarmfulLick);
                monster.canLearn.Add(MoveName.Antitoxins);
                monster.canLearn.Add(MoveName.Confiscate);
                monster.canLearn.Add(MoveName.MadnessBuff);
                break;
            case MonsterName.Granpah:
                monster.trait1 = MonsterTrait.LastRush;
                monster.trait2 = MonsterTrait.Bully;
                monster.type1 = MonsterType.Wind;
                monster.type2 = MonsterType.None;
                monster.baseHP = 69;
                monster.baseSTA = 36;
                monster.baseSPD = 78;
                monster.baseATK = 55;
                monster.baseDEF = 61;
                monster.baseSpATK = 72;
                monster.baseSpDEF = 66;
                //Learnset
                monster.canLearn.Add(MoveName.Peck);
                monster.canLearn.Add(MoveName.Stare);
                monster.canLearn.Add(MoveName.Hypnosis);
                monster.canLearn.Add(MoveName.WindBlade);
                monster.canLearn.Add(MoveName.WindBurst);
                monster.canLearn.Add(MoveName.CheerUp);
                monster.canLearn.Add(MoveName.FeatherGatling);
                monster.canLearn.Add(MoveName.Hypoxia);
                monster.canLearn.Add(MoveName.Tornado);
                monster.canLearn.Add(MoveName.TurboChoreography);
                monster.canLearn.Add(MoveName.WakeUp);
                monster.canLearn.Add(MoveName.Misogi);
                monster.canLearn.Add(MoveName.Confiscate);
                monster.canLearn.Add(MoveName.HyperkineticStrike);
                monster.canLearn.Add(MoveName.HumiliatingSlap);
                break;
            case MonsterName.Gyalis:
                monster.trait1 = MonsterTrait.Mirroring;
                monster.trait2 = MonsterTrait.Resistant;
                monster.type1 = MonsterType.Crystal;
                monster.type2 = MonsterType.Melee;
                monster.baseHP = 86;
                monster.baseSTA = 44;
                monster.baseSPD = 100;
                monster.baseATK = 85;
                monster.baseDEF = 61;
                monster.baseSpATK = 23;
                monster.baseSpDEF = 61;
                //Learnset
                monster.canLearn.Add(MoveName.GlassBlade);
                monster.canLearn.Add(MoveName.Kick);
                monster.canLearn.Add(MoveName.ShowOff);
                monster.canLearn.Add(MoveName.SharpStabs);
                monster.canLearn.Add(MoveName.Footwork);
                monster.canLearn.Add(MoveName.Block);
                monster.canLearn.Add(MoveName.DrillImpact);
                monster.canLearn.Add(MoveName.CrystalBite);
                monster.canLearn.Add(MoveName.NinjaJutsu);
                monster.canLearn.Add(MoveName.AwfulSong);
                monster.canLearn.Add(MoveName.Antitoxins);
                monster.canLearn.Add(MoveName.Rend);
                monster.canLearn.Add(MoveName.MajorSlash);
                monster.canLearn.Add(MoveName.CrystalSpikes);
                monster.canLearn.Add(MoveName.Crystallize);
                monster.canLearn.Add(MoveName.HeatUp);
                monster.canLearn.Add(MoveName.EarthWave);
                monster.canLearn.Add(MoveName.HaitoUchi);
                break;
            case MonsterName.Hidody:
                monster.trait1 = MonsterTrait.ElectricSynthesize;
                monster.trait2 = MonsterTrait.Botanist;
                monster.type1 = MonsterType.Nature;
                monster.type2 = MonsterType.None;
                monster.baseHP = 49;
                monster.baseSTA = 70;
                monster.baseSPD = 39;
                monster.baseATK = 42;
                monster.baseDEF = 39;
                monster.baseSpATK = 62;
                monster.baseSpDEF = 55;
                //Learnset
                monster.canLearn.Add(MoveName.Scratch);
                monster.canLearn.Add(MoveName.SandSplatter);
                monster.canLearn.Add(MoveName.SharpLeaf);
                monster.canLearn.Add(MoveName.CheerUp);
                monster.canLearn.Add(MoveName.AllergicSpread);
                monster.canLearn.Add(MoveName.Gaia);
                monster.canLearn.Add(MoveName.BarkShield);
                monster.canLearn.Add(MoveName.WakeUp);
                monster.canLearn.Add(MoveName.Misogi);
                monster.canLearn.Add(MoveName.Antitoxins);
                monster.canLearn.Add(MoveName.Cage);
                monster.canLearn.Add(MoveName.Relax);
                monster.canLearn.Add(MoveName.Spores);
                monster.canLearn.Add(MoveName.Lullaby);
                monster.canLearn.Add(MoveName.WaterCuttingLily);
                monster.canLearn.Add(MoveName.Sacrifice);
                monster.canLearn.Add(MoveName.Hypoxia);
                break;
            case MonsterName.Hocus:
                monster.trait1 = MonsterTrait.SoftTouch;
                monster.trait2 = MonsterTrait.Mirroring;
                monster.type1 = MonsterType.Mental;
                monster.type2 = MonsterType.None;
                monster.baseHP = 49;
                monster.baseSTA = 61;
                monster.baseSPD = 65;
                monster.baseATK = 55;
                monster.baseDEF = 34;
                monster.baseSpATK = 55;
                monster.baseSpDEF = 34;
                //Learnset
                monster.canLearn.Add(MoveName.Psychosis);
                monster.canLearn.Add(MoveName.BetaBurst);
                monster.canLearn.Add(MoveName.TelekineticShrapnel);
                monster.canLearn.Add(MoveName.GammaBurst);
                break;
            case MonsterName.Houchic:
                monster.trait1 = MonsterTrait.MentalAlliance;
                monster.trait2 = MonsterTrait.SoftTouch;
                monster.type1 = MonsterType.Mental;
                monster.type2 = MonsterType.None;
                monster.baseHP = 38;
                monster.baseSTA = 44;
                monster.baseSPD = 66;
                monster.baseATK = 40;
                monster.baseDEF = 41;
                monster.baseSpATK = 72;
                monster.baseSpDEF = 52;
                //Learnset
                monster.canLearn.Add(MoveName.Hypnosis);
                monster.canLearn.Add(MoveName.PsyWave);
                monster.canLearn.Add(MoveName.Kick);
                monster.canLearn.Add(MoveName.Tenderness);
                monster.canLearn.Add(MoveName.EnergyManipulation);
                monster.canLearn.Add(MoveName.TelekineticShrapnel);
                monster.canLearn.Add(MoveName.BetaBurst);
                monster.canLearn.Add(MoveName.PsySurge);
                monster.canLearn.Add(MoveName.HumiliatingSlap);
                monster.canLearn.Add(MoveName.Lullaby);
                break;
            case MonsterName.Kaku:
                monster.trait1 = MonsterTrait.Caffeinated;
                monster.trait2 = MonsterTrait.Mithridatism;
                monster.type1 = MonsterType.Nature;
                monster.type2 = MonsterType.None;
                monster.baseHP = 69;
                monster.baseSTA = 48;
                monster.baseSPD = 35;
                monster.baseATK = 35;
                monster.baseDEF = 60;
                monster.baseSpATK = 60;
                monster.baseSpDEF = 50;
                //Learnset
                monster.canLearn.Add(MoveName.ShyShield);
                monster.canLearn.Add(MoveName.ToxicSpores);
                monster.canLearn.Add(MoveName.Nimble);
                monster.canLearn.Add(MoveName.Urushiol);
                monster.canLearn.Add(MoveName.SharpLeaf);
                monster.canLearn.Add(MoveName.WindBurst);
                monster.canLearn.Add(MoveName.NarcolepticHit);
                monster.canLearn.Add(MoveName.Boomerang);
                monster.canLearn.Add(MoveName.AllergicSpread);
                monster.canLearn.Add(MoveName.WakeUp);
                monster.canLearn.Add(MoveName.NoxiousBomb);
                monster.canLearn.Add(MoveName.BarkShield);
                monster.canLearn.Add(MoveName.LifefulSap);
                break;
            case MonsterName.Kalabyss:
                monster.trait1 = MonsterTrait.Botanophobia;
                monster.trait2 = MonsterTrait.Loneliness;
                monster.type1 = MonsterType.Water;
                monster.type2 = MonsterType.Toxic;
                monster.baseHP = 82;
                monster.baseSTA = 37;
                monster.baseSPD = 37;
                monster.baseATK = 75;
                monster.baseDEF = 100;
                monster.baseSpATK = 65;
                monster.baseSpDEF = 55;
                //Learnset
                monster.canLearn.Add(MoveName.Bubbles);
                monster.canLearn.Add(MoveName.TentacleWhip);
                monster.canLearn.Add(MoveName.WaterBlade);
                monster.canLearn.Add(MoveName.Strangle);
                monster.canLearn.Add(MoveName.AquaStone);
                monster.canLearn.Add(MoveName.ToxicInk);
                monster.canLearn.Add(MoveName.HighPressureWater);
                monster.canLearn.Add(MoveName.HumiliatingSlap);
                monster.canLearn.Add(MoveName.Flood);
                monster.canLearn.Add(MoveName.Tsunami);
                monster.canLearn.Add(MoveName.WakeUp);
                monster.canLearn.Add(MoveName.MajorSlash);
                monster.canLearn.Add(MoveName.IcedStalactite);
                monster.canLearn.Add(MoveName.ToxicSlime);
                monster.canLearn.Add(MoveName.Clinch);
                break;
            case MonsterName.Kalazu:
                monster.trait1 = MonsterTrait.Mithridatism;
                monster.trait2 = MonsterTrait.Hydrologist;
                monster.type1 = MonsterType.Water;
                monster.type2 = MonsterType.None;
                monster.baseHP = 63;
                monster.baseSTA = 24;
                monster.baseSPD = 28;
                monster.baseATK = 54;
                monster.baseDEF = 70;
                monster.baseSpATK = 38;
                monster.baseSpDEF = 44;
                //Learnset
                monster.canLearn.Add(MoveName.Bubbles);
                monster.canLearn.Add(MoveName.TentacleWhip);
                monster.canLearn.Add(MoveName.WaterBlade);
                monster.canLearn.Add(MoveName.Strangle);
                monster.canLearn.Add(MoveName.AquaStone);
                monster.canLearn.Add(MoveName.HighPressureWater);
                monster.canLearn.Add(MoveName.HumiliatingSlap);
                monster.canLearn.Add(MoveName.Tsunami);
                monster.canLearn.Add(MoveName.WakeUp);
                monster.canLearn.Add(MoveName.IcedStalactite);
                monster.canLearn.Add(MoveName.ToxicSlime);
                monster.canLearn.Add(MoveName.Clinch);
                break;
            case MonsterName.Kinu:
                monster.trait1 = MonsterTrait.Protector;
                monster.trait2 = MonsterTrait.Benefactor;
                monster.type1 = MonsterType.Nature;
                monster.type2 = MonsterType.Mental;
                monster.baseHP = 47;
                monster.baseSTA = 74;
                monster.baseSPD = 74;
                monster.baseATK = 53;
                monster.baseDEF = 41;
                monster.baseSpATK = 69;
                monster.baseSpDEF = 96;
                //Learnset
                monster.canLearn.Add(MoveName.Scratch);
                monster.canLearn.Add(MoveName.SharpLeaf);
                monster.canLearn.Add(MoveName.Hypnosis);
                monster.canLearn.Add(MoveName.PsyWave);
                monster.canLearn.Add(MoveName.Revitalize);
                monster.canLearn.Add(MoveName.BetaBurst);
                monster.canLearn.Add(MoveName.Gaia);
                monster.canLearn.Add(MoveName.LifefulSap);
                monster.canLearn.Add(MoveName.Sacrifice);
                monster.canLearn.Add(MoveName.StoneWall);
                monster.canLearn.Add(MoveName.TurboChoreography);
                monster.canLearn.Add(MoveName.WakeUp);
                monster.canLearn.Add(MoveName.Misogi);
                monster.canLearn.Add(MoveName.Lullaby);
                break;
            case MonsterName.Lapinite:
                monster.trait1 = MonsterTrait.Scavenger;
                monster.trait2 = MonsterTrait.ElectricSynthesize;
                monster.type1 = MonsterType.Crystal;
                monster.type2 = MonsterType.None;
                monster.baseHP = 58;
                monster.baseSTA = 31;
                monster.baseSPD = 46;
                monster.baseATK = 44;
                monster.baseDEF = 63;
                monster.baseSpATK = 55;
                monster.baseSpDEF = 56;
                //Learnset
                monster.canLearn.Add(MoveName.Scratch);
                monster.canLearn.Add(MoveName.Nibble);
                monster.canLearn.Add(MoveName.GlassBlade);
                monster.canLearn.Add(MoveName.TailStrike);
                monster.canLearn.Add(MoveName.SharpStabs);
                monster.canLearn.Add(MoveName.CrystalSpikes);
                monster.canLearn.Add(MoveName.Footwork);
                monster.canLearn.Add(MoveName.DiamondFort);
                break;
            case MonsterName.Loali:
                monster.trait1 = MonsterTrait.Botanist;
                monster.trait2 = MonsterTrait.ToxicFarewell;
                monster.type1 = MonsterType.Nature;
                monster.type2 = MonsterType.Wind;
                monster.baseHP = 55;
                monster.baseSTA = 80;
                monster.baseSPD = 80;
                monster.baseATK = 60;
                monster.baseDEF = 50;
                monster.baseSpATK = 70;
                monster.baseSpDEF = 90;
                //Learnset
                monster.canLearn.Add(MoveName.ShyShield);
                monster.canLearn.Add(MoveName.Tenderness);
                monster.canLearn.Add(MoveName.Urushiol);
                monster.canLearn.Add(MoveName.WindBlade);
                monster.canLearn.Add(MoveName.ToxicSpores);
                monster.canLearn.Add(MoveName.Nimble);
                monster.canLearn.Add(MoveName.Photosynthesis);
                monster.canLearn.Add(MoveName.Blizzard);
                monster.canLearn.Add(MoveName.BarkShield);
                monster.canLearn.Add(MoveName.AllergicSpread);
                monster.canLearn.Add(MoveName.TurboChoreography);
                monster.canLearn.Add(MoveName.WakeUp);
                monster.canLearn.Add(MoveName.Misogi);
                monster.canLearn.Add(MoveName.Spores);
                monster.canLearn.Add(MoveName.Hypoxia);
                break;
            case MonsterName.Magmis:
                monster.trait1 = MonsterTrait.Caffeinated;
                monster.trait2 = MonsterTrait.ThickSkin;
                monster.type1 = MonsterType.Fire;
                monster.type2 = MonsterType.None;
                monster.baseHP = 52;
                monster.baseSTA = 51;
                monster.baseSPD = 37;
                monster.baseATK = 55;
                monster.baseDEF = 42;
                monster.baseSpATK = 45;
                monster.baseSpDEF = 25;
                //Learnset
                monster.canLearn.Add(MoveName.Tenderness);
                monster.canLearn.Add(MoveName.FireFlame);
                monster.canLearn.Add(MoveName.JawStrike);
                monster.canLearn.Add(MoveName.Rage);
                monster.canLearn.Add(MoveName.WarmCuddle);
                monster.canLearn.Add(MoveName.Embers);
                break;
            case MonsterName.Mastione:
                monster.trait1 = MonsterTrait.Bully;
                monster.trait2 = MonsterTrait.Pyromaniac;
                monster.type1 = MonsterType.Fire;
                monster.type2 = MonsterType.None;
                monster.baseHP = 69;
                monster.baseSTA = 62;
                monster.baseSPD = 52;
                monster.baseATK = 91;
                monster.baseDEF = 65;
                monster.baseSpATK = 62;
                monster.baseSpDEF = 37;
                //Learnset
                monster.canLearn.Add(MoveName.Tenderness);
                monster.canLearn.Add(MoveName.FireFlame);
                monster.canLearn.Add(MoveName.JawStrike);
                monster.canLearn.Add(MoveName.Rage);
                monster.canLearn.Add(MoveName.WarmCuddle);
                monster.canLearn.Add(MoveName.Embers);
                monster.canLearn.Add(MoveName.MeteorSwarm);
                monster.canLearn.Add(MoveName.MagmaCannon);
                monster.canLearn.Add(MoveName.Cage);
                monster.canLearn.Add(MoveName.Rend);
                monster.canLearn.Add(MoveName.Block);
                monster.canLearn.Add(MoveName.Footwork);
                monster.canLearn.Add(MoveName.MajorSlash);
                break;
            case MonsterName.Mudrid:
                monster.trait1 = MonsterTrait.Receptive;
                monster.trait2 = MonsterTrait.Resilient;
                monster.type1 = MonsterType.Earth;
                monster.type2 = MonsterType.Crystal;
                monster.baseHP = 85;
                monster.baseSTA = 44;
                monster.baseSPD = 95;
                monster.baseATK = 60;
                monster.baseDEF = 42;
                monster.baseSpATK = 80;
                monster.baseSpDEF = 50;
                //Learnset
                monster.canLearn.Add(MoveName.Scratch);
                monster.canLearn.Add(MoveName.Nibble);
                monster.canLearn.Add(MoveName.Tenderness);
                monster.canLearn.Add(MoveName.CrystalDust);
                monster.canLearn.Add(MoveName.SandSplatter);
                monster.canLearn.Add(MoveName.MudShower);
                monster.canLearn.Add(MoveName.HeadRam);
                monster.canLearn.Add(MoveName.StoneBall);
                monster.canLearn.Add(MoveName.EarthWave);
                monster.canLearn.Add(MoveName.TurboChoreography);
                monster.canLearn.Add(MoveName.Rend);
                monster.canLearn.Add(MoveName.Footwork);
                monster.canLearn.Add(MoveName.DustVortex);
                monster.canLearn.Add(MoveName.CrystalBite);
                break;
            case MonsterName.Mushi:
                monster.trait1 = MonsterTrait.Resistant;
                monster.trait2 = MonsterTrait.Resilient;
                monster.type1 = MonsterType.Toxic;
                monster.type2 = MonsterType.None;
                monster.baseHP = 48;
                monster.baseSTA = 33;
                monster.baseSPD = 68;
                monster.baseATK = 48;
                monster.baseDEF = 36;
                monster.baseSpATK = 48;
                monster.baseSpDEF = 29;
                //Learnset
                monster.canLearn.Add(MoveName.Nibble);
                monster.canLearn.Add(MoveName.Tenderness);
                monster.canLearn.Add(MoveName.Urushiol);
                monster.canLearn.Add(MoveName.ToxicSpores);
                monster.canLearn.Add(MoveName.ShrillVoice);
                monster.canLearn.Add(MoveName.HumiliatingSlap);
                monster.canLearn.Add(MoveName.ParalysingPoison);
                monster.canLearn.Add(MoveName.InnerSpirit);
                monster.canLearn.Add(MoveName.Intimidation);
                break;
            case MonsterName.Mushook:
                monster.trait1 = MonsterTrait.Parrier;
                monster.trait2 = MonsterTrait.Tireless;
                monster.type1 = MonsterType.Toxic;
                monster.type2 = MonsterType.Melee;
                monster.baseHP = 67;
                monster.baseSTA = 45;
                monster.baseSPD = 81;
                monster.baseATK = 81;
                monster.baseDEF = 80;
                monster.baseSpATK = 49;
                monster.baseSpDEF = 41;
                //Learnset
                monster.canLearn.Add(MoveName.Nibble);
                monster.canLearn.Add(MoveName.Tenderness);
                monster.canLearn.Add(MoveName.Urushiol);
                monster.canLearn.Add(MoveName.ToxicSpores);
                monster.canLearn.Add(MoveName.ShrillVoice);
                monster.canLearn.Add(MoveName.HumiliatingSlap);
                monster.canLearn.Add(MoveName.ParalysingPoison);
                monster.canLearn.Add(MoveName.PerfectJab);
                monster.canLearn.Add(MoveName.Uppercut);
                monster.canLearn.Add(MoveName.Footwork);
                monster.canLearn.Add(MoveName.TurboChoreography);
                monster.canLearn.Add(MoveName.Confiscate);
                monster.canLearn.Add(MoveName.Cage);
                monster.canLearn.Add(MoveName.Block);
                monster.canLearn.Add(MoveName.InnerSpirit);
                monster.canLearn.Add(MoveName.Intimidation);
                break;
            case MonsterName.Myx:
                monster.trait1 = MonsterTrait.PuppetMaster;
                monster.trait2 = MonsterTrait.Rejuvinate;
                monster.type1 = MonsterType.Crystal;
                monster.type2 = MonsterType.Mental;
                monster.baseHP = 51;
                monster.baseSTA = 59;
                monster.baseSPD = 65;
                monster.baseATK = 51;
                monster.baseDEF = 43;
                monster.baseSpATK = 94;
                monster.baseSpDEF = 80;
                //Learnset
                monster.canLearn.Add(MoveName.NovicePunch);
                monster.canLearn.Add(MoveName.GlassBlade);
                monster.canLearn.Add(MoveName.Crystallize);
                monster.canLearn.Add(MoveName.HeavyBlow);
                monster.canLearn.Add(MoveName.EnergyManipulation);
                monster.canLearn.Add(MoveName.HeadRam);
                monster.canLearn.Add(MoveName.CrystalBite);
                monster.canLearn.Add(MoveName.Clinch);
                monster.canLearn.Add(MoveName.Hallucination);
                monster.canLearn.Add(MoveName.CrystalSpikes);
                monster.canLearn.Add(MoveName.Cage);
                monster.canLearn.Add(MoveName.Rend);
                monster.canLearn.Add(MoveName.PsySurge);
                monster.canLearn.Add(MoveName.HumiliatingSlap);
                break;
            case MonsterName.Nessla:
                monster.trait1 = MonsterTrait.ElectricSynthesize;
                monster.trait2 = MonsterTrait.Hydrologist;
                monster.type1 = MonsterType.Water;
                monster.type2 = MonsterType.Electric;
                monster.baseHP = 45;
                monster.baseSTA = 58;
                monster.baseSPD = 66;
                monster.baseATK = 76;
                monster.baseDEF = 50;
                monster.baseSpATK = 70;
                monster.baseSpDEF = 72;
                //Learnset
                monster.canLearn.Add(MoveName.Bubbles);
                monster.canLearn.Add(MoveName.WaterBlade);
                monster.canLearn.Add(MoveName.ChainLightning);
                monster.canLearn.Add(MoveName.Sparks);
                monster.canLearn.Add(MoveName.Strangle);
                monster.canLearn.Add(MoveName.TeslaPrison);
                monster.canLearn.Add(MoveName.Stare);
                monster.canLearn.Add(MoveName.IcedStalactite);
                monster.canLearn.Add(MoveName.ElectricStorm);
                monster.canLearn.Add(MoveName.WakeUp);
                monster.canLearn.Add(MoveName.Rend);
                break;
            case MonsterName.Nidrasil:
                monster.trait1 = MonsterTrait.ToxicFarewell;
                monster.trait2 = MonsterTrait.TriApothecary;
                monster.type1 = MonsterType.Nature;
                monster.type2 = MonsterType.Toxic;
                monster.baseHP = 77;
                monster.baseSTA = 52;
                monster.baseSPD = 61;
                monster.baseATK = 88;
                monster.baseDEF = 80;
                monster.baseSpATK = 36;
                monster.baseSpDEF = 51;
                //Learnset
                monster.canLearn.Add(MoveName.Nibble);
                monster.canLearn.Add(MoveName.Hypnosis);
                monster.canLearn.Add(MoveName.ToxicFang);
                monster.canLearn.Add(MoveName.Spores);
                monster.canLearn.Add(MoveName.SharpLeaf);
                monster.canLearn.Add(MoveName.Roots);
                monster.canLearn.Add(MoveName.ToxicInk);
                monster.canLearn.Add(MoveName.AllergicSpread);
                monster.canLearn.Add(MoveName.Hallucination);
                monster.canLearn.Add(MoveName.WakeUp);
                monster.canLearn.Add(MoveName.Antitoxins);
                monster.canLearn.Add(MoveName.MadnessBuff);
                monster.canLearn.Add(MoveName.HeldAnger);
                monster.canLearn.Add(MoveName.NarcolepticHit);
                monster.canLearn.Add(MoveName.Photosynthesis);
                monster.canLearn.Add(MoveName.BarkShield);
                break;
            case MonsterName.Noxolotl:
                monster.trait1 = MonsterTrait.Trance;
                monster.trait2 = MonsterTrait.ToxicSkin;
                monster.type1 = MonsterType.Toxic;
                monster.type2 = MonsterType.None;
                monster.baseHP = 72;
                monster.baseSTA = 49;
                monster.baseSPD = 61;
                monster.baseATK = 78;
                monster.baseDEF = 78;
                monster.baseSpATK = 85;
                monster.baseSpDEF = 45;
                //Learnset
                monster.canLearn.Add(MoveName.Scratch);
                monster.canLearn.Add(MoveName.Hypnosis);
                monster.canLearn.Add(MoveName.Stare);
                monster.canLearn.Add(MoveName.VenomousClaws);
                monster.canLearn.Add(MoveName.ToxicInk);
                monster.canLearn.Add(MoveName.TentacleWhip);
                monster.canLearn.Add(MoveName.HarmfulLick);
                monster.canLearn.Add(MoveName.Hallucination);
                monster.canLearn.Add(MoveName.TurboChoreography);
                monster.canLearn.Add(MoveName.NoxiousBomb);
                monster.canLearn.Add(MoveName.MadnessBuff);
                monster.canLearn.Add(MoveName.NarcolepticHit);
                break;
            case MonsterName.Occlura:
                monster.trait1 = MonsterTrait.Warmblooded;
                monster.trait2 = MonsterTrait.Scavenger;
                monster.type1 = MonsterType.Crystal;
                monster.type2 = MonsterType.None;
                monster.baseHP = 50;
                monster.baseSTA = 39;
                monster.baseSPD = 50;
                monster.baseATK = 45;
                monster.baseDEF = 43;
                monster.baseSpATK = 38;
                monster.baseSpDEF = 65;
                //Learnset
                monster.canLearn.Add(MoveName.NovicePunch);
                monster.canLearn.Add(MoveName.GlassBlade);
                monster.canLearn.Add(MoveName.Crystallize);
                monster.canLearn.Add(MoveName.HeavyBlow);
                monster.canLearn.Add(MoveName.EnergyManipulation);
                monster.canLearn.Add(MoveName.HeadRam);
                monster.canLearn.Add(MoveName.CrystalBite);
                monster.canLearn.Add(MoveName.PsySurge);
                monster.canLearn.Add(MoveName.HumiliatingSlap);
                break;
            case MonsterName.Oceara:
                monster.trait1 = MonsterTrait.Hydrologist;
                monster.trait2 = MonsterTrait.Mithridatism;
                monster.type1 = MonsterType.Water;
                monster.type2 = MonsterType.None;
                monster.baseHP = 64;
                monster.baseSTA = 42;
                monster.baseSPD = 100;
                monster.baseATK = 54;
                monster.baseDEF = 51;
                monster.baseSpATK = 110;
                monster.baseSpDEF = 65;
                //Learnset
                monster.canLearn.Add(MoveName.Kick);
                monster.canLearn.Add(MoveName.HighPressureWater);
                monster.canLearn.Add(MoveName.Tsunami);
                monster.canLearn.Add(MoveName.IceShuriken);
                monster.canLearn.Add(MoveName.Blizzard);
                monster.canLearn.Add(MoveName.Flood);
                monster.canLearn.Add(MoveName.AquaticWhirlwind);
                break;
            case MonsterName.Orphyll:
                monster.trait1 = MonsterTrait.ToxicAffinity;
                monster.trait2 = MonsterTrait.Apothecary;
                monster.type1 = MonsterType.Nature;
                monster.type2 = MonsterType.Toxic;
                monster.baseHP = 42;
                monster.baseSTA = 48;
                monster.baseSPD = 75;
                monster.baseATK = 68;
                monster.baseDEF = 64;
                monster.baseSpATK = 27;
                monster.baseSpDEF = 40;
                //Learnset
                monster.canLearn.Add(MoveName.Nibble);
                monster.canLearn.Add(MoveName.Hypnosis);
                monster.canLearn.Add(MoveName.ToxicFang);
                monster.canLearn.Add(MoveName.Spores);
                monster.canLearn.Add(MoveName.SharpLeaf);
                monster.canLearn.Add(MoveName.Roots);
                monster.canLearn.Add(MoveName.ToxicInk);
                monster.canLearn.Add(MoveName.AllergicSpread);
                monster.canLearn.Add(MoveName.WakeUp);
                monster.canLearn.Add(MoveName.Antitoxins);
                monster.canLearn.Add(MoveName.MadnessBuff);
                monster.canLearn.Add(MoveName.HeldAnger);
                monster.canLearn.Add(MoveName.NarcolepticHit);
                monster.canLearn.Add(MoveName.Photosynthesis);
                monster.canLearn.Add(MoveName.BarkShield);
                break;
            case MonsterName.Paharac:
                monster.evolvesFrom = MonsterName.Granpah;
                monster.trait1 = MonsterTrait.Caffeinated;
                monster.trait2 = MonsterTrait.Camaraderie;
                monster.type1 = MonsterType.Wind;
                monster.type2 = MonsterType.None;
                monster.baseHP = 60;
                monster.baseSTA = 30;
                monster.baseSPD = 70;
                monster.baseATK = 50;
                monster.baseDEF = 55;
                monster.baseSpATK = 60;
                monster.baseSpDEF = 60;
                //Learnset
                monster.canLearn.Add(MoveName.Peck);
                monster.canLearn.Add(MoveName.Stare);
                monster.canLearn.Add(MoveName.Hypnosis);
                monster.canLearn.Add(MoveName.WindBlade);
                monster.canLearn.Add(MoveName.WindBurst);
                monster.canLearn.Add(MoveName.CheerUp);
                monster.canLearn.Add(MoveName.FeatherGatling);
                monster.canLearn.Add(MoveName.Hypoxia);
                monster.canLearn.Add(MoveName.Tornado);
                monster.canLearn.Add(MoveName.TurboChoreography);
                monster.canLearn.Add(MoveName.WakeUp);
                monster.canLearn.Add(MoveName.Misogi);
                monster.canLearn.Add(MoveName.HyperkineticStrike);
                monster.canLearn.Add(MoveName.HumiliatingSlap);
                break;
            case MonsterName.Paharo:
                monster.trait1 = MonsterTrait.Hover;
                monster.trait2 = MonsterTrait.Friendship;
                monster.type1 = MonsterType.Wind;
                monster.type2 = MonsterType.None;
                monster.baseHP = 48;
                monster.baseSTA = 18;
                monster.baseSPD = 60;
                monster.baseATK = 40;
                monster.baseDEF = 40;
                monster.baseSpATK = 50;
                monster.baseSpDEF = 50;
                //Learnset
                monster.canLearn.Add(MoveName.Peck);
                monster.canLearn.Add(MoveName.Stare);
                monster.canLearn.Add(MoveName.Hypnosis);
                monster.canLearn.Add(MoveName.WindBlade);
                monster.canLearn.Add(MoveName.WindBurst);
                monster.canLearn.Add(MoveName.CheerUp);
                monster.canLearn.Add(MoveName.FeatherGatling);
                monster.canLearn.Add(MoveName.Hypoxia);
                monster.canLearn.Add(MoveName.Tornado);
                monster.canLearn.Add(MoveName.TurboChoreography);
                monster.canLearn.Add(MoveName.WakeUp);
                monster.canLearn.Add(MoveName.Misogi);
                monster.canLearn.Add(MoveName.HyperkineticStrike);
                monster.canLearn.Add(MoveName.HumiliatingSlap);
                break;
            case MonsterName.Pewki:
                monster.trait1 = MonsterTrait.Hydrologist;
                monster.trait2 = MonsterTrait.Rested;
                monster.type1 = MonsterType.Water;
                monster.type2 = MonsterType.None;
                monster.baseHP = 70;
                monster.baseSTA = 32;
                monster.baseSPD = 33;
                monster.baseATK = 42;
                monster.baseDEF = 45;
                monster.baseSpATK = 31;
                monster.baseSpDEF = 10;
                //Learnset
                monster.canLearn.Add(MoveName.HeadCharge);
                monster.canLearn.Add(MoveName.Bubbles);
                monster.canLearn.Add(MoveName.Finbeat);
                monster.canLearn.Add(MoveName.WaterBlade);
                monster.canLearn.Add(MoveName.JawStrike);
                monster.canLearn.Add(MoveName.CheerUp);
                monster.canLearn.Add(MoveName.HumiliatingSlap);
                monster.canLearn.Add(MoveName.AquaticWhirlwind);
                monster.canLearn.Add(MoveName.Tsunami);
                monster.canLearn.Add(MoveName.NoxiousBomb);
                monster.canLearn.Add(MoveName.HighPressureWater);
                monster.canLearn.Add(MoveName.Flood);
                break;
            case MonsterName.Pigepic:
                monster.trait1 = MonsterTrait.Friendship;
                monster.trait2 = MonsterTrait.FaintedCurse;
                monster.type1 = MonsterType.Wind;
                monster.type2 = MonsterType.None;
                monster.baseHP = 54;
                monster.baseSTA = 72;
                monster.baseSPD = 58;
                monster.baseATK = 60;
                monster.baseDEF = 72;
                monster.baseSpATK = 45;
                monster.baseSpDEF = 72;
                //Learnset
                monster.canLearn.Add(MoveName.Bamboozle);
                monster.canLearn.Add(MoveName.Scratch);
                monster.canLearn.Add(MoveName.Nibble);
                monster.canLearn.Add(MoveName.Nimble);
                monster.canLearn.Add(MoveName.HeavyBlow);
                monster.canLearn.Add(MoveName.WindBurst);
                monster.canLearn.Add(MoveName.Tornado);
                monster.canLearn.Add(MoveName.OshiDashi);
                break;
            case MonsterName.Piraniant:
                monster.trait1 = MonsterTrait.Patient;
                monster.trait2 = MonsterTrait.EnergyReserve;
                monster.type1 = MonsterType.Water;
                monster.type2 = MonsterType.None;
                monster.baseHP = 80;
                monster.baseSTA = 50;
                monster.baseSPD = 55;
                monster.baseATK = 77;
                monster.baseDEF = 85;
                monster.baseSpATK = 65;
                monster.baseSpDEF = 37;
                //Learnset
                monster.canLearn.Add(MoveName.HeadCharge);
                monster.canLearn.Add(MoveName.Bubbles);
                monster.canLearn.Add(MoveName.Finbeat);
                monster.canLearn.Add(MoveName.WaterBlade);
                monster.canLearn.Add(MoveName.JawStrike);
                monster.canLearn.Add(MoveName.CheerUp);
                monster.canLearn.Add(MoveName.HumiliatingSlap);
                monster.canLearn.Add(MoveName.AquaticWhirlwind);
                monster.canLearn.Add(MoveName.Rend);
                monster.canLearn.Add(MoveName.Tsunami);
                monster.canLearn.Add(MoveName.NoxiousBomb);
                monster.canLearn.Add(MoveName.HighPressureWater);
                monster.canLearn.Add(MoveName.Flood);
                break;
            case MonsterName.Platimous:
                monster.trait1 = MonsterTrait.Zen;
                monster.trait2 = MonsterTrait.Determined;
                monster.type1 = MonsterType.Water;
                monster.type2 = MonsterType.Toxic;
                monster.baseHP = 71;
                monster.baseSTA = 49;
                monster.baseSPD = 82;
                monster.baseATK = 56;
                monster.baseDEF = 39;
                monster.baseSpATK = 90;
                monster.baseSpDEF = 70;
                //Learnset
                monster.canLearn.Add(MoveName.Finbeat);
                monster.canLearn.Add(MoveName.WaterBlade);
                monster.canLearn.Add(MoveName.VenomousClaws);
                monster.canLearn.Add(MoveName.SandSplatter);
                monster.canLearn.Add(MoveName.CheerUp);
                monster.canLearn.Add(MoveName.AquaBulletHell);
                monster.canLearn.Add(MoveName.Tsunami);
                monster.canLearn.Add(MoveName.ToxicFang);
                monster.canLearn.Add(MoveName.ParalysingPoison);
                monster.canLearn.Add(MoveName.AquaticWhirlwind);
                monster.canLearn.Add(MoveName.Misogi);
                monster.canLearn.Add(MoveName.NoxiousBomb);
                monster.canLearn.Add(MoveName.Rend);
                monster.canLearn.Add(MoveName.Footwork);
                monster.canLearn.Add(MoveName.HeldAnger);
                monster.canLearn.Add(MoveName.MajorSlash);
                monster.canLearn.Add(MoveName.Urushiol);
                monster.canLearn.Add(MoveName.Antitoxins);
                monster.canLearn.Add(MoveName.SharpRain);
                monster.canLearn.Add(MoveName.Flood);
                monster.canLearn.Add(MoveName.Intimidation);
                monster.canLearn.Add(MoveName.ShrillVoice);
                break;
            case MonsterName.Platox:
                monster.trait1 = MonsterTrait.Resistant;
                monster.trait2 = MonsterTrait.Resilient;
                monster.type1 = MonsterType.Water;
                monster.type2 = MonsterType.Toxic;
                monster.baseHP = 62;
                monster.baseSTA = 44;
                monster.baseSPD = 75;
                monster.baseATK = 50;
                monster.baseDEF = 35;
                monster.baseSpATK = 76;
                monster.baseSpDEF = 63;
                //Learnset
                monster.canLearn.Add(MoveName.Finbeat);
                monster.canLearn.Add(MoveName.WaterBlade);
                monster.canLearn.Add(MoveName.VenomousClaws);
                monster.canLearn.Add(MoveName.SandSplatter);
                monster.canLearn.Add(MoveName.CheerUp);
                monster.canLearn.Add(MoveName.AquaBulletHell);
                monster.canLearn.Add(MoveName.Tsunami);
                monster.canLearn.Add(MoveName.ToxicFang);
                monster.canLearn.Add(MoveName.ParalysingPoison);
                monster.canLearn.Add(MoveName.Misogi);
                monster.canLearn.Add(MoveName.NoxiousBomb);
                monster.canLearn.Add(MoveName.Rend);
                monster.canLearn.Add(MoveName.Footwork);
                monster.canLearn.Add(MoveName.HeldAnger);
                monster.canLearn.Add(MoveName.MajorSlash);
                monster.canLearn.Add(MoveName.Urushiol);
                monster.canLearn.Add(MoveName.Antitoxins);
                monster.canLearn.Add(MoveName.SharpRain);
                monster.canLearn.Add(MoveName.Flood);
                monster.canLearn.Add(MoveName.Intimidation);
                monster.canLearn.Add(MoveName.ShrillVoice);
                break;
            case MonsterName.Platypet:
                monster.trait1 = MonsterTrait.ToxicAffinity;
                monster.trait2 = MonsterTrait.Amphibian;
                monster.type1 = MonsterType.Water;
                monster.type2 = MonsterType.Toxic;
                monster.baseHP = 55;
                monster.baseSTA = 39;
                monster.baseSPD = 65;
                monster.baseATK = 45;
                monster.baseDEF = 31;
                monster.baseSpATK = 67;
                monster.baseSpDEF = 56;
                //Learnset
                monster.canLearn.Add(MoveName.Finbeat);
                monster.canLearn.Add(MoveName.WaterBlade);
                monster.canLearn.Add(MoveName.VenomousClaws);
                monster.canLearn.Add(MoveName.SandSplatter);
                monster.canLearn.Add(MoveName.CheerUp);
                monster.canLearn.Add(MoveName.AquaBulletHell);
                monster.canLearn.Add(MoveName.Tsunami);
                monster.canLearn.Add(MoveName.Urushiol);
                monster.canLearn.Add(MoveName.Antitoxins);
                monster.canLearn.Add(MoveName.SharpRain);
                monster.canLearn.Add(MoveName.Flood);
                monster.canLearn.Add(MoveName.Intimidation);
                monster.canLearn.Add(MoveName.ShrillVoice);
                break;
            case MonsterName.Pocus:
                monster.trait1 = MonsterTrait.DreadedAlarm;
                monster.trait2 = MonsterTrait.Rejuvinate;
                monster.type1 = MonsterType.Mental;
                monster.type2 = MonsterType.None;
                monster.baseHP = 60;
                monster.baseSTA = 73;
                monster.baseSPD = 78;
                monster.baseATK = 69;
                monster.baseDEF = 36;
                monster.baseSpATK = 77;
                monster.baseSpDEF = 38;
                //Learnset
                monster.canLearn.Add(MoveName.NinjaJutsu);
                break;
            case MonsterName.Raiber:
                monster.trait1 = MonsterTrait.Camaraderie;
                monster.trait2 = MonsterTrait.Rested;
                monster.type1 = MonsterType.Fire;
                monster.type2 = MonsterType.None;
                monster.baseHP = 57;
                monster.baseSTA = 35;
                monster.baseSPD = 42;
                monster.baseATK = 40;
                monster.baseDEF = 61;
                monster.baseSpATK = 59;
                monster.baseSpDEF = 38;
                //Learnset
                monster.canLearn.Add(MoveName.Scratch);
                monster.canLearn.Add(MoveName.SandSplatter);
                monster.canLearn.Add(MoveName.FireFlame);
                monster.canLearn.Add(MoveName.Roar);
                monster.canLearn.Add(MoveName.FierceClaw);
                monster.canLearn.Add(MoveName.Embers);
                monster.canLearn.Add(MoveName.FireTornado);
                break;
            case MonsterName.Raican:
                monster.evolvesFrom = MonsterName.Raiber;
                monster.trait1 = MonsterTrait.Prideful;
                monster.trait2 = MonsterTrait.Motivator;
                monster.type1 = MonsterType.Fire;
                monster.type2 = MonsterType.None;
                monster.baseHP = 77;
                monster.baseSTA = 49;
                monster.baseSPD = 60;
                monster.baseATK = 77;
                monster.baseDEF = 77;
                monster.baseSpATK = 51;
                monster.baseSpDEF = 50;
                //Learnset
                monster.canLearn.Add(MoveName.Scratch);
                monster.canLearn.Add(MoveName.SandSplatter);
                monster.canLearn.Add(MoveName.FireFlame);
                monster.canLearn.Add(MoveName.Roar);
                monster.canLearn.Add(MoveName.FierceClaw);
                monster.canLearn.Add(MoveName.Embers);
                monster.canLearn.Add(MoveName.FireTornado);
                monster.canLearn.Add(MoveName.KingsRoar);
                monster.canLearn.Add(MoveName.MeteorSwarm);
                monster.canLearn.Add(MoveName.HeldAnger);
                monster.canLearn.Add(MoveName.Rampage);
                break;
            case MonsterName.Raize:
                monster.evolvesFrom = MonsterName.Raiber;
                monster.trait1 = MonsterTrait.Furor;
                monster.trait2 = MonsterTrait.Demoralize;
                monster.type1 = MonsterType.Fire;
                monster.type2 = MonsterType.None;
                monster.baseHP = 66;
                monster.baseSTA = 46;
                monster.baseSPD = 40;
                monster.baseATK = 46;
                monster.baseDEF = 74;
                monster.baseSpATK = 69;
                monster.baseSpDEF = 43;
                //Learnset
                monster.canLearn.Add(MoveName.Scratch);
                monster.canLearn.Add(MoveName.SandSplatter);
                monster.canLearn.Add(MoveName.FireFlame);
                monster.canLearn.Add(MoveName.Roar);
                monster.canLearn.Add(MoveName.FierceClaw);
                monster.canLearn.Add(MoveName.Embers);
                monster.canLearn.Add(MoveName.FireTornado);
                monster.canLearn.Add(MoveName.KingsRoar);
                monster.canLearn.Add(MoveName.Rampage);
                break;
            case MonsterName.Saipat:
                monster.trait1 = MonsterTrait.Amphibian;
                monster.trait2 = MonsterTrait.ToxicAffinity;
                monster.type1 = MonsterType.Water;
                monster.type2 = MonsterType.Melee;
                monster.baseHP = 92;
                monster.baseSTA = 42;
                monster.baseSPD = 70;
                monster.baseATK = 80;
                monster.baseDEF = 50;
                monster.baseSpATK = 70;
                monster.baseSpDEF = 40;
                //Learnset
                monster.canLearn.Add(MoveName.MartialStrike);
                monster.canLearn.Add(MoveName.WaterBlade);
                monster.canLearn.Add(MoveName.Rage);
                monster.canLearn.Add(MoveName.Stare);
                monster.canLearn.Add(MoveName.VenomousClaws);
                monster.canLearn.Add(MoveName.HighPressureWater);
                monster.canLearn.Add(MoveName.HeldAnger);
                monster.canLearn.Add(MoveName.NichoSai);
                monster.canLearn.Add(MoveName.IcedStalactite);
                monster.canLearn.Add(MoveName.NinjaJutsu);
                monster.canLearn.Add(MoveName.Tsunami);
                monster.canLearn.Add(MoveName.Misogi);
                monster.canLearn.Add(MoveName.ToxicInk);
                monster.canLearn.Add(MoveName.IceShuriken);
                break;
            case MonsterName.Saku:
                monster.trait1 = MonsterTrait.AirSpecialist;
                monster.trait2 = MonsterTrait.Botanist;
                monster.type1 = MonsterType.Nature;
                monster.type2 = MonsterType.Wind;
                monster.baseHP = 82;
                monster.baseSTA = 60;
                monster.baseSPD = 40;
                monster.baseATK = 40;
                monster.baseDEF = 62;
                monster.baseSpATK = 66;
                monster.baseSpDEF = 70;
                //Learnset
                monster.canLearn.Add(MoveName.ShyShield);
                monster.canLearn.Add(MoveName.ToxicSpores);
                monster.canLearn.Add(MoveName.Nimble);
                monster.canLearn.Add(MoveName.Urushiol);
                monster.canLearn.Add(MoveName.SharpLeaf);
                monster.canLearn.Add(MoveName.WindBurst);
                monster.canLearn.Add(MoveName.NarcolepticHit);
                monster.canLearn.Add(MoveName.Boomerang);
                monster.canLearn.Add(MoveName.AllergicSpread);
                monster.canLearn.Add(MoveName.Tornado);
                monster.canLearn.Add(MoveName.WakeUp);
                monster.canLearn.Add(MoveName.NoxiousBomb);
                monster.canLearn.Add(MoveName.HeldAnger);
                monster.canLearn.Add(MoveName.Relax);
                monster.canLearn.Add(MoveName.BarkShield);
                monster.canLearn.Add(MoveName.LifefulSap);
                break;
            case MonsterName.Sherald:
                monster.trait1 = MonsterTrait.Mirroring;
                monster.trait2 = MonsterTrait.Provident;
                monster.type1 = MonsterType.Crystal;
                monster.type2 = MonsterType.None;
                monster.baseHP = 68;
                monster.baseSTA = 45;
                monster.baseSPD = 43;
                monster.baseATK = 69;
                monster.baseDEF = 78;
                monster.baseSpATK = 51;
                monster.baseSpDEF = 48;
                //Learnset
                monster.canLearn.Add(MoveName.GlassBlade);
                monster.canLearn.Add(MoveName.MirrorShell);
                monster.canLearn.Add(MoveName.Nibble);
                monster.canLearn.Add(MoveName.CrystalDust);
                monster.canLearn.Add(MoveName.HeadRam);
                monster.canLearn.Add(MoveName.Crystallize);
                monster.canLearn.Add(MoveName.CrystalSpikes);
                monster.canLearn.Add(MoveName.Rampage);
                monster.canLearn.Add(MoveName.DiamondFort);
                monster.canLearn.Add(MoveName.StoneWall);
                monster.canLearn.Add(MoveName.Cage);
                break;
            case MonsterName.Shuine:
                monster.trait1 = MonsterTrait.Immunity;
                monster.trait2 = MonsterTrait.Guardian;
                monster.type1 = MonsterType.Crystal;
                monster.type2 = MonsterType.Water;
                monster.baseHP = 43;
                monster.baseSTA = 90;
                monster.baseSPD = 81;
                monster.baseATK = 67;
                monster.baseDEF = 49;
                monster.baseSpATK = 72;
                monster.baseSpDEF = 60;
                //Learnset
                monster.canLearn.Add(MoveName.Nibble);
                monster.canLearn.Add(MoveName.GlassBlade);
                monster.canLearn.Add(MoveName.AquaBulletHell);
                monster.canLearn.Add(MoveName.IcedStalactite);
                monster.canLearn.Add(MoveName.Flood);
                monster.canLearn.Add(MoveName.CrystalBite);
                monster.canLearn.Add(MoveName.NinjaJutsu);
                monster.canLearn.Add(MoveName.Sacrifice);
                monster.canLearn.Add(MoveName.Antitoxins);
                monster.canLearn.Add(MoveName.Confiscate);
                monster.canLearn.Add(MoveName.Relax);
                break;
            case MonsterName.Skail:
                monster.trait1 = MonsterTrait.Furor;
                monster.trait2 = MonsterTrait.Scavenger;
                monster.type1 = MonsterType.Neutral;
                monster.type2 = MonsterType.None;
                monster.baseHP = 57;
                monster.baseSTA = 43;
                monster.baseSPD = 60;
                monster.baseATK = 45;
                monster.baseDEF = 50;
                monster.baseSpATK = 32;
                monster.baseSpDEF = 41;
                //Learnset
                monster.canLearn.Add(MoveName.TailStrike);
                monster.canLearn.Add(MoveName.Scratch);
                monster.canLearn.Add(MoveName.SandSplatter);
                monster.canLearn.Add(MoveName.HeldAnger);
                monster.canLearn.Add(MoveName.FierceClaw);
                monster.canLearn.Add(MoveName.HaitoUchi);
                monster.canLearn.Add(MoveName.StoneWall);
                monster.canLearn.Add(MoveName.WakeUp);
                monster.canLearn.Add(MoveName.Misogi);
                monster.canLearn.Add(MoveName.PerfectJab);
                monster.canLearn.Add(MoveName.OshiDashi);
                break;
            case MonsterName.Skunch:
                monster.trait1 = MonsterTrait.Brawny;
                monster.trait2 = MonsterTrait.Bully;
                monster.type1 = MonsterType.Neutral;
                monster.type2 = MonsterType.Melee;
                monster.baseHP = 72;
                monster.baseSTA = 62;
                monster.baseSPD = 75;
                monster.baseATK = 70;
                monster.baseDEF = 70;
                monster.baseSpATK = 45;
                monster.baseSpDEF = 60;
                //Learnset
                monster.canLearn.Add(MoveName.TailStrike);
                monster.canLearn.Add(MoveName.Scratch);
                monster.canLearn.Add(MoveName.SandSplatter);
                monster.canLearn.Add(MoveName.HeldAnger);
                monster.canLearn.Add(MoveName.FierceClaw);
                monster.canLearn.Add(MoveName.HaitoUchi);
                monster.canLearn.Add(MoveName.InnerSpirit);
                monster.canLearn.Add(MoveName.NinjaJutsu);
                monster.canLearn.Add(MoveName.StoneWall);
                monster.canLearn.Add(MoveName.WakeUp);
                monster.canLearn.Add(MoveName.Misogi);
                monster.canLearn.Add(MoveName.Cage);
                monster.canLearn.Add(MoveName.PerfectJab);
                monster.canLearn.Add(MoveName.OshiDashi);
                break;
            case MonsterName.Smazee:
                monster.trait1 = MonsterTrait.FeverRush;
                monster.trait2 = MonsterTrait.Friendship;
                monster.type1 = MonsterType.Melee;
                monster.type2 = MonsterType.None;
                monster.baseHP = 49;
                monster.baseSTA = 55;
                monster.baseSPD = 66;
                monster.baseATK = 59;
                monster.baseDEF = 44;
                monster.baseSpATK = 37;
                monster.baseSpDEF = 37;
                //Learnset
                monster.canLearn.Add(MoveName.Kick);
                monster.canLearn.Add(MoveName.MartialStrike);
                monster.canLearn.Add(MoveName.TailStrike);
                monster.canLearn.Add(MoveName.SandSplatter);
                monster.canLearn.Add(MoveName.ShowOff);
                monster.canLearn.Add(MoveName.Uppercut);
                monster.canLearn.Add(MoveName.Intimidation);
                monster.canLearn.Add(MoveName.PerfectJab);
                monster.canLearn.Add(MoveName.HeatUp);
                monster.canLearn.Add(MoveName.StoneWall);
                monster.canLearn.Add(MoveName.Misogi);
                monster.canLearn.Add(MoveName.EarthWave);
                break;
            case MonsterName.Spriole:
                monster.trait1 = MonsterTrait.Camaraderie;
                monster.trait2 = MonsterTrait.Botanist;
                monster.type1 = MonsterType.Nature;
                monster.type2 = MonsterType.None;
                monster.baseHP = 72;
                monster.baseSTA = 38;
                monster.baseSPD = 65;
                monster.baseATK = 42;
                monster.baseDEF = 70;
                monster.baseSpATK = 37;
                monster.baseSpDEF = 31;
                //Learnset
                monster.canLearn.Add(MoveName.ShyShield);
                monster.canLearn.Add(MoveName.Nibble);
                monster.canLearn.Add(MoveName.Roots);
                monster.canLearn.Add(MoveName.SharpLeaf);
                monster.canLearn.Add(MoveName.AllergicSpread);
                monster.canLearn.Add(MoveName.Rampage);
                monster.canLearn.Add(MoveName.Revitalize);
                monster.canLearn.Add(MoveName.Spores);
                monster.canLearn.Add(MoveName.FrondWhip);
                break;
            case MonsterName.Swali:
                monster.trait1 = MonsterTrait.SharedPain;
                monster.trait2 = MonsterTrait.Mithridatism;
                monster.type1 = MonsterType.Nature;
                monster.type2 = MonsterType.None;
                monster.baseHP = 44;
                monster.baseSTA = 65;
                monster.baseSPD = 35;
                monster.baseATK = 50;
                monster.baseDEF = 40;
                monster.baseSpATK = 55;
                monster.baseSpDEF = 60;
                //Learnset
                monster.canLearn.Add(MoveName.ShyShield);
                monster.canLearn.Add(MoveName.Tenderness);
                monster.canLearn.Add(MoveName.Urushiol);
                monster.canLearn.Add(MoveName.ToxicSpores);
                monster.canLearn.Add(MoveName.Nimble);
                monster.canLearn.Add(MoveName.Photosynthesis);
                monster.canLearn.Add(MoveName.BarkShield);
                monster.canLearn.Add(MoveName.AllergicSpread);
                monster.canLearn.Add(MoveName.TurboChoreography);
                monster.canLearn.Add(MoveName.WakeUp);
                monster.canLearn.Add(MoveName.Misogi);
                monster.canLearn.Add(MoveName.Spores);
                monster.canLearn.Add(MoveName.Hypoxia);
                break;
            case MonsterName.Taifu:
                monster.trait1 = MonsterTrait.ToxicFarewell;
                monster.trait2 = MonsterTrait.Resilient;
                monster.type1 = MonsterType.Nature;
                monster.type2 = MonsterType.None;
                monster.baseHP = 60;
                monster.baseSTA = 87;
                monster.baseSPD = 45;
                monster.baseATK = 50;
                monster.baseDEF = 45;
                monster.baseSpATK = 85;
                monster.baseSpDEF = 89;
                //Learnset
                monster.canLearn.Add(MoveName.Scratch);
                monster.canLearn.Add(MoveName.SandSplatter);
                monster.canLearn.Add(MoveName.SharpLeaf);
                monster.canLearn.Add(MoveName.CheerUp);
                monster.canLearn.Add(MoveName.AllergicSpread);
                monster.canLearn.Add(MoveName.Gaia);
                monster.canLearn.Add(MoveName.BarkShield);
                monster.canLearn.Add(MoveName.DustVortex);
                monster.canLearn.Add(MoveName.FrondWhip);
                monster.canLearn.Add(MoveName.WakeUp);
                monster.canLearn.Add(MoveName.Misogi);
                monster.canLearn.Add(MoveName.Antitoxins);
                monster.canLearn.Add(MoveName.Cage);
                monster.canLearn.Add(MoveName.Relax);
                monster.canLearn.Add(MoveName.MajorSlash);
                monster.canLearn.Add(MoveName.Spores);
                monster.canLearn.Add(MoveName.Lullaby);
                monster.canLearn.Add(MoveName.WaterCuttingLily);
                monster.canLearn.Add(MoveName.Sacrifice);
                monster.canLearn.Add(MoveName.Hypoxia);
                break;
            case MonsterName.Tateru:
                monster.trait1 = MonsterTrait.SoftTouch;
                monster.trait2 = MonsterTrait.Resilient;
                monster.type1 = MonsterType.Neutral;
                monster.type2 = MonsterType.None;
                monster.baseHP = 79;
                monster.baseSTA = 84;
                monster.baseSPD = 60;
                monster.baseATK = 78;
                monster.baseDEF = 66;
                monster.baseSpATK = 54;
                monster.baseSpDEF = 66;
                //Learnset
                monster.canLearn.Add(MoveName.Tenderness);
                monster.canLearn.Add(MoveName.Scratch);
                monster.canLearn.Add(MoveName.Nibble);
                monster.canLearn.Add(MoveName.HeavyBlow);
                monster.canLearn.Add(MoveName.SandSplatter);
                monster.canLearn.Add(MoveName.Rage);
                monster.canLearn.Add(MoveName.FierceClaw);
                monster.canLearn.Add(MoveName.Lullaby);
                monster.canLearn.Add(MoveName.StoneBall);
                monster.canLearn.Add(MoveName.TurboChoreography);
                monster.canLearn.Add(MoveName.WakeUp);
                monster.canLearn.Add(MoveName.NoxiousBomb);
                monster.canLearn.Add(MoveName.Confiscate);
                monster.canLearn.Add(MoveName.Cage);
                monster.canLearn.Add(MoveName.Rend);
                monster.canLearn.Add(MoveName.HeldAnger);
                monster.canLearn.Add(MoveName.MajorSlash);
                monster.canLearn.Add(MoveName.InnerSpirit);
                monster.canLearn.Add(MoveName.HeldAnger);
                monster.canLearn.Add(MoveName.PerfectJab);
                break;
            case MonsterName.Tental:
                monster.trait1 = MonsterTrait.WaterAFfinity;
                monster.trait2 = MonsterTrait.Avenger;
                monster.type1 = MonsterType.Mental;
                monster.type2 = MonsterType.None;
                monster.baseHP = 41;
                monster.baseSTA = 51;
                monster.baseSPD = 76;
                monster.baseATK = 42;
                monster.baseDEF = 50;
                monster.baseSpATK = 81;
                monster.baseSpDEF = 62;
                //Learnset
                monster.canLearn.Add(MoveName.Hypnosis);
                monster.canLearn.Add(MoveName.PsyWave);
                monster.canLearn.Add(MoveName.Kick);
                monster.canLearn.Add(MoveName.Tenderness);
                monster.canLearn.Add(MoveName.EnergyManipulation);
                monster.canLearn.Add(MoveName.TelekineticShrapnel);
                monster.canLearn.Add(MoveName.BetaBurst);
                monster.canLearn.Add(MoveName.PsySurge);
                monster.canLearn.Add(MoveName.HumiliatingSlap);
                monster.canLearn.Add(MoveName.HighPressureWater);
                monster.canLearn.Add(MoveName.Lullaby);
                monster.canLearn.Add(MoveName.NinjaJutsu);
                monster.canLearn.Add(MoveName.AwfulSong);
                monster.canLearn.Add(MoveName.Confiscate);
                monster.canLearn.Add(MoveName.Block);
                monster.canLearn.Add(MoveName.MadnessBuff);
                break;
            case MonsterName.Toxolotl:
                monster.trait1 = MonsterTrait.PowerNap;
                monster.trait2 = MonsterTrait.ToxicFarewell;
                monster.type1 = MonsterType.Toxic;
                monster.type2 = MonsterType.None;
                monster.baseHP = 59;
                monster.baseSTA = 40;
                monster.baseSPD = 47;
                monster.baseATK = 50;
                monster.baseDEF = 64;
                monster.baseSpATK = 65;
                monster.baseSpDEF = 37;
                //Learnset
                monster.canLearn.Add(MoveName.Scratch);
                monster.canLearn.Add(MoveName.Hypnosis);
                monster.canLearn.Add(MoveName.Stare);
                monster.canLearn.Add(MoveName.VenomousClaws);
                monster.canLearn.Add(MoveName.ToxicInk);
                monster.canLearn.Add(MoveName.TentacleWhip);
                monster.canLearn.Add(MoveName.HarmfulLick);
                monster.canLearn.Add(MoveName.TurboChoreography);
                monster.canLearn.Add(MoveName.NoxiousBomb);
                monster.canLearn.Add(MoveName.MadnessBuff);
                monster.canLearn.Add(MoveName.NarcolepticHit);
                break;
            case MonsterName.Tuvine:
                monster.trait1 = MonsterTrait.Receptive;
                monster.trait2 = MonsterTrait.Determined;
                monster.type1 = MonsterType.Crystal;
                monster.type2 = MonsterType.Wind;
                monster.baseHP = 57;
                monster.baseSTA = 47;
                monster.baseSPD = 65;
                monster.baseATK = 65;
                monster.baseDEF = 111;
                monster.baseSpATK = 56;
                monster.baseSpDEF = 47;
                //Learnset
                monster.canLearn.Add(MoveName.Peck);
                monster.canLearn.Add(MoveName.WindBlade);
                monster.canLearn.Add(MoveName.ShrillVoice);
                monster.canLearn.Add(MoveName.FeatherGatling);
                monster.canLearn.Add(MoveName.WindBurst);
                monster.canLearn.Add(MoveName.MultiplePecks);
                monster.canLearn.Add(MoveName.HumiliatingSlap);
                monster.canLearn.Add(MoveName.Tornado);
                monster.canLearn.Add(MoveName.CrystalPumeGatling);
                monster.canLearn.Add(MoveName.DiamondFort);
                monster.canLearn.Add(MoveName.NoxiousBomb);
                break;
            case MonsterName.Tuwai:
                monster.trait1 = MonsterTrait.Spoilsport;
                monster.trait2 = MonsterTrait.Resilient;
                monster.type1 = MonsterType.Wind;
                monster.type2 = MonsterType.None;
                monster.baseHP = 54;
                monster.baseSTA = 47;
                monster.baseSPD = 58;
                monster.baseATK = 62;
                monster.baseDEF = 45;
                monster.baseSpATK = 60;
                monster.baseSpDEF = 47;
                //Learnset
                monster.canLearn.Add(MoveName.Peck);
                monster.canLearn.Add(MoveName.WindBlade);
                monster.canLearn.Add(MoveName.ShrillVoice);
                monster.canLearn.Add(MoveName.FeatherGatling);
                monster.canLearn.Add(MoveName.WindBurst);
                monster.canLearn.Add(MoveName.MultiplePecks);
                monster.canLearn.Add(MoveName.HumiliatingSlap);
                monster.canLearn.Add(MoveName.Tornado);
                monster.canLearn.Add(MoveName.NoxiousBomb);
                break;
            case MonsterName.Ukama:
                monster.trait1 = MonsterTrait.Hydrologist;
                monster.trait2 = MonsterTrait.Plethoric;
                monster.type1 = MonsterType.Water;
                monster.type2 = MonsterType.None;
                monster.baseHP = 68;
                monster.baseSTA = 90;
                monster.baseSPD = 100;
                monster.baseATK = 34;
                monster.baseDEF = 51;
                monster.baseSpATK = 76;
                monster.baseSpDEF = 54;
                //Learnset
                monster.canLearn.Add(MoveName.Finbeat);
                monster.canLearn.Add(MoveName.WaterBlade);
                monster.canLearn.Add(MoveName.Nimble);
                monster.canLearn.Add(MoveName.Cooperation);
                monster.canLearn.Add(MoveName.WaterCannon);
                monster.canLearn.Add(MoveName.SharpRain);
                monster.canLearn.Add(MoveName.AquaBulletHell);
                monster.canLearn.Add(MoveName.AquaticWhirlwind);
                monster.canLearn.Add(MoveName.Blizzard);
                monster.canLearn.Add(MoveName.Tsunami);
                monster.canLearn.Add(MoveName.TurboChoreography);
                monster.canLearn.Add(MoveName.MajorSlash);
                monster.canLearn.Add(MoveName.Flood);
                break;
            case MonsterName.Umishi:
                monster.trait1 = MonsterTrait.SharedPain;
                monster.trait2 = MonsterTrait.Caffeinated;
                monster.type1 = MonsterType.Water;
                monster.type2 = MonsterType.None;
                monster.baseHP = 51;
                monster.baseSTA = 76;
                monster.baseSPD = 80;
                monster.baseATK = 21;
                monster.baseDEF = 34;
                monster.baseSpATK = 63;
                monster.baseSpDEF = 45;
                //Learnset
                monster.canLearn.Add(MoveName.Finbeat);
                monster.canLearn.Add(MoveName.WaterBlade);
                monster.canLearn.Add(MoveName.Nimble);
                monster.canLearn.Add(MoveName.Cooperation);
                monster.canLearn.Add(MoveName.WaterCannon);
                monster.canLearn.Add(MoveName.SharpRain);
                monster.canLearn.Add(MoveName.AquaBulletHell);
                monster.canLearn.Add(MoveName.AquaticWhirlwind);
                monster.canLearn.Add(MoveName.Tsunami);
                monster.canLearn.Add(MoveName.TurboChoreography);
                monster.canLearn.Add(MoveName.Flood);
                break;
            case MonsterName.Valash:
                monster.trait1 = MonsterTrait.Scavenger;
                monster.trait2 = MonsterTrait.Determined;
                monster.type1 = MonsterType.Neutral;
                monster.type2 = MonsterType.Crystal;
                monster.baseHP = 58;
                monster.baseSTA = 57;
                monster.baseSPD = 90;
                monster.baseATK = 74;
                monster.baseDEF = 56;
                monster.baseSpATK = 74;
                monster.baseSpDEF = 56;
                //Learnset
                monster.canLearn.Add(MoveName.Scratch);
                monster.canLearn.Add(MoveName.GlassBlade);
                monster.canLearn.Add(MoveName.CrystalDust);
                monster.canLearn.Add(MoveName.SharpStabs);
                monster.canLearn.Add(MoveName.CrystalBite);
                monster.canLearn.Add(MoveName.CrystalSpikes);
                monster.canLearn.Add(MoveName.Rend);
                monster.canLearn.Add(MoveName.HeldAnger);
                monster.canLearn.Add(MoveName.StoneWall);
                monster.canLearn.Add(MoveName.Block);
                monster.canLearn.Add(MoveName.MadnessBuff);
                monster.canLearn.Add(MoveName.Footwork);
                monster.canLearn.Add(MoveName.MajorSlash);
                monster.canLearn.Add(MoveName.Clinch);
                monster.canLearn.Add(MoveName.NinjaJutsu);
                break;
            case MonsterName.Volarend:
                monster.trait1 = MonsterTrait.Aerobic;
                monster.trait2 = MonsterTrait.Anaerobic;
                monster.type1 = MonsterType.Toxic;
                monster.type2 = MonsterType.Wind;
                monster.baseHP = 64;
                monster.baseSTA = 38;
                monster.baseSPD = 74;
                monster.baseATK = 51;
                monster.baseDEF = 61;
                monster.baseSpATK = 68;
                monster.baseSpDEF = 96;
                //Learnset
                monster.canLearn.Add(MoveName.Scratch);
                monster.canLearn.Add(MoveName.WindBlade);
                monster.canLearn.Add(MoveName.VenomousClaws);
                monster.canLearn.Add(MoveName.MultiplePecks);
                monster.canLearn.Add(MoveName.Blizzard);
                monster.canLearn.Add(MoveName.ToxicPlume);
                monster.canLearn.Add(MoveName.Tornado);
                monster.canLearn.Add(MoveName.HyperkineticStrike);
                monster.canLearn.Add(MoveName.NoxiousBomb);
                monster.canLearn.Add(MoveName.Rend);
                monster.canLearn.Add(MoveName.FeatherGatling);
                break;
            case MonsterName.Vulcrane:
                monster.evolvesFrom = MonsterName.Vulvir;
                monster.trait1 = MonsterTrait.Receptive;
                monster.trait2 = MonsterTrait.Vigorous;
                monster.type1 = MonsterType.Fire;
                monster.type2 = MonsterType.Earth;
                monster.baseHP = 76;
                monster.baseSTA = 65;
                monster.baseSPD = 73;
                monster.baseATK = 74;
                monster.baseDEF = 86;
                monster.baseSpATK = 64;
                monster.baseSpDEF = 35;
                //Learnset
                monster.canLearn.Add(MoveName.Scratch);
                monster.canLearn.Add(MoveName.Stare);
                monster.canLearn.Add(MoveName.SandSplatter);
                monster.canLearn.Add(MoveName.FireFlame);
                monster.canLearn.Add(MoveName.HeadRam);
                monster.canLearn.Add(MoveName.Embers);
                monster.canLearn.Add(MoveName.DoubleKick);
                monster.canLearn.Add(MoveName.StoneBall);
                monster.canLearn.Add(MoveName.NinjaJutsu);
                monster.canLearn.Add(MoveName.WakeUp);
                monster.canLearn.Add(MoveName.MagmaCannon);
                monster.canLearn.Add(MoveName.Rend);
                monster.canLearn.Add(MoveName.MajorSlash);
                monster.canLearn.Add(MoveName.EarthWave);
                monster.canLearn.Add(MoveName.Extinction);
                break;
            case MonsterName.Vulor:
                monster.evolvesFrom = MonsterName.Vulvir;
                monster.trait1 = MonsterTrait.Pyromaniac;
                monster.trait2 = MonsterTrait.Individualist;
                monster.type1 = MonsterType.Fire;
                monster.type2 = MonsterType.Earth;
                monster.baseHP = 65;
                monster.baseSTA = 59;
                monster.baseSPD = 63;
                monster.baseATK = 49;
                monster.baseDEF = 71;
                monster.baseSpATK = 49;
                monster.baseSpDEF = 32;
                //Learnset
                monster.canLearn.Add(MoveName.Scratch);
                monster.canLearn.Add(MoveName.Stare);
                monster.canLearn.Add(MoveName.SandSplatter);
                monster.canLearn.Add(MoveName.FireFlame);
                monster.canLearn.Add(MoveName.HeadRam);
                monster.canLearn.Add(MoveName.Embers);
                monster.canLearn.Add(MoveName.DoubleKick);
                monster.canLearn.Add(MoveName.StoneBall);
                monster.canLearn.Add(MoveName.WakeUp);
                monster.canLearn.Add(MoveName.MagmaCannon);
                monster.canLearn.Add(MoveName.EarthWave);
                monster.canLearn.Add(MoveName.Extinction);
                break;
            case MonsterName.Vulvir:
                monster.trait1 = MonsterTrait.Camaraderie;
                monster.trait2 = MonsterTrait.Caffeinated;
                monster.type1 = MonsterType.Fire;
                monster.type2 = MonsterType.Earth;
                monster.baseHP = 59;
                monster.baseSTA = 54;
                monster.baseSPD = 57;
                monster.baseATK = 47;
                monster.baseDEF = 64;
                monster.baseSpATK = 47;
                monster.baseSpDEF = 31;
                //Learnset
                monster.canLearn.Add(MoveName.Scratch);
                monster.canLearn.Add(MoveName.Stare);
                monster.canLearn.Add(MoveName.SandSplatter);
                monster.canLearn.Add(MoveName.FireFlame);
                monster.canLearn.Add(MoveName.HeadRam);
                monster.canLearn.Add(MoveName.Embers);
                monster.canLearn.Add(MoveName.WakeUp);
                monster.canLearn.Add(MoveName.MagmaCannon);
                monster.canLearn.Add(MoveName.EarthWave);
                monster.canLearn.Add(MoveName.Extinction);
                break;
            case MonsterName.Wiplump:
                monster.trait1 = MonsterTrait.Plethoric;
                monster.trait2 = MonsterTrait.Patient;
                monster.type1 = MonsterType.Water;
                monster.type2 = MonsterType.Wind;
                monster.baseHP = 66;
                monster.baseSTA = 80;
                monster.baseSPD = 70;
                monster.baseATK = 40;
                monster.baseDEF = 50;
                monster.baseSpATK = 95;
                monster.baseSpDEF = 80;
                //Learnset
                monster.canLearn.Add(MoveName.Bubbles);
                monster.canLearn.Add(MoveName.HeadCharge);
                monster.canLearn.Add(MoveName.Tenderness);
                monster.canLearn.Add(MoveName.IceCubes);
                monster.canLearn.Add(MoveName.Blizzard);
                monster.canLearn.Add(MoveName.ColdBreeze);
                monster.canLearn.Add(MoveName.DrillImpact);
                monster.canLearn.Add(MoveName.Tornado);
                monster.canLearn.Add(MoveName.Tsunami);
                monster.canLearn.Add(MoveName.NoxiousBomb);
                monster.canLearn.Add(MoveName.AwfulSong);
                monster.canLearn.Add(MoveName.IceShuriken);
                monster.canLearn.Add(MoveName.Lullaby);
                monster.canLearn.Add(MoveName.SharpRain);
                break;
            case MonsterName.Zenoreth:
                monster.trait1 = MonsterTrait.Channeler;
                monster.trait2 = MonsterTrait.WreckedFarewell;
                monster.type1 = MonsterType.Crystal;
                monster.type2 = MonsterType.None;
                monster.baseHP = 71;
                monster.baseSTA = 35;
                monster.baseSPD = 56;
                monster.baseATK = 67;
                monster.baseDEF = 87;
                monster.baseSpATK = 65;
                monster.baseSpDEF = 69;
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
            case MonsterName.Zephyruff:
                monster.trait1 = MonsterTrait.ToxicAffinity;
                monster.trait2 = MonsterTrait.AirSpecialist;
                monster.type1 = MonsterType.Toxic;
                monster.type2 = MonsterType.Wind;
                monster.baseHP = 58;
                monster.baseSTA = 34;
                monster.baseSPD = 68;
                monster.baseATK = 43;
                monster.baseDEF = 47;
                monster.baseSpATK = 50;
                monster.baseSpDEF = 51;
                //Learnset
                monster.canLearn.Add(MoveName.Scratch);
                monster.canLearn.Add(MoveName.WindBlade);
                monster.canLearn.Add(MoveName.VenomousClaws);
                monster.canLearn.Add(MoveName.MultiplePecks);
                monster.canLearn.Add(MoveName.Blizzard);
                monster.canLearn.Add(MoveName.ToxicPlume);
                monster.canLearn.Add(MoveName.Tornado);
                monster.canLearn.Add(MoveName.FeatherGatling);
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
