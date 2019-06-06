using Scripts.RemoteConfig;
using UnityEngine;

namespace Dev
{
    public class DevelopersOnly : MonoBehaviour
    {
        public bool UseRemoteConfig = false;
        
        private void Start()
        {
            
            if (!Developers.Enabled && (!UseRemoteConfig || StencilRemote.IsProd()))
                gameObject.SetActive(false);
        }
    }
}