using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminProject.Model
{
    public class Lieu
    {
        public String Id { get; set; }

        public String nom { get; set; }

        public String adresse { get; set; }

        public Double latitude { get; set; }

        public Double longitude { get; set; }

        public String ville { get; set; }

        public int codepostal { get; set; }

        public String pays { get; set; }


    }
}
