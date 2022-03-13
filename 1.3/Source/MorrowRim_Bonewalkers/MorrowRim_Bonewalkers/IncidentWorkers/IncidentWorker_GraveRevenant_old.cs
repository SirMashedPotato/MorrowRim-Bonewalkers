using System;
using System.Collections.Generic;
using UnityEngine;
using Verse;
using RimWorld;
using System.Reflection.Emit;
using System.Linq;

namespace MorrowRim_Bonewalkers
{
    class IncidentWorker_GraveRevenant_old : IncidentWorker
    {
        protected override bool CanFireNowSub(IncidentParms parms)
        {
            Pawn p = GetBonewalker(parms);
            return base.CanFireNowSub(parms) && p != null && !IsSafe(p);
        }

        protected override bool TryExecuteWorker(IncidentParms parms)
        {
            Map map = (Map)parms.target;
            Pawn bonewalker = GetBonewalker(parms);
            if(bonewalker != null && !IsSafe(bonewalker))
            {
                bonewalker.health.AddHediff(HediffDefOf.MorrowRim_GraveRevenant);
                bonewalker.mindState.mentalStateHandler.TryStartMentalState(MentalStateDefOf.ManhunterPermanent, null, true, false, null, true, false, false);
                Find.LetterStack.ReceiveLetter("MorrowRim_BonewalkerGraveRevenant_LetterLabel".Translate(bonewalker).CapitalizeFirst(), "MorrowRim_BonewalkerGraveRevenant_LetterText".Translate(bonewalker), base.def.letterDef, bonewalker, null, null);
            }
            return false;
        }

        public Pawn GetBonewalker(IncidentParms parms)
        {
            Map map = parms.target as Map;
            List<Pawn> bonewalkers = map.mapPawns.AllPawnsSpawned.Where(x => x.def.tradeTags != null && x.def.tradeTags.Contains("MorrowRim_Bonewalker")).ToList();
            return bonewalkers.NullOrEmpty() ? null : bonewalkers.RandomElement();
        }

        public bool IsSafe(Pawn p)
        {
            return p.Faction.ideos.PrimaryIdeo.PreceptsListForReading.Where(x => x.def.defName == "MorrowRim_BonewalkerSupremecy_Intelligence").Any();
        }
    }
}
