using Pizzi_CaniEGatti.Grafica;
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
using Pensione_CaniEGatti.Gestione;
using System.Collections;

namespace Pizzi_CaniEGatti
{
    public partial class MainForm : Form
    {

        private GestorePrenotazioni _gestorePrenotazioni;
        private bool _ascending = true;

        public MainForm()
        {
            InitializeComponent();
            _gestorePrenotazioni = Gestione.GestorePrenotazioni.GetInstance();
            UpdateDaFareOggi();
            UpdatePrenotazioniListView();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            InserisciPrenotazioneForm inserisci = new InserisciPrenotazioneForm(this);
            inserisci.Show();
        }

        public void UpdatePrenotazioniListView()
        {
            _prenotazioniListView.Items.Clear();
            List<Prenotazione> prenotazioni = (List<Prenotazione>)_gestorePrenotazioni.Prenotazioni;
            foreach (Prenotazione p in _gestorePrenotazioni.Prenotazioni)
            {
                ListViewItem lvi = new ListViewItem();
                String boxString = "";
                foreach (List<Periodo> listaPeriodi in p.ListaBox)
                {
                    foreach (Periodo periodo in listaPeriodi)
                    {
                        boxString += periodo.Box;
                        if (listaPeriodi.IndexOf(periodo) != listaPeriodi.Count - 1)
                            boxString += ", ";
                    }
                    int indexOfListaPeriodi = p.ListaBox.IndexOf(listaPeriodi);
                    if (indexOfListaPeriodi != p.ListaBox.Count - 1)
                        boxString += " | ";
                }

                String[] row = { p.ID.ToString(), p.Tipo == Prenotazione.CANE ? "CANI" : "GATTI", p.Nome, p.Cognome,
                    p.Telefono, p.Entrata.ToString("dd/MM/yyyy - HH:mm"), p.Uscita.ToString("dd/MM/yyyy - HH:mm"), p.NumBox.ToString(), boxString };
                _prenotazioniListView.Items.Add(new ListViewItem(row));
            }
        }

        public void UpdateDaFareOggi()
        {
            String todo = "Da fare oggi:" + System.Environment.NewLine  + System.Environment.NewLine;
            foreach(Gestione.Switch sw in _gestorePrenotazioni.TodayChangeBoxList())
            {
                todo = todo + sw.ToString() + System.Environment.NewLine;
            }
            _toDoText.Text = todo;
        }

        private void _impostazioni_Click(object sender, EventArgs e)
        {
            ImpsotazioniForm form = new ImpsotazioniForm(this);
            form.Show();
        }

        private void _prenotazioniListView_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (_prenotazioniListView.FocusedItem.Bounds.Contains(e.Location) == true)
                {
                    contextMenuStrip1.Show(Cursor.Position);
                }
            }
        }

        private void _prenotazioniListView_Click(object sender, EventArgs e)
        {
        }
        
        private void cancellaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int toDelete = _prenotazioniListView.SelectedIndices[0];
            Prenotazione prenToDelete = GestorePrenotazioni.GetInstance().Prenotazioni[toDelete];
            Gestione.GestorePrenotazioni.GetInstance().RemovePrenotazione(prenToDelete.ID);
            UpdateDaFareOggi();
            UpdatePrenotazioniListView();
        }

        private void _cercaButton_Click(object sender, EventArgs e)
        {
            CercaForm cf = new CercaForm();
            cf.Show();
        }

        private void modificaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Prenotazione toModify = GestorePrenotazioni.GetInstance().GetById(int.Parse(
                _prenotazioniListView.SelectedItems[0].SubItems[0].Text));
            InserisciPrenotazioneForm ifa = new InserisciPrenotazioneForm(this, toModify);
            ifa.Show();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string searchText = _searchTextBox.Text;
            string[] toSearch = searchText.Split(' ');
            _prenotazioniListView.Items.Clear();
            foreach (Prenotazione p in GestorePrenotazioni.GetInstance().Prenotazioni)
            {
                bool write = true;
                foreach (string s in toSearch)
                {
                    if (!(p.Nome.ToUpper().Contains(s.ToUpper()) || p.Cognome.ToUpper().Contains(s.ToUpper()) || p.Telefono.Contains(s.ToUpper())))
                        write = false;
                }

                if (write)
                {
                    String boxString = "";
                    foreach (List<Periodo> listaPeriodi in p.ListaBox)
                    {
                        foreach (Periodo periodo in listaPeriodi)
                        {
                            boxString += periodo.Box;
                            if (listaPeriodi.IndexOf(periodo) != listaPeriodi.Count - 1)
                                boxString += ", ";
                        }
                        int indexOfListaPeriodi = p.ListaBox.IndexOf(listaPeriodi);
                        if (indexOfListaPeriodi != p.ListaBox.Count - 1)
                            boxString += " | ";
                    }
                    String[] row = { p.ID.ToString(), p.Tipo == Prenotazione.CANE ? "CANI" : "GATTI", p.Nome, p.Cognome,
                    p.Telefono, p.Entrata.ToString("dd/MM/yyyy - HH:mm"), p.Uscita.ToString("dd/MM/yyyy - HH:mm"), p.NumBox.ToString(), boxString };
                    _prenotazioniListView.Items.Add(new ListViewItem(row));
                }
            }
        }

        private void _rubricaButton_Click(object sender, EventArgs e)
        {
            AnagraficaForm af = new AnagraficaForm();
            af.Show();
        }

        private void _prenotazioniListView_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            ColumnHeader clickedCol = _prenotazioniListView.Columns[e.Column];
            _ascending = !_ascending;

            int numItems = _prenotazioniListView.Items.Count;
            _prenotazioniListView.BeginUpdate();

            ArrayList SortArray = new ArrayList();
            for (int i = 0; i < numItems; i++)
            {
                SortArray.Add(new SortWrapper(_prenotazioniListView.Items[i], e.Column));
            }

            SortArray.Sort(0, SortArray.Count, new SortWrapper.SortComparer(_ascending));

            _prenotazioniListView.Items.Clear();
            for (int i = 0; i < numItems; i++)
                _prenotazioniListView.Items.Add(((SortWrapper)SortArray[i]).sortItem);

            _prenotazioniListView.EndUpdate();
        }
    }
}
