using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaladeurMultiFormats
{
    public class ChansonWMA : Chanson
    {
        private int m_codage;

        public override string Format { get { return "WMA"; } }

		public override void LireEntete() 
		{
			StreamReader file = new StreamReader(m_nomFichier);
			string[] data = file.ReadLine().Split('/');
			m_codage = int.Parse(data[0]);
			m_annee = int.Parse(data[1]);
			m_titre = data[2].Trim();
			m_artiste = data[3].Trim();

			file.Close();

		}

		public override string LireParoles(StreamReader pobjFichier)
		{
			string pParoles = pobjFichier.ReadToEnd();
			return OutilsFormats.DecoderWMA(pParoles, m_codage);
		}

		public override void EcrireEntete(StreamWriter pobjFichier)
		{
			Random random = new Random();
			m_codage = random.Next(3, 16);

			pobjFichier.WriteLine($@"{m_codage} / {m_annee} / {m_titre} / {m_artiste}");
			
		}

		public override void EcrireParoles(StreamWriter pobjFichier, string pParoles)
		{
			string value = OutilsFormats.EncoderWMA(pParoles, m_codage);
			pobjFichier.Write(value);
		}

		public ChansonWMA(string pNomFichier) : base(pNomFichier)
        {
        }

        public ChansonWMA(string pRepertoire, string pArtiste, string pTitre, int pAnnee) : base(pRepertoire, pArtiste, pTitre, pAnnee)
        {
        }
    }
}
