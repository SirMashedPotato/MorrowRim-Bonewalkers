using HarmonyLib;
using RimWorld;
using System.Reflection;
using Verse;
using System.Collections.Generic;
using System.Linq;

namespace MorrowRim_Bonewalkers
{
    [StaticConstructorOnStartup]
    public class Main
    {
        static Main()
        {
            var harmony = new Harmony("com.SirMashedPotato.MorrowRim.Bonewalkers");
            harmony.PatchAll(Assembly.GetExecutingAssembly());
        }
    }

    [HarmonyPatch(typeof(IncidentWorker_Disease))]
    [HarmonyPatch("PotentialVictims")]
    public static class IncidentWorker_Disease_PotentialVictims_Patch
    {
        [HarmonyPostfix]
        public static void Bonewalkers_PreventDiseaseInfection_Patch(ref IEnumerable<Pawn> __result)
        {
            List<Pawn> toRemove = new List<Pawn> { };
            foreach (Pawn p in __result)
            {
                var props = PawnProperties.Get(p.def);
                if (props != null && props.preventDisease)
                {
                    toRemove.Add(p);
                }
            }
            if (!toRemove.NullOrEmpty())
            {
                List<Pawn> temp = __result.ToList();
                foreach (Pawn p in toRemove)
                {
                    temp.Remove(p);
                }
                __result = temp;
            }
        }
    }

    [HarmonyPatch(typeof(Pawn_TrainingTracker))]
    [HarmonyPatch("TrainingTrackerTickRare")]
    public static class Pawn_TrainingTrackerTickRare_Patch
    {
        [HarmonyPrefix]
        public static bool Bonewalkers_PreventTrainingDecayPatch(ref Pawn ___pawn)
        {
            var props = PawnProperties.Get(___pawn.def);
            if (props != null && props.preventTrainingDecay)
            {
                return false;
            }
            return true;
        }
    }

    [HarmonyPatch(typeof(HediffComp_Infecter))]
    [HarmonyPatch("CheckMakeInfection")]
    public static class HediffComp_Infecter_CheckMakeInfection_Patch
    {
        [HarmonyPrefix]
        public static bool Bonewalkers_PreventWoundInfectionPatch(ref HediffComp_Infecter __instance)
        {
            var props = PawnProperties.Get(__instance.Pawn.def);
            if (props != null && props.preventWoundInfection)
            {
                return false;
            }
            return true;
        }
    }
}
