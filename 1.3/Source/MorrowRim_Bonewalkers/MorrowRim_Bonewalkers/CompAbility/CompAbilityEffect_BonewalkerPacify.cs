using RimWorld;
using Verse;


namespace MorrowRim_Bonewalkers
{
    class CompAbilityEffect_BonewalkerPacify : CompAbilityEffect
    {
        public new CompProperties_BonewalkerPacify Props
    {
        get
        {
            return (CompProperties_BonewalkerPacify)this.props;
        }
    }

        public override void Apply(LocalTargetInfo target, LocalTargetInfo dest)
        {
            Pawn p = target.Pawn;
            if (p != null && !p.Dead)
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
}
