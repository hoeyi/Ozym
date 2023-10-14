namespace Ozym.Web.Components
{
    public static class PropertyAccessor
    {
        public static object? GetValue<TModel>(string path, object obj)
        {
            var type = typeof(TModel);

            var pathElements = path.Split(".");

            // If the path element count is 1 the property is not nested.
            if (pathElements.Length == 1)
            {
                return type.GetProperty(path)?.GetValue(obj);
            }
            // If the path element count is 2 the property is nested. Return the property value 
            // for the first nested member.
            else if (pathElements.Length == 2)
            {
                var complexMemberInfo = type.GetProperty(pathElements[0]);

                var complexMemberValue = complexMemberInfo?.GetValue(obj);

                return complexMemberInfo
                    ?.PropertyType
                    ?.GetProperty(pathElements[1])
                    ?.GetValue(complexMemberValue);
            }
            // TODO: Add support for nested properties beyond first-level?
            else
                return null;
        }
    }
}
