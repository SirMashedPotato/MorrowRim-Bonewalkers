using Verse;

namespace MorrowRim_Bonewalkers
{
    class MorrowRim_Bonewalkers_ModSettings : ModSettings
    {
        //settings
        public bool MorrowRim_BonewalkerSetting_GraveRevenantEnabled = MorrowRim_BonewalkerSetting_GraveRevenantEnabled_def;
        public bool MorrowRim_BonewalkerSetting_GraveRevenantVersion = MorrowRim_BonewalkerSetting_GraveRevenantVersion_def;
        public float MorrowRim_BonewalkerSetting_GraveRevenantPrecentage = MorrowRim_BonewalkerSetting_GraveRevenantPrecentage_def;

        //defaults
        private static readonly bool MorrowRim_BonewalkerSetting_GraveRevenantEnabled_def = true;
        private static readonly bool MorrowRim_BonewalkerSetting_GraveRevenantVersion_def = false;
        private static readonly float MorrowRim_BonewalkerSetting_GraveRevenantPrecentage_def = 0.35f;

        public override void ExposeData()
        {
            Scribe_Values.Look(ref MorrowRim_BonewalkerSetting_GraveRevenantEnabled, "MorrowRim_BonewalkerSetting_GraveRevenantEnabled", MorrowRim_BonewalkerSetting_GraveRevenantEnabled_def);
            Scribe_Values.Look(ref MorrowRim_BonewalkerSetting_GraveRevenantVersion, "MorrowRim_BonewalkerSetting_GraveRevenantVersion", MorrowRim_BonewalkerSetting_GraveRevenantVersion_def);
            Scribe_Values.Look(ref MorrowRim_BonewalkerSetting_GraveRevenantPrecentage, "MorrowRim_BonewalkerSetting_GraveRevenantPrecentage", MorrowRim_BonewalkerSetting_GraveRevenantPrecentage_def);
        }

        public static void ResetSettings(MorrowRim_Bonewalkers_ModSettings settings)
        {
            settings.MorrowRim_BonewalkerSetting_GraveRevenantEnabled = MorrowRim_BonewalkerSetting_GraveRevenantEnabled_def;
            settings.MorrowRim_BonewalkerSetting_GraveRevenantVersion = MorrowRim_BonewalkerSetting_GraveRevenantVersion_def;
            settings.MorrowRim_BonewalkerSetting_GraveRevenantPrecentage = MorrowRim_BonewalkerSetting_GraveRevenantPrecentage_def;
        }
    }
}
