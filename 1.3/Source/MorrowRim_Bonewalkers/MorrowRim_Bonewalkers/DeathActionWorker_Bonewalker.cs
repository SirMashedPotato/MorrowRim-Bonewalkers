using Verse;
using RimWorld;
using UnityEngine;

namespace MorrowRim_Bonewalkers
{
    class DeathActionWorker_Bonewalker : DeathActionWorker
    {

        public override void PawnDied(Corpse corpse)
        {
            if(corpse != null && corpse.Map != null)
            {
                var rot = corpse.GetComp<CompRottable>();
                rot.RotProgress = rot.PropsRot.TicksToDessicated;

                FilthMaker.TryMakeFilth(corpse.Position, corpse.Map, RimWorld.ThingDefOf.Filth_Ash, 3);
                FilthMaker.TryMakeFilth(corpse.Position, corpse.Map, RimWorld.ThingDefOf.Filth_CorpseBile, 1);
                FleckMaker.AttachedOverlay(corpse, FleckDefOf.DustPuffThick, Vector3.zero, 10, -1);
            }
        }
    }
}
