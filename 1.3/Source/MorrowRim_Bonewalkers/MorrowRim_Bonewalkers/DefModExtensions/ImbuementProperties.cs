using System;
using System.Collections.Generic;
using System.Linq;
using Verse;
using RimWorld;

namespace MorrowRim_Bonewalkers
{
    class ImbuementProperties : DefModExtension
    {
        public HediffDef hediff;
        public float chance = 0.1f;
        public FloatRange severityRange = FloatRange.One;   //percentage of damage converted to severity

        public static ImbuementProperties Get(Def def)
        {
            return def.GetModExtension<ImbuementProperties>();
        }
    }
}
