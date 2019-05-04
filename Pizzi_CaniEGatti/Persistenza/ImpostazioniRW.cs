using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Pizzi_CaniEGatti.Gestione;
using Pensione_CaniEGatti.Gestione;

namespace Pizzi_CaniEGatti.Persistenza
{
    class ImpostazioniRW
    {
        private static readonly String FileName = "Impostazioni.txt";

        public ImpostazioniRW()
        {

        }

        public static void writeSettings(int cani, int gatti)
        {
            String toWrite = "Cani=" + cani + ";" + "Gatti=" + gatti;
            File.WriteAllText(FileName, toWrite);
        }

        public static BoxSizes LoadSettings()
        {
            try
            {
                string readText = File.ReadAllText(FileName);
                string[] rows = readText.Split(';');
                return new BoxSizes(int.Parse(rows[0].Split('=')[1]), int.Parse(rows[1].Split('=')[1]));
            } catch(Exception ex)
            {
                if (ex is FileNotFoundException || ex is FormatException)
                {
                    
                }
            }
            writeSettings(24, 12);
            return new BoxSizes(24, 12);
        }
    }
}
