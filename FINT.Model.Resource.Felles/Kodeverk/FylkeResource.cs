// Built from tag v2.8.0

using System.Collections.Generic;
using FINT.Model.Felles.Basisklasser;
using FINT.Model.Resource;
using Newtonsoft.Json;

namespace FINT.Model.Felles.Kodeverk
{
    public class FylkeResource : Begrep
    {
        public FylkeResource()
        {
            Links = new Dictionary<string, List<Link>>();
        }

        [JsonProperty(PropertyName = "_links")]
        public Dictionary<string, List<Link>> Links { get; private set; }

        private void AddLink(string key, Link link)
        {
            if (Links.ContainsKey(key)) return;

            Links.Add(key, new List<Link>());
            Links[key].Add(link);
        }

        public void AddKommune(Link link)
        {
            AddLink("kommune", link);
        }
    }
}