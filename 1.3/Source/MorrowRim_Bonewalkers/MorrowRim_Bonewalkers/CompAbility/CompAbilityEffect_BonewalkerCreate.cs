using Verse;
using RimWorld;
using UnityEngine;

namespace MorrowRim_Bonewalkers
{
    class CompAbilityEffect_BonewalkerCreate : CompAbilityEffect
    {
        public new CompProperties_BonewalkerCreate Props
        {
            get
            {
                return (CompProperties_BonewalkerCreate)this.props;
            }
        }

        public override bool GizmoDisabled(out string reason)
        {
            if(Props.requriedResearch != null && !Props.requriedResearch.IsFinished)
            {
                reason = "MorrowRim_Bonewalker_NeedResearch".Translate(Props.requriedResearch.label);
                return true;
            }
            return base.GizmoDisabled(out reason);
        }

        public override void Apply(LocalTargetInfo target, LocalTargetInfo dest)
        {
            Corpse c = target.Thing as Corpse;
            Pawn user = parent.pawn;
            if (c != null)
            {
                float quality = (user.skills.GetSkill(Props.skill).Level - 5) / 5;

                if (this.Props.pawnKind != null)
                {
                    Pawn servant = PawnGenerator.GeneratePawn(this.Props.pawnKind, Props.playerFaction ? user.Faction : null);
                    PawnUtility.TrySpawnHatchedOrBornPawn(servant, user);

                    //Imbuements
                    if (Props.addImbuement)
                    {
                        var imbuementProps = PawnProperties.Get(servant.def);
                        if (imbuementProps != null)
                        {
                            servant.health.AddHediff(imbuementProps.imbuements.RandomElement());
                        }
                    }
                    //Fully train
                    if (Props.fullyTrain) BonewalkerUtility.TrainServant(servant);

                    //Bond
                    if (this.Props.bond) servant.relations.AddDirectRelation(PawnRelationDefOf.Bond, user);

                    //Quality
                    if (Props.qualityHediff != null)
                    {
                        servant.health.AddHediff(Props.qualityHediff).Severity = (quality / 10) + 0.1f;

                    }

                    //Awakening
                    if (this.Props.awakeningHediff != null)
                    {
                        servant.health.AddHediff(this.Props.awakeningHediff).Severity = 0.9f;
                    }

                    //Additional hediffs
                    if (!this.Props.additionalHediffs.NullOrEmpty())
                    {
                        foreach (HediffDef hediff in Props.additionalHediffs)
                        {
                            servant.health.AddHediff(hediff);
                        }
                    }

                    //Finish up
                    FilthMaker.TryMakeFilth(c.Position, c.Map, RimWorld.ThingDefOf.Filth_Ash, 3);
                    FilthMaker.TryMakeFilth(c.Position, c.Map, RimWorld.ThingDefOf.Filth_CorpseBile, 3);
                    FleckMaker.AttachedOverlay(c, FleckDefOf.DustPuffThick, Vector3.zero, 10, -1);
                    c.Destroy();
                }
            }
        }
    }
}
