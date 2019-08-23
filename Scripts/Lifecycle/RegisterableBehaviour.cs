using UnityEngine;

namespace UI
{
    public abstract class RegisterableBehaviour : MonoBehaviour
    {
        public bool Registered;
        public bool Unregistered;
        
        public virtual void Register() {}
        public virtual void DidRegister() {}
        
        public virtual void Unregister() {}        
        public virtual void WillUnregister() {}
    }
}
