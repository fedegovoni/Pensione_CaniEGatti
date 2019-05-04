using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pizzi_CaniEGatti.Grafica;
using Pizzi_CaniEGatti.Gestione;
using System.Windows.Forms;

namespace Pizzi_CaniEGatti.Grafica
{
    public partial class ImpsotazioniForm : Form
    {
        private MainForm _mainForm;

        public ImpsotazioniForm(MainForm form)
        {
            InitializeComponent();
            _mainForm = form;
            _numCaniTextBox.Text = Gestione.GestorePrenotazioni.BOX_CANI_SIZE + "";
            _numGattiTextBox.Text = Gestione.GestorePrenotazioni.BOX_GATTI_SIZE + "";
            DateTime now = DateTime.Now;
            now = now.AddDays(-3);
            _deleteTimePicker.Text = now.ToLongDateString();
        }

        private void _okButton_Click(object sender, EventArgs e)
        {
            int num;
            if (int.TryParse(_numCaniTextBox.Text, out num))
                Gestione.GestorePrenotazioni.GetInstance().BoxCani = num;
            if (int.TryParse(_numGattiTextBox.Text, out num))
                Gestione.GestorePrenotazioni.GetInstance().BoxGatti = num;
            Persistenza.ImpostazioniRW.writeSettings(Gestione.GestorePrenotazioni.BOX_CANI_SIZE, Gestione.GestorePrenotazioni.BOX_GATTI_SIZE);

            Close();
        }

        private void _deleteButton_Click(object sender, EventArgs e)
        {
            DateTime date = DateTime.Parse(_deleteTimePicker.Text);
            var confirmResult = MessageBox.Show("Sei sicuro di voler cancellare le prenotazioni fino al "
                + date.ToShortDateString() + "?", "Conferma",
                                     MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                List<Prenotazione> toDelete = new List<Prenotazione>();
                foreach (Prenotazione pren in GestorePrenotazioni.GetInstance().Prenotazioni)
                    if (pren.Uscita <= date)
                        toDelete.Add(pren);

                foreach (Prenotazione p in toDelete)
                    GestorePrenotazioni.GetInstance().RemovePrenotazione(p.ID);

                _mainForm.UpdateDaFareOggi();
                _mainForm.UpdatePrenotazioniListView();

            }
            else
            {
                
            }
        }
    }
}
