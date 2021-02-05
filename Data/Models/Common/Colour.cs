using Microsoft.Rest.ClientRuntime.Azure.Authentication.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infrastructure.Data.Models.Common
{
    class Colour
    {
        public int Id { get; set; }
        public string Hex { get; set; }

        public Colour() { }


        /* Needs to be moved to Validator once created 
        public Colour(string colour)
        {
            Check.NotEmptyNotNull(colour);

            if (colour.Length == 7 && colour.StartsWith("#"))
            {
                foreach (var ch in colour.ToCharArray())
                {
                    if (ch == '#') continue;
                    else if (!"1234567890ABCDEF".Contains(ch)) throw new Exception("The application tried to add a colour out of the range of accepted Hexadecimal characters. Check the input colour.");
                }
                Hex = colour;
            }
            else throw new Exception("A colour with too many characters was created, please check your input.");
        }
        */
    }
}
