using System;
using Verse;
using RimWorld;
using System.Collections.Generic;
using System.Linq;

namespace MorrowRim_Bonewalkers
{
    public static class BonewalkerUtility
    {
        public static bool PawnIsBonewalker(Pawn p)
        {
            return p != null && !p.def.tradeTags.NullOrEmpty() && p.def.tradeTags.Contains("MorrowRim_Bonewalker");
        }

        public static bool CorpseIsBonewalker(Thing t)
        {
            return t is Corpse c && !c.InnerPawn.def.tradeTags.NullOrEmpty() && c.InnerPawn.def.tradeTags.Contains("MorrowRim_Bonewalker");
        }

        public static bool CorpseIsHumanlike(Thing t)
        {
            return t is Corpse c && c.InnerPawn.RaceProps.Humanlike;
        }

        public static bool CanBeUpgraded(Pawn p)
        {
            return p != null && (p.health.hediffSet.GetFirstHediffOfDef(HediffDefOf.MorrowRim_BonewalkerQuality) != null 
                || (p.health.hediffSet.GetFirstHediffOfDef(HediffDefOf.MorrowRim_BonewalkerQuality_Legendary) != null) 
                && p.health.hediffSet.GetFirstHediffOfDef(HediffDefOf.MorrowRim_BonewalkerQuality_Legendary).Severity < 1f);
        }

        public static bool CanShuffleImbuement(Pawn p)
        {
            if(p != null)
            {
                var props = PawnProperties.Get(p.def);
                return props != null && props.imbuements.Count > 1;
            }
            return false;
        }

        public static bool IsPosessed(Pawn p)
        {
            return p != null && p.health.hediffSet.GetFirstHediffOfDef(HediffDefOf.MorrowRim_GraveRevenant) != null;
        }

        public static void TrainServant(Pawn servant)
        {
            foreach (TrainableDef td in DefDatabase<TrainableDef>.AllDefs)
            {
                if (servant.training.CanAssignToTrain(td))
                {
                    servant.training.Train(td, null, true);
                }
            }
        }

        public static int BonewalkersInFaction(Faction faction)
        {
            if (faction == null)
            {
                return 0;
            }
            int num = 0;
            using (List<Pawn>.Enumerator enumerator = PawnsFinder.AllMaps_SpawnedPawnsInFaction(faction).GetEnumerator())
            {
                while (enumerator.MoveNext())
                {
                    if (PawnIsBonewalker(enumerator.Current))
                    {
                        num++;
                    }
                }
            }
            return num;
        }

        public static List<Pawn> BonewalkersInMap(Map map)
        {
            if (map == null)
            {
                return null;
            }
            List<Pawn> servants = new List<Pawn> { };
            using (List<Pawn>.Enumerator enumerator = map.mapPawns.AllPawnsSpawned.GetEnumerator())
            {
                while (enumerator.MoveNext())
                {
                    if (PawnIsBonewalker(enumerator.Current))
                    {
                        servants.Add(enumerator.Current);
                    }
                }
            }
            return servants;
        }
    }
}
