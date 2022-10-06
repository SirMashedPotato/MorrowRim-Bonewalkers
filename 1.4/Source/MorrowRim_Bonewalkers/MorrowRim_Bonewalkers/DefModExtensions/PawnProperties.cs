using System.Collections.Generic;
using Verse;

namespace MorrowRim_Bonewalkers
{
    public class PawnProperties : DefModExtension
    {
        public List<HediffDef> imbuements;
        public bool preventDisease = true;
        public bool preventTrainingDecay = true;
        public bool preventWoundInfection = true;

        public static PawnProperties Get(Def def)
        {
            return def.GetModExtension<PawnProperties>();
        }
    }
}
