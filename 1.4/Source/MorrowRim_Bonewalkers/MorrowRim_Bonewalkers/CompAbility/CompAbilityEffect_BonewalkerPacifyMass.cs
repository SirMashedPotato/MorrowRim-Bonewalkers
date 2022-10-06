using RimWorld;
using Verse;

namespace MorrowRim_Bonewalkers
{
    class CompAbilityEffect_BonewalkerPacifyMass : CompAbilityEffect
    {
        public new CompProperties_BonewalkerPacifyMass Props
        {
            get
            {
                return (CompProperties_BonewalkerPacifyMass)this.props;
            }
        }

        public override void Apply(LocalTargetInfo target, LocalTargetInfo dest)
        {
            Pawn p = target.Pawn;
            float chance = GetChance();
            if (p != null && !p.Dead)
            {
                if (Rand.Chance(chance))
                {
                    Hediff hediff = p.health.hediffSet.GetFirstHediffOfDef(HediffDefOf.MorrowRim_GraveRevenant);
                    if (hediff != null)
                    {
                        p.health.RemoveHediff(hediff);
                        p.mindState.mentalStateHandler.Reset();
                    }
                }
            }
        }

        public override bool Valid(LocalTargetInfo target, bool throwMessages = false)
        {
            Pawn pawn = target.Pawn;
            return pawn != null && BonewalkerUtility.PawnIsBonewalker(pawn) && BonewalkerUtility.IsPosessed(pawn);
        }

        public override bool CanApplyOn(LocalTargetInfo target, LocalTargetInfo dest)
        {
            return true;
        }

        public override string ExtraTooltipPart()
        {
            float chance = GetChance();
            return "MorrowRim_Bonewalker_MassPacifyChance".Translate() + ": " + chance.ToStringPercent();
        }

        public float GetChance()
        {
            float chance = (0.05f * this.parent.pawn.GetStatValue(StatDefOf.PsychicSensitivity)) * 10f;
            return chance > 0.9f ? 0.9f : chance;
        }
    }
}
