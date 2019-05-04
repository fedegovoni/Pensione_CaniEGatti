using Pensione_CaniEGatti.Gestione;
using Pizzi_CaniEGatti.Grafica;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pensione_CaniEGatti.Grafica
{
    public partial class AnagraficaForm : Form
    {

        private InserisciPrenotazioneForm _inserisciForm;
        private Rubrica _rubrica;
        private bool _ascending = true;

        public AnagraficaForm()
        {
            _rubrica = Rubrica.GetInstance();
            InitializeComponent();
            UpdateRubricaListView();
        }

        public AnagraficaForm(InserisciPrenotazioneForm inserisciForm) : this()
        {
            _inserisciForm = inserisciForm;
        }

        private void _searchTextBox_TextChanged(object sender, EventArgs e)
        {
            UpdateRubricaListView();
        }

        public void UpdateRubricaListView()
        {
            string toSearch = _searchTextBox.Text;
            _rubricaListView.Items.Clear();
            foreach (Persona p in Rubrica.GetInstance().Search(toSearch))
            {
                string[] row = { p.ID.ToString(), p.Cognome, p.Nome, p.Telefono, p.CodiceFiscale, p.PadroneDi.Replace(System.Environment.NewLine, " ") };
                _rubricaListView.Items.Add(new ListViewItem(row));
            }
        }

        private void _rubricaListView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if(_inserisciForm != null)
            {
                ListViewItem item = null;
                try {
                    item = _rubricaListView.SelectedItems[0];
                } catch (IndexOutOfRangeException)
                {
                    Close();
                }
                int pos = _rubricaListView.SelectedIndices[0];
                Persona selectedPersona = _rubrica.Persone[pos];
                _inserisciForm.NomeText = selectedPersona.Nome;
                _inserisciForm.CognomeText = selectedPersona.Cognome;
                _inserisciForm.TelefonoText = selectedPersona.Telefono;
                Close();
            }
        }

        private void _inserisciPersonaButton_Click(object sender, EventArgs e)
        {
            InserisciPersonaForm ifa = new InserisciPersonaForm(this);
            ifa.Show();
        }

        private void _rubricaListView_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (_rubricaListView.FocusedItem.Bounds.Contains(e.Location) == true)
                {
                    contextMenuStrip1.Show(Cursor.Position);
                }
            }
        }
        
        private void modificaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Persona toModify = _rubrica.GetById(int.Parse(_rubricaListView.SelectedItems[0].SubItems[0].Text));
            InserisciPersonaForm ifa = new InserisciPersonaForm(this, toModify);
            ifa.Show();
        }

        private void cancellaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var items = _rubricaListView.SelectedItems[0].SubItems;
            _rubrica.RemovePersona(int.Parse(items[0].Text));
            UpdateRubricaListView();
        }

        private void _listView_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            ColumnHeader clickedCol = _rubricaListView.Columns[e.Column];
            _ascending = !_ascending;

            int numItems = _rubricaListView.Items.Count;
            _rubricaListView.BeginUpdate();

            ArrayList SortArray = new ArrayList();
            for (int i = 0; i < numItems; i++)
            {
                SortArray.Add(new SortWrapper(_rubricaListView.Items[i], e.Column));
            }

            SortArray.Sort(0, SortArray.Count, new SortWrapper.SortComparer(_ascending));

            _rubricaListView.Items.Clear();
            for (int i = 0; i < numItems; i++)
                _rubricaListView.Items.Add(((SortWrapper)SortArray[i]).sortItem);

            _rubricaListView.EndUpdate();
        }
    }
}
