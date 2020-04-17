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

    public enum BuffApply
    {
        None,
        addAtk,
        addDef,
        addSpatk,
        addSpdef,
        addSpeed,
        lowAtk,
        lowDef,
        lowSpatk,
        lowSpdef,
        lowSpeed
    }

    public enum MoveCondition
    {
        None,
        Status,
        Damage,
        Special,
        Physical
    }

    public enum StatusApply
    {
        //-1 means status is negative, 1 is positive for trait check purposes later.
        None,
        Alerted = 1,
        Asleep = -1,
        Burn = -1,
        Cold = -1,
        Doom = 0,
        Evading = 1,
        Exhausted = -1,
        Immune = 0,
        Neutralize = -1,
        Poison = -1,
        Regenerate = 1,
        Seized = -1,
        Trapped = -1,
        Vigorized = 1
    }

    //remake valid targets system
    public enum ValidTargets
    {
        None,
        Self,
        notSelf,
        singleAny,
        singleEnemies,
        Ally,
        Enemy1,
        Enemy2,
        aoeEnemies,
        aoeAllies,
        aoeAny,
        //this last one means it automatically hits everyone on the field
        aoeAll
    }

    public enum MoveName
    {
        TestMove,
        None,
        Rest,
        AllergicSpread,
        Antitoxins,
        AquaStone,
        AquaticWhirlwind,
        AwfulSong,
        Bamboozle,
        BarkShield,
        BetaBurst,
        Blizzard,
        Block,
        Boomerang,
        Bubbles,
        Cage,
        ChainLightning,
        ChainsHit,
        CheerUp,
        Clinch,
        ColdBreeze,
        Confiscate,
        Cooperation,
        CrystalBite,
        CrystalDust,
        CrystalPumeGatling,
        CrystalSpikes,
        Crystallize,
        DataBurst,
        DCBeam,
        DiamondFort,
        DoubleKick,
        DrillImpact,
        DustVortex,
        EarthWave,
        ElectricStorm,
        Embers,
        EnergyManipulation,
        Extinction,
        FeatherGatling,
        FierceClaw,
        Finbeat,
        FireFlame,
        FireTornado,
        Firewall,
        Flood,
        Footwork,
        FrondWhip,
        Gaia,
        GammaBurst,
        GlassBlade,
        HaitoUchi,
        Hallucination,
        HarmfulLick,
        HeadCharge,
        HeadRam,
        HeatUp,
        HeavyBlow,
        HeldAnger,
        HighPressureWater,
        HumiliatingSlap,
        HyperkineticStrike,
        Hypnosis,
        Hypoxia,
        IceCubes,
        IceShuriken,
        IcedStalactite,
        InnerSpirit,
        Intimidation,
        JawStrike,
        Kick,
        KingsRoar,
        LifefulSap,
        Lullaby,
        MadnessBuff,
        MagmaCannon,
        MajorSlash,
        MartialStrike,
        MechanicalHeat,
        Meditation,
        MeteorSwarm,
        MirrorShell,
        Misogi,
        MudShower,
        MultiplePecks,
        NarcolepticHit,
        Nibble,
        NichoSai,
        Nimble,
        NinjaJutsu,
        NovicePunch,
        NoxiousBomb,
        OshiDashi,
        Overclock,
        ParalysingPoison,
        Peck,
        PerfectJab,
        Photosynthesis,
        Pollution,
        PsySurge,
        PsyWave,
        PsychicCollaborator,
        Psychosis,
        Rage,
        Rampage,
        Regenerate,
        Relax,
        Rend,
        Revitalize,
        Roar,
        Roots,
        Sacrifice,
        SandSplatter,
        Scratch,
        SharpLeaf,
        SharpRain,
        SharpStabs,
        ShowOff,
        ShrillVoice,
        ShyShield,
        Slime,
        SlowDown,
        Sparks,
        Spores,
        Stare,
        StoneBall,
        StoneWall,
        Strangle,
        TailStrike,
        TelekineticShrapnel,
        Tenderness,
        TentacleWhip,
        TeslaPrison,
        Tornado,
        ToxicFang,
        ToxicInk,
        ToxicPlume,
        ToxicSlime,
        ToxicSpores,
        Tsunami,
        TurboAttack,
        TurboCharge,
        TurboChoreography,
        Uppercut,
        Urushiol,
        VenomousClaws,
        WakeUp,
        WarmCuddle,
        WaterBlade,
        WaterCannon,
        WaterCuttingLily,
        WindBlade,
        WindBurst
    }
}

[System.Serializable]
public struct Move
{
    [HideInInspector]
    public string name;
    [DisplayWithoutEdit()]
    public MoveName moveName;
    [DisplayWithoutEdit()]
    public int moveBP;
    [DisplayWithoutEdit()]
    public int stamCost;
    [DisplayWithoutEdit()]
    public int holdTime;
    [DisplayWithoutEdit()]
    public int priority;
    [DisplayWithoutEdit()]
    public MoveElement element;
    [DisplayWithoutEdit()]
    public MoveElement synergyWith;
    [DisplayWithoutEdit()]
    public MoveCondition moveCondition;
    [DisplayWithoutEdit()]
    public StatusApply status1Apply; 
    [DisplayWithoutEdit()]
    public StatusApply status2Apply;
    [DisplayWithoutEdit()]
    public BuffApply buff1Apply;
    [DisplayWithoutEdit()]
    public BuffApply buff2Apply;
    //targeting system will need to be planned better later 
    [DisplayWithoutEdit()]
    public ValidTargets validTargets;
    [DisplayWithoutEdit()]
    public ValidTargets status1Target;
    [DisplayWithoutEdit()]
    public ValidTargets status2Target;
    [DisplayWithoutEdit()]
    public ValidTargets buff1Target;
    [DisplayWithoutEdit()]
    public ValidTargets buff2Target;

    ///Status Duration to be checked elsewhere/later.

    //constructor
    public Move(MoveName moveName,
                string name = "",
                int moveBP = 0,
                int stamCost = 0,
                int holdTime = 0,
                int priority = 2,
                MoveElement element = MoveElement.None,
                MoveCondition condition = MoveCondition.None,
                MoveElement synergyWith = MoveElement.None,
                StatusApply status1Apply = StatusApply.None,
                StatusApply status2Apply = StatusApply.None,
                BuffApply buff1Apply = BuffApply.None,
                BuffApply buff2Apply = BuffApply.None,
                ValidTargets validTargets = ValidTargets.singleAny,
                ValidTargets status1Target = ValidTargets.None,
                ValidTargets status2Target = ValidTargets.None,
                ValidTargets buff1Target = ValidTargets.None,
                ValidTargets buff2Target = ValidTargets.None)
    {
        this.moveName = moveName;
        this.moveBP = moveBP;
        this.stamCost = stamCost;
        this.holdTime = holdTime;
        this.priority = priority;
        this.element = element;
        this.moveCondition = condition;
        this.synergyWith = synergyWith;
        this.status1Apply = status1Apply;
        this.status2Apply = status2Apply;
        this.buff1Apply = buff1Apply;
        this.buff2Apply = buff2Apply;
        this.status1Target = status1Target;
        this.status2Target = status2Target;
        this.buff1Target = buff1Target;
        this.buff2Target = buff2Target;
        this.validTargets = validTargets;

        this.name = moveName.ToString();
    }
}



//TriA should be checked on execution of calculations for special moves, individual of the move itself. The status will be applied at the very end of attack execution.
//You do not need to add property entries for some moves due to default. If something has 2 priority, 0 hold, 0 base damage, etc, you can leave it blank.
//Use "None" move to copy/paste and edit from if you're confused.
//We will possibly have to revisit buffs here.
public class MoveDictionary : MonoBehaviour
{
    [DisplayWithoutEdit()]
    public bool listLoaded = false;

    public List<Move> moveList;

    public void Start()
    {
        //populate the list
        foreach(MoveName n in Enum.GetValues(typeof(MoveName)))
        {
            Move m = new Move(n);
            SetMoveValues(ref m);
            moveList.Add(m);
        }
        //example of grabbing a move by enum name to access a value
        //output of moveList[(int)MoveName.TurboCharge].name
        listLoaded = true;
    }

    public void SetMoveValues(ref Move move)
    {
        switch (move.moveName)
        {
            case MoveName.TestMove:
                //This fake move applies sleep status to self, buffs the ally's atk, and lowers both enemy defenses.
                move.element = MoveElement.Toxic;
                move.moveCondition = MoveCondition.Status;
                move.status1Apply = StatusApply.Asleep;
                move.status1Target = ValidTargets.Self;
                move.buff1Apply = BuffApply.addAtk;
                move.buff1Target = ValidTargets.Ally;
                move.buff2Apply = BuffApply.lowDef;
                move.buff2Target = ValidTargets.aoeEnemies;
                move.validTargets = ValidTargets.aoeEnemies;
                break;
            case MoveName.None:
                move.moveBP = 0;
                move.stamCost = 0;
                move.priority = 0;
                move.holdTime = 0;
                move.element = MoveElement.None;
                move.moveCondition = MoveCondition.None;
                move.status1Apply = StatusApply.None;
                move.status1Target = ValidTargets.None;
                move.buff1Apply = BuffApply.None;
                move.buff1Target = ValidTargets.None;
                move.synergyWith = MoveElement.None;
                move.validTargets = ValidTargets.None;
                break;
            case MoveName.Rest:
                break;
            case MoveName.AllergicSpread:
                move.moveBP = 58;
                move.stamCost = 18;
                move.holdTime = 1;
                move.element = MoveElement.Nature;
                move.moveCondition = MoveCondition.Special;
                move.validTargets = ValidTargets.aoeAny;
                break;
            case MoveName.Antitoxins:
                move.stamCost = 26;
                move.holdTime = 2;
                move.element = MoveElement.Nature;
                move.moveCondition = MoveCondition.Status;
                break;
            case MoveName.AquaStone:
                move.moveBP = 80;
                move.stamCost = 21;
                move.holdTime = 1;
                move.element = MoveElement.Water;
                move.moveCondition = MoveCondition.Physical;
                move.status1Apply = StatusApply.None;
                move.synergyWith = MoveElement.Earth;
                break;
            case MoveName.AquaticWhirlwind:
                move.moveBP = 130;
                move.stamCost = 29;
                move.priority = 3;
                move.holdTime = 1;
                move.element = MoveElement.Water;
                move.moveCondition = MoveCondition.Special;
                break;
            case MoveName.AwfulSong:
                move.moveBP = 96;
                move.stamCost = 20;
                move.priority = 2;
                move.holdTime = 1;
                move.element = MoveElement.Neutral;
                move.moveCondition = MoveCondition.Special;
                move.synergyWith = MoveElement.Neutral;
                break;
            case MoveName.Bamboozle:
                move.stamCost = 18;
                move.element = MoveElement.Mental;
                move.moveCondition = MoveCondition.Status;
                move.status1Apply = StatusApply.Evading;
                break;
            case MoveName.BarkShield:
                move.stamCost = 30;
                move.priority = 1;
                move.holdTime = 2;
                move.element = MoveElement.Nature;
                move.moveCondition = MoveCondition.Status;
                move.validTargets = ValidTargets.aoeAny;
                break;
            case MoveName.BetaBurst:
                move.moveBP = 100;
                move.stamCost = 23;
                move.element = MoveElement.Mental;
                move.moveCondition = MoveCondition.Special;
                break;
            case MoveName.Blizzard:
                move.moveBP = 120;
                move.stamCost = 15;
                move.priority = 1;
                move.holdTime = 1;
                move.element = MoveElement.Wind;
                move.moveCondition = MoveCondition.Special;
                break;
            case MoveName.Block:
                move.stamCost = 16;
                move.holdTime = 1;
                move.element = MoveElement.Melee;
                move.moveCondition = MoveCondition.Status;
                move.validTargets = ValidTargets.Self;
                break;
            case MoveName.Boomerang:
                move.moveBP = 85;
                move.stamCost = 14;
                move.priority = 3;
                move.holdTime = 1;
                move.element = MoveElement.Wind;
                move.moveCondition = MoveCondition.Physical;
                break;
            case MoveName.Bubbles:
                move.moveBP = 27;
                move.stamCost = 5;
                move.element = MoveElement.Water;
                move.moveCondition = MoveCondition.Special;
                move.validTargets = ValidTargets.singleAny;
                break;
            case MoveName.Cage:
                move.stamCost = 23;
                //Ultra priority
                move.priority = 10;
                move.holdTime = 1;
                move.element = MoveElement.Neutral;
                move.moveCondition = MoveCondition.Status;
                move.status1Apply = StatusApply.Trapped;
                move.status1Target = ValidTargets.aoeAll;
                move.validTargets = ValidTargets.aoeAll;
                break;
            case MoveName.ChainLightning:
                //UNUSUAL EFFECT
                move.moveBP = 48;
                move.stamCost = 15;
                move.element = MoveElement.Electric;
                move.moveCondition = MoveCondition.Special;
                break;
            case MoveName.ChainsHit:
                move.moveBP = 110;
                move.stamCost = 16;
                move.element = MoveElement.Neutral;
                move.moveCondition = MoveCondition.Physical;
                break;
            case MoveName.CheerUp:
                move.stamCost = 7;
                move.priority = 4;
                move.element = MoveElement.Neutral;
                move.moveCondition = MoveCondition.Status;
                break;
            case MoveName.Clinch:
                move.moveBP = 85;
                move.stamCost = 14;
                move.priority = 1;
                move.element = MoveElement.Neutral;
                move.moveCondition = MoveCondition.Physical;
                break;
            case MoveName.ColdBreeze:
                move.moveBP = 10;
                move.stamCost = 9;
                move.element = MoveElement.Wind;
                move.moveCondition = MoveCondition.Special;
                move.status1Apply = StatusApply.Cold;
                move.status1Target = ValidTargets.singleAny;
                break;
            case MoveName.Confiscate:
                move.stamCost = 7;
                move.element = MoveElement.Neutral;
                move.moveCondition = MoveCondition.Status;
                move.status1Apply = StatusApply.Seized;
                move.status1Target = ValidTargets.singleAny;
                //check benefit with resist trait
                break;
            case MoveName.Cooperation:
                //UNUSUAL EFFECT
                move.stamCost = 1;
                move.priority = 4;
                move.element = MoveElement.Neutral;
                move.moveCondition = MoveCondition.Status;
                move.validTargets = ValidTargets.aoeAny;
                break;
            case MoveName.CrystalBite:
                move.moveBP = 130;
                move.stamCost = 22;
                move.holdTime = 1;
                move.element = MoveElement.Crystal;
                move.moveCondition = MoveCondition.Physical;
                break;
            case MoveName.CrystalDust:
                move.moveBP = 60;
                move.stamCost = 11;
                move.priority = 3;
                move.element = MoveElement.Crystal;
                move.moveCondition = MoveCondition.Special;
                move.synergyWith = MoveElement.Wind;
                break;
            case MoveName.Crystallize:
                move.stamCost = 18;
                move.holdTime = 1;
                move.element = MoveElement.Crystal;
                move.moveCondition = MoveCondition.Status;
                move.buff1Apply = BuffApply.addDef;
                move.buff2Apply = BuffApply.lowSpeed;
                move.buff1Target = ValidTargets.Self;
                break;
            case MoveName.CrystalPumeGatling:
                move.moveBP = 130;
                move.stamCost = 24;
                move.element = MoveElement.Crystal;
                move.moveCondition = MoveCondition.Physical;
                break;
            case MoveName.CrystalSpikes:
                move.moveBP = 120;
                move.stamCost = 27;
                move.priority = 3;
                move.element = MoveElement.Crystal;
                move.moveCondition = MoveCondition.Special;
                break;
            case MoveName.DataBurst:
                //not available, update later
                move.moveBP = 48;
                move.stamCost = 6;
                move.element = MoveElement.Digital;
                break;
            case MoveName.DCBeam:
                move.moveBP = 35;
                move.stamCost = 5;
                move.priority = 3;
                move.element = MoveElement.Electric;
                move.moveCondition = MoveCondition.Special;
                break;
            case MoveName.DiamondFort:
                move.stamCost = 26;
                move.priority = 1;
                move.holdTime = 2;
                move.element = MoveElement.Crystal;
                move.moveCondition = MoveCondition.Status;
                move.buff1Apply = BuffApply.addDef;
                move.buff1Target = ValidTargets.Self;
                move.buff2Apply = BuffApply.addSpdef;
                move.buff2Target = ValidTargets.Self;
                move.validTargets = ValidTargets.Self;
                break;
            case MoveName.DoubleKick:
                move.moveBP = 80;
                move.stamCost = 22;
                move.priority = 3;
                move.element = MoveElement.Neutral;
                move.moveCondition = MoveCondition.Physical;
                break;
            case MoveName.DrillImpact:
                move.moveBP = 120;
                move.stamCost = 20;
                move.element = MoveElement.Neutral;
                move.moveCondition = MoveCondition.Physical;
                break;
            case MoveName.DustVortex:
                move.moveBP = 131;
                move.stamCost = 24;
                move.holdTime = 1;
                move.element = MoveElement.Earth;
                move.moveCondition = MoveCondition.Special;
                break;
            case MoveName.EarthWave:
                move.moveBP = 90;
                move.stamCost = 28;
                move.priority = 1;
                move.holdTime = 2;
                move.element = MoveElement.Earth;
                move.moveCondition = MoveCondition.Physical;
                move.validTargets = ValidTargets.aoeAny;
                break;
            case MoveName.ElectricStorm:
                move.moveBP = 76;
                move.stamCost = 26;
                move.holdTime = 1;
                move.element = MoveElement.Electric;
                move.moveCondition = MoveCondition.Special;
                move.validTargets = ValidTargets.aoeAny;
                break;
            case MoveName.Embers:
                move.moveBP = 63;
                move.stamCost = 15;
                move.element = MoveElement.Fire;
                move.moveCondition = MoveCondition.Physical;
                move.status1Apply = StatusApply.Burn;
                move.status1Target = ValidTargets.singleAny;
                break;
            case MoveName.EnergyManipulation:
                move.moveBP = 45;
                move.stamCost = 11;
                move.priority = 3;
                move.element = MoveElement.Mental;
                move.moveCondition = MoveCondition.Special;
                move.status1Apply = StatusApply.Exhausted;
                move.status1Target = ValidTargets.singleAny;
                move.synergyWith = MoveElement.Nature;
                break;
            case MoveName.Extinction:
                move.stamCost = 32;
                move.holdTime = 2;
                move.element = MoveElement.Fire;
                move.moveCondition = MoveCondition.Status;
                move.status1Apply = StatusApply.Doom;
                move.status1Target = ValidTargets.aoeAll;
                move.validTargets = ValidTargets.aoeAll;
                break;
            case MoveName.FeatherGatling:
                move.moveBP = 100;
                move.stamCost = 17;
                move.element = MoveElement.Wind;
                move.moveCondition = MoveCondition.Physical;
                break;
            case MoveName.FierceClaw:
                move.moveBP = 71;
                move.stamCost = 13;
                move.element = MoveElement.Neutral;
                move.moveCondition = MoveCondition.Physical;
                break;
            case MoveName.Finbeat:
                move.moveBP = 32;
                move.stamCost = 4;
                move.priority = 3;
                move.element = MoveElement.Neutral;
                move.moveCondition = MoveCondition.Physical;
                break;
            case MoveName.FireFlame:
                move.moveBP = 45;
                move.stamCost = 7;
                move.element = MoveElement.Fire;
                move.moveCondition = MoveCondition.Special;
                break;
            case MoveName.FireTornado:
                move.moveBP = 145;
                move.stamCost = 22;
                move.holdTime = 2;
                move.element = MoveElement.Fire;
                move.moveCondition = MoveCondition.Special;
                break;
            case MoveName.Firewall:
                //not available, update later
                move.stamCost = 15;
                move.holdTime = 1;
                move.element = MoveElement.Digital;
                move.moveCondition = MoveCondition.Status;
                break;
            case MoveName.Flood:
                move.stamCost = 22;
                move.holdTime = 1;
                move.element = MoveElement.Water;
                move.moveCondition = MoveCondition.Status;
                move.buff1Apply = BuffApply.lowDef;
                move.buff1Target = ValidTargets.aoeEnemies;
                move.synergyWith = MoveElement.Earth;
                move.validTargets = ValidTargets.aoeAny;
                break;
            case MoveName.Footwork:
                move.stamCost = 15;
                move.priority = 3;
                move.holdTime = 1;
                move.element = MoveElement.Melee;
                move.moveCondition = MoveCondition.Status;
                move.buff1Apply = BuffApply.addSpeed;
                move.buff1Target = ValidTargets.Self;
                move.validTargets = ValidTargets.Self;
                break;
            case MoveName.FrondWhip:
                move.moveBP = 146;
                move.stamCost = 28;
                move.priority = 1;
                move.holdTime = 1;
                move.element = MoveElement.Nature;
                move.moveCondition = MoveCondition.Physical;
                break;
            case MoveName.Gaia:
                //UNUSUAL EFFECT
                move.stamCost = 15;
                move.priority = 0;
                move.holdTime = 3;
                move.element = MoveElement.Nature;
                move.moveCondition = MoveCondition.Status;
                move.validTargets = ValidTargets.Self;
                break;
            case MoveName.GammaBurst:
                move.moveBP = 150;
                move.stamCost = 51;
                move.element = MoveElement.Mental;
                move.moveCondition = MoveCondition.Special;
                move.status1Apply = StatusApply.Exhausted;
                move.status1Target = ValidTargets.singleAny;
                break;
            case MoveName.GlassBlade:
                move.moveBP = 32;
                move.stamCost = 5;
                move.element = MoveElement.Crystal;
                move.moveCondition = MoveCondition.Physical;
                break;
            case MoveName.HaitoUchi:
                move.moveBP = 85;
                move.stamCost = 21;
                move.holdTime = 1;
                move.element = MoveElement.Melee;
                move.moveCondition = MoveCondition.Physical;
                move.status1Apply = StatusApply.Asleep;
                move.status1Target = ValidTargets.singleAny;
                break;
            case MoveName.Hallucination:
                //triA
                move.stamCost = 22;
                move.element = MoveElement.Toxic;
                move.moveCondition = MoveCondition.Status;
                move.status1Apply = StatusApply.Trapped;
                move.status1Target = ValidTargets.singleAny;
                move.status2Apply = StatusApply.Exhausted;
                move.status2Target = ValidTargets.singleAny;
                move.synergyWith = MoveElement.Mental;
                break;
            case MoveName.HarmfulLick:
                move.moveBP = 150;
                move.stamCost = 29;
                move.priority = 1;
                move.element = MoveElement.Neutral;
                move.moveCondition = MoveCondition.Physical;
                break;
            case MoveName.HeadCharge:
                move.moveBP = 80;
                move.stamCost = 17;
                move.holdTime = 1;
                move.priority = 1;
                move.element = MoveElement.Melee;
                move.moveCondition = MoveCondition.Physical;
                break;
            case MoveName.HeadRam:
                move.moveBP = 100;
                move.stamCost = 17;
                move.priority = 1;
                move.element = MoveElement.Neutral;
                move.moveCondition = MoveCondition.Physical;
                break;
            case MoveName.HeatUp:
                move.stamCost = 23;
                move.element = MoveElement.Fire;
                move.moveCondition = MoveCondition.Status;
                move.buff1Apply = BuffApply.addAtk;
                move.buff1Target = ValidTargets.Self;
                move.validTargets = ValidTargets.Self;
                break;
            case MoveName.HeavyBlow:
                move.moveBP = 58;
                move.stamCost = 11;
                move.element = MoveElement.Neutral;
                move.moveCondition = MoveCondition.Physical;
                break;
            case MoveName.HeldAnger:
                move.moveBP = 130;
                move.stamCost = 12;
                move.priority = 1;
                move.holdTime = 3;
                move.element = MoveElement.None;
                move.moveCondition = MoveCondition.Physical;
                break;
            case MoveName.HighPressureWater:
                move.moveBP = 50;
                move.stamCost = 15;
                move.holdTime = 1;
                move.element = MoveElement.Water;
                move.moveCondition = MoveCondition.Special;
                move.synergyWith = MoveElement.Fire;
                break;
            case MoveName.HumiliatingSlap:
                move.moveBP = 90;
                move.stamCost = 20;
                move.element = MoveElement.Neutral;
                move.moveCondition = MoveCondition.Physical;
                move.buff1Apply = BuffApply.lowDef;
                move.buff1Target = ValidTargets.singleAny;
                break;
            case MoveName.HyperkineticStrike:
                //UNUSUAL MOVE
                move.moveBP = 59;
                move.stamCost = 28;
                move.priority = 3;
                move.holdTime = 1;
                move.element = MoveElement.Wind;
                move.moveCondition = MoveCondition.Special;
                break;
            case MoveName.Hypnosis:
                move.stamCost = 14;
                move.holdTime = 1;
                move.element = MoveElement.Mental;
                move.moveCondition = MoveCondition.Status;
                move.status1Apply = StatusApply.Asleep;
                move.status1Target = ValidTargets.singleAny;
                break;
            case MoveName.Hypoxia:
                move.moveBP = 120;
                move.stamCost = 30;
                move.element = MoveElement.Wind;
                move.moveCondition = MoveCondition.Special;
                break;
            case MoveName.IceCubes:
                move.moveBP = 54;
                move.stamCost = 13;
                move.element = MoveElement.Water;
                move.moveCondition = MoveCondition.Physical;
                move.synergyWith = MoveElement.Water;
                break;
            case MoveName.IcedStalactite:
                move.moveBP = 82;
                move.stamCost = 22;
                move.holdTime = 1;
                move.element = MoveElement.Water;
                move.moveCondition = MoveCondition.Physical;
                move.status1Apply = StatusApply.Cold;
                move.status1Target = ValidTargets.singleAny;
                break;
            case MoveName.IceShuriken:
                move.moveBP = 60;
                move.stamCost = 14;
                move.element = MoveElement.Water;
                move.moveCondition = MoveCondition.Physical;
                move.status1Apply = StatusApply.Cold;
                move.status1Target = ValidTargets.singleAny;
                break;
            case MoveName.InnerSpirit:
                move.moveBP = 170;
                move.stamCost = 23;
                move.holdTime = 2;
                move.element = MoveElement.Melee;
                move.moveCondition = MoveCondition.Special;
                break;
            case MoveName.Intimidation:
                move.stamCost = 12;
                move.priority = 1;
                move.holdTime = 2;
                move.element = MoveElement.Mental;
                move.moveCondition = MoveCondition.Status;
                move.status1Apply = StatusApply.Exhausted;
                move.status1Target = ValidTargets.aoeAny;
                move.validTargets = ValidTargets.aoeAny;
                break;
            case MoveName.JawStrike:
                move.moveBP = 60;
                move.stamCost = 9;
                move.element = MoveElement.Neutral;
                move.moveCondition = MoveCondition.Physical;
                break;
            case MoveName.Kick:
                move.moveBP = 32;
                move.stamCost = 8;
                move.priority = 3;
                move.element = MoveElement.Neutral;
                move.moveCondition = MoveCondition.Physical;
                break;
            case MoveName.KingsRoar:
                move.stamCost = 24;
                move.holdTime = 3;
                move.element = MoveElement.Neutral;
                move.moveCondition = MoveCondition.Status;
                move.buff1Apply = BuffApply.lowSpeed;
                move.buff2Apply = BuffApply.lowAtk;
                move.buff1Target = ValidTargets.aoeAny;
                move.buff2Target = ValidTargets.aoeAny;
                move.validTargets = ValidTargets.aoeAny;
                break;
            case MoveName.LifefulSap:
                move.stamCost = 12;
                move.element = MoveElement.Nature;
                move.moveCondition = MoveCondition.Status;
                move.status1Apply = StatusApply.Regenerate;
                move.status1Target = ValidTargets.Self;
                move.validTargets = ValidTargets.Self;
                break;
            case MoveName.Lullaby:
                move.stamCost = 27;
                move.priority = 1;
                move.holdTime = 2;
                move.element = MoveElement.Mental;
                move.moveCondition = MoveCondition.Status;
                move.status1Apply = StatusApply.Asleep;
                move.status1Target = ValidTargets.aoeAny;
                move.validTargets = ValidTargets.aoeAny;
                break;
            case MoveName.MadnessBuff:
                //UNUSUAL EFFECT
                move.stamCost = 15;
                move.element = MoveElement.Melee;
                move.moveCondition = MoveCondition.Special;
                move.buff1Apply = BuffApply.addSpatk;
                move.buff2Apply = BuffApply.addSpdef;
                move.buff1Target = ValidTargets.Self;
                move.buff2Target = ValidTargets.Self;
                move.validTargets = ValidTargets.Self;
                break;
            case MoveName.MagmaCannon:
                move.moveBP = 70;
                move.stamCost = 37;
                move.priority = 1;
                move.holdTime = 3;
                move.element = MoveElement.Fire;
                move.moveCondition = MoveCondition.Special;
                move.status1Apply = StatusApply.Burn;
                move.status1Target = ValidTargets.singleAny;
                break;
            case MoveName.MajorSlash:
                move.moveBP = 150;
                move.stamCost = 33;
                move.holdTime = 1;
                move.element = MoveElement.Neutral;
                move.moveCondition = MoveCondition.Physical;
                break;
            case MoveName.MartialStrike:
                move.moveBP = 50;
                move.stamCost = 5;
                move.holdTime = 1;
                move.element = MoveElement.Melee;
                move.moveCondition = MoveCondition.Special;
                break;
            case MoveName.MechanicalHeat:
                //Unavailable, update later
                move.moveBP = 55;
                move.stamCost = 7;
                move.element = MoveElement.Fire;
                move.moveCondition = MoveCondition.Physical;
                break;
            case MoveName.Meditation:
                //unavailable, update later
                break;
            case MoveName.MeteorSwarm:
                move.moveBP = 75;
                move.stamCost = 25;
                move.priority = 1;
                move.holdTime = 1;
                move.element = MoveElement.Fire;
                move.moveCondition = MoveCondition.Physical;
                move.synergyWith = MoveElement.Fire;
                move.validTargets = ValidTargets.aoeAny;
                break;
            case MoveName.MirrorShell:
                move.stamCost = 15;
                move.priority = 1;
                move.holdTime = 1;
                move.element = MoveElement.Crystal;
                move.moveCondition = MoveCondition.Status;
                move.buff1Apply = BuffApply.addSpdef;
                move.buff1Target = ValidTargets.Self;
                move.validTargets = ValidTargets.Self;
                break;
            case MoveName.Misogi:
                //UNUSUAL EFFECT
                move.stamCost = 22;
                move.holdTime = 2;
                move.element = MoveElement.None;
                move.moveCondition = MoveCondition.None;
                move.status1Apply = StatusApply.None;
                move.synergyWith = MoveElement.Water;
                move.validTargets = ValidTargets.Self;
                break;
            case MoveName.MudShower:
                move.moveBP = 70;
                move.stamCost = 14;
                move.element = MoveElement.Earth;
                move.moveCondition = MoveCondition.Special;
                break;
            case MoveName.MultiplePecks:
                move.moveBP = 110;
                move.stamCost = 26;
                move.element = MoveElement.Neutral;
                move.moveCondition = MoveCondition.Physical;
                break;
            case MoveName.NarcolepticHit:
                move.moveBP = 150;
                move.stamCost = 15;
                move.priority = 1;
                move.holdTime = 1;
                move.element = MoveElement.Mental;
                move.moveCondition = MoveCondition.Physical;
                move.status1Apply = StatusApply.Asleep;
                move.status1Target = ValidTargets.Self;
                move.validTargets = ValidTargets.singleAny;
                break;
            case MoveName.Nibble:
                move.moveBP = 37;
                move.stamCost = 7;
                move.element = MoveElement.Neutral;
                move.moveCondition = MoveCondition.Physical;
                break;
            case MoveName.NichoSai:
                move.moveBP = 135;
                move.stamCost = 29;
                move.priority = 3;
                move.holdTime = 1;
                move.element = MoveElement.Melee;
                move.moveCondition = MoveCondition.Physical;
                break;
            case MoveName.Nimble:
                move.stamCost = 4;
                move.element = MoveElement.Wind;
                move.moveCondition = MoveCondition.Status;
                move.buff1Apply = BuffApply.addSpeed;
                move.buff1Target = ValidTargets.singleAny;
                break;
            case MoveName.NinjaJutsu:
                move.moveBP = 130;
                move.stamCost = 27;
                move.priority = 4;
                move.holdTime = 2;
                move.element = MoveElement.Neutral;
                move.moveCondition = MoveCondition.Physical;
                break;
            case MoveName.NovicePunch:
                move.moveBP = 30;
                move.stamCost = 3;
                move.element = MoveElement.Melee;
                move.moveCondition = MoveCondition.Physical;
                move.synergyWith = MoveElement.Melee;
                break;
            case MoveName.NoxiousBomb:
                move.moveBP = 100;
                move.stamCost = 20;
                move.element = MoveElement.Toxic;
                move.moveCondition = MoveCondition.Physical;
                move.status1Apply = StatusApply.None;
                break;
            case MoveName.OshiDashi:
                move.moveBP = 150;
                move.stamCost = 28;
                move.holdTime = 1;
                move.element = MoveElement.Melee;
                move.moveCondition = MoveCondition.Physical;
                break;
            case MoveName.Overclock:
                //unavailable, update later
                break;
            case MoveName.ParalysingPoison:
                move.stamCost = 20;
                move.holdTime = 2;
                move.element = MoveElement.Toxic;
                move.moveCondition = MoveCondition.Status;
                move.status1Apply = StatusApply.Poison;
                move.status2Apply = StatusApply.Trapped;
                move.status1Target = ValidTargets.singleAny;
                move.status2Target = ValidTargets.singleAny;
                move.synergyWith = MoveElement.Toxic;
                break;
            case MoveName.Peck:
                move.moveBP = 24;
                move.stamCost = 5;
                move.priority = 4;
                move.element = MoveElement.Neutral;
                move.moveCondition = MoveCondition.Physical;
                break;
            case MoveName.PerfectJab:
                move.moveBP = 40;
                move.stamCost = 15;
                move.element = MoveElement.Melee;
                move.moveCondition = MoveCondition.Physical;
                move.buff1Apply = BuffApply.lowDef;
                move.buff1Target = ValidTargets.singleAny;
                break;
            case MoveName.Photosynthesis:
                //UNUSUAL EFFECT
                move.stamCost = 7;
                move.element = MoveElement.Nature;
                move.moveCondition = MoveCondition.Status;
                move.validTargets = ValidTargets.Self;
                break;
            case MoveName.Pollution:
                move.stamCost = 22;
                move.holdTime = 2;
                move.element = MoveElement.Toxic;
                move.moveCondition = MoveCondition.Status;
                move.status1Apply = StatusApply.Poison;
                move.status1Target = ValidTargets.aoeAny;
                move.validTargets = ValidTargets.aoeAny;
                break;
            case MoveName.PsychicCollaborator:
                move.moveBP = 1;
                move.stamCost = 19;
                move.holdTime = 1;
                move.element = MoveElement.Mental;
                move.moveCondition = MoveCondition.Special;
                move.synergyWith = MoveElement.Mental;
                break;
            case MoveName.Psychosis:
                //unavailable, update later
                break;
            case MoveName.PsySurge:
                move.moveBP = 100;
                move.stamCost = 15;
                move.priority = 1;
                move.holdTime = 1;
                move.element = MoveElement.Mental;
                move.moveCondition = MoveCondition.Special;
                move.validTargets = ValidTargets.singleAny;
                break;
            case MoveName.PsyWave:
                move.moveBP = 61;
                move.stamCost = 7;
                move.holdTime = 1;
                move.element = MoveElement.Mental;
                move.moveCondition = MoveCondition.Special;
                break;
            case MoveName.Rage:
                move.stamCost = 10;
                move.holdTime = 1;
                move.element = MoveElement.Melee;
                move.moveCondition = MoveCondition.Status;
                move.buff1Apply = BuffApply.addAtk;
                move.buff2Apply = BuffApply.lowDef;
                move.buff1Target = ValidTargets.Self;
                move.buff2Target = ValidTargets.Self;
                move.validTargets = ValidTargets.Self;
                break;
            case MoveName.Rampage:
                move.moveBP = 65;
                move.stamCost = 26;
                move.priority = 1;
                move.holdTime = 1;
                move.element = MoveElement.Neutral;
                move.moveCondition = MoveCondition.Physical;
                move.synergyWith = MoveElement.Neutral;
                break;
            case MoveName.Regenerate:
                //unavailable, update later
                break;
            case MoveName.Relax:
                move.stamCost = 12;
                move.priority = 1;
                move.holdTime = 1;
                move.element = MoveElement.Neutral;
                move.moveCondition = MoveCondition.Status;
                move.status1Apply = StatusApply.Asleep;
                move.status1Target = ValidTargets.aoeAll;
                move.validTargets = ValidTargets.aoeAll;
                break;
            case MoveName.Rend:
                move.moveBP = 50;
                move.stamCost = 22;
                move.holdTime = 2;
                move.element = MoveElement.Neutral;
                move.moveCondition = MoveCondition.Status;
                move.status1Apply = StatusApply.Neutralize;
                move.status1Target = ValidTargets.singleAny;
                break;
            case MoveName.Revitalize:
                //UNUSUAL EFFECT
                move.stamCost = 15;
                move.holdTime = 1;
                move.element = MoveElement.Nature;
                move.moveCondition = MoveCondition.Status;
                move.synergyWith = MoveElement.Nature;
                move.validTargets = ValidTargets.aoeAll;
                break;
            case MoveName.Roar:
                move.stamCost = 10;
                move.holdTime = 2;
                move.element = MoveElement.Neutral;
                move.moveCondition = MoveCondition.Status;
                move.buff1Apply = BuffApply.lowAtk;
                move.buff1Target = ValidTargets.aoeAny;
                move.validTargets = ValidTargets.aoeAny;
                break;
            case MoveName.Roots:
                move.stamCost = 5;
                move.element = MoveElement.Nature;
                move.moveCondition = MoveCondition.Status;
                move.buff1Apply = BuffApply.lowSpeed;
                move.buff1Target = ValidTargets.singleAny;
                move.validTargets = ValidTargets.singleAny;
                break;
            case MoveName.Sacrifice:
                move.priority = 3;
                move.holdTime = 1;
                move.element = MoveElement.Neutral;
                move.moveCondition = MoveCondition.Status;
                move.buff1Apply = BuffApply.addDef;
                move.buff2Apply = BuffApply.addSpdef;
                move.buff1Target = ValidTargets.notSelf;
                move.buff2Target = ValidTargets.notSelf;
                move.validTargets = ValidTargets.notSelf;
                break;
            case MoveName.SandSplatter:
                move.moveBP = 35;
                move.stamCost = 7;
                move.element = MoveElement.Earth;
                move.moveCondition = MoveCondition.Physical;
                break;
            case MoveName.Scratch:
                move.moveBP = 20;
                move.stamCost = 4;
                move.element = MoveElement.Neutral;
                move.moveCondition = MoveCondition.Physical;
                break;
            case MoveName.SharpLeaf:
                move.moveBP = 50;
                move.stamCost = 7;
                move.element = MoveElement.Nature;
                move.moveCondition = MoveCondition.Physical;
                break;
            case MoveName.SharpRain:
                move.moveBP = 130;
                move.stamCost = 20;
                move.holdTime = 2;
                move.element = MoveElement.Water;
                move.moveCondition = MoveCondition.Special;
                break;
            case MoveName.SharpStabs:
                move.moveBP = 76;
                move.stamCost = 15;
                move.priority = 3;
                move.holdTime = 1;
                move.element = MoveElement.Crystal;
                move.moveCondition = MoveCondition.Physical;
                break;
            case MoveName.ShowOff:
                move.stamCost = 7;
                move.element = MoveElement.Melee;
                move.moveCondition = MoveCondition.Status;
                move.buff1Apply = BuffApply.addAtk;
                move.buff1Target = ValidTargets.Self;
                move.synergyWith = MoveElement.Melee;
                move.validTargets = ValidTargets.Self;
                break;
            case MoveName.ShrillVoice:
                move.moveBP = 42;
                move.stamCost = 12;
                move.holdTime = 1;
                move.element = MoveElement.Neutral;
                move.moveCondition = MoveCondition.Special;
                move.validTargets = ValidTargets.aoeAny;
                break;
            case MoveName.ShyShield:
                move.stamCost = 4;
                move.priority = 3;
                move.element = MoveElement.Neutral;
                move.moveCondition = MoveCondition.Status;
                move.buff1Apply = BuffApply.addDef;
                move.buff1Target = ValidTargets.Self;
                move.validTargets = ValidTargets.Self;
                break;
            case MoveName.Slime:
                move.stamCost = 12;
                move.priority = 1;
                move.element = MoveElement.Neutral;
                move.moveCondition = MoveCondition.Status;
                move.status1Apply = StatusApply.Trapped;
                move.status1Target = ValidTargets.singleAny;
                move.buff1Apply = BuffApply.lowSpeed;
                move.buff1Target = ValidTargets.singleAny;
                break;
            case MoveName.SlowDown:
                //unavailable, update later
                break;
            case MoveName.Sparks:
                move.stamCost = 5;
                move.element = MoveElement.Electric;
                move.moveCondition = MoveCondition.Status;
                move.buff1Apply = BuffApply.addSpatk;
                move.buff1Target = ValidTargets.singleAny;
                move.validTargets = ValidTargets.singleAny;
                break;
            case MoveName.Spores:
                move.moveBP = 37;
                move.stamCost = 6;
                move.element = MoveElement.Nature;
                move.moveCondition = MoveCondition.Special;
                break;
            case MoveName.Stare:
                move.stamCost = 6;
                move.element = MoveElement.Mental;
                move.moveCondition = MoveCondition.Status;
                move.status1Apply = StatusApply.Alerted;
                move.status1Target = ValidTargets.Self;
                move.buff1Apply = BuffApply.lowDef;
                move.buff1Target = ValidTargets.singleAny;
                break;
            case MoveName.StoneBall:
                move.moveBP = 130;
                move.stamCost = 29;
                move.priority = 1;
                move.element = MoveElement.Earth;
                move.moveCondition = MoveCondition.Physical;
                move.synergyWith = MoveElement.Fire;
                break;
            case MoveName.StoneWall:
                move.stamCost = 18;
                move.priority = 1;
                move.holdTime = 1;
                move.element = MoveElement.Earth;
                move.moveCondition = MoveCondition.Status;
                move.buff1Apply = BuffApply.addDef;
                move.buff2Apply = BuffApply.addSpdef;
                move.buff1Target = ValidTargets.singleAny;
                move.buff2Target = ValidTargets.singleAny;
                break;
            case MoveName.Strangle:
                //UNUSUAL EFFECT
                //MAY WANT "DISABLED" STATUS
                move.moveBP = 25;
                move.stamCost = 11;
                move.priority = 0;
                move.element = MoveElement.Neutral;
                move.moveCondition = MoveCondition.Physical;
                break;
            case MoveName.TailStrike:
                move.moveBP = 50;
                move.stamCost = 5;
                move.holdTime = 1;
                move.element = MoveElement.Neutral;
                move.moveCondition = MoveCondition.Physical;
                break;
            case MoveName.TelekineticShrapnel:
                move.moveBP = 80;
                move.stamCost = 8;
                move.holdTime = 1;
                move.element = MoveElement.Mental;
                move.moveCondition = MoveCondition.Physical;
                break;
            case MoveName.Tenderness:
                move.stamCost = 3;
                move.element = MoveElement.Neutral;
                move.moveCondition = MoveCondition.Status;
                move.buff1Apply = BuffApply.lowAtk;
                move.buff1Target = ValidTargets.singleAny;
                break;
            case MoveName.TentacleWhip:
                move.moveBP = 60;
                move.stamCost = 15;
                move.element = MoveElement.Neutral;
                move.moveCondition = MoveCondition.Physical;
                break;
            case MoveName.TeslaPrison:
                move.moveBP = 50;
                move.stamCost = 12;
                move.element = MoveElement.Electric;
                move.moveCondition = MoveCondition.Special;
                move.buff1Apply = BuffApply.lowSpeed;
                move.buff1Target = ValidTargets.singleAny;
                break;
            case MoveName.Tornado:
                move.moveBP = 135;
                move.stamCost = 31;
                move.priority = 3;
                move.holdTime = 1;
                move.element = MoveElement.Wind;
                move.moveCondition = MoveCondition.Special;
                break;
            case MoveName.ToxicFang:
                move.moveBP = 62;
                move.stamCost = 12;
                move.holdTime = 1;
                move.element = MoveElement.Toxic;
                move.moveCondition = MoveCondition.Physical;
                break;
            case MoveName.ToxicInk:
                move.moveBP = 80;
                move.stamCost = 16;
                move.element = MoveElement.Toxic;
                move.moveCondition = MoveCondition.Physical;
                move.status1Apply = StatusApply.Poison;
                move.status1Target = ValidTargets.singleAny;
                break;
            case MoveName.ToxicPlume:
                move.moveBP = 50;
                move.stamCost = 24;
                move.holdTime = 1;
                move.element = MoveElement.Toxic;
                move.moveCondition = MoveCondition.Special;
                move.status1Apply = StatusApply.Poison;
                move.status1Target = ValidTargets.aoeAny;
                move.synergyWith = MoveElement.Crystal;
                move.validTargets = ValidTargets.aoeAny;
                break;
            case MoveName.ToxicSlime:
                move.moveBP = 50;
                move.stamCost = 12;
                move.element = MoveElement.Toxic;
                move.moveCondition = MoveCondition.Physical;
                break;
            case MoveName.ToxicSpores:
                move.stamCost = 9;
                move.priority = 1;
                move.element = MoveElement.Toxic;
                move.moveCondition = MoveCondition.Status;
                move.status1Apply = StatusApply.Poison;
                move.status1Target = ValidTargets.singleAny;
                break;
            case MoveName.Tsunami:
                move.moveBP = 70;
                move.stamCost = 25;
                move.holdTime = 1;
                move.element = MoveElement.Water;
                move.moveCondition = MoveCondition.Special;
                move.synergyWith = MoveElement.Wind;
                move.validTargets = ValidTargets.aoeAny;
                break;
            case MoveName.TurboAttack:
                //unavailable, update later
                break;
            case MoveName.TurboCharge:
                //UNUSUAL EFFECT
                move.stamCost = 21;
                move.priority = 4;
                move.holdTime = 1;
                move.element = MoveElement.Electric;
                move.moveCondition = MoveCondition.Status;
                move.validTargets = ValidTargets.aoeAny;
                break;
            case MoveName.TurboChoreography:
                move.stamCost = 27;
                move.priority = 4;
                move.holdTime = 1;
                move.element = MoveElement.Wind;
                move.moveCondition = MoveCondition.Status;
                move.buff1Apply = BuffApply.addSpeed;
                move.buff1Target = ValidTargets.aoeAny;
                move.synergyWith = MoveElement.Wind;
                move.validTargets = ValidTargets.aoeAny;
                break;
            case MoveName.Uppercut:
                move.moveBP = 80;
                move.stamCost = 12;
                move.element = MoveElement.Melee;
                move.moveCondition = MoveCondition.Physical;
                break;
            case MoveName.Urushiol:
                move.moveBP = 41;
                move.stamCost = 8;
                move.element = MoveElement.Toxic;
                move.moveCondition = MoveCondition.Physical;
                move.synergyWith = MoveElement.Toxic;
                move.validTargets = ValidTargets.singleAny;
                break;
            case MoveName.VenomousClaws:
                move.moveBP = 40;
                move.stamCost = 9;
                move.element = MoveElement.Toxic;
                move.moveCondition = MoveCondition.Physical;
                break;
            case MoveName.WakeUp:
                move.moveBP = 1;
                move.priority = 4;
                move.element = MoveElement.Neutral;
                move.moveCondition = MoveCondition.Physical;
                break;
            case MoveName.WarmCuddle:
                move.moveBP = 53;
                move.stamCost = 12;
                move.element = MoveElement.Fire;
                move.moveCondition = MoveCondition.Physical;
                break;
            case MoveName.WaterBlade:
                move.moveBP = 52;
                move.stamCost = 10;
                move.priority = 1;
                move.element = MoveElement.Water;
                break;
            case MoveName.WaterCannon:
                move.moveBP = 100;
                move.stamCost = 21;
                move.element = MoveElement.Water;
                move.moveCondition = MoveCondition.Special;
                move.synergyWith = MoveElement.Toxic;
                break;
            case MoveName.WaterCuttingLily:
                move.moveBP = 120;
                move.stamCost = 31;
                move.priority = 3;
                move.element = MoveElement.Nature;
                move.moveCondition = MoveCondition.Physical;
                move.synergyWith = MoveElement.Water;
                break;
            case MoveName.WindBlade:
                move.moveBP = 40;
                move.stamCost = 9;
                move.element = MoveElement.Wind;
                move.moveCondition = MoveCondition.Special;
                break;
            case MoveName.WindBurst:
                move.moveBP = 90;
                move.stamCost = 12;
                move.element = MoveElement.Wind;
                move.moveCondition = MoveCondition.Special;
                break;
            default:
                break;
        }
    }

    public Move GetMoveByName(MoveName name)
    {
        return moveList[(int)name];
    }

    //if loneliness trait, synergyWith = MoveElement.None

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