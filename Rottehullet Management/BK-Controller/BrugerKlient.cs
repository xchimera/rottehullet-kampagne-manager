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
        BrugerDBFacade brugerdbfacade;
        BrugerCollection brugercollection;

        public BrugerKlient()
        {
            brugerdbfacade = new BrugerDBFacade(this);
            brugercollection = new BrugerCollection();
        }

        public bool Opretbruger(string email, string kodeord, string navn, DateTime fødselsdag, long tlf, long nød_tlf, bool vegetar, bool veganer)
        {
            if (brugerdbfacade.OpretBruger(email, kodeord, navn, fødselsdag, tlf, nød_tlf, vegetar, veganer))
            {
                brugercollection.OpretBruger(email, navn, fødselsdag, tlf, nød_tlf, vegetar, veganer);
                return true;
            }
            return false;
        }
    }

    
}