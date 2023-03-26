using System.Data;
using System.Reflection;

namespace CallCenterCoreAPI
{
    public static class AppSettingsHelper
    {
        private static IConfiguration _configuration;
        public static void AppSettingsConfigure(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public static string Setting(string Key) 
        { 
            return _configuration.GetSection(key:Key).Value;
        
        }


        public static List<T> ToListof<T>(this DataTable dt)
        {
            const BindingFlags flags = BindingFlags.Public | BindingFlags.Instance;
            var columnNames = dt.Columns.Cast<DataColumn>()
                .Select(c => c.ColumnName)
                .ToList();
            var objectProperties = typeof(T).GetProperties(flags);
            var targetList = dt.AsEnumerable().Select(dataRow =>
            {
                var instanceOfT = Activator.CreateInstance<T>();

                foreach (var properties in objectProperties.Where(properties => columnNames.Contains(properties.Name) && dataRow[properties.Name] != DBNull.Value))
                {
                    properties.SetValue(instanceOfT, dataRow[properties.Name], null);
                }
                return instanceOfT;
            }).ToList();

            return targetList;
        }

    }


}
