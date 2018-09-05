using System;
using System.Linq.Expressions;
using System.Reflection;

namespace SimpleObjectBuilder
{
    public class ObjectBuilder<TObject> where TObject : new()
    {
        private TObject obj;

        public ObjectBuilder()
        {
            obj = new TObject();
        }

        public ObjectBuilder<TObject> With<TPropertyType>(Expression<Func<TObject, TPropertyType>> propertySelector, TPropertyType value)
        {
            if (!(propertySelector.Body is MemberExpression memberExpression))
            {
                throw new ArgumentException(nameof(propertySelector));
            }

            switch (memberExpression.Member)
            {
                case PropertyInfo propertyInfo:
                    propertyInfo.SetValue(obj, value);
                    break;
                case FieldInfo fieldInfo:
                    fieldInfo.SetValue(obj, value);
                    break;
            }

            return this;
        }

        public TObject Build()
        {
            return obj;
        }
    }
}