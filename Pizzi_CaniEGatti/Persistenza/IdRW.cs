using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Pizzi_CaniEGatti.Persistenza
{
    class IdRW
    {
        private static readonly String FileName = "Id.txt";

        public static void writeId(int id)
        {
            String toWrite = id + "";
            File.WriteAllText(FileName, toWrite);
        }

        public static int GetNewId()
        {
            int newId = 0;
            try
            {
                string readText = File.ReadAllText(FileName);
                newId = int.Parse(readText);
                newId++;
                writeId(newId);

            } catch(Exception ex)
            {
                if (ex is FileNotFoundException || ex is FormatException || ex is FormatException)
                {
                    foreach (Gestione.Prenotazione pren in Gestione.GestorePrenotazioni.GetInstance().Prenotazioni)
                        if (pren.ID > newId)
                            newId = pren.ID;
                    newId++;
                    writeId(newId);
                }
            }
            return newId; 
        }
    }
}
