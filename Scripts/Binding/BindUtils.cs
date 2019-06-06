using System;
using System.Linq;
using System.Reflection;
using State.Dynamic;
using UnityEngine;

namespace Binding
{
    public static class BindUtils
    {
        private static BindingFlags GetFlags()
        {
            return BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance;
        }
        
        public static void Bind(this MonoBehaviour obj, bool subclasses = false)
        {
            var attr = typeof(Bind);
            var type = obj.GetType();
            var fields = type.GetFields(GetFlags())
                .Where(field => field.IsDefined(attr, true));
            foreach (var field in fields)
                field.SetValue(obj, obj.GetComponent(field.FieldType));
            var props = type.GetProperties(GetFlags())
                .Where(prop => prop.IsDefined(attr, true));
            foreach (var prop in props)
                prop.SetValue(obj, obj.GetComponent(prop.PropertyType));
        }

        public static void BindStates(this MonoBehaviour obj)
        {
            var attr = typeof(BindState);
            var type = obj.GetType();
            var states = Resources.FindObjectsOfTypeAll<DynamicState>();

            var fields = type.GetFields(GetFlags())
                .Where(field => field.IsDefined(attr, true));
            foreach (var field in fields)
            {
                var bstate = field.GetCustomAttribute<BindState>();
                field.SetValue(obj, Find(bstate.Name ?? field.Name, states));
            }

            var props = type.GetProperties(GetFlags())
                .Where(prop => prop.IsDefined(attr, true));
            foreach (var prop in props)
            {
                var bstate = prop.GetCustomAttribute<BindState>();
                prop.SetValue(obj, Find(bstate.Name ?? prop.Name, states));
            }
        }

        private static DynamicState Find(string name, DynamicState[] states)
        {
            var find = states.FirstOrDefault((arg) => arg.Name.Replace(" ", "") == name);
            if (find == null)
                throw new Exception($"Could not find state {name}");
            return find;
        }
    }
}