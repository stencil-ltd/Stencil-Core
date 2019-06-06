using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Util
{
    public static class Objects
    {
        [Obsolete]
        public static Animator Animator(this Component component) => component.GetComponent<Animator>();
        
        public static bool SetField<T>(
            this object any,
            ref T field,
            T value,
            [CanBeNull] IPropertyListener onChange = null)
        {
            if (EqualityComparer<T>.Default.Equals(field, value)) return false;
            field = value;
            onChange?.OnPropertyChanged();
            return true;
        }

        public static bool SetField<T>(
            this object any,
            ref T field,
            T value,
            ref bool dirtyFlag)
        {
            var retval = SetField(any, ref field, value);
            if (retval) dirtyFlag = true;
            return retval;
        }

        public static bool IsMainThread => UnityMainThreadDispatcher.IsMainThread;

        public static string ShortName(this Type t)
        {
            return t.Name.Split('.').Last();
        }
        
        public static void Configure()
        {
            new GameObject("Main Thread Dispatch")
                .AddComponent<UnityMainThreadDispatcher>();
        }
        
        public static void Enqueue(this object any, Action action)
        {
            Enqueue(action);
        }

        public static Coroutine StartCoroutine(IEnumerator coroutine)
        {
            return UnityMainThreadDispatcher.Instance().StartCoroutine(coroutine);
        }
        
        public static void StopCoroutine(Coroutine coroutine)
        {
            UnityMainThreadDispatcher.Instance().StopCoroutine(coroutine);
        }

        public static void OnMain(Action Action)
        {
            if (IsMainThread)
                Action();
            else Enqueue(Action);
        }
        
        public static void Enqueue(Action action)
        {
            UnityMainThreadDispatcher.Instance().Enqueue(action);
        }

        public static void Invoke<T>([CanBeNull] this EventHandler<T> handler, T obj)
        {
            handler?.Invoke(null, obj);    
        }
        
        public static void Invoke([CanBeNull] this EventHandler handler, object sender = null)
        {
            handler?.Invoke(sender, EventArgs.Empty);
        }

        public static T SafeDestroy<T>(T obj) where T : Object
        {
            if (Application.isEditor)
                Object.DestroyImmediate(obj);
            else
                Object.Destroy(obj);
     
            return null;
        } 
        
        public static T SafeDestroyGameObject<T>(T component) where T : Component
        {
            if (component != null)
                SafeDestroy(component.gameObject);
            return null;
        }
        
        public static void DestroyAllChildren(this Transform transform)
        {
            foreach (var child in transform.GetChildren())
                Object.Destroy(child.gameObject);
            transform.DetachChildren();
        }

        public static void DestroyAllChildren<T>(this Transform transform) where T : Component
        {
            foreach (var child in transform.GetChildren())
            {
                if (child.GetComponent<T>() != null)
                    Object.Destroy(child.gameObject);
            }
        }
        
        public static RectTransform[] GetChildren(this RectTransform transform)
        {
            var retval = new RectTransform[transform.childCount];
            for (var i = 0; i < transform.childCount; i++)
            {
                retval[i] = (RectTransform) transform.GetChild(i);
            }
            return retval;
        }
        
        public static Transform[] GetChildren(this Transform transform)
        {
            var retval = new Transform[transform.childCount];
            for (var i = 0; i < transform.childCount; i++)
            {
                retval[i] = transform.GetChild(i);
            }
            return retval;
        }
    }
}