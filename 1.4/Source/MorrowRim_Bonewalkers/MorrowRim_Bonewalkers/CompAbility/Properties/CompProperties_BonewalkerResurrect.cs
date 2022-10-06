using RimWorld;
using Verse;

namespace MorrowRim_Bonewalkers
{
    class CompProperties_BonewalkerResurrect : CompProperties_AbilityEffect
    {
        public CompProperties_BonewalkerResurrect()
        {
            this.compClass = typeof(CompAbilityEffect_BonewalkerResurrect);
        }

        public HediffDef ressurectionhediff;
        public float severity = 0.9f;   //don't set to 1f, just kills the pawn again
    }
}
