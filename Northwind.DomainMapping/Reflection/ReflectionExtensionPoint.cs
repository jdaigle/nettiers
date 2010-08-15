using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace Northwind.DomainMapping.Reflection {
    public class ReflectionExtensionPoint {

        public ReflectionExtensionPoint(object @object) {
            Object = @object;
        }

        public Object Object { get; set; }
    }
}
