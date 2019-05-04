using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace Pizzi_CaniEGatti.Persistenza
{
    class PrenotazioniRW
    {
        public static readonly string PrenotazioniFileName = "Prenotazioni.bin";

        public static void Store(List<Gestione.Prenotazione> prenotazioni)
        {
            using (Stream stream = File.Open(PrenotazioniFileName, FileMode.Create))
            {
                var bformatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();

                bformatter.Serialize(stream, prenotazioni);
            }

        }

        public static List<Gestione.Prenotazione> Load()
        {   
            List<Gestione.Prenotazione> prenotazioni = null;
            try {
                using (Stream stream = File.Open(PrenotazioniFileName, FileMode.Open))
                {
                    var bformatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();

                    prenotazioni = (List<Gestione.Prenotazione>)bformatter.Deserialize(stream);
                }
               
                return prenotazioni;
            } catch (FileNotFoundException)
            {
                return new List<Gestione.Prenotazione>();
            }
        }

    }
}
