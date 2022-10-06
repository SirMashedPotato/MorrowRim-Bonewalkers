using System;
using Verse;
using RimWorld;

namespace MorrowRim_Bonewalkers
{
    class Verb_CastAbilityTouch_BonewalkerPacify : Verb_CastAbilityTouch_Bonewalker
    {
        public override bool ValidateTarget(LocalTargetInfo target, bool showMessages = true)
        {
            return base.ValidateTarget(target, showMessages) && BonewalkerUtility.IsPosessed(target.Pawn);
        }
    }
}
