using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pensione_CaniEGatti.Gestione;
using System.IO;

namespace Pensione_CaniEGatti.Persistenza
{
    class RubricaRW
    {
        public static readonly string PrenotazioniFileName = "Rubrica.bin";

        public static void Store(List<Persona> prenotazioni)
        {
            using (Stream stream = File.Open(PrenotazioniFileName, FileMode.Create))
            {
                var bformatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();

                bformatter.Serialize(stream, prenotazioni);
            }

        }

        public static List<Persona> Load()
        {
            List<Persona> prenotazioni = null;
            try
            {
                using (Stream stream = File.Open(PrenotazioniFileName, FileMode.Open))
                {
                    var bformatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();

                    prenotazioni = (List<Persona>)bformatter.Deserialize(stream);
                }

                return prenotazioni;
            }
            catch (FileNotFoundException)
            {
                return new List<Persona>();
            }
        }
    }
}
