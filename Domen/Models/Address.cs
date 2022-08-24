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
        protected Address()
        {

        }
        internal Address(string country, string city, string street, string zipcode)
        {
            if (string.IsNullOrWhiteSpace(country))
            {
                throw new ArgumentNullException("Country must be required");
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
            this.City = city;
            this.Street = street;
            this.ZipCode = zipcode;
        }

        public string Country { get; }
        public string City { get; }
        public string Street { get; }
        public string ZipCode { get; }

        public static Address CreateInstance(string country, string city, string zipcode, string street)
        {
            return new Address(country, city, street, zipcode);
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Street;
            yield return City;
            yield return Country;
            yield return ZipCode;
        }
    }
}
