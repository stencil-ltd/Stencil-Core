using UnityEngine;

namespace UI
{
    public abstract class RegisterableBehaviour : MonoBehaviour
    {
        [HideInInspector]
        public bool Registered;
        [HideInInspector]
        public bool Unregistered;
        
        public virtual void Register() {}
        public virtual void DidRegister() {}
        
        public virtual void Unregister() {}        
        public virtual void WillUnregister() {}
    }
}
