using System;
using System.Collections.Generic;
using System.Text;

namespace Ns.Application.Models.Identity
{
    public class JwtSetings
    {
        public string Key { get; set; }

        public string Issuer { get; set; }

        public string Audience { get; set; }

        public int DurationInMinutes { get; set; }
    }
}
