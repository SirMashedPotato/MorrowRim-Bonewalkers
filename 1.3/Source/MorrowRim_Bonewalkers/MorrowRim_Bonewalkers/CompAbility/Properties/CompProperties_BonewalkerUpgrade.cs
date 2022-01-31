using RimWorld;
using Verse;


namespace MorrowRim_Bonewalkers
{
    class CompProperties_BonewalkerUpgrade : CompProperties_AbilityEffect
    {
        public CompProperties_BonewalkerUpgrade()
        {
            this.compClass = typeof(CompAbilityEffect_BonewalkerUpgrade);
        }

        public ResearchProjectDef requriedResearch;
    }
}
