using FrooxEngine;
using FrooxEngine.CommonAvatar;
using FrooxEngine.ProtoFlux;
using HarmonyLib;
using MonkeyLoader.Patching;
using MonkeyLoader.Resonite;
using System.Collections.Generic;

namespace JohnResoniteMod
{
    [HarmonyPatchCategory(nameof(AURA_Patch))]
    [HarmonyPatch(typeof(AvatarNameTagAssigner), "SetLabel")]
    internal class AURA_Patch : ConfiguredResoniteMonkey<AURA_Patch, JohnResoniteConfig>
    {
        public override bool CanBeDisabled => true;

        private static void Postfix(AvatarUserReferenceAssigner __instance, SyncRefList<IField<string>> ___LabelTargets)
        {
            if (!Enabled)
            {
                return;
            }

            if (___LabelTargets == null)
            {
                //Logger.Error(() => "Label targets == null!!");
                return;
            }

            foreach (IField<string> target in ___LabelTargets)
            {
                if (target != null)
                {
                    target.Value = ConfigSection.UserName;
                }
            }
        }
    }
}
