using Verse;
using RimWorld;
using System.Collections.Generic;

namespace MorrowRim_Bonewalkers
{
    public class CompProperties_UseEffect_ActivateBonewalker : CompProperties_UseEffect
    {
        public CompProperties_UseEffect_ActivateBonewalker()
        {
            this.compClass = typeof(CompUseEffect_ActivateBonewalker);
        }

        public PawnKindDef pawnKind;
        public bool playerFaction = true;
        public bool addImbuement = true;
        public bool fullyTrain = true;
        public bool bond = false;

        //Quality stuff
        public string qualityIdeoRoleName = null;       //increases the quality by 1 when activated by a pawn with this role
        public string qualityIdeoPreceptName = null;    //hopefully you get the idea
        public List<HediffDef> qualityHediffDefs;       //Specifically for the activator
        public HediffDef qualityHediff = null;
        public HediffDef legendaryQualityHediff = null;

        public HediffDef awakeningHediff = null;
        public List<HediffDef> additionalHediffs;

        public List<string> ideoPreceptNames;
        public List<HediffDef> ideoHediffNames;

        public List<ConceptDef> conceptDefs;

        public float additionalQualityLevels = 0;   //Float so don't set to stuff like 1 or 5, use 0.1 or 0.5

    }
}
