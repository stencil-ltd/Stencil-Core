#if STENCIL_FIREBASE
using Binding;
using Firebase.RemoteConfig;
using UnityEngine;
using UnityEngine.UI;

namespace Dev
{
    [RequireComponent(typeof(Text))]
    public class RemoteConfigText : MonoBehaviour
    {
        public string Key;
        
        [Bind] private Text _text;

        private void Awake()
        {
            this.Bind();
        }
        
        private void Update()
        {
            _text.text = $"{Key}: {FirebaseRemoteConfig.GetValue(Key).StringValue}";
        }
    }
}
#endif