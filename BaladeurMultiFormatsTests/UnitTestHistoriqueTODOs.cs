using BaladeurMultiFormats;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace BaladeurMultiFormatsTests
{
    [TestClass]
    public class UnitTestHistoriqueTODOs
    {

        #region Tests de la méthode NbConsultationDepuisXSecondes
        // TODO Test E : HistoriqueTestNbConsultationDepuisXSecondesParamNegatifTest
        // Compléter la méthode pour tester le cas où la valeur du délai passé en paramètre est négative
        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void HistoriqueTestNbConsultationDepuisXSecondesParamNegatifTest()
        {
            // Arrange : Instancier un objet Historique
            Historique history = new Historique();

            // Act : Appeler la méthode NbConsultationsDepuisXSecondes
            history.NbConsultationsDepuisXSecondes(-10);

            // Assert : Vérifier si la méthode lève une exception IndexOutOfRangeException

        }


        // TODO Test F : HistoriqueTestNbConsultationDepuisXSecondesValideTest
        // Compléter la méthode pour tester le cas valide
        [TestMethod]
        public void HistoriqueTestNbConsultationDepuisXSecondesValideTest()
        {
            // Arrange : Instancier un objet Historique et y ajouter trois consultations d'une même chansonAAC
            // La première consultation depuis 100 secondes (DateTime.AddSeconds(-100))
            // La deuxième consultation depuis 150 secondes (DateTime.AddSeconds(-150))
            // La troisième consultation depuis 300 secondes (DateTime.AddSeconds(-300))
            ChansonAAC chansonAAC = new ChansonAAC(@"Chansons/Dancing Queen.AAC");
            Historique history = new Historique()
            {
                new Consultation (DateTime.Now.AddSeconds(-100), chansonAAC),
                new Consultation (DateTime.Now.AddSeconds(-150), chansonAAC),
                new Consultation (DateTime.Now.AddSeconds(-300), chansonAAC),
            };



            // Act : Appeler la méthode NbConsultationsDepuisXSecondes pour calculer le nombre 
            // de chansons consultées depuis 200 secondes.
            int calculatedConsultations = history.NbConsultationsDepuisXSecondes(200);

            // Assert : Vérifier si la méthode retourne le bon nombre de consultations qui est 2 !
            Assert.AreEqual(calculatedConsultations, 2);


        }
        #endregion

        #region Tests de la méthode NbConsultationsPourUneChanson
        // TODO Test G : HistoriqueTestNbConsultationsPourUneChansonParamNullTest
        // Compléter la méthode pour tester le cas où la chanson passée en paramètre est à null
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void HistoriqueTestNbConsultationsPourUneChansonParamNullTest()
        {
            // Arrange : Instancier un objet Historique
            Historique history = new Historique();


            // Act : Appeler la méthode NbConsultationsDepuisXSecondes en lui passant la valeur null
            history.NbConsultationsPourUneChanson(null);


            // Assert : Vérifier si la méthode lève une exception ArgumentNullException

        }

        // TODO Test H : HistoriqueTestNbConsultationsPourUneChansonValideTest
        // Compléter la méthode pour tester le cas valide
        [TestMethod()]
        public void HistoriqueTestNbConsultationsPourUneChansonValideTest()
        {
            // Arrange : Instancier un objet Historique et un objet ChansonAAC
            // Ajouter quatre consultations de cette même chansonAAC dans l'objet Historique
            // La première consultation depuis 100 secondes (DateTime.AddSeconds(-100))
            // La deuxième consultation depuis 150 secondes (DateTime.AddSeconds(-150))
            // La troisième consultation depuis 300 secondes (DateTime.AddSeconds(-300))
            // La quatrième consultation depuis 350 secondes (DateTime.AddSeconds(-350))
            ChansonAAC chansonAAC = new ChansonAAC(@"Chansons/Dancing Queen.AAC");
            Historique history = new Historique()
            {
                new Consultation (DateTime.Now.AddSeconds(-100), chansonAAC),
                new Consultation (DateTime.Now.AddSeconds(-150), chansonAAC),
                new Consultation (DateTime.Now.AddSeconds(-300), chansonAAC),
                new Consultation (DateTime.Now.AddSeconds(-350), chansonAAC),
            };


            // Act : Appeler la méthode NbConsultationsDepuisXSecondes pour calculer le nombre 
            // de fois que la chansonAAC a été consultée.
            int calculatedConsultations = history.NbConsultationsDepuisXSecondes(500);


            // Assert : Vérifier si la méthode retourne la bon nombre de consultations qui est 4
            Assert.AreEqual(calculatedConsultations, 4);



        }


        #endregion
    }
}
