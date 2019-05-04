using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Pizzi_CaniEGatti.Gestione
{
    class Switch : ISerializable
    {
        private int _fromBox;
        private int _toBox;
        private Prenotazione _prenotazione;

        public Switch(int from, int to, Prenotazione prenotazione)
        {
            _fromBox = from;
            _toBox = to;
            _prenotazione = prenotazione;
        }

        public int FromBox { get { return _fromBox; } set { _fromBox = value; } }

        public int ToBox { get { return _toBox; } set { _toBox = value; } }

        public int Tipo { get { return _prenotazione.Tipo; } set { _prenotazione.Tipo = value; } }

        public Prenotazione Prenotazione { get { return _prenotazione; } set { _prenotazione = value; } }

        override
        public String ToString()
        {
            if(_toBox == -1)
            {
                return "Uscita dei " + (Tipo == Prenotazione.CANE ? "cani" : "gatti") + " del signor/a " + _prenotazione.Cognome + " " + _prenotazione.Nome +
                    " dal box " + _fromBox + " alle ore " +  _prenotazione.Uscita.ToString("HH:mm") + ". Tel: " + _prenotazione.Telefono + "." + System.Environment.NewLine;
            }
            else if(_fromBox == -1)
            {
                return "Arrivo dei " + (Tipo == Prenotazione.CANE ? "cani" : "gatti") + " del signor/a " + _prenotazione.Cognome + " " + _prenotazione.Nome +
                    " al box " + _toBox + " alle ore " + _prenotazione.Entrata.ToString("HH:mm") + ". Tel: " + _prenotazione.Telefono + "." + System.Environment.NewLine;
            }
            else
            {
                return "Spostamento dei " + (Tipo == Prenotazione.CANE ? "cani" : "gatti") + " del signor/a " + _prenotazione.Cognome + " " + _prenotazione.Nome +
                   "dal box " + _fromBox + " al box " + _toBox + ". Tel: " + _prenotazione.Telefono + "." + System.Environment.NewLine;
            }
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            throw new NotImplementedException();
        }
    }
}
