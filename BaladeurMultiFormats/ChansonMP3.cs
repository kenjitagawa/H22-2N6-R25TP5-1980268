using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaladeurMultiFormats
{
    internal class ChansonMP3 : Chanson
    {
        public override string Format { get { return "MP3"; } }
        public override void LireEntete()
        {
            StreamReader file = new StreamReader(m_nomFichier);
            string[] data = file.ReadLine().Split('|');
            m_artiste = data[0].Trim();
            m_annee = int.Parse(data[1]); // No need to trim
            m_titre = data[2].Trim();

            file.Close();
        }

        public override string LireParoles(StreamReader pobjFichier)
        {
            string paroles = pobjFichier.ReadToEnd();
            return OutilsFormats.DecoderMP3(paroles);
        }

        public override void EcrireEntete(StreamWriter pobjFichier)
        {
            pobjFichier.WriteLine($@"{m_artiste} | {m_annee} | {m_titre}");
        }

        public override void EcrireParoles(StreamWriter pobjFichier, string pParoles)
        {
            string value = OutilsFormats.EncoderMP3(pParoles);
            pobjFichier.Write(value);
        }


        public ChansonMP3(string pNomFichier) : base(pNomFichier)
        {
        }

        public ChansonMP3(string pRepertoire, string pArtiste, string pTitre, int pAnnee) : base(pRepertoire, pArtiste, pTitre, pAnnee)
        {
        }
    }
}
