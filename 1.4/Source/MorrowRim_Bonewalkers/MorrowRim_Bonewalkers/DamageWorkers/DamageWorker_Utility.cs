using System.Linq;
using Verse;

namespace MorrowRim_Bonewalkers
{
    static class DamageWorker_Utility
    {
        public static void DoImbumentDamage(DamageInfo dinfo, Pawn pawn)
        {
            if ((!pawn.def.tradeTags.NullOrEmpty() && pawn.def.tradeTags.Contains("MorrowRim_Bonewalker")) || pawn.def.race.IsMechanoid)
            {
                return;
            }

            Pawn inst = dinfo.Instigator as Pawn;
            Hediff imbuement = inst.health.hediffSet.hediffs.Where(x => ImbuementProperties.Get(x.def) != null).FirstOrDefault();

            if (imbuement != null)
            {
                var props = ImbuementProperties.Get(imbuement.def);
                float severityIncrease = props.severityRange.RandomInRange;
                Hediff hediff = pawn.health.hediffSet.GetFirstHediffOfDef(props.hediff);
                if (hediff != null)
                {
                    hediff.Severity += severityIncrease;
                }
                else
                {
                    pawn.health.AddHediff(props.hediff).Severity = severityIncrease;
                }
            }
        }
    }
}
