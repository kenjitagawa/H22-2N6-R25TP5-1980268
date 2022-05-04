using System.IO;
using System.Windows.Forms;

namespace BaladeurMultiFormats
{
    public abstract class Chanson : IChanson
    {

        #region Propriétés et Champs
        

        protected int m_annee;
        /// <summary>
        /// Obtient l’année de création de la chanson 
        /// </summary>
        public int Annee { get { return m_annee; } }

        protected string m_artiste;
        /// <summary>
        /// Obtient le nom de l’artiste
        /// </summary>
        public string Artiste { get { return m_artiste; } }


        protected string m_nomFichier;
        /// <summary>
        /// Obtient le nom de fichier de la chanson
        /// </summary>
        public string NomFichier { get { return m_nomFichier; } }


        protected string m_titre;
        /// <summary>
        /// Obtient le titre de la chanson
        /// </summary>
        public string Titre { get { return m_titre; } }

        /// <summary>
        /// Cette propriété calculée va vérifier si le fichier de la chanson existe, afin de l'ouvrir pour ensuite sauter l'en-tête pour lire les paroles les traiter et les retourner.
        /// </summary>
        public string Paroles 
        {
            get 
            { 
                if (File.Exists(m_nomFichier))
                {
                    StreamReader fichier = new StreamReader(m_nomFichier);
                    // L'entete c'est la premiere ligne. Skip the headers with SauterEntete().
                    SauterEntete(fichier);
                    string result = LireParoles(fichier);
                    fichier.Close();
                    return result;
                }
                MessageBox.Show("Cannot find the desired file!", Application.ProductName, MessageBoxButtons.OK);
                return "";
            } 
        }
        
        // Abstract Property
        /// <summary>
        /// Propriétés abstraite. Obtient le format audio de la chanson par exemple AAC, MP3 ou WMA
        /// </summary>
        public abstract string Format { get; }

        #endregion



        #region Méthodes

        /// <summary>
        /// Constructeur qui initialise une instance de la classe, elle appelle la méthode LireEntete pour trouver les proprietes necessaires.
        /// </summary>
        /// <param name="pNomFichier">Nom du fichier de la chanson choisi.</param>
        public Chanson(string pNomFichier)
        {
            m_nomFichier = pNomFichier;
            LireEntete();
        }


        /// <summary>
        /// Constructeur qui initialise une instance de la classe.
        /// </summary>
        /// <param name="pRepertoire">Repertoire ou se trouve la chanson</param>
        /// <param name="pArtiste">Nom du artiste</param>
        /// <param name="pTitre">Titre de la chanson</param>
        /// <param name="pAnnee">Annee de debut de la chanson</param>
        public Chanson(string pRepertoire, string pArtiste, string pTitre, int pAnnee)
        { 
            m_artiste = pArtiste;
            m_titre = pTitre;
            m_annee = pAnnee;
            m_nomFichier = $@"{pRepertoire}\{pTitre}.{Format.ToLower()}";
        }

        /// <summary>
        /// Écrit les paroles passées en paramètre dans le fichier de la chanson.
        /// </summary>
        /// <param name="pParoles">Paroles de la chanson a ecrire dans le fichier.</param>
        public void Ecrire(string pParoles) 
        {
            StreamWriter fichier = new StreamWriter(m_nomFichier);
            EcrireEntete(fichier);
            EcrireParoles(fichier, pParoles);
            fichier.Close();
        }

        /// <summary>
        /// Lit une ligne à partir du fichier passé en paramètre.
        /// </summary>
        /// <param name="pobjFichier">Fichier à lire</param>
        public void SauterEntete(StreamReader pobjFichier)
        {
            pobjFichier.ReadLine(); // Reads the first line and goes on with the file.
        }

        #region Abstract Methods
        /// <summary>
        /// Écrit uniquement l'entête de la chanson.
        /// </summary>
        /// <param name="pobjFichier">Nom du fichier dans lequel l'entête sera ecrite</param>
        public abstract void EcrireEntete(StreamWriter pobjFichier);
        
        
        /// <summary>
        /// Écrit uniquement les paroles de la chanson
        /// </summary>
        /// <param name="pobjFichier">Fichier dans lequel il faut ecrire les paroles</param>
        /// <param name="pParoles">Paroles a ecrire dans le fichier</param>
        public abstract void EcrireParoles(StreamWriter pobjFichier, string pParoles);
        
        
        /// <summary>
        /// Lecture de l’en-tête du fichier soit uniquement la première ligne
        /// </summary>
        public abstract void LireEntete();
        
        
        /// <summary>
        /// Obtient les paroles à partir d'un fichier binaire déjà ouvert.
        /// </summary>
        /// <param name="pobjFichier"></param>
        /// <returns></returns>
        public abstract string LireParoles(StreamReader pobjFichier);

        #endregion



        #endregion
    }
}
