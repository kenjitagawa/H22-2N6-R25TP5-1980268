# TP #5 BALADEUR MULTIFORMATS (Music Player) :musical_score:

> **_Note:_** This project will also be graded on the quality of the code and the comments, meaning that it can bring the grade down by up to 15% of the final grade of the project. :bangbang:

> **_Note 2:_** ALWAYS TEST THE CODE BEFORE PUSHING IT!!! :bangbang:

> **_Note 3:_** The name is a standard that must be followed within the Software Engineering department. :bangbang:

Final class project for the semester. This app simulates an Android music player. The goal of this project is to touch base in all of the new concepts seen in class during the semester. Those of which can be found below:

- Inheritance :heavy_check_mark:
- Polymorphism :heavy_check_mark:
- Classes :heavy_check_mark:
- Abstract Properties :heavy_check_mark:
- Static Classes and Methods :heavy_check_mark:
- Git and Version Control :heavy_check_mark:
- Exceptions Management :heavy_check_mark:
- Unit Tests :heavy_check_mark:
- Test Driven Development (TDD) :heavy_check_mark:

# :arrow_forward: Description of the Software :rocket:

The goal is to develop an software that will simulate a smartphone capable of reading audio files of different formats. The software **_WILL NOT_** read actual files, but instead it will read text files with the lyrics replacing the audio. Consequently, instead of the audio being played, the lyrics will be requested on demand whenever the user selects the desired song. The accepted audio types will be the following: **_AAC, MP3 and WMA_**

# :arrow_forward: Technical Description of the Software :scroll:

A folder called **_"Chansons"_** (French for Songs), will contain a song for each one of the songs. the files will have the following extensions:

- _.AAC_
- _.MP3_
- _.WMA_

As it is a simulation, the files will in reality be a file that can be read with any simple text editor (VIM, NANO, Notepad++).

The structure of the audio formats are much simpler than the structures used in real life. **All** of the files begin with a line that contains the headers of the song, followed by a long string of unreadable characters containing the lyrics to the respective song. Note that each different lyric will have a different encoding and will thus need to be decoded to be properly displayed in the text area. In the material provided, a **_static class_** with several different methods will be used to decode the content.

The table below provides the details of the headers of each different file type in their respective orders.

|     |        |        |       |        |
| --- | ------ | ------ | ----- | ------ |
| AAC | Title  | Artist | Year  | -      |
| MP3 | Artist | Year   | Title | -      |
| WMA | ID     | Year   | Title | Artist |

In order to properly simulate reading the audio file, the lyrics will only be read from a file at the time of request, meaning that the lyrics will not be stored in a field or in an automatic property.

# :arrow_forward: TO-DO's :white_check_mark:

> **\*Note: After each thing that gets completed below, you **MUST** do a git commit and git push!!!\***

- [x] Set-up GitHub repository :heavy_check_mark:
- [x] Define interface **_IChanson_** :heavy_check_mark:

  - [x] Commit Message: FCT : TODO #02 Ajout de l’interface IChanson

- [x] Define the abstract class **_Chanson_** :heavy_check_mark:

  - [x] Commit Message: FCT : TODO #03 Ajout de la classe Chanson

- [x] Define inherited class **_ChansonAAC_** :heavy_check_mark:

  - [x] Commit Message: FCT : TODO #04 Ajout de la classe ChansonAAC

- [x] Define inherited class **_ChansonMP3_** :heavy_check_mark:

  - [x] Commit Message: FCT : TODO #05 Ajout de la classe ChansonMP3

- [x] Define inherited class **_ChansonWMA_** :heavy_check_mark:

  - [x] Commit Message: FCT : TODO #06 Ajout de la classe ChansonWMA

- [x] Define interface **_IBaladeur_** :heavy_check_mark:

  - [x] Commit Message: FCT : TODO #07 Ajout de l’interface IBaladeur

- [x] Define class **_Baladeur_** without completing the code for the methods. Ensure compilation is successful before push. :heavy_check_mark:

  - [x] Commit Message: FCT : TODO #08 Ajout de la classe Baladeur

- [x] Complete method **_ConstruireLaListeDesChansons_** :heavy_check_mark:

  - [x] Commit Message: FCT : TODO #09 Complétion de la méthode ConstruireLaListeDesChansons

- [x] Complete code for **_AfficherLesChansons_** :heavy_check_mark:

  - [x] Commit Message: FCT : TODO #10 Complétion de la méthode AfficherLesChansons

- [x] Complete method **_ConvertirVersAAC_** :heavy_check_mark:

  - [x] Commit Message: FCT : TODO #11 Complétion de la méthode ConvertirVersAAC

- [x] Complete method **_ConvertirVersMP3_** :heavy_check_mark:

  - [x] Commit Message: FCT : TODO #12 Complétion de la méthode ConvertirVersMP3

- [x] Complete method **_ConvertirVersWMA_** :heavy_check_mark:

  - [x] Commit Message: FCT : TODO #13 Complétion de la méthode ConvertirVersWMA

- [x] Define 4 tests for the class **_Consultation_** :heavy_check_mark:

  - [x] Commit Message: FCT : TODO #14 Ajout des tests pour la classe Consultation

- [x] Define 4 tests for the class **_Historique_** :heavy_check_mark:

  - [x] Commit Message: FCT : TODO #15 Ajout des tests pour la classe Historique

- [x] Complete the **_FrmPrincipal.cs_** in order to ensure the whole program works as expected. :heavy_check_mark:

## TO-DO's continued :white_check_mark:

> **_Note:_** This part is **not** a part of the project. It will be for my own learning purposes. Meaning that the above list will most likely be completed before any of the ones below get completed.

- [x] Complete and well documented README :heavy_check_mark:
- [ ] Set CI/CD workflow in the repository. Tutorial can be found [here](https://www.cbtnuggets.com/blog/certifications/microsoft/setting-up-a-ci-pipeline-with-github-actions-in-c-with-examples)
- [ ] Add GitHub Pages documentation website.
  - [ ] Add domain back to the repositories.
