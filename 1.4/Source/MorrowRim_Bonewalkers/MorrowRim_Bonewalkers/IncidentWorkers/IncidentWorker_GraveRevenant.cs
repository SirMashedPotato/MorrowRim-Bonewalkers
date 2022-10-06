using System;
using System.Collections.Generic;
using UnityEngine;
using Verse;
using RimWorld;
using System.Reflection.Emit;
using System.Linq;
using System.Text;

namespace MorrowRim_Bonewalkers
{
    class IncidentWorker_GraveRevenant : IncidentWorker
    {
        protected override bool CanFireNowSub(IncidentParms parms)
        {
            Pawn p = GetBonewalker(parms);
            return base.CanFireNowSub(parms) && p != null && !IsSafe(p) && ModSettingsUtility.MorrowRim_BonewalkerSetting_GraveRevenantEnabled();
        }

        protected override bool TryExecuteWorker(IncidentParms parms)
        {
            Map map = (Map)parms.target;

            //the original one, only targets a single pawn
            if (ModSettingsUtility.MorrowRim_BonewalkerSetting_GraveRevenantVersion())
            {
                Pawn bonewalker = GetBonewalker(parms);
                if (bonewalker != null && !IsSafe(bonewalker))
                {
                    bonewalker.health.AddHediff(HediffDefOf.MorrowRim_GraveRevenant);
                    bonewalker.mindState.mentalStateHandler.TryStartMentalState(MentalStateDefOf.ManhunterPermanent, null, true, false, null, true, false, false);
                    Find.LetterStack.ReceiveLetter("MorrowRim_BonewalkerGraveRevenant_LetterLabel".Translate(bonewalker).CapitalizeFirst(), "MorrowRim_BonewalkerGraveRevenant_LetterText".Translate(bonewalker), base.def.letterDef, bonewalker, null, null);
                    return true;
                }
            }

            //new one, affects a percentage of all on the map
            else
            {
                List<Pawn> targets = BonewalkerUtility.BonewalkersInMap(map);
                int num = targets.Count;
                if(num > 0)
                {
                    List<Pawn> affected = new List<Pawn> { };
                    float targetNum = num * ModSettingsUtility.MorrowRim_BonewalkerSetting_GraveRevenantPrecentage();
                    int countLeft = (int)targetNum;
                    if (countLeft < 1) countLeft = 1;
                    while(countLeft > 0)
                    {
                        if (targets.Count <= 0)
                        {
                            break;
                        }

                        Pawn p = targets.RandomElement();
                        if(p.health.hediffSet.GetFirstHediffOfDef(HediffDefOf.MorrowRim_GraveRevenant) == null)
                        {
                            p.health.AddHediff(HediffDefOf.MorrowRim_GraveRevenant);
                            p.mindState.mentalStateHandler.TryStartMentalState(MentalStateDefOf.ManhunterPermanent, null, true, false, null, true, false, false);
                            affected.Add(p);
                            countLeft--;
                        }
                        targets.Remove(p);
                    }

                    if (affected.Count > 0)
                    {
                        if (affected.Count == 1)
                        {
                            Find.LetterStack.ReceiveLetter("MorrowRim_BonewalkerGraveRevenant_LetterLabel".Translate(affected[0]).CapitalizeFirst(), "MorrowRim_BonewalkerGraveRevenant_LetterText".Translate(affected[0]), base.def.letterDef, affected[0], null, null);
                        }
                        else
                        {
                            StringBuilder stringBuilder = new StringBuilder();
                            for (int i = 0; i < affected.Count; i++)
                            {
                                if (stringBuilder.Length != 0)
                                {
                                    stringBuilder.AppendLine();
                                }
                                stringBuilder.Append("  - " + affected[i].LabelNoCountColored.Resolve());
                            }
                            Find.LetterStack.ReceiveLetter("MorrowRim_BonewalkerGraveRevenant_LetterLabel_multi".Translate().CapitalizeFirst(), "MorrowRim_BonewalkerGraveRevenant_LetterText_multi".Translate(affected.Count, stringBuilder), base.def.letterDef, affected, null, null);
                        }
                        return true;
                    }
                }
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
