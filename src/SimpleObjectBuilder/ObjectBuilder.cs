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
            var memberExpression = propertySelector.Body as MemberExpression;
            var propertyInfo = memberExpression.Member as PropertyInfo;
            propertyInfo.SetValue(obj, value);

            return this;
        }

        public TObject Build()
        {
            return obj;
        }
    }
}