using Pensione_CaniEGatti.Gestione;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pensione_CaniEGatti.Persistenza
{
    class PersonaIdRW
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

            }
            catch (Exception ex)
            {
                if (ex is FileNotFoundException || ex is FormatException || ex is FormatException)
                {
                    foreach (Persona pers in Rubrica.GetInstance().Persone)
                        if (pers.ID > newId)
                            newId = pers.ID;
                    newId++;
                    writeId(newId);
                }
            }
            return newId;
        }
    }
}
