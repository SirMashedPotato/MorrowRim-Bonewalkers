using Verse;
using RimWorld;
using UnityEngine;

namespace MorrowRim_Bonewalkers
{
    public class DeathActionWorker_DessicateOnDeath : DeathActionWorker
    {

        public override void PawnDied(Corpse corpse)
        {
            if (corpse != null && corpse.Map != null)
            {
                var rot = corpse.GetComp<CompRottable>();
                if(rot != null)
                {
                    rot.RotProgress = rot.PropsRot.TicksToDessicated;
                    if (corpse.InnerPawn.def.race.BloodDef != null)
                    {
                        FilthMaker.TryMakeFilth(corpse.Position, corpse.Map, corpse.InnerPawn.def.race.BloodDef, 3);
                    }
                    FleckMaker.AttachedOverlay(corpse, FleckDefOf.DustPuffThick, Vector3.zero, corpse.InnerPawn.RaceProps.baseBodySize*2, -1);
                }
            }
        }
    }
}
