using System;
using Verse;
using RimWorld;

namespace MorrowRim_Bonewalkers
{
    class Verb_CastAbilityTouch_BonewalkerCreate : Verb_CastAbilityTouch
    {
        public override bool ValidateTarget(LocalTargetInfo target, bool showMessages = true)
        {
            return base.ValidateTarget(target, showMessages) && BonewalkerUtility.CorpseIsHumanlike(target.Thing);
        }
    }
}
