using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace FMODUnity
{
    public class PlatformDefault : Platform
    {
        public PlatformDefault()
        {
            Identifier = ConstIdentifier;
        }

        public const string ConstIdentifier = "default";

        public override string DisplayName { get { return "Default Settings"; } }
        public override void DeclareUnityMappings(Settings settings) { }
#if UNITY_EDITOR
        public override Legacy.Platform LegacyIdentifier { get { return Legacy.Platform.Default; } }
#endif

        public override bool IsIntrinsic { get { return true; } }

        protected override void InitializeProperties()
        {
            base.InitializeProperties();

            ParentIdentifier = null;
            PropertyAccessors.Plugins.Set(this, new List<string>());
        }
    }
}
