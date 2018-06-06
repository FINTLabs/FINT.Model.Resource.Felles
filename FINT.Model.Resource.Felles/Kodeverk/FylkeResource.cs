// Built from tag v3.0.0-rc-1

using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using FINT.Model.Resource;

using FINT.Model.Felles.Basisklasser;

namespace FINT.Model.Felles.Kodeverk
{

	public class FylkeResource : Begrep 
	{

        
        
        public FylkeResource()
        {
            Links = new Dictionary<string, List<Link>>();
        }

        [JsonProperty(PropertyName = "_links")]
        public new Dictionary<string, List<Link>> Links { get; private set; }
        
        private void AddLink(string key, Link link)
        {
            if (!Links.ContainsKey(key))
            {
                Links.Add(key, new List<Link>());
            }
            Links[key].Add(link);
        }
            

        public void AddKommune(Link link)
        {
            AddLink("kommune", link);
        }
    }
}
