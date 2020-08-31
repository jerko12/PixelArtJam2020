using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

#if !UNITY_EDITOR
namespace FMOD
{
    public partial class VERSION
    {
#if UNITY_STANDALONE_WIN
        public const string dll = "fmodstudio" + dllSuffix;
#elif UNITY_WSA
        public const string dll = "fmod" + dllSuffix;
#endif
    }
}

namespace FMOD.Studio
{
    public partial class STUDIO_VERSION
    {
#if UNITY_STANDALONE_WIN || UNITY_WSA
        public const string dll = "fmodstudio" + dllSuffix;
#endif
    }
}
#endif

namespace FMODUnity
{
#if UNITY_EDITOR
    [InitializeOnLoad]
#endif
    public class PlatformWindows : Platform
    {
        static PlatformWindows()
        {
            Settings.AddPlatformTemplate<PlatformWindows>("2c5177b11d81d824dbb064f9ac8527da");
        }

        public override string DisplayName { get { return "Windows"; } }
        public override void DeclareUnityMappings(Settings settings)
        {
            settings.DeclareRuntimePlatform(RuntimePlatform.WindowsPlayer, this);
            settings.DeclareRuntimePlatform(RuntimePlatform.WSAPlayerX86, this);
            settings.DeclareRuntimePlatform(RuntimePlatform.WSAPlayerX64, this);
            settings.DeclareRuntimePlatform(RuntimePlatform.WSAPlayerARM, this);

#if UNITY_EDITOR
            settings.DeclareBuildTarget(BuildTarget.StandaloneWindows, this);
            settings.DeclareBuildTarget(BuildTarget.StandaloneWindows64, this);
            settings.DeclareBuildTarget(BuildTarget.WSAPlayer, this);
#endif
        }

#if UNITY_EDITOR
        public override Legacy.Platform LegacyIdentifier { get { return Legacy.Platform.Windows; } }
#endif

#if UNITY_WINRT_8_1 || UNITY_WSA_10_0
        public override string GetBankFolder()
        {
            return "ms-appx:///Data/StreamingAssets";
        }
#endif

        public override string GetPluginPath(string pluginName)
        {
#if UNITY_STANDALONE_WIN
            return string.Format("{0}/{1}.dll", GetPluginBasePath(), pluginName);
#else // UNITY_WSA
            return string.Format("{0}.dll", pluginName);
#endif
        }
    }
}
