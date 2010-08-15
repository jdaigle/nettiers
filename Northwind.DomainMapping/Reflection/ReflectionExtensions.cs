using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace Northwind.DomainMapping.Reflection {
    public static class ReflectionExtensions {

        public static void Set(this ReflectionExtensionPoint extensionPoint, string property, object value) {
            var member = extensionPoint.FindDescriptor(property);
            if (member is PropertyInfo)
                SetProperty(member as PropertyInfo, extensionPoint.Object, value);
            else if (member is FieldInfo)
                SetField(member as FieldInfo, extensionPoint.Object, value);
            else
                throw new ArgumentException(string.Format("The property {0} was not found on the instance of type {1}", property, extensionPoint.Object.GetType().Name), "property");
        }

        private static void SetProperty(PropertyInfo propertyInfo, object @object, object value) {
            propertyInfo.SetValue(@object, value, null);
        }

        private static void SetField(FieldInfo fieldInfo, object @object, object value) {
            fieldInfo.SetValue(@object, value);
        }

        public static object Get(this ReflectionExtensionPoint extensionPoint, string property) {
            var member = extensionPoint.FindDescriptor(property);
            if (member is PropertyInfo)
                return GetProperty(member as PropertyInfo, extensionPoint.Object);
            else if (member is FieldInfo)
                return GetField(member as FieldInfo, extensionPoint.Object);
            else
                throw new ArgumentException(string.Format("The property {0} was not found on the instance of type {1}", property, extensionPoint.Object.GetType().Name), "property");
        }

        private static object GetProperty(PropertyInfo propertyInfo, object @object) {
            return propertyInfo.GetValue(@object, null);
        }

        private static object GetField(FieldInfo fieldInfo, object @object) {
            return fieldInfo.GetValue(@object);
        }

        public static MemberInfo FindDescriptor(this ReflectionExtensionPoint extensionPoint, string memberName) {
            return Reflect(extensionPoint.Object.GetType()).FindDescriptor(memberName);
        }


        private static IDictionary<Type, ReflectionInfo> cachedReflectionInfo = new Dictionary<Type, ReflectionInfo>();
        private static object myLock = new object();

        private static ReflectionInfo Reflect(Type type) {
            if (cachedReflectionInfo.ContainsKey(type))
                return cachedReflectionInfo[type];
            // Lock so that we don't add the cached info twice
            lock (myLock) {
                // check again inside the lock, just to be sure
                if (cachedReflectionInfo.ContainsKey(type))
                    return cachedReflectionInfo[type];
                var reflectionInfo = new ReflectionInfo(type);
                cachedReflectionInfo.Add(type, reflectionInfo);
                return reflectionInfo;
            }
        }
    }
}
