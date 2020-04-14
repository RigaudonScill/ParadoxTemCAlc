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
    public enum MoveName
    {
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
    public StatusApply statusApply;
    //targeting system will need to be planned better later 
    public ValidTargets validTargets;


    //constructor
    public Move(MoveName moveName,
                string name = "",
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
        this.moveName = moveName;
        this.moveBP = moveBP;
        this.stamCost = stamCost;
        this.holdTime = holdTime;
        this.priority = priority;
        this.element = element;
        this.moveCondition = condition;
        this.statusApply = statusApply;
        this.synergyWith = synergyWith;
        this.validTargets = validTargets;

        this.name = moveName.ToString();
    }
}



//TriA should be checked on execution of calculations for special moves, individual of the move itself. The status will be applied at the very end of attack execution.
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
        //moveList[(int)MoveName.TurboCharge].name
    }

    public void SetMoveValues(ref Move move)
    {
        switch (move.moveName)
        {
            case MoveName.None:
                break;
            case MoveName.Rest:
                break;
            case MoveName.AllergicSpread:
                break;
            case MoveName.Antitoxins:
                break;
            case MoveName.AquaStone:
                break;
            case MoveName.AquaticWhirlwind:
                break;
            case MoveName.AwfulSong:
                break;
            case MoveName.Bamboozle:
                break;
            case MoveName.BarkShield:
                break;
            case MoveName.BetaBurst:
                break;
            case MoveName.Blizzard:
                break;
            case MoveName.Block:
                break;
            case MoveName.Boomerang:
                break;
            case MoveName.Bubbles:
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