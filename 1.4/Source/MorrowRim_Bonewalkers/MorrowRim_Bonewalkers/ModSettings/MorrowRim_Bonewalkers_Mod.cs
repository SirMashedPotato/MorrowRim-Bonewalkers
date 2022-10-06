using UnityEngine;
using Verse;
using System;

namespace MorrowRim_Bonewalkers
{
    class MorrowRim_Bonewalkers_Mod : Mod
    {
        MorrowRim_Bonewalkers_ModSettings settings;
        public MorrowRim_Bonewalkers_Mod(ModContentPack contentPack) : base(contentPack)
        {
            this.settings = GetSettings<MorrowRim_Bonewalkers_ModSettings>();
        }

        public override string SettingsCategory() => "MorrowRim_Bonewalker_ModName".Translate();

        public override void DoSettingsWindowContents(Rect inRect)
        {
            Listing_Standard listing_Standard = new Listing_Standard();
            listing_Standard.Begin(inRect);

            listing_Standard.CheckboxLabeled("MorrowRim_BonewalkerSetting_GraveRevenantEnabled".Translate(), ref settings.MorrowRim_BonewalkerSetting_GraveRevenantEnabled);
            listing_Standard.Gap();

            listing_Standard.CheckboxLabeled("MorrowRim_BonewalkerSetting_GraveRevenantVersion".Translate(), ref settings.MorrowRim_BonewalkerSetting_GraveRevenantVersion);
            listing_Standard.Gap();

            listing_Standard.Label("MorrowRim_BonewalkerSetting_GraveRevenantPrecentage".Translate() + " (" + settings.MorrowRim_BonewalkerSetting_GraveRevenantPrecentage * 100 + "%)");
            settings.MorrowRim_BonewalkerSetting_GraveRevenantPrecentage = (float)Math.Round(listing_Standard.Slider(settings.MorrowRim_BonewalkerSetting_GraveRevenantPrecentage, 0.05f, 1f) * 20) / 20;
            listing_Standard.Gap();

            Rect rectDefault = listing_Standard.GetRect(30f);
            TooltipHandler.TipRegion(rectDefault, "ESCP_Reset".Translate());
            if (Widgets.ButtonText(rectDefault, "ESCP_Reset".Translate(), true, true, true))
            {
                MorrowRim_Bonewalkers_ModSettings.ResetSettings(settings);
            }

            listing_Standard.End();
            base.DoSettingsWindowContents(inRect);
        }
    }
}
