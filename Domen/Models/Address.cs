using Domen.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domen.Models
{
    public class Address : ValueObject
    {
        internal Address(string country, string city, string zipcode, string street)
        {

            if (string.IsNullOrWhiteSpace(country))
            {
                throw new ArgumentNullException("Country must be required");
            }

            if (string.IsNullOrWhiteSpace(zipcode))
            {
                throw new ArgumentNullException("Zipcode must be required");
            }

            if (string.IsNullOrWhiteSpace(city))
            {
                throw new ArgumentNullException("City must be required");
            }

            if (string.IsNullOrWhiteSpace(street))
            {
                throw new ArgumentNullException("Street must be required");
            }

            this.Country = country;
            this.ZipCode = zipcode;
            this.City = city;
            this.Street = street;
        }

        public static Address CreateInstance(string country, string city, string zipcode, string street)
        {
            return new Address(country, city, zipcode, street);
        }

        public string Country { get; private set; } = String.Empty;
        public string City { get; private set; } = String.Empty;
        public string ZipCode { get; private set; } = String.Empty;
        public string Street { get; private set; } = String.Empty;

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Street;
            yield return City;
            yield return Country;
            yield return ZipCode;
        }
    }
}
