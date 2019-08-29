using UnityEngine;

namespace State.Active
{
    [RequireComponent(typeof(ActiveManager))]
    public abstract class ActiveGate : MonoBehaviour
    {
        public ActiveManager ActiveManager { get; private set; }

        [Tooltip("This flag causes a false check to supersede all other gates.")]
        public bool Veto = false;

        public abstract bool? Check();
        public virtual void Register(ActiveManager manager) 
        {
            ActiveManager = manager;
        }

        public virtual void DidRegister() {}

        public virtual void Unregister() {}

        public virtual void WillUnregister() {}

        public void RequestCheck() => ActiveManager.Check();
    }
}