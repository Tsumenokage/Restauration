using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Restauration
{
    class Reservation
    {
        public int _numeroReservation { get; private set; }
        private static int _numTotal;
        public String _nomClient { get; private set; }
        private String _numeroTelephone { get; set; }
        public DateTime _dateReservation { get; private set; }
        private int _nbConvives { get; set; }
        private string _formuleRetenue { get; set; }
        private List<Table> _listesTables;

        public Reservation(String _nomClient, String _numeroTelephone,
            DateTime _dateReservation, int _nbConvives, string _formuleRetenue)
        {
            _numeroReservation = _numTotal + 1;
            _numTotal++;
            this._nomClient = _nomClient;
            this._numeroTelephone = _numeroTelephone;
            this._dateReservation = _dateReservation;
            this._nbConvives = _nbConvives;
            this._formuleRetenue = _formuleRetenue;
            this._listesTables = new List<Table>();
        }

        public override string ToString()
        {
            String res;

            res = "    Numéro de réservation : " + _numeroReservation +"\n";
            res += "    Nom du client : " + _nomClient + "\n";
            res += "    Numéro de téléphone : " + _numeroTelephone + "\n";
            res += "    Date de Résèrvation : " + _dateReservation.ToString("g") + "\n";
            res += "    Nombre de convives : " + _nbConvives + "\n";
            res += "    Formule retenue : " + _formuleRetenue + "\n";

            return res;
        }


    }
}
