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
        // we wanna be able to disable this.
        public override bool CanBeDisabled => true;

        // harmony is not harmony to learn.
        private static void Postfix(AvatarUserReferenceAssigner __instance, SyncRefList<IField<string>> ___LabelTargets)
        {
            // this version of enabled comes from the monkey itself, rather than a config. (it's why we set `CanBeDisabled` above!)
            // you could create a general `Enabled` toggle under ur config but that's the RML way to do it.
            if (!Enabled)
            {
                return;
            }

            // harmony fixez.
            if (___LabelTargets == null)
            {
                //Logger.Error(() => "Label targets == null!!");
                return;
            }

            // name people "john resonite".
            foreach (IField<string> target in ___LabelTargets)
            {
                if (target != null)
                {
                    // `ConfigSection` comes from the fact we're using `ConfiguredResoniteMonkey<T, C>`
                    // if for some reason you're not: apparently there's a way to access configs, see:
                    // https://resonitemoddinggroup.github.io/MonkeyLoader.GamePacks.Resonite/docs/configuration.html
                    // but i couldn't get it to work.
                    // just use this method, it's even recommended!
                    target.Value = ConfigSection.UserName;
                }
            }
        }
    }
}
