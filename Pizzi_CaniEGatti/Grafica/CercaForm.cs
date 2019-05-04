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

namespace Pizzi_CaniEGatti.Grafica
{
    public partial class CercaForm : Form
    {

        private bool _initValueInizio = true;
        private bool _initValueFine = true;
        private DateTime _prevDateInizio;
        private DateTime _prevDateFine;

        public CercaForm()
        {
            InitializeComponent();
            DateTime tmp = DateTime.MinValue;
            _oraFine.Text = tmp.ToString("HH:mm");
            _oraInizio.Text = tmp.ToString("HH:mm");
            _caniRadioButton.Checked = true;
            _prevDateInizio = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0);
            _prevDateFine = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0);
        }

        private void _chiudiButton_Click_1(object sender, EventArgs e)
        {
            Close();
        }

        private void _cercaButton_Click(object sender, EventArgs e)
        {
            _resLabel.Text = "Box disponibili: " + System.Environment.NewLine;
            DateTime start = DateTime.Parse(_dataInizio.Text);
            DateTime startTime = DateTime.Parse(_oraInizio.Text);
            start = start.AddHours(startTime.Hour);
            start = start.AddMinutes(startTime.Minute);

            DateTime end = DateTime.Parse(_dataFine.Text);
            DateTime endTime = DateTime.Parse(_oraFine.Text);
            end = end.AddHours(endTime.Hour);
            end = end.AddMinutes(endTime.Minute);

            if(start >= end)
            {
                _resLabel.Text = "Controlla le date!";
                _resLabel.ForeColor = Color.Red;
                return;
            }

            int tipo = _caniRadioButton.Checked ? Prenotazione.CANE : Prenotazione.GATTO;
            List<int> freeBoxes = GestorePrenotazioni.GetInstance().FreeBoxesInPeriod(start, end, tipo);
            List<List<Periodo>> solution = GestorePrenotazioni.GetInstance().FindAStay(start, end, tipo, 1);
            bool isThereASolution = true;
            foreach(List<Periodo> listaPeriodi in solution)
                foreach (Periodo periodo in listaPeriodi)
                    if (periodo.Box == -1)
                      isThereASolution = false;

            if (freeBoxes.Count > 0)
            {
                _resLabel.Text += System.Environment.NewLine;
                foreach (int box in freeBoxes)
                {
                    _resLabel.Text = _resLabel.Text + box;
                    if (freeBoxes.IndexOf(box) != freeBoxes.Count - 1)
                        _resLabel.Text = _resLabel.Text + ", ";
                }
                _resLabel.ForeColor = Color.Green;
            }
            else if (isThereASolution)
            {
                _resLabel.ForeColor = Color.Green;
                _resLabel.Text = "Non ci sono box sempre disponibili ma c'è almeno una soluzione logistica:" + System.Environment.NewLine;
                foreach (List<Periodo> listaPeriodi in solution)
                    foreach (Periodo periodo in listaPeriodi)
                        _resLabel.Text = _resLabel.Text + periodo.ToString();
            }
            else
            {
                _resLabel.Text = "Non ci sono soluzioni disponibili.";
                _resLabel.ForeColor = Color.Red;
            }
        }

        private void _resLabel_Click(object sender, EventArgs e)
        {

        }

        private void _oraInizio_ValueChanged(object sender, EventArgs e)
        {
            if (_initValueInizio)
            {
                _initValueInizio = false;
                return;
            }
            DateTime dt = _oraInizio.Value;
            TimeSpan diff = dt - _prevDateInizio;

            if (dt.Minute - _prevDateInizio.Minute != 0)
            {
                if (diff.Ticks < 0)
                    _oraInizio.Value = _prevDateInizio.AddMinutes(-30);
                else
                    _oraInizio.Value = _prevDateInizio.AddMinutes(30);
            }
            _prevDateInizio = _oraInizio.Value;
        }

        private void _oraFine_ValueChanged(object sender, EventArgs e)
        {
            if (_initValueFine)
            {
                _initValueFine = false;
                return;
            }
            DateTime dt = _oraFine.Value;
            TimeSpan diff = dt - _prevDateFine;

            if (dt.Minute - _prevDateFine.Minute != 0)
            {
                if (diff.Ticks < 0)
                    _oraFine.Value = _prevDateFine.AddMinutes(-30);
                else
                    _oraFine.Value = _prevDateFine.AddMinutes(30);
            }
            _prevDateFine = _oraFine.Value;
        }
    }
}
