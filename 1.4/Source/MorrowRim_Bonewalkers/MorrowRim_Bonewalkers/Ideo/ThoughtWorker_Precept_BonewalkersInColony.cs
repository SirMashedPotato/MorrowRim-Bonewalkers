using System;
using Verse;
using RimWorld;

namespace MorrowRim_Bonewalkers
{
    class ThoughtWorker_Precept_BonewalkersInColony : ThoughtWorker_Precept
    {
        protected override ThoughtState ShouldHaveThought(Pawn p)
        {
            return p.IsColonist && !p.IsSlave && !p.IsPrisoner && BonewalkerUtility.BonewalkersInFaction(p.Faction) > 0;
        }
    }
}