using RimWorld;

namespace MorrowRim_Bonewalkers
{
    class CompProperties_BonewalkerPacifyMass : CompProperties_AbilityEffect
    {
        public CompProperties_BonewalkerPacifyMass()
        {
            this.compClass = typeof(CompAbilityEffect_BonewalkerPacifyMass);
        }

        public float minSensitivty = 1.3f;
    }
}
