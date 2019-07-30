using System.Linq;
using System.Reflection;
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

    }
}