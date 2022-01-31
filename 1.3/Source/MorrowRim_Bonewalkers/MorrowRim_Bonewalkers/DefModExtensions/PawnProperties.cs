using System;
using System.Collections.Generic;
using System.Linq;
using Verse;
using RimWorld;

namespace MorrowRim_Bonewalkers
{
    class PawnProperties : DefModExtension
    {
        public List<HediffDef> imbuements;

        public static PawnProperties Get(Def def)
        {
            return def.GetModExtension<PawnProperties>();
        }
    }
}
