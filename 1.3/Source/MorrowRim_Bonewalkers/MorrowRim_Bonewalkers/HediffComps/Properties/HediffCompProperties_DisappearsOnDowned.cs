using System;
using Verse;

namespace MorrowRim_Bonewalkers
{
    class HediffCompProperties_DisappearsOnDowned : HediffCompProperties
    {
        public HediffCompProperties_DisappearsOnDowned()
        {
            this.compClass = typeof(HediffComp_DisappearsOnDowned);
        }
    }
}
