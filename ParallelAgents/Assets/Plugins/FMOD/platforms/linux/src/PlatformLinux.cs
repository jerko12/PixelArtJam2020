using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

#if UNITY_STANDALONE_LINUX && !UNITY_EDITOR
namespace FMOD
{
    public partial class VERSION
    {
        public const string dll = "fmodstudio" + dllSuffix;
    }
}

namespace FMOD.Studio
{
    public partial class STUDIO_VERSION
    {
        public const string dll = "fmodstudio" + dllSuffix;
    }
}
#endif

namespace FMODUnity
{
#if UNITY_EDITOR
    [InitializeOnLoad]
#endif
    public class PlatformLinux : Platform
    {
        static PlatformLinux()
        {
            Settings.AddPlatformTemplate<PlatformLinux>("b7716510a1f36934c87976f3a81dbf3d");
        }

        public override string DisplayName { get { return "Linux"; } }
        public override void DeclareUnityMappings(Settings settings)
        {
            settings.DeclareRuntimePlatform(RuntimePlatform.LinuxPlayer, this);

#if UNITY_EDITOR
            settings.DeclareBuildTarget(BuildTarget.StandaloneLinux64, this);
#if !UNITY_2019_2_OR_NEWER
            settings.DeclareBuildTarget(BuildTarget.StandaloneLinux, this);
            settings.DeclareBuildTarget(BuildTarget.StandaloneLinuxUniversal, this);
#endif
#endif
        }

#if UNITY_EDITOR
        public override Legacy.Platform LegacyIdentifier { get { return Legacy.Platform.Linux; } }
#endif

        public override string GetPluginPath(string pluginName)
        {
            return StaticGetPluginPath(GetEditorPluginBasePath(), pluginName);
        }

        public static string StaticGetPluginPath(string basePath, string pluginName)
        {
            if (System.IntPtr.Size == 8)
            {
                return string.Format("{0}/linux/x86_64/lib{1}.so", basePath, pluginName);
            }
            else
            {
                return string.Format("{0}/linux/x86/lib{1}.so", basePath, pluginName);
            }
        }
    }
}
