using Verse;
using RimWorld;

namespace MorrowRim_Bonewalkers
{
    public class CompProperties_UseEffectKnowledgeBook : CompProperties_UseEffect
    {
        public CompProperties_UseEffectKnowledgeBook()
        {
            this.compClass = typeof(CompUseEffect_KnowledgeBook);
        }
        public HediffDef hediffDef;
    }
}
