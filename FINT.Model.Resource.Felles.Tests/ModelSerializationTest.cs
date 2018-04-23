using System;
using System.Collections.Generic;
using FINT.Model.Felles;
using FINT.Model.Felles.Kompleksedatatyper;
using FINT.Model.Resource.Administrasjon.Tests;
using Newtonsoft.Json;
using Xunit;

namespace FINT.Model.Resource.Felles.Tests
{
    public class ModelSerializationTest
    {
        [Fact(DisplayName = "Serialize Person without Links")]
        public void Serialize_Person_without_Links()
        {
            var person = new Person
            {
                Fodselsnummer = new Identifikator {Identifikatorverdi = "12345678901"},
                Navn = new Personnavn {Fornavn = "Tore", Etternavn = "Test"},
                Fodselsdato = new DateTime(55, 5, 15),
                Bostedsadresse = new Adresse
                {
                    Postnummer = "1234",
                    Poststed = "Test",
                    Adresselinje = new List<string> {"Storgata 12"}
                }
            };

            var settings = new JsonSerializerSettings {ContractResolver = new LowercaseContractResolver()};
            var json = JsonConvert.SerializeObject(person, settings);
            Console.WriteLine(json);

            var deserializeObject = JsonConvert.DeserializeObject<Person>(json);
            Assert.NotNull(deserializeObject);
            Assert.NotNull(deserializeObject.Bostedsadresse.Adresselinje);
            Assert.NotNull(deserializeObject.Navn.Etternavn);
        }

        [Fact(DisplayName = "Serialize PersonResource with deep links")]
        public void Serialize_PersonResource_with_deep_links()
        {
            var person = new PersonResource
            {
                Fodselsnummer = new Identifikator {Identifikatorverdi = "12345678901"},
                Navn = new Personnavn {Fornavn = "Tore", Etternavn = "Test"},
                Fodselsdato = new DateTime(55, 5, 15),
                Bostedsadresse = new AdresseResource
                {
                    Postnummer = "1234",
                    Poststed = "Test",
                    Adresselinje = new List<string> {"Storgata 12"}
                }
            };
            person.AddKjonn(Link.with("/felles/kjonn/systemid/1"));
            person.AddStatsborgerskap(Link.with("/felles/land/systemid/no"));

            person.Bostedsadresse.AddLand(Link.with("/felles/land/systemid/no"));

            var settings = new JsonSerializerSettings {ContractResolver = new LowercaseContractResolver()};
            var json = JsonConvert.SerializeObject(person, settings);
            Console.WriteLine(json);

            var deserializeObject = JsonConvert.DeserializeObject<PersonResource>(json);
            Assert.NotNull(deserializeObject);
            Assert.True(deserializeObject.Bostedsadresse.Links.ContainsKey("land"));
        }

        [Fact(DisplayName = "Serialize PersonResource with only own links")]
        public void Serialize_PersonResource_with_only_own_links()
        {
            var person = new PersonResource
            {
                Fodselsnummer = new Identifikator {Identifikatorverdi = "12345678901"},
                Navn = new Personnavn {Fornavn = "Tore", Etternavn = "Test"},
                Fodselsdato = new DateTime(55, 5, 15),
                Bostedsadresse = new AdresseResource
                {
                    Postnummer = "1234",
                    Poststed = "Test",
                    Adresselinje = new List<string> {"Storgata 12"}
                }
            };
            person.AddKjonn(Link.with("/felles/kjonn/systemid/1"));
            person.AddStatsborgerskap(Link.with("/felles/land/systemid/no"));

            var settings = new JsonSerializerSettings {ContractResolver = new LowercaseContractResolver()};
            var json = JsonConvert.SerializeObject(person, settings);
            Console.WriteLine(json);

            var deserializeObject = JsonConvert.DeserializeObject<PersonResource>(json);
            Assert.NotNull(deserializeObject);
            Assert.True(deserializeObject.Links.ContainsKey("statsborgerskap"));
        }
    }
}