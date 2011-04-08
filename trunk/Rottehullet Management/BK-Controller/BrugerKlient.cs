﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Model;
using Controller;
namespace BK_Controller
{
    public class BrugerKlient
    {
        /// <summary>
        /// bruger her en anden databasefacade og controller da dette er brugerklienten
        /// og ikke skal have så mange rettigheder som en superbruger eller admin.
        /// normalt skulle der kun bruges en anden controller, men da dbfacaden for kampagnemanageren's constructor
        /// forventer at det en kompagnemanager af objectet KampagneManager, blev vi nødt til at lave en separat controller og dbfacade.
        /// </summary>
        BrugerDBFacade brugerdbfacade;
        BrugerCollection brugercollection;

        public BrugerKlient()
        {
            brugerdbfacade = new BrugerDBFacade(this);
            brugercollection = new BrugerCollection();
        }

        public bool Opretbruger(string email, string kodeord, string navn, DateTime fødselsdag, long tlf, long nød_tlf, bool vegetar, bool veganer)
        {
            long brugerID = brugerdbfacade.OpretBruger(email, kodeord, navn, fødselsdag, tlf, nød_tlf, vegetar, veganer);
            
            if (brugerID>0)
            {
                brugercollection.OpretBruger(brugerID, email, navn, fødselsdag, tlf, nød_tlf, vegetar, veganer);
                return true;
            }
            return false;
        }
    }

    
}