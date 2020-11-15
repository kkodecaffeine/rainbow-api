using System.Reflection;

namespace RainbowApp.Core.Entities
{
    public class BaseEntity
    {
        public BaseEntity()
        {
            if (GetType().IsSubclassOf(typeof(BaseEntity)))
            {
                var properties = GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);

                foreach (var property in properties)
                {
                    // Get only string properties
                    if (property.PropertyType != typeof(string))
                    {
                        continue;
                    }

                    if (!property.CanWrite || !property.CanRead)
                    {
                        continue;
                    }

                    if (property.GetGetMethod(false) == null)
                    {
                        continue;
                    }
                    if (property.GetSetMethod(false) == null)
                    {
                        continue;
                    }

                    if (string.IsNullOrEmpty((string)property.GetValue(this, null)))
                    {
                        property.SetValue(this.ToString().ToLower(), string.Empty, null);
                    }
                }
            }
        }
    }
}
