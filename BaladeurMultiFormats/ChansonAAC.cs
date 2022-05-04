using System.IO;

namespace BaladeurMultiFormats
{
    public class ChansonAAC : Chanson
    {
        /// <summary>
        /// Obtient le format du fichier (AAC) 
        /// </summary>
        public override string Format { get { return "AAC"; } }


        /// <summary>
        /// Écrit une ligne dans le fichier passé en paramètre. Cette ligne correspond à l’entête du fichier et contient les informations sur la chanson.
        /// </summary>
        /// <param name="pobjFichier">Fichier dans lequel l'entete doit etre écrit</param>
        public override void EcrireEntete(StreamWriter pobjFichier)
        {
            string ligne = $"TITRE = {m_titre} : ARTISTE = {m_artiste} : ANNÉE = {m_annee}";
            pobjFichier.WriteLine(ligne);
        }

        /// <summary>
        /// Encode les paroles reçues en paramètre au format AAC, ensuite écrit ses paroles encodées dans le fichier passé en paramètre.
        /// </summary>
        /// <param name="pobjFichier">Fichier dans lequel les paroles doivent etre écrites</param>
        /// <param name="pParoles">Les paroles a ecrire dans le fichier</param>
        public override void EcrireParoles(StreamWriter pobjFichier, string pParoles)
        {
            string value = OutilsFormats.EncoderAAC(pParoles);
            pobjFichier.WriteLine(value);
        }


        /// <summary>
        /// Lit la premiere ligne du fichier de la chanson et initialise les champs de la chanson (titre, artiste et année de création de la chanson). 
        /// </summary>
        public override void LireEntete()
        {
            StreamReader fichier = new StreamReader(m_nomFichier);
            string[] array = fichier.ReadLine().Split(':');
            m_titre = array[0].Split('=')[1].Trim();
            m_artiste = array[1].Split('=')[1].Trim();
            m_annee = int.Parse(array[2].Split('=')[1]); 
        }


        /// <summary>
        /// Récupère les paroles de la chanson à partir du fichier passé en paramètre, les décode selon le format AAC et les retourne.
        /// </summary>
        /// <param name="pobjFichier">Fichier ou trouver les paroles</param>
        /// <returns>Les paroles decodees</returns>
        public override string LireParoles(StreamReader pobjFichier)
        {
            string lyrics = pobjFichier.ReadToEnd();
            return OutilsFormats.DecoderAAC(lyrics);
        }

        /// <summary>
        /// Initialise une instance avec les données passées en paramètres en appelant le constructeur de la classe de base.
        /// </summary>
        /// <param name="pNomFichier">Nom du fichier ou trouver les informations de la chanson</param>
        public ChansonAAC(string pNomFichier) : base(pNomFichier)
        {
        }

        /// <summary>
        /// Initialise une instance avec les données passées en paramètres en appelant le constructeur de la classe de base.
        /// </summary>
        /// <param name="pRepertoire">Repertoire ou se trouve la chanson</param>
        /// <param name="pArtiste">Nom du artiste</param>
        /// <param name="pTitre">Titre de la chanson</param>
        /// <param name="pAnnee">Annee de debut de la chanson</param>
        public ChansonAAC(string pRepertoire, string pArtiste, string pTitre, int pAnnee) : base(pRepertoire, pArtiste, pTitre, pAnnee)
        {
        }

    }
}
