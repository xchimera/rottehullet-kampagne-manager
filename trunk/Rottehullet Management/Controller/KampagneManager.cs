using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Controller
{
    class KampagneManager
    {
        List<string[]> rettigheder;


        public void IndsætRettighed(string kampagneID, string navn, string type)
        {
            string[] rettighed = new string[3] {kampagneID, navn, type};
            rettigheder.Add(rettighed);

        }

    }
}
