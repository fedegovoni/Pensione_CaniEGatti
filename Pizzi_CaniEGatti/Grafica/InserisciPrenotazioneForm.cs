using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Pizzi_CaniEGatti.Gestione;
using Pensione_CaniEGatti.Grafica;

namespace Pizzi_CaniEGatti.Grafica
{
    public partial class InserisciPrenotazioneForm : Form
    {

        private MainForm _mainForm = null;
        private Prenotazione _toModify = null;
        private DateTime _prevDateEntrata;
        private DateTime _prevDateUscita;
        private bool _initValueEntrata = true;
        private bool _initValueUscita = true;
        private GestorePrenotazioni _gestorePrenotazioni;

        public InserisciPrenotazioneForm(MainForm mainForm)
        {
            InitializeComponent();
            _caneRadioButton.Checked = true;
            _mainForm = mainForm;
            _oraEntrataTimePicker.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0);
            _oraUscitaTimePicker.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0);
            _answer.Text = "";
            _prevDateEntrata = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0);
            _prevDateUscita = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0);
            _gestorePrenotazioni = GestorePrenotazioni.GetInstance();
        }



        public InserisciPrenotazioneForm(MainForm mainForm, Prenotazione toModify)
        {
            InitializeComponent();
            _caneRadioButton.Checked = true;
            _mainForm = mainForm;
            _toModify = toModify;
            _entrataTimePicker.Value = toModify.Entrata;
            _uscitaTimePicker.Value = toModify.Uscita;
            _oraEntrataTimePicker.Value = toModify.Entrata;
            _oraUscitaTimePicker.Value = toModify.Uscita;
            _nomeTextBox.Text = toModify.Nome;
            _telefonoTextBox.Text = toModify.Telefono;
            _cognomeTextBox.Text = toModify.Cognome;
            _boxNumTextBox.Text = toModify.NumBox.ToString();
            _answer.Text = "";
            if(toModify.Tipo == Prenotazione.CANE)
            {
                _caneRadioButton.Checked = true;
                _gattoRadioButton.Checked = false;
            }
            else
            {
                _caneRadioButton.Checked = false;
                _gattoRadioButton.Checked = true;
            }
        }
        
        public string NomeText { get { return _nomeTextBox.Text; }set { _nomeTextBox.Text = value; } }

        public string CognomeText { get { return _cognomeTextBox.Text; } set { _cognomeTextBox.Text = value; } }

        public string TelefonoText { get { return _telefonoTextBox.Text; } set { _telefonoTextBox.Text = value; } } 

        private void _ok_Click(object sender, EventArgs e)
        {
            Prenotazione original = null;
            if (_toModify != null)
            {
                original = GestorePrenotazioni.GetInstance().GetById(_toModify.ID);
                GestorePrenotazioni.GetInstance().RemovePrenotazione(_toModify.ID);
            }

                int numBox = 0;
            try
            {
                numBox = int.Parse(_boxNumTextBox.Text);
                if (numBox <= 0)
                    throw new FormatException();
            }
            catch (Exception ex)
            {
                if (ex is ArgumentNullException || ex is FormatException)
                {
                    MessageBox.Show("Errore", "Inserisci un numero di box maggiore di 0", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            DateTime entrata = DateTime.Parse(_entrataTimePicker.Text);
            entrata = entrata.AddHours(DateTime.Parse(_oraEntrataTimePicker.Text).Hour);
            entrata = entrata.AddMinutes(DateTime.Parse(_oraEntrataTimePicker.Text).Minute);
            DateTime uscita = DateTime.Parse(_uscitaTimePicker.Text);
            uscita = uscita.AddHours(DateTime.Parse(_oraUscitaTimePicker.Text).Hour);
            uscita = uscita.AddMinutes(DateTime.Parse(_oraUscitaTimePicker.Text).Minute);
            string nome = _nomeTextBox.Text;
            string cognome = _cognomeTextBox.Text;
            string telefono = _telefonoTextBox.Text;

            if (uscita <= entrata)
            {
                _answer.Text = "Controlla le date!";
                _answer.ForeColor = Color.Red;
                return;
            }

            List<int> preferiti = new List<int>();
            foreach (string s in _preferenzeTextBox.Text.Split(','))
            {
                try
                {
                    preferiti.Add(int.Parse(s.Trim()));
                }
                catch (FormatException) { }
            }

            int tipo = _caneRadioButton.Checked ? Prenotazione.CANE : Prenotazione.GATTO;
            List<List<Periodo>> free = GestorePrenotazioni.GetInstance().FindAStay(entrata, uscita, tipo, numBox, preferiti);

            String text = "";
            foreach (List<Periodo> listaPeriodi in free)
            {
                foreach (Periodo periodo in listaPeriodi)
                    text += periodo.ToString();
                if (free.IndexOf(listaPeriodi) != free.Count - 1)
                    text += System.Environment.NewLine;
            }
            bool libero = true;
            foreach (List<Periodo> listaPeriodi in free)
                foreach (Periodo p in listaPeriodi)
                {
                    if (p.Box == -1)
                    {
                        libero = false;
                        break;
                    }
                }
            _answer.Text = text;
            if (libero && _toModify == null)
            {
                GestorePrenotazioni.GetInstance().AddPrenotazione(new Prenotazione(nome, cognome, telefono, entrata, uscita, tipo, free));
                _mainForm.UpdateDaFareOggi();
                _mainForm.UpdatePrenotazioniListView();
                Close();
            }
            else if (libero && _toModify != null)
            {
                Prenotazione p = new Prenotazione(original);
                p.Cognome = cognome;
                p.Nome = nome;
                p.ListaBox = free;
                p.Tipo = tipo;
                p.Uscita = uscita;
                p.Entrata = entrata;
                p.Telefono = telefono;
                GestorePrenotazioni.GetInstance().AddPrenotazione(p);
                _mainForm.UpdateDaFareOggi();
                _mainForm.UpdatePrenotazioniListView();
                Close();
            }
            else
            {
                _answer.ForeColor = Color.Red;
                _answer.Text = "In almeno un giorno c'è un box non disponibile!";
                if(original != null)
                    GestorePrenotazioni.GetInstance().AddPrenotazione(original);
            }
        }
    

        private void _annulla_Click(object sender, EventArgs e)
        {
            _toModify = null;
            this.Close();
        }

        private void _checkButton_Click(object sender, EventArgs e)
        {
            Prenotazione original = null;
            if (_toModify != null)
            {
                original = GestorePrenotazioni.GetInstance().GetById(_toModify.ID);
                GestorePrenotazioni.GetInstance().RemovePrenotazione(_toModify.ID);
            }

            List<int> preferiti = new List<int>();
            foreach (string s in _preferenzeTextBox.Text.Split(','))
            {
                try
                {
                    preferiti.Add(int.Parse(s.Trim()));
                }
                catch (FormatException) { }
            }

            int numBox = 0;
            try
            {
                numBox = int.Parse(_boxNumTextBox.Text);
                if (numBox <= 0)
                    throw new FormatException();
            }
            catch (Exception ex)
            {
                if (ex is ArgumentNullException || ex is FormatException)
                {
                    MessageBox.Show("Errore", "Inserisci un numero di box maggiore di 0", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            DateTime entrata = DateTime.Parse(_entrataTimePicker.Text);
            entrata = entrata.AddHours(DateTime.Parse(_oraEntrataTimePicker.Text).Hour);
            entrata = entrata.AddMinutes(DateTime.Parse(_oraEntrataTimePicker.Text).Minute);
            DateTime uscita = DateTime.Parse(_uscitaTimePicker.Text);
            uscita = uscita.AddHours(DateTime.Parse(_oraUscitaTimePicker.Text).Hour);
            uscita = uscita.AddMinutes(DateTime.Parse(_oraUscitaTimePicker.Text).Minute);

            if (uscita <= entrata) {
                _answer.Text = "Controlla le date!";
                _answer.ForeColor = Color.Red;
                return;
            }

            int tipo = _caneRadioButton.Checked ? Prenotazione.CANE : Prenotazione.GATTO;
            List<List<Periodo>> free = _gestorePrenotazioni.FindAStay(entrata, uscita, tipo, numBox, preferiti);

            String text = "";
            bool tuttiPreferiti = true;
            foreach (List<Periodo> listaPeriodi in free) {
                foreach (Periodo periodo in listaPeriodi)
                {
                    text += periodo.ToString();
                    if (preferiti.Count() > 0 && !preferiti.Contains(periodo.Box))
                        tuttiPreferiti = false;
                }
                if (free.IndexOf(listaPeriodi) != free.Count - 1)
                    text += System.Environment.NewLine;
            }
            bool libero = true;
            foreach (List<Periodo> listaPeriodi in free)
                foreach (Periodo p in listaPeriodi) {
                    if (p.Box == -1)
                    {
                        libero = false;
                        break;
                    }
                }
            _answer.Text = text;

            if (libero) {
                if (!tuttiPreferiti)
                {
                    _answer.ForeColor = Color.DarkOrange;
                    _answer.Text = "ATTENZIONE: " + System.Environment.NewLine + "Non tutte le soluzioni comprendono i box selezionati:"
                        + System.Environment.NewLine + System.Environment.NewLine + _answer.Text;
                }
                else
                    _answer.ForeColor = Color.Green;
            }
            else
                _answer.ForeColor = Color.Red;
            if(_toModify != null && original != null)
                GestorePrenotazioni.GetInstance().AddPrenotazione(original);
        }

        private void _oraEntrataTimePicker_ValueChanged(object sender, EventArgs e)
        {
            if(_initValueEntrata)
            {
                _initValueEntrata = false;
                return;
            }
            DateTime dt = _oraEntrataTimePicker.Value;
            TimeSpan diff = dt - _prevDateEntrata;

            if (dt.Minute - _prevDateEntrata.Minute != 0)
            {
                if (diff.Ticks < 0)
                    _oraEntrataTimePicker.Value = _prevDateEntrata.AddMinutes(-30);
                else
                    _oraEntrataTimePicker.Value = _prevDateEntrata.AddMinutes(30);
            }
            _prevDateEntrata = _oraEntrataTimePicker.Value;
        }

        private void _oraUscitaTimePicker_ValueChanged(object sender, EventArgs e)
        {
            if (_initValueUscita)
            {
                _initValueUscita = false;
                return;
            }
            DateTime dt = _oraUscitaTimePicker.Value;
            TimeSpan diff = dt - _prevDateUscita;

            if (dt.Minute - _prevDateUscita.Minute != 0)
            {
                if (diff.Ticks < 0)
                    _oraUscitaTimePicker.Value = _prevDateUscita.AddMinutes(-30);
                else
                    _oraUscitaTimePicker.Value = _prevDateUscita.AddMinutes(30);
            }
            _prevDateUscita = _oraUscitaTimePicker.Value;
        }

        private void _rubricaButton_Click(object sender, EventArgs e)
        {
            AnagraficaForm af = new AnagraficaForm(this);
            af.Show();
        }

        private void label12_Click(object sender, EventArgs e)
        {

        }
    }
}
