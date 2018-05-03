// Built from tag v2.7.0

using System;
using System.Collections.Generic;
using FINT.Model.Felles.Basisklasser;
using FINT.Model.Felles.Kompleksedatatyper;
using FINT.Model.Resource;
using Newtonsoft.Json;

namespace FINT.Model.Felles
{
    public class PersonResource : AktorResource
    {
        public PersonResource()
        {
            Links = new Dictionary<string, List<Link>>();
        }


        [JsonProperty(PropertyName = "_links")]
        public new Dictionary<string, List<Link>> Links { get; private set; }

        public string Bilde { get; set; }
        public AdresseResource Bostedsadresse { get; set; }
        public DateTime? Fodselsdato { get; set; }
        public Identifikator Fodselsnummer { get; set; }
        public Personnavn Navn { get; set; }

        private void AddLink(string key, Link link)
        {
            if (Links.ContainsKey(key)) return;

            Links.Add(key, new List<Link>());
            Links[key].Add(link);
        }

        public void AddStatsborgerskap(Link link)
        {
            AddLink("statsborgerskap", link);
        }

        public void AddKjonn(Link link)
        {
            AddLink("kjonn", link);
        }

        public void AddMalform(Link link)
        {
            AddLink("malform", link);
        }

        public void AddPersonalressurs(Link link)
        {
            AddLink("personalressurs", link);
        }

        public void AddMorsmal(Link link)
        {
            AddLink("morsmal", link);
        }

        public void AddElev(Link link)
        {
            AddLink("elev", link);
        }
    }
}