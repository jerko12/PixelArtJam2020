using System;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

#if UNITY_ANDROID && !UNITY_EDITOR
namespace FMOD
{
    public partial class VERSION
    {
        public const string dll = "fmod" + dllSuffix;
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
    public class PlatformAndroid : Platform
    {
        static PlatformAndroid()
        {
            Settings.AddPlatformTemplate<PlatformAndroid>("2fea114e74ecf3c4f920e1d5cc1c4c40");
        }

        public override string DisplayName { get { return "Android"; } }
        public override void DeclareUnityMappings(Settings settings)
        {
            settings.DeclareRuntimePlatform(RuntimePlatform.Android, this);

#if UNITY_EDITOR
            settings.DeclareBuildTarget(BuildTarget.Android, this);
#endif
        }

#if UNITY_EDITOR
        public override Legacy.Platform LegacyIdentifier { get { return Legacy.Platform.Android; } }
#endif

        public override string GetBankFolder()
        {
            if (System.IO.Path.GetExtension(Application.dataPath) == ".apk")
            {
                return "file:///android_asset";
            }
            else
            {
                return string.Format("jar:file://{0}!/assets", Application.dataPath);
            }
        }

        public override string GetPluginPath(string pluginName)
        {
            return StaticGetPluginPath(pluginName);
        }

        public static string StaticGetPluginPath(string pluginName)
        {
            return string.Format("lib{0}.so", pluginName);
        }
    }
}
