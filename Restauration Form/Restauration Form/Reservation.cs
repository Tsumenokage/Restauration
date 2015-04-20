using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Restauration_Form
{
    class Reservation
    {
        private int _numeroReservation { get; set; }
        private String _nomClient { get; set; }
        private String _numeroTelephone { get; set; }
        private DateTime _dateReservation { get; set; }
        private int _nbConvives { get; set; }
        private Formule _formuleRetenue { get; set; }

        public Reservation(int _numeroReservation, String _nomClient, String _numeroTelephone,
            DateTime _dateReservation, int _nbConvives, Formule _formuleRetenue)
        {
            this._numeroReservation = _numeroReservation;
            this._nomClient = _nomClient;
            this._numeroTelephone = _numeroTelephone;
            this._dateReservation = _dateReservation;
            this._nbConvives = _nbConvives;
            this._formuleRetenue = _formuleRetenue;
        }

        public override string ToString()
        {
            String res;

            res = "    Numéro de réservation : " + _numeroReservation +"\n";
            res += "    Nom du client : " + _nomClient + "\n";
            res += "    Numéro de téléphone : " + _numeroTelephone + "\n";
            res += "    Date de Résèrvation : " + _dateReservation.ToString("g") + "\n";
            res += "    Nombre de convives : " + _nbConvives + "\n";
            res += "    Formule retenue : " + _formuleRetenue._nomFormule + "\n";

            return res;
        }

    }
}
