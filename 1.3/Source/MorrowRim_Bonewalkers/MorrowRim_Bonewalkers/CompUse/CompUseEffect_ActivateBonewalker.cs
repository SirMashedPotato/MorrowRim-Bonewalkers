using System;
using Verse;
using RimWorld;
using System.Linq;
using System.Collections.Generic;

namespace MorrowRim_Bonewalkers
{
    class CompUseEffect_ActivateBonewalker : CompUseEffect
    {
		public CompProperties_UseEffect_ActivateBonewalker Props
		{
			get
			{
				return (CompProperties_UseEffect_ActivateBonewalker)this.props;
			}
		}

        public override void DoEffect(Pawn usedBy)
        {
            base.DoEffect(usedBy);
			if (this.Props.pawnKind != null)
			{
				Pawn servant = PawnGenerator.GeneratePawn(this.Props.pawnKind, Props.playerFaction? usedBy.Faction : null);
				PawnUtility.TrySpawnHatchedOrBornPawn(servant, parent);

                //Imbuements
                if (Props.addImbuement)
                {
					var imbuementProps = PawnProperties.Get(servant.def);
					if(imbuementProps != null)
                    {
						servant.health.AddHediff(imbuementProps.imbuements.RandomElement());
                    }
                }
                //Fully train
                if (Props.fullyTrain) BonewalkerUtility.TrainServant(servant);

				//Bond
				if (this.Props.bond) servant.relations.AddDirectRelation(PawnRelationDefOf.Bond, usedBy);

                //Quality
                if (Props.qualityHediff != null)
                {
					SetQuality(servant, usedBy);

				}

				//Awakening
				if (this.Props.awakeningHediff != null)
				{
					servant.health.AddHediff(this.Props.awakeningHediff).Severity = 0.9f;
				}

				//Additional hediffs
				if (!this.Props.additionalHediffs.NullOrEmpty())
				{
					foreach(HediffDef hediff in Props.additionalHediffs)
                    {
						servant.health.AddHediff(hediff);
                    }
				}

				//Hediffs given by ideo precepts
				if(ModsConfig.IdeologyActive && Props.ideoPreceptNames != null && Props.ideoHediffNames != null)
                {
					for (int i = 0; i < Props.ideoPreceptNames.Count; i++)
					{
						if (usedBy.ideo.Ideo.PreceptsListForReading.Where(x => x.def.defName == Props.ideoPreceptNames[i]).Any())
						{
							servant.health.AddHediff(Props.ideoHediffNames[i]);
							break;
						}
					}
                }
				foreach(ConceptDef cd in Props.conceptDefs)
                {
					LessonAutoActivator.TeachOpportunity(cd, OpportunityType.Important);
				}
			}
		}

		public void SetQuality(Pawn servant, Pawn usedBy)
		{
			HediffDef defToAdd = Props.qualityHediff;

			//getting, and turning into a percentage
			parent.TryGetQuality(out QualityCategory qc);
			float q = (float)qc;
			q /= 10f;

			//Check optionals
			if (Props.qualityBackstoryName != null)
            {
				if(usedBy.story.GetBackstory(BackstorySlot.Adulthood) != null && usedBy.story.GetBackstory(BackstorySlot.Adulthood).identifier.ToString() == Props.qualityBackstoryName)
                {
					q += 0.1f;  //Add one quality level to q
				}
			}

            if (ModsConfig.IdeologyActive)
            {
				if (Props.qualityIdeoRoleName != null)
				{
					Precept_Role role = usedBy.Ideo.GetRole(usedBy);
					if (role != null && role.def.defName == Props.qualityIdeoRoleName)
					{
						q += 0.1f;  //Add one quality level to q
					}
				}
				if(Props.qualityIdeoPreceptName != null)
                {
					if(usedBy.ideo.Ideo.PreceptsListForReading.Where(x=>x.def.defName == Props.qualityIdeoPreceptName).Any())
					{
						q += 0.1f;  //Add one quality level to q
                    }
                }
			}

			q += Props.additionalQualityLevels;

			if (q >= 0.7f && Props.legendaryQualityHediff != null)
			{
				defToAdd = Props.legendaryQualityHediff;
				q -= 0.6f;
			}
			servant.health.AddHediff(defToAdd).Severity = q + 0.1f;
		}
	}
}
