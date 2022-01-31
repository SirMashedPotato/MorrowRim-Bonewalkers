using Verse;

namespace MorrowRim_Bonewalkers
{
    class DamageWorker_BonewalkerBlunt : DamageWorker_Blunt
    {
        protected override BodyPartRecord ChooseHitPart(DamageInfo dinfo, Pawn pawn)
        {
            DamageWorker_Utility.DoImbumentDamage(dinfo, pawn);
            return base.ChooseHitPart(dinfo, pawn);
        }
    }
}
