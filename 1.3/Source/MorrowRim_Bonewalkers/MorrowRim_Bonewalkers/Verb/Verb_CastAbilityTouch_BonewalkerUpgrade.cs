using System;
using Verse;
using RimWorld;

namespace MorrowRim_Bonewalkers
{
    class Verb_CastAbilityTouch_BonewalkerUpgrade : Verb_CastAbilityTouch_Bonewalker
    {
        public override bool ValidateTarget(LocalTargetInfo target, bool showMessages = true)
        {
            return base.ValidateTarget(target, showMessages) && BonewalkerUtility.CanBeUpgraded(target.Pawn);
        }
    }
}
