using Verse;

namespace MorrowRim_Bonewalkers
{
    class DamageWorker_BonewalkerBite : DamageWorker_Bite
    {
        protected override BodyPartRecord ChooseHitPart(DamageInfo dinfo, Pawn pawn)
        {
            DamageWorker_Utility.DoImbumentDamage(dinfo, pawn);
            return base.ChooseHitPart(dinfo, pawn);
        }
    }
}
