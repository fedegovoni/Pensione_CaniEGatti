using Pensione_CaniEGatti.Gestione;
using System;
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
    public partial class InserisciPersonaForm : Form
    {
        private Persona _toModify = null;
        private AnagraficaForm _anagraficaForm;
        private Rubrica _rubrica;

        public InserisciPersonaForm(AnagraficaForm anagraficaForm)
        {
            InitializeComponent();
            _rubrica = Rubrica.GetInstance();
            _anagraficaForm = anagraficaForm;
        }

        public InserisciPersonaForm(AnagraficaForm anagraficaForm, Persona toModify) : this(anagraficaForm)
        {
            _toModify = toModify;
            if(_toModify != null)
            {
                _cognomeTextBox.Text = toModify.Cognome;
                _nomeTextBox .Text= toModify.Nome;
                _cfTextBox.Text = toModify.CodiceFiscale;
                _telefonoTextBox.Text = toModify.Telefono;
                _padroneDiTextBox.Text = toModify.PadroneDi;
            }
        }

        private void _okButton_Click(object sender, EventArgs e)
        {
            Persona toAdd;
            if (_toModify != null)
            {
                _rubrica.RemovePersona(_toModify.ID);
                toAdd = _toModify;
                toAdd.Nome = _nomeTextBox.Text;
                toAdd.Cognome = _cognomeTextBox.Text;
                toAdd.CodiceFiscale = _cfTextBox.Text;
                toAdd.Telefono = _telefonoTextBox.Text;
                toAdd.PadroneDi = _padroneDiTextBox.Text;
            }
            else
            {
                toAdd = new Persona(_nomeTextBox.Text, _cognomeTextBox.Text, _telefonoTextBox.Text,
                    _cfTextBox.Text, _padroneDiTextBox.Text);
            }
            var confirmResult = DialogResult.Yes;
            bool exist = false;
            bool existCf = false;
            foreach (Persona p in _rubrica.Persone)
                if (p.Cognome == toAdd.Cognome && p.Nome == toAdd.Nome)
                {
                    exist = true;
                    if (p.CodiceFiscale == toAdd.CodiceFiscale)
                        existCf = true;
                }
            if(exist && existCf)
            {
                confirmResult = MessageBox.Show("Esiste una persona con stesso nome, cognome e codice fiscale." + 
                    System.Environment.NewLine + "Inserire ugualmente?", "Conferma",
                                     MessageBoxButtons.YesNo);                
            } else if (exist)
            {
                confirmResult = MessageBox.Show("Esiste una persona con stesso nome e cognome ma codice fiscale diverso." +
                    System.Environment.NewLine + "Inserire ugualmente?", "Conferma",
                                     MessageBoxButtons.YesNo);
            }
            if (confirmResult == DialogResult.Yes)
            {
                _rubrica.AddPersona(toAdd);
                
                _anagraficaForm.UpdateRubricaListView();
                Close();
            }
        }

        private void _annullaButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
