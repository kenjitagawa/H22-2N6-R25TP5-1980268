using System;
using System.Windows.Forms;
using System.IO;


namespace BaladeurMultiFormats
{
    // Étapes de  réalisation :
    // Étape #1 : Définir les classes Chanson et ChasonAAC

    public partial class FrmPrincipal : Form
    {
        public const string APP_INFO = "(Matériel)";

        #region Propriété : MonHistorique
        public Historique MonHistorique { get; }

        private Baladeur baladeur { get; }

        public Chanson ChansonCourante
        {
            get
            {
                if (lsvChansons.SelectedIndices.Count == 0)
                {
                    return null;
                }
                return baladeur.ChansonAt(lsvChansons.SelectedIndices[0]);
            }
        }

        public int IndexChansonCourante
        {
            get
            {
                if (lsvChansons.SelectedIndices.Count == 0)
                {
                    return -1;
                }
                return lsvChansons.SelectedIndices[0];
            }
        }


        #endregion
        //---------------------------------------------------------------------------------
        #region FrmPrincipal
        public FrmPrincipal()
        {
            InitializeComponent();
            Text += APP_INFO;
            MonHistorique = new Historique();

            baladeur = new Baladeur();
            baladeur.ConstruireLaListeDesChansons();
            baladeur.AfficherLesChansons(lsvChansons);
            lblNbChansons.Text = lsvChansons.Items.Count.ToString();
            MettreAJourSelonContexte();
            MonHistorique = new Historique();

        }
        #endregion
        //---------------------------------------------------------------------------------
        #region Méthode : MettreAJourSelonContexte
        private void MettreAJourSelonContexte()
        {
            if (ChansonCourante == null)
            {
                MnuFormatConvertirVersWMA.Enabled = false;
                MnuFormatConvertirVersMP3.Enabled = false;
                MnuFormatConvertirVersAAC.Enabled = false;
                txtParoles.Text = string.Empty;
            }
            else
            {
                MnuFormatConvertirVersMP3.Enabled = ChansonCourante.Format != "MP3";
                MnuFormatConvertirVersWMA.Enabled = ChansonCourante.Format != "WMA";
                MnuFormatConvertirVersAAC.Enabled = ChansonCourante.Format != "AAC";
            }
        }
        #endregion
        //---------------------------------------------------------------------------------
        #region Événement : LsvChansons_SelectedIndexChanged
        private void LsvChansons_SelectedIndexChanged(object sender, EventArgs e)
        {
            MettreAJourSelonContexte();
            if (lsvChansons.SelectedIndices.Count > 0)
            {
                txtParoles.Text = ChansonCourante.Paroles;
                MonHistorique.Add(new Consultation(DateTime.Now, ChansonCourante));
            }
        }
        #endregion

        //---------------------------------------------------------------------------------
        #region Méthodes : Convertir vers les formats AAC, MP3 ou WMA
        private void MnuFormatConvertirVersAAC_Click(object sender, EventArgs e)
        {
            // Vider l'historique car les références ne sont plus bonnes
            MonHistorique.Clear();
            baladeur.ConvertirVersAAC(IndexChansonCourante);
            lsvChansons.Items[IndexChansonCourante].SubItems[3].Text = "AAC";
            MettreAJourSelonContexte();
        }
        private void MnuFormatConvertirVersMP3_Click(object sender, EventArgs e)
        {
            // Vider l'historique car les références ne sont plus bonnes
            MonHistorique.Clear();
            baladeur.ConvertirVersMP3(IndexChansonCourante);
            lsvChansons.Items[IndexChansonCourante].SubItems[3].Text = "MP3";
            MettreAJourSelonContexte();
        }
        private void MnuFormatConvertirVersWMA_Click(object sender, EventArgs e)
        {
            // Vider l'historique car les références ne sont plus bonnes
            MonHistorique.Clear();
            baladeur.ConvertirVersWMA(IndexChansonCourante);
            lsvChansons.Items[IndexChansonCourante].SubItems[3].Text = "WMA";
            MettreAJourSelonContexte();
        }
        #endregion
        //---------------------------------------------------------------------------------
        #region Historique
        private void MnuSpécialHistorique_Click(object sender, EventArgs e)
        {
            FrmHistorique objFormulaire = new FrmHistorique(MonHistorique);
            objFormulaire.ShowDialog();
        }
        #endregion
         //---------------------------------------------------------------------------------
        #region Méthodes : MnuFichierQuitter_Click
        //---------------------------------------------------------------------------------
        private void MnuFichierQuitter_Click(object sender, EventArgs e)
        {
            Close();
        }
        #endregion
    }
}
