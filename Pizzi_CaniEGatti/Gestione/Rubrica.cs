using Pensione_CaniEGatti.Persistenza;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pensione_CaniEGatti.Gestione
{

    class Rubrica
    {
        private List<Persona> _persone;
        private static Rubrica _instance;

        public static Rubrica GetInstance()
        {
            if (_instance == null)
                _instance = new Rubrica();
            return _instance;
        }

        public Rubrica()
        {
            _persone = RubricaRW.Load();
        }

        public void AddPersona(Persona p)
        {
            _persone.Add(p);
            _persone.Sort();
            RubricaRW.Store(_persone);
        }

        public void RemovePersona(int id)
        {
            foreach (Persona p in _persone)
                if (p.ID == id)
                {
                    _persone.Remove(p);
                    break;
                }
            RubricaRW.Store(_persone);
        }

        public Persona GetById(int id)
        {
            foreach (Persona p in _persone)
                if (p.ID == id)
                    return p;
            return null;
        }

        public List<Persona> Persone { get { return _persone; } set { _persone = value; _persone.Sort(); } }

        public List<Persona> Search(string [] toSearch)
        {
            List<Persona> aux = new List<Persona>();

            foreach (string s in toSearch)
                foreach (Persona p in _persone)
                    if ((p.CodiceFiscale.ToUpper().Contains(s.ToUpper()) || 
                        p.Nome.ToUpper().Contains(s.ToUpper()) || 
                        p.Cognome.ToUpper().Contains(s.ToUpper()) ||
                        p.Telefono.ToUpper().Contains(s.ToUpper()) ||
                        p.PadroneDi.ToUpper().Contains(s.ToUpper())) &&
                        !aux.Contains(p))
                        aux.Add(p);
            return aux;
        }

        public List<Persona> Search(string toSearch)
        {
            return Search(toSearch.Split(' '));
        }

        public void ModifyPersona(Persona old, string nome, string cognome, string telefono, string cf, string padroneDi)
        {
            if(_persone.Contains(old))
            {
                old.CodiceFiscale = cf;
                old.PadroneDi = padroneDi;
                old.Cognome = cognome;
                old.Nome = nome;
                old.Telefono = telefono;
                RubricaRW.Store(_persone);
            }
            else
            {
                _persone.Add(new Persona(nome, cognome, telefono, cf, padroneDi));
            }
        }
    }
}
