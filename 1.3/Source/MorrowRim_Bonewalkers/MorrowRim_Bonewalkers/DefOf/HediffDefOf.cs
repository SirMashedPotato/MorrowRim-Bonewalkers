using System;
using Verse;
using RimWorld;

namespace MorrowRim_Bonewalkers
{
    [DefOf]
    public static class HediffDefOf
    {
        static HediffDefOf()
        {
            DefOfHelper.EnsureInitializedInCtor(typeof(HediffDefOf));
        }

        public static HediffDef MorrowRim_GraveRevenant;
        public static HediffDef MorrowRim_BonewalkerQuality;
        public static HediffDef MorrowRim_BonewalkerQuality_Legendary;
    }
}
