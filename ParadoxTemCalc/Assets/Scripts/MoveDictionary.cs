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
        Vigorized,
        Buff,
        Positive,
        Negative,
    }

    //remake valid targets system
    public enum ValidTargets
    {
        None,
        Self,
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
    public string name;
    public MoveName moveName;
    public int moveBP;
    public int stamCost;
    public int holdTime;
    public int priority;
    public MoveElement element;
    public MoveElement synergyWith;
    public MoveCondition moveCondition;
    public StatusApply status1Apply;
    public StatusApply status2Apply;
    public StatusApply status1Benefit;
    public StatusApply status2Benefit;
    public BuffApply buff1Apply;
    public BuffApply buff2Apply;
    public StatusApply buff1Benefit;
    public StatusApply buff2Benefit;
    //targeting system will need to be planned better later 
    public ValidTargets validTargets;
    public ValidTargets status1Target;
    public ValidTargets status2Target;
    public ValidTargets buff1Target;
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
                StatusApply status1Benefit = StatusApply.None,
                StatusApply status2Benefit = StatusApply.None,
                BuffApply buff1Apply = BuffApply.None,
                BuffApply buff2Apply = BuffApply.None,
                StatusApply buff1Benefit = StatusApply.None,
                StatusApply buff2Benefit = StatusApply.None,
                ValidTargets validTargets = ValidTargets.singleAny,
                ValidTargets status1Target = ValidTargets.None,
                ValidTargets status2Target = ValidTargets.None,
                ValidTargets buff1Target = ValidTargets.None,
                ValidTargets buff2Target = ValidTargets.None)
    {
        this.name = name;
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
        this.status1Benefit = status1Benefit;
        this.status2Benefit = status2Benefit;
        this.buff1Apply = buff1Apply;
        this.buff2Apply = buff2Apply;
        this.buff1Benefit = buff1Benefit;
        this.buff2Benefit = buff2Benefit;
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
                move.status1Benefit = StatusApply.None;
                move.buff1Apply = BuffApply.None;
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
                move.status1Benefit = StatusApply.Positive;
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
                break;
            case MoveName.ChainLightning:
                break;
            case MoveName.ChainsHit:
                break;
            case MoveName.CheerUp:
                break;
            case MoveName.Clinch:
                break;
            case MoveName.ColdBreeze:
                break;
            case MoveName.Confiscate:
                break;
            case MoveName.Cooperation:
                break;
            case MoveName.CrystalBite:
                break;
            case MoveName.CrystalDust:
                break;
            case MoveName.Crystallize:
                break;
            case MoveName.CrystalPumeGatling:
                break;
            case MoveName.CrystalSpikes:
                break;
            case MoveName.DataBurst:
                break;
            case MoveName.DCBeam:
                break;
            case MoveName.DiamondFort:
                break;
            case MoveName.DoubleKick:
                break;
            case MoveName.DrillImpact:
                break;
            case MoveName.DustVortex:
                break;
            case MoveName.EarthWave:
                break;
            case MoveName.ElectricStorm:
                break;
            case MoveName.Embers:
                break;
            case MoveName.EnergyManipulation:
                break;
            case MoveName.Extinction:
                break;
            case MoveName.FeatherGatling:
                break;
            case MoveName.FierceClaw:
                break;
            case MoveName.Finbeat:
                break;
            case MoveName.FireFlame:
                break;
            case MoveName.FireTornado:
                break;
            case MoveName.Firewall:
                break;
            case MoveName.Flood:
                break;
            case MoveName.Footwork:
                break;
            case MoveName.FrondWhip:
                break;
            case MoveName.Gaia:
                break;
            case MoveName.GammaBurst:
                break;
            case MoveName.GlassBlade:
                break;
            case MoveName.HaitoUchi:
                break;
            case MoveName.Hallucination:
                break;
            case MoveName.HarmfulLick:
                break;
            case MoveName.HeadCharge:
                break;
            case MoveName.HeadRam:
                break;
            case MoveName.HeatUp:
                break;
            case MoveName.HeavyBlow:
                break;
            case MoveName.HeldAnger:
                break;
            case MoveName.HighPressureWater:
                break;
            case MoveName.HumiliatingSlap:
                break;
            case MoveName.HyperkineticStrike:
                break;
            case MoveName.Hypnosis:
                break;
            case MoveName.Hypoxia:
                break;
            case MoveName.IceCubes:
                break;
            case MoveName.IcedStalactite:
                break;
            case MoveName.IceShuriken:
                break;
            case MoveName.InnerSpirit:
                break;
            case MoveName.Intimidation:
                break;
            case MoveName.JawStrike:
                break;
            case MoveName.Kick:
                break;
            case MoveName.KingsRoar:
                break;
            case MoveName.LifefulSap:
                break;
            case MoveName.Lullaby:
                break;
            case MoveName.MadnessBuff:
                break;
            case MoveName.MagmaCannon:
                break;
            case MoveName.MajorSlash:
                break;
            case MoveName.MartialStrike:
                break;
            case MoveName.MechanicalHeat:
                break;
            case MoveName.Meditation:
                break;
            case MoveName.MeteorSwarm:
                break;
            case MoveName.MirrorShell:
                break;
            case MoveName.Misogi:
                break;
            case MoveName.MudShower:
                break;
            case MoveName.MultiplePecks:
                break;
            case MoveName.NarcolepticHit:
                break;
            case MoveName.Nibble:
                break;
            case MoveName.NichoSai:
                break;
            case MoveName.Nimble:
                break;
            case MoveName.NinjaJutsu:
                break;
            case MoveName.NovicePunch:
                break;
            case MoveName.NoxiousBomb:
                break;
            case MoveName.OshiDashi:
                break;
            case MoveName.Overclock:
                break;
            case MoveName.ParalysingPoison:
                break;
            case MoveName.Peck:
                break;
            case MoveName.PerfectJab:
                break;
            case MoveName.Photosynthesis:
                break;
            case MoveName.Pollution:
                break;
            case MoveName.PsychicCollaborator:
                break;
            case MoveName.Psychosis:
                break;
            case MoveName.PsySurge:
                break;
            case MoveName.PsyWave:
                break;
            case MoveName.Rage:
                break;
            case MoveName.Rampage:
                break;
            case MoveName.Regenerate:
                break;
            case MoveName.Relax:
                break;
            case MoveName.Rend:
                break;
            case MoveName.Revitalize:
                break;
            case MoveName.Roar:
                break;
            case MoveName.Roots:
                break;
            case MoveName.Sacrifice:
                break;
            case MoveName.SandSplatter:
                break;
            case MoveName.Scratch:
                break;
            case MoveName.SharpLeaf:
                break;
            case MoveName.SharpRain:
                break;
            case MoveName.SharpStabs:
                break;
            case MoveName.ShowOff:
                break;
            case MoveName.ShrillVoice:
                break;
            case MoveName.ShyShield:
                break;
            case MoveName.Slime:
                break;
            case MoveName.SlowDown:
                break;
            case MoveName.Sparks:
                break;
            case MoveName.Spores:
                break;
            case MoveName.Stare:
                break;
            case MoveName.StoneBall:
                break;
            case MoveName.StoneWall:
                break;
            case MoveName.Strangle:
                break;
            case MoveName.TailStrike:
                break;
            case MoveName.TelekineticShrapnel:
                break;
            case MoveName.Tenderness:
                break;
            case MoveName.TentacleWhip:
                break;
            case MoveName.TeslaPrison:
                break;
            case MoveName.Tornado:
                break;
            case MoveName.ToxicFang:
                break;
            case MoveName.ToxicInk:
                break;
            case MoveName.ToxicPlume:
                break;
            case MoveName.ToxicSlime:
                break;
            case MoveName.ToxicSpores:
                break;
            case MoveName.Tsunami:
                break;
            case MoveName.TurboAttack:
                break;
            case MoveName.TurboCharge:
                break;
            case MoveName.TurboChoreography:
                break;
            case MoveName.Uppercut:
                break;
            case MoveName.Urushiol:
                break;
            case MoveName.VenomousClaws:
                break;
            case MoveName.WakeUp:
                break;
            case MoveName.WarmCuddle:
                break;
            case MoveName.WaterBlade:
                break;
            case MoveName.WaterCannon:
                break;
            case MoveName.WaterCuttingLily:
                break;
            case MoveName.WindBlade:
                break;
            case MoveName.WindBurst:
                break;
            default:
                break;
        }
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