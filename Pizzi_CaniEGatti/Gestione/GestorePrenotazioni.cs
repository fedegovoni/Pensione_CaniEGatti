using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pizzi_CaniEGatti.Persistenza;
using Pensione_CaniEGatti.Gestione;

namespace Pizzi_CaniEGatti.Gestione
{
    class GestorePrenotazioni
    {
        

        private List<Prenotazione> _prenotazioni = null;
        private static GestorePrenotazioni _instance;

        public static int BOX_CANI_SIZE = 4;
        public static int BOX_GATTI_SIZE = 3;

        public static GestorePrenotazioni GetInstance()
        {
            if (_instance == null)
                _instance = new GestorePrenotazioni();
            return _instance;
        }

        private GestorePrenotazioni()
        {
            _prenotazioni = PrenotazioniRW.Load();
            BoxSizes bs = ImpostazioniRW.LoadSettings();
            BOX_CANI_SIZE = bs.NumBoxCani;
            BOX_GATTI_SIZE = bs.NumBoxGatti;
        }

        public List<Prenotazione> Prenotazioni { get { return _prenotazioni; } set { _prenotazioni = value; _prenotazioni.Sort(); } }

        public void AddPrenotazione(Prenotazione p)
        {
            if (GetById(p.ID) == null)
            {
                _prenotazioni.Add(p);
                _prenotazioni.Sort();
                PrenotazioniRW.Store(_prenotazioni);
            }
            else
                throw new ArgumentException();
        }

        public void RemovePrenotazione(int id)
        {
            foreach (Prenotazione p in _prenotazioni)
                if (p.ID == id)
                {
                    _prenotazioni.Remove(p);
                    break;
                }
            PrenotazioniRW.Store(_prenotazioni);
        }

        public Prenotazione GetById(int id)
        {
            foreach(Prenotazione p in _prenotazioni)
            {
                if (id == p.ID) return p;
            }
            return null;
        }

        public List<Prenotazione> GetByPeriod(DateTime start, DateTime end)
        {
            List<Prenotazione> aux = new List<Prenotazione>();
            foreach (Prenotazione p in _prenotazioni)
            {
                if (!((p.Entrata < start && p.Uscita < start) || (p.Uscita > end && p.Entrata > end)))
                    aux.Add(p);
            }
            return aux;
        }

        public List<int> GetByDay(DateTime day)
        {
            List<int> aux = new List<int>();
            foreach (Prenotazione p in _prenotazioni)
            {
                foreach(List<Periodo> listaPeriodi in p.ListaBox)
                    foreach(Periodo periodo in listaPeriodi)
                        if (!((periodo.StartTime < day && periodo.EndTime < day) || (periodo.StartTime > day && periodo.EndTime > day)))
                            aux.Add(periodo.Box);
            }
            return aux;
        }

        //ritorna i box liberi in un singolo giorno.
        public List<int> FreeBoxesInADay(DateTime day, int tipo, List<List<Periodo>> addToCheck)
        {
            int box = (tipo == Prenotazione.CANE ? BOX_CANI_SIZE : BOX_GATTI_SIZE);

            List < int > free = new List<int>();
            for (int i = 0; i < box; i++)
                free.Add(i);

            List<Prenotazione> prenotazioniToCheck = (tipo == Prenotazione.CANE ? PrenotazioniCani : PrenotazioniGatti);
            List<Periodo> periodiToCheck = new List<Periodo>();
            foreach (Prenotazione pren in prenotazioniToCheck)
                foreach (List<Periodo> per in pren.ListaBox)
                    periodiToCheck.AddRange(per);
            foreach (List<Periodo> per in addToCheck)
                periodiToCheck.AddRange(per);
            
            foreach (Periodo periodo in periodiToCheck)
                if (free.Contains(periodo.Box) && !((periodo.StartTime < day && periodo.EndTime < day) || (periodo.StartTime > day && periodo.EndTime > day)))
                    free.Remove(periodo.Box);

            return free;
        }

        public List<int> AlwaysFreeBox(DateTime start, DateTime end, int tipo, List<List<Periodo>> addToCheck)
        {
            List<int> indexes = new List<int>();

            int size = tipo == Prenotazione.CANE ? BOX_CANI_SIZE : BOX_GATTI_SIZE;
           
            for (int i = 0; i < size; i++)
            {
                bool libero = true;
                for (DateTime tmp = start; tmp < end && libero; tmp = tmp.AddMinutes(30))
                {
                    //se è contenuto tra quelli liberi
                    if (!FreeBoxesInADay(tmp, tipo, addToCheck).Contains(i))
                        libero = false;
                }
                if (libero)
                    indexes.Add(i);
             }
            return indexes;
        }

        public List<int> FreeBoxesInPeriod(DateTime start, DateTime end, int tipo)
        {
            List<int> freeBoxes = new List<int>();
            List<Prenotazione> prenotazioni = tipo == Prenotazione.CANE ? PrenotazioniCani : PrenotazioniGatti;
            int size = tipo == Prenotazione.CANE ? BOX_CANI_SIZE : BOX_GATTI_SIZE;

            for (int i = 0; i < size; i++)
                freeBoxes.Add(i);

            foreach (Prenotazione p in prenotazioni)
                foreach(List<Periodo> listaPeriodi in p.ListaBox)
                    foreach (Periodo periodo in listaPeriodi)
                        if (!((periodo.StartTime < start && periodo.EndTime < start) ||
                            (periodo.StartTime > end && periodo.EndTime > end)) && freeBoxes.Contains(periodo.Box))
                            freeBoxes.Remove(periodo.Box);

            return freeBoxes;
        }

        public List<List<Periodo>> FindAStay(DateTime start, DateTime end, int tipo, int requiredBox)
        {
            return FindAStay(start, end, tipo, requiredBox, new List<int>());
        }

        public List<List<Periodo>> FindAStay(DateTime start, DateTime end, int tipo, int requiredBox, List<int> listPreferiti)
        {
            List<List<Periodo>> free = new List<List<Periodo>>();
            
            bool ok = true;
            

            for (int i = 0; i < requiredBox && ok; i++)
            {
                List<int> sempreLiberi = AlwaysFreeBox(start, end, tipo, free);
                if (sempreLiberi.Count == 0)
                {
                    ok = false;
                    break;
                }
                List<Periodo> tmp = new List<Periodo>();
                foreach (int index in sempreLiberi)
                    if ((listPreferiti.Contains(index) || listPreferiti.Count == 0 ) && free.Count < requiredBox )
                    {
                        tmp.Add(new Periodo(start, end, index));
                        free.Add(tmp);
                    }
            }

            for (int i = free.Count; i < requiredBox; i++)
            {
                List<Periodo> currentListPeriodi = new List<Periodo>();
                Periodo current = new Periodo(start, start, -1);
                while (current.EndTime < end)
                {
                    //box liberi oggi
                    List<int> tmpFree = FreeBoxesInADay(current.EndTime, tipo, free);

                    //box liberi oggi e tra i preferiti
                    List<int> tmpFreeAndPreferred = new List<int>();

                    foreach (int j in tmpFree)
                        if(listPreferiti.Contains(j))
                            tmpFreeAndPreferred.Add(j); 
                        
                    if (current.Box == -1 && tmpFree.Count > 0 && current.StartTime == current.EndTime)
                    {
                        //se riesco aggiungo uno di quelli richiesti
                        if (tmpFreeAndPreferred.Count > 0)
                            current.Box = tmpFreeAndPreferred[0];
                        else
                            current.Box = tmpFree[0];
                    }

                    //allungo il periodo se la lista tmpFree contiene il box del giorno precedente oppure se sia il giorno "oggi" che quello
                    //successivo non ci sono box disponibili.
                    if((current.Box >= 0 && tmpFree.Contains(current.Box) && (tmpFreeAndPreferred.Count == 0 || tmpFreeAndPreferred.Contains(current.Box)) || (current.Box == -1 && tmpFree.Count == 0))) // && tmpFreeAndPreferred.Count == 0 )
                        current.EndTime = current.EndTime.AddMinutes(30);
                    else if (tmpFree.Count > 0)
                    {
                        currentListPeriodi.Add(current);
                        DateTime endDate = current.EndTime;
                        if(tmpFreeAndPreferred.Count > 0)
                            current = new Periodo(endDate, endDate, tmpFreeAndPreferred[0]);
                        else
                            current = new Periodo(endDate, endDate, tmpFree[0]);
                    }
                    else {
                        currentListPeriodi.Add(current);
                        DateTime endDate = current.EndTime;
                        current = new Periodo(endDate, endDate, -1);
                    }
                }
                currentListPeriodi.Add(current);
                free.Add(currentListPeriodi);
            }

            //ottimizzazione finale per vedere di usare il numero minore di box
            foreach (List<Periodo> listaPeriodi in free)
            {
                bool modified;
                do
                {   
                    modified = false;
                    for (int i = 0; i < listaPeriodi.Count -1; i++)
                    {
                        
                        List<List<Periodo>> copy = new List<List<Periodo>>();
                        copy.AddRange(free);
                        copy.Remove(listaPeriodi);

                        List<int> newList;
                        if (!listPreferiti.Contains(listaPeriodi[i].Box) &&
                            !listPreferiti.Contains(listaPeriodi[i + 1].Box) &&
                            (newList = AlwaysFreeBox(listaPeriodi[i].StartTime, listaPeriodi[i + 1].EndTime, tipo, copy)).Count > 0)
                        {
                            listaPeriodi[i].Box = newList[0];
                            listaPeriodi[i].EndTime = listaPeriodi[i + 1].EndTime;
                            listaPeriodi.RemoveAt(i + 1);
                            modified = true;
                        }
                    }
                } while (modified);
            }
            return free;
        }

        public List<Switch> TodayChangeBoxList()
        {
            List<Switch> switches = new List<Switch>();
            foreach(Prenotazione prenotazione in _prenotazioni)
            {
                foreach(List<Periodo> listaPeriodi in prenotazione.ListaBox)
                    foreach(Periodo periodo in listaPeriodi)
                    {
                        if (periodo.EndTime.Date == DateTime.Now.Date)
                        {
                            if (prenotazione.Uscita.Date == periodo.EndTime.Date)
                                switches.Add(new Switch(periodo.Box, -1, prenotazione));
                            else
                            {
                                //aggiunge uno switch dato dal box, dal box del periodo successivo e dalla prenotazione.
                                //
                                int posBox = prenotazione.ListaBox.IndexOf(listaPeriodi);
                                List<Periodo> listaBox = prenotazione.ListaBox[posBox];
                                if(periodo.Box != listaBox.ElementAt(listaBox.IndexOf(periodo) + 1).Box)
                                    switches.Add(new Switch(periodo.Box, listaBox.ElementAt(
                                        listaBox.IndexOf(periodo) + 1).Box, prenotazione));
                            }
                         }
                         else if(prenotazione.Entrata.Date == DateTime.Now.Date)
                        {
                            int posBox = prenotazione.ListaBox.IndexOf(listaPeriodi);
                            List<Periodo> listaBox = prenotazione.ListaBox[posBox];
                            switches.Add(new Switch(-1, listaBox[0].Box, prenotazione));
                        }
                    }
            }
            return switches;
        }

        public int BoxCani { get { return BOX_CANI_SIZE; } set { BOX_CANI_SIZE = value; } }

        public int BoxGatti { get { return BOX_GATTI_SIZE; } set { BOX_GATTI_SIZE = value; } }

        public List<Prenotazione> PrenotazioniCani
        {
            get
            {
                List<Prenotazione> res = new List<Prenotazione>();
                foreach (Prenotazione pren in _prenotazioni)
                    if (pren.Tipo == Prenotazione.CANE)
                        res.Add(pren);
                return res;
            }
        }

        public List<Prenotazione> PrenotazioniGatti
        { get
            {
                List<Prenotazione> res = new List<Prenotazione>();
                foreach (Prenotazione pren in _prenotazioni)
                    if (pren.Tipo == Prenotazione.GATTO)
                        res.Add(pren);
                return res;
            }
        }
    }
}
