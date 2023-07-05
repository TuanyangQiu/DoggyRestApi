using System.Dynamic;
using System.Reflection;

namespace DoggyRestApi.Helper
{
    /// <summary>
    /// This class is for shaping data before return to front-end
    /// </summary>
    public static class DataShaper
    {
        /// <summary>
        /// Shape data for a list of object
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entities"></param>
        /// <param name="fields"></param>
        /// <returns></returns>
        public static IEnumerable<ExpandoObject> ShapeDataForIEnumerable<T>(this IEnumerable<T> entities, string? fields)
        {
            ArgumentNullException.ThrowIfNull(entities, nameof(entities));

            List<PropertyInfo> properties = GetRequiredProperties<T>(fields);
            List<ExpandoObject> shapedDataList = new List<ExpandoObject>();
            foreach (var e in entities)
                shapedDataList.Add(FetchDataForEntity(e, properties));

            return shapedDataList;
        }

        /// <summary>
        /// Shape data for a single object
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="fields"></param>
        /// <returns></returns>
        public static ExpandoObject ShapeData4SingleObject<T>(this T entity, string? fields)
        {
            ArgumentNullException.ThrowIfNull(entity, nameof(entity));

            List<PropertyInfo> properties = GetRequiredProperties<T>(fields);
            return FetchDataForEntity(entity, properties);
        }


        private static ExpandoObject FetchDataForEntity<T>(T entity, List<PropertyInfo> listPropertyInfo)
        {
            ExpandoObject expObj = new ExpandoObject();
            foreach (var p in listPropertyInfo)
                expObj.TryAdd(p.Name, p.GetValue(entity));

            return expObj;
        }

        private static List<PropertyInfo> GetRequiredProperties<T>(string? fields)
        {
            List<PropertyInfo> requiredProperties = new List<PropertyInfo>();

            //if fields is empty, return all fields
            //else, return specified fields
            if (string.IsNullOrWhiteSpace(fields))
                requiredProperties = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.IgnoreCase).ToList();
            else
            {
                string[] fieldsArray = fields.Split(',', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);
                foreach (var f in fieldsArray)
                {
                    PropertyInfo? p = typeof(T).GetProperty(f, BindingFlags.Public | BindingFlags.Instance | BindingFlags.IgnoreCase);
                    if (p != null)
                        requiredProperties.Add(p);
                }

            }

            return requiredProperties;
        }

    }
}
