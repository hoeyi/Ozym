namespace EulerFinancial.Blazor.Components.Generic
{
    public static class PropertyAccessor
    {
        public static object GetValue<TModel>(string path, object obj)
        {
            var type = typeof(TModel);

            var pathElements = path.Split(".");

            if (pathElements.Length == 1)
            {
                return type.GetProperty(path)?.GetValue(obj);
            }
            else if (pathElements.Length == 2)
            {
                var complexMemberInfo = type.GetProperty(pathElements[0]);

                var complexMemberValue = complexMemberInfo?.GetValue(obj);

                return complexMemberInfo
                    ?.PropertyType
                    ?.GetProperty(pathElements[1])
                    ?.GetValue(complexMemberValue);
            }
            else
                return null;
        }
    }
}
