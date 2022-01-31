using RimWorld;
using Verse;
using System.Collections.Generic;
using System.Linq;

namespace MorrowRim_Bonewalkers
{
    class CompAbilityEffect_BonewalkerShuffleImbuement : CompAbilityEffect
    {
        public new CompProperties_BonewalkerShuffleImbuement Props
        {
            get
            {
                return (CompProperties_BonewalkerShuffleImbuement)this.props;
            }
        }

        public override void Apply(LocalTargetInfo target, LocalTargetInfo dest)
        {
            Pawn p = target.Pawn;
            if (p != null && !p.Dead)
            {
                var props = PawnProperties.Get(p.def);
                List<HediffDef> imbuements = new List<HediffDef>(props.imbuements);
                Hediff current = p.health.hediffSet.hediffs.Where(x => imbuements.Contains(x.def)).First();

                if(current != null)
                {
                    imbuements.Remove(current.def);
                    p.health.RemoveHediff(current);
                }
                
                p.health.AddHediff(imbuements.RandomElement());
            }
        }
    }
}
