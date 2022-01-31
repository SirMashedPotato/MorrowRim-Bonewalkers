using System;
using Verse;
using RimWorld;

namespace MorrowRim_Bonewalkers
{
    class Thought_Situational_Precept_BonewalkersInColony : Thought_Situational
    {
        public override float MoodOffset()
        {
            return this.BaseMoodOffset * (float)BonewalkerUtility.BonewalkersInFaction(this.pawn.Faction);
        }
    }
}



