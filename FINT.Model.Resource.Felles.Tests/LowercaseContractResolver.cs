using Newtonsoft.Json.Serialization;

namespace FINT.Model.Resource.Administrasjon.Tests
{
    public class LowercaseContractResolver : DefaultContractResolver
    {
        protected override string ResolvePropertyName(string propertyName)
        {
            return propertyName.ToLower();
        }
    }
}