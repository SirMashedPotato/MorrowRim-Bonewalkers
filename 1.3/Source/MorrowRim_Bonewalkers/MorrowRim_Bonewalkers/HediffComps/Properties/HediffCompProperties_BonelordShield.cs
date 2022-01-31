using System;
using System.Collections.Generic;
using Verse;
using RimWorld;

namespace MorrowRim_Bonewalkers
{
    class HediffCompProperties_BonelordShield : HediffCompProperties
    {
        public HediffCompProperties_BonelordShield()
        {
            this.compClass = typeof(HediffComp_BonelordShield);
        }

        public float severityDecrease = 0.01f;
        public float stuffWeaknessesMultiplier = 3;
        public List<ThingDef> stuffWeaknesses;
    }
}
