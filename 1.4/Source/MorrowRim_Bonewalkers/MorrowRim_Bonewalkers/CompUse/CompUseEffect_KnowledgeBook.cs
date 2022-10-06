using Verse;
using RimWorld;

namespace MorrowRim_Bonewalkers
{
    public class CompUseEffect_KnowledgeBook : CompUseEffect
	{
		public CompProperties_UseEffectKnowledgeBook Props
		{
			get
			{
				return (CompProperties_UseEffectKnowledgeBook)this.props;
			}
		}

		public override void DoEffect(Pawn usedBy)
		{
			base.DoEffect(usedBy);
			if (Props.hediffDef != null)
			{
				usedBy.health.AddHediff(Props.hediffDef);
				Messages.Message("MorrowRim_Bonewalker_KnowledgeGained".Translate(usedBy.Name, parent.Label), usedBy, MessageTypeDefOf.PositiveEvent);
			}
			parent.Destroy();
		}

        public override bool CanBeUsedBy(Pawn p, out string failReason)
        {
            if (Props.hediffDef != null && p.health.hediffSet.HasHediff(Props.hediffDef))
            {
				failReason = "MorrowRim_Bonewalker_BookAlreadyRead".Translate(p.Name);
				return false;
            }
            return base.CanBeUsedBy(p, out failReason);
        }
    }
}
