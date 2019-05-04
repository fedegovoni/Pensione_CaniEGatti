using Pensione_CaniEGatti.Persistenza;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace Pensione_CaniEGatti.Gestione
{
    [Serializable]
    public class Persona : ISerializable, IComparable
    {
        private int _id;
        private string _cognome;
        private string _nome;
        private string _telefono;
        private string _codiceFiscale;
        private string _padroneDi;

        public Persona(string nome, string cognome, string telefono, string cf, string padroneDi)
        {
            _id = PersonaIdRW.GetNewId();
            _codiceFiscale = cf;
            _nome = nome;
            _cognome = cognome;
            _telefono = telefono;
            _padroneDi = padroneDi;
        }

        public Persona(SerializationInfo info, StreamingContext context)
        {
            _id = (int)info.GetValue("id", typeof(int));
            _nome = (string)info.GetValue("nome", typeof(string));
            _cognome = (string)info.GetValue("cognome", typeof(string));
            _codiceFiscale = (string)info.GetValue("cf", typeof(string));
            _telefono = (string)info.GetValue("telefono", typeof(string));
            _padroneDi = (string)info.GetValue("padroneDi", typeof(string));
        }

        [SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("id", _id);
            info.AddValue("nome", _nome);
            info.AddValue("cognome", _cognome);
            info.AddValue("cf", _codiceFiscale);
            info.AddValue("telefono", _telefono);
            info.AddValue("padroneDi", _padroneDi);
        }

        public int ID { get { return _id; } set { _id = value; } }

        public string CodiceFiscale { get { return _codiceFiscale; } set { _codiceFiscale = value; } }

        public string Telefono { get { return _telefono; } set { _telefono = value; } }
        
        public string Nome { get { return _nome; } set { _nome = value; } }
        
        public string Cognome { get { return _cognome; } set { _cognome = value; } }

        public string PadroneDi { get { return _padroneDi; } set { _padroneDi = value; } }

        override
        public bool Equals(Object b)
        {
            Persona p = b as Persona;
            return (_id == p.ID &&_nome == p.Nome && _codiceFiscale == p.CodiceFiscale && _cognome == p.Cognome && _padroneDi == p.PadroneDi && _telefono == p.Telefono);
        }

        public int CompareTo(object obj)
        {
            Persona p = obj as Persona;
            return (Cognome.CompareTo(p.Cognome) == 0 ? Cognome.CompareTo(p.Cognome) : Nome.CompareTo(p.Nome));
        }
    }
}
