using System;
using Verse;
using RimWorld;

namespace MorrowRim_Bonewalkers
{
    class Verb_CastAbilityTouch_BonewalkerResurrect : Verb_CastAbilityTouch
    {
        public override bool ValidateTarget(LocalTargetInfo target, bool showMessages = true)
        {
            return base.ValidateTarget(target, showMessages) && BonewalkerUtility.CorpseIsBonewalker(target.Thing);
        }
    }
}
