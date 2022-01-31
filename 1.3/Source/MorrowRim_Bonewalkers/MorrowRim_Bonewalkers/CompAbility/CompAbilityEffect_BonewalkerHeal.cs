using RimWorld;
using Verse;
using System.Collections.Generic;
using System.Linq;

namespace MorrowRim_Bonewalkers
{
    class CompAbilityEffect_BonewalkerHeal : CompAbilityEffect
    {
		public new CompProperties_BonewalkerHeal Props
		{
			get
			{
				return (CompProperties_BonewalkerHeal)this.props;
			}
		}

        public override void Apply(LocalTargetInfo target, LocalTargetInfo dest)
        {
            Pawn p = target.Pawn;
            if(p != null && !p.Dead)
            {
                List<Hediff> hediffList = new List<Hediff>() { };
                foreach(Hediff hd in p.health.hediffSet.hediffs.Where(x=>x.def.displayWound || x.def.tendable))
                {
                    hediffList.Add(hd);
                    //p.health.RemoveHediff(hd);
                }
                for(int i = 0; i < hediffList.Count; i++)
                {
                    p.health.RemoveHediff(hediffList[i]);
                }

                hediffList.Clear();

                foreach (Hediff hd in p.health.hediffSet.hediffs.Where(x => p.health.hediffSet.PartIsMissing(x.Part)))
                {
                    hediffList.Add(hd);
                    //p.health.RemoveHediff(hd);
                }
                for (int i = 0; i < hediffList.Count; i++)
                {
                    p.health.RestorePart(hediffList[i].Part);
                }
            }
        }
    }
}
