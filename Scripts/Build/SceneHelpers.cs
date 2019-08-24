using System;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Scripts.Build
{
    public static class SceneHelpers
    {
        public static void EditorConfirmExists<TSelf>() where TSelf : Component
        {
            if (!Application.isEditor) return;
            var obj = Object.FindObjectOfType<TSelf>();
            if (!obj) Debug.LogError($"Could not find instance of {typeof(TSelf)}");
        }
        
        public static bool FindAndAttach<TSelf, TTarget>() where TTarget : Component where TSelf : Component
        {
            Debug.Log($"Attempting to find and attach {typeof(TSelf)} to {typeof(TTarget)}");
            var obj = Object.FindObjectOfType<TTarget>()?.gameObject;
            if (obj == null)
            {
                Debug.LogWarning($"Could not find instance of {typeof(TTarget)}");
                return false;
            }
            var existing = obj.GetComponent<TSelf>();
            if (existing != null)
            {
                Debug.Log($"Pre-existing instance of {typeof(TSelf)} on {typeof(TTarget)}");
                return false;
            }
            obj.AddComponent<TSelf>();
            Debug.LogWarning($"Added new instance of {typeof(TSelf)} to {typeof(TTarget)}");
            return true;
        }
    }
}