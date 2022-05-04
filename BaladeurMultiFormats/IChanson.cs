using System.IO;

namespace BaladeurMultiFormats
{
    internal interface IChanson
    {

        /// <summary>
        /// Obtient l’année de création de la chanson 
        /// </summary>
        int Annee { get; }

        /// <summary>
        /// Obtient le nom de l’artiste ou du groupe ayant créé la chanson
        /// </summary>
        string Artiste { get; }

        /// <summary>
        /// Obtient le format audio de la chanson par exemple AAC, MP3 ou WMA
        /// </summary>
        string Format { get; }

        /// <summary>
        /// Obtient le nom de fichier de la chanson
        /// </summary>
        string NomFichier { get; }

        /// <summary>
        /// Cette propriété calculée va obtenir les paroles de la chanson à partir d’un fichier texte
        /// </summary>
        string Paroles { get; }

        /// <summary>
        /// Obtient le titre de la chanson
        /// </summary>
        string Titre { get; }


        /// <summary>
        /// Écrit les paroles passées en paramètre dans le fichier de la chanson.
        /// </summary>
        /// <param name="pParoles">Une chaine de paroles de la chanson</param>
        void Ecrire(string pParoles);

        /// <summary>
        /// Écrit uniquement l'entête de la chanson.
        /// </summary>
        /// <param name="pobjFichier">Nom du fichier dans lequel l'entête sera ecrite</param>
        void EcrireEntete(StreamWriter pobjFichier);

        /// <summary>
        /// Écrit uniquement les paroles de la chanson
        /// </summary>
        /// <param name="pobjFichier">Fichier dans lequel il faut ecrire les paroles</param>
        /// <param name="pParoles">Paroles a ecrire dans le fichier</param>
        void EcrireParoles(StreamWriter pobjFichier, string pParoles);

        /// <summary>
        /// Lecture de l’en-tête du fichier soit uniquement la première ligne
        /// </summary>
        void LireEntete();

        /// <summary>
        /// Obtient les paroles à partir d'un fichier binaire déjà ouvert.
        /// </summary>
        /// <param name="pobjFichier"></param>
        /// <returns></returns>
        string LireParoles(StreamReader pobjFichier);


        /// <summary>
        /// Lit une ligne à partir du fichier passé en paramètre.
        /// </summary>
        /// <param name="pobjFichier">Fichier dans lequel l'entete se trouve</param>
        void SauterEntete(StreamReader pobjFichier);

    }
}
