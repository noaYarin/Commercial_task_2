﻿using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_2
{
    internal class Address
    {
        private string street;
        private int numberOfStreet;
        private string city;
        private string country;

        public Address(string street, int numberOfStreet, string city, string country)
        {
            Street = street;
            NumberOfStreet = numberOfStreet;
            City = city;
            Country = country;
        }

        public Address(Address addr)
        {
            Street = addr.street;
            NumberOfStreet = addr.numberOfStreet;
            City = addr.city;
            Country = addr.country;
        }

        public string Street
        {
            get { return street; }
            set { street = SetStreet(value); }
        }

        public int NumberOfStreet
        {
            get { return numberOfStreet; }
            set { numberOfStreet = SetNumberOfStreet(value); }
        }

        public string City
        {
            get { return city; }
            set { city = SetCity(value); }
        }

        public string Country
        {
            get { return country; }
            set { country = SetCountry(value); }
        }

        private string SetStreet(string street)
        {
            if (street != null && !Validation.IsContainDigit(street))
            {
                return street;
            }
            throw new ArgumentException("Street contains digit");
        }

        int SetNumberOfStreet(int numberOfStreet)
        {
            if (numberOfStreet > 0 && numberOfStreet < 999)
            {
                return numberOfStreet;
            }
            throw new ArgumentException("Street number must be between 0 - 999");
        }

        string SetCity(string city)
        {
            if (city != null && !Validation.IsContainDigit(city))
            {
                return city;
            }
            throw new ArgumentException("City contains digit");
        }

        string SetCountry(string country)
        {
            if (country != null && !Validation.IsContainDigit(country))
            {
                return country;
            }
            throw new ArgumentException("Country contains digit");
        }

        public string ToString()
        {
            return "Country: " + Country + ", city: " + City + ", street: " + Street + ", number: " + NumberOfStreet;
        }
    }
}
