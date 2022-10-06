using System;
using Verse;
using RimWorld;
using System.Linq;
using System.Collections.Generic;

namespace MorrowRim_Bonewalkers
{
    class CompProperties_BonewalkerCreate : CompProperties_AbilityEffect
    {
        public CompProperties_BonewalkerCreate()
        {
            this.compClass = typeof(CompAbilityEffect_BonewalkerCreate);
        }

        public SkillDef skill;
        public ResearchProjectDef requriedResearch;
        public PawnKindDef pawnKind;
        public bool playerFaction = true;
        public bool addImbuement = true;
        public bool fullyTrain = true;
        public bool bond = false;
        public HediffDef qualityHediff = null;
        public HediffDef awakeningHediff = null;
        public List<HediffDef> additionalHediffs = null;
    }
}
