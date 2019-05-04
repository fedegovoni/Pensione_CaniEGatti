using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Pizzi_CaniEGatti.Gestione
{
    [Serializable]
    public class Prenotazione : ISerializable, IComparable
    {
        public static readonly int CANE = 0;
        public static readonly int GATTO = 1;

        private int _id;
        private String _nome;
        private String _cognome;
        private String _telefono;
        List<List<Periodo>> _listaBox;
        private DateTime _entrata;
        private DateTime _uscita;
        private int _tipo;

        public Prenotazione(SerializationInfo info, StreamingContext context)
        {
            _id = (int) info.GetValue("id", typeof(int));
            Nome = (string)info.GetValue("nome", typeof(string));
            Cognome = (string)info.GetValue("cognome", typeof(string));
            Telefono = (string)info.GetValue("telefono", typeof(string));
            Entrata = (DateTime)info.GetValue("entrata", typeof(DateTime));
            Uscita = (DateTime)info.GetValue("uscita", typeof(DateTime));
            Tipo = (int)info.GetValue("tipo", typeof(int));

            ListaBox = (List<List<Periodo>>)info.GetValue("lista_box", typeof(List<List<Periodo>>));
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("id", ID);
            info.AddValue("nome", Nome);
            info.AddValue("cognome", Cognome);
            info.AddValue("telefono", Telefono);
            info.AddValue("entrata", Entrata);
            info.AddValue("uscita", Uscita);
            info.AddValue("tipo", Tipo);

            info.AddValue("lista_box", ListaBox);
        }

        public Prenotazione(String nome, String cognome, String telefono, DateTime entrata, DateTime uscita, int tipo, List<List<Periodo>> listaBox)
        {
            _id = Persistenza.IdRW.GetNewId();
            _nome = nome;
            _cognome = cognome;
            _telefono = telefono;
            _entrata = entrata;
            _uscita = uscita;
            _tipo = tipo;
            _listaBox = listaBox;
        }

        public Prenotazione(Prenotazione p)
        {
            _id = p.ID;
            _nome = p.Nome;
            _cognome = p.Cognome;
            _telefono = p.Telefono;
            _entrata = p.Entrata;
            _uscita = p.Uscita;
            _tipo = p.Tipo;
            _listaBox = p.ListaBox;
        }
        
        public int ID { get { return _id;  } }

        public String Nome { get { return _nome; } set { _nome = value; } }

        public String Cognome { get { return _cognome; } set { _cognome = value; } }

        public String Telefono { get { return _telefono; } set { _telefono = value; } }

        public DateTime Entrata
        {
            get { return _entrata; }
            set { _entrata = value; }
        }

        public DateTime Uscita { get { return _uscita; } set { _uscita = value; } }

        public int Tipo { get { return _tipo; } set { _tipo = value; } }

        public List<List<Periodo>> ListaBox
        {
            get { return _listaBox; }
            set { _listaBox = value; }
        }

        public int NumBox { get { return _listaBox.Count; } }

        public int CompareTo(object obj)
        {
            Prenotazione p = obj as Prenotazione;
            DateTime now = DateTime.Now;
            if(now > Entrata && now > p.Entrata)
            {
                return Uscita.CompareTo(p.Uscita);
            }
            else if (now > Entrata || now > p.Entrata)
            {
                return (now > Entrata ? 1 : -1);
            }
            else
            {
                return Entrata.CompareTo(p.Entrata);
            }
        }
    }
}
