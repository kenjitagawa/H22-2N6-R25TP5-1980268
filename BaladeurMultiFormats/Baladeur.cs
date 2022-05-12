using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaladeurMultiFormats
{
    public class Baladeur :IBaladeur
    {
		private const string NOM_RÉPERTOIRE = "Chansons";

		private List<Chanson> m_colChansons;

		public int NbChansons { get { return m_colChansons.Count; } }

		public Baladeur()
		{
			m_colChansons = new List<Chanson>();
		}


		public void ConstruireLaListeDesChansons()
		{
            if (Directory.Exists(NOM_RÉPERTOIRE))
            {
                int num = 0;
                string[] files = Directory.GetFiles("Chansons");
                Array.Sort(files);
                string[] arrayOfFiles = files;
                foreach (string text in arrayOfFiles)
                {
                    string[] directoryList = text.Split('\\');
                    string nameFile = directoryList[directoryList.Length - 1]; // Name of the file
                    string extension = nameFile.Substring(nameFile.Length - 3); // File extension. Possible to use "Path.GetExtension()" 
                    Chanson chanson = null;
                    try
                    {
                        switch (extension.ToUpper())
                        {
                            case "MP3":
                                chanson = new ChansonMP3(text);
                                break;
                            case "WMA":
                                chanson = new ChansonWMA(text);
                                break;
                            case "AAC":
                                chanson = new ChansonAAC(text);
                                break;
                        }
                    }
                    catch (Exception)
                    {
                        chanson = null;
                        num++;
                    }
                    if (chanson != null)
                    {
                        m_colChansons.Add(chanson);
                    }
                }
                if (num > 0)
                {
                    MessageBox.Show(num + " songs were not able to be loaded into the app!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
            }
            else
            {
                MessageBox.Show("Could not find the folder with the songs requested!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }
		

        public void AfficherLesChansons(ListView pListView)
        {
            pListView.Items.Clear();
            pListView.BeginUpdate(); // Increases updating speed of the ListView
            foreach (Chanson colChanson in m_colChansons)
            {
                ListViewItem listViewItem = new ListViewItem(colChanson.Artiste); // Artist column
                listViewItem.SubItems.Add(colChanson.Titre); // Title Column
                listViewItem.SubItems.Add(colChanson.Annee.ToString()); // Year column
                listViewItem.SubItems.Add(colChanson.Format); // File format column
                listViewItem.Tag = colChanson;
                pListView.Items.Add(listViewItem); // Adding the item to the view
            }
            pListView.EndUpdate();
        }

        public Chanson ChansonAt(int pIndex)
        {
			throw new NotImplementedException();
			//return m_colChansons[pIndex]; 
		}

        public void ConvertirVersAAC(int pIndex)
        {
            //Chanson chanson = m_colChansons[pIndex];
            //ChansonAAC chansonAAC = new ChansonAAC("Chansons", chanson.Artiste, chanson.Titre, chanson.Annee);
            //chansonAAC.Ecrire(chanson.Paroles);
            //File.Delete(chanson.NomFichier);
            //m_colChansons[pIndex] = chansonAAC;

        }

		public void ConvertirVersMP3(int pIndex)
        {
            //Chanson chanson = m_colChansons[pIndex];
            //ChansonMP3 chansonMP = new ChansonMP3("Chansons", chanson.Artiste, chanson.Titre, chanson.Annee);
            //chansonMP.Ecrire(chanson.Paroles);
            //File.Delete(chanson.NomFichier);
            //m_colChansons[pIndex] = chansonMP;
        }

        public void ConvertirVersWMA(int pIndex)
        {
            //Chanson chanson = m_colChansons[pIndex];
            //ChansonWMA chansonWMA = new ChansonWMA("Chansons", chanson.Artiste, chanson.Titre, chanson.Annee);
            //chansonWMA.Ecrire(chanson.Paroles);
            //File.Delete(chanson.NomFichier);
            //m_colChansons[pIndex] = chansonWMA;
        }
    }
}
