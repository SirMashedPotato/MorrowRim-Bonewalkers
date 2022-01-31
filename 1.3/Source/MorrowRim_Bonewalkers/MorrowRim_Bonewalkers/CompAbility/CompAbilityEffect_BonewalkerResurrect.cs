using RimWorld;
using Verse;

namespace MorrowRim_Bonewalkers
{
    class CompAbilityEffect_BonewalkerResurrect : CompAbilityEffect
    {
        public new CompProperties_BonewalkerResurrect Props
        {
            get
            {
                return (CompProperties_BonewalkerResurrect)this.props;
            }
        }

        public override void Apply(LocalTargetInfo target, LocalTargetInfo dest)
        {
            Corpse c = target.Thing as Corpse;
            Pawn p = c.InnerPawn;
            if (c != null)
            {
                ResurrectionUtility.Resurrect(c.InnerPawn);
                if(Props.ressurectionhediff != null)
                {
                    p.health.AddHediff(Props.ressurectionhediff).Severity = Props.severity;
                }
            }
        }
    }
}
