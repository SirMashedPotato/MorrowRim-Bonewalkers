using System;
using System.Collections.Generic;
using Verse;
using RimWorld;
using System.Linq;

namespace MorrowRim_Bonewalkers
{
    class HediffComp_BonelordShield : HediffComp
    {

        public HediffCompProperties_BonelordShield Props
        {
            get
            {
                return (HediffCompProperties_BonelordShield)this.props;
            }
        }

        public bool shieldDisabled = false;

        public override void CompExposeData()
        {
            base.CompExposeData();
            Scribe_Values.Look(ref shieldDisabled, "MorrowRim_BonelordShieldDisabled", false);
        }

        public override void CompPostTick(ref float severityAdjustment)
        {
            if (parent.pawn.Spawned && !parent.pawn.Dead)
            {
                if (parent.CurStageIndex == 0 && !shieldDisabled)
                {
                    shieldDisabled = true;
                    parent.Severity = parent.def.minSeverity;
                }
                else
                {
                    if (parent.CurStageIndex == 1 && shieldDisabled)
                    {
                        shieldDisabled = false;
                    }
                }
            }
        }

        public override void Notify_PawnPostApplyDamage(DamageInfo dinfo, float totalDamageDealt)
        {
            base.Notify_PawnPostApplyDamage(dinfo, totalDamageDealt);

            float severityImpact = Props.severityDecrease * totalDamageDealt;
            if (dinfo.Instigator is Pawn)
            {
                Pawn p = dinfo.Instigator as Pawn;

                if (p.equipment != null && p.equipment.Primary != null)
                {
                    Thing t = p.equipment.Primary;
                    if (t.Stuff != null && Props.stuffWeaknesses.Contains(t.Stuff) || (t.def.costList != null && t.def.costList.Where(x=>Props.stuffWeaknesses.Contains(x.thingDef)) != null))
                    {
                        severityImpact *= Props.stuffWeaknessesMultiplier;
                    }
                }

            }
            parent.Severity -= severityImpact;
        }

        public override string CompLabelInBracketsExtra => base.CompLabelInBracketsExtra + parent.Severity.ToStringPercent();
    }
}
