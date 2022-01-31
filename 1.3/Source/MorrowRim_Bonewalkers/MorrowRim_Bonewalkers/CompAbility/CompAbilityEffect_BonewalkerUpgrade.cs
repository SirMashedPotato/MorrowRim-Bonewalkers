using RimWorld;
using Verse;

namespace MorrowRim_Bonewalkers
{
    class CompAbilityEffect_BonewalkerUpgrade : CompAbilityEffect
    {
        public new CompProperties_BonewalkerUpgrade Props
        {
            get
            {
                return (CompProperties_BonewalkerUpgrade)this.props;
            }
        }

        public override bool GizmoDisabled(out string reason)
        {
            if (Props.requriedResearch != null && !Props.requriedResearch.IsFinished)
            {
                reason = "MorrowRim_Bonewalker_NeedResearch".Translate(Props.requriedResearch.label);
                return true;
            }
            return base.GizmoDisabled(out reason);
        }

        public override void Apply(LocalTargetInfo target, LocalTargetInfo dest)
        {
            Pawn p = target.Pawn;
            if (p != null && !p.Dead)
            {
                Hediff quality = p.health.hediffSet.GetFirstHediffOfDef(HediffDefOf.MorrowRim_BonewalkerQuality);
                if(quality != null)
                {
                    if(quality.Severity >= 0.6f)
                    {
                        p.health.RemoveHediff(quality);
                        p.health.AddHediff(HediffDefOf.MorrowRim_BonewalkerQuality_Legendary).Severity = 0.1f;
                    }
                    else
                    {
                        quality.Severity += 0.1f;
                    }
                } 
                else
                {
                    quality = p.health.hediffSet.GetFirstHediffOfDef(HediffDefOf.MorrowRim_BonewalkerQuality_Legendary);
                    if(quality != null && quality.Severity < 1f)
                    {
                        quality.Severity += 0.1f;
                    }
                }
            }
        }
    }
}
