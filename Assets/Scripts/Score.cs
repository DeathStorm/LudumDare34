using UnityEngine;
using UnityEngine.UI;
using System.Collections;

using BUILDINGS = Buildings.BUILDINGS;

public class Score : MonoBehaviour {

    //
    // --- Component Variables
    Round_Manager rManager;
    Player pManager;
    Buildings build;
    
    
    //
    // --- Public Variables
    public GameObject backgroundGrass;
    public GameObject panel;
    public GameObject scorePanel;
    public Text scoreBoardTitleText;
    public Text highscoreText;
    public Text newHighscore;
    public int gameRoundsToEnd = 100;
    public int multiFarm = 2;
    public int multiWell = 2;
    public int multiHouse = 2;
    public int multiLumberjack = 2;
    public int multiQuarry = 2;
    public int multiMine = 2;
    public int multiStorage = 2;

    public int multiHuman = 2;
    public int multiFood = 2;
    public int multiWater = 2;
    public int multiWood = 2;
    public int multiStone = 2;
    public int multiOre = 2;



    //
    // --- Private Variables
    float actScore = 0f;
    bool scoreShowd = false;
    
    
    //
    // ----- Methods
	void Start () 
    {
        rManager = this.GetComponent<Round_Manager>();
        pManager = this.GetComponent<Player>();
        build = this.GetComponent<Buildings>();
	} // END Start


    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.LoadLevel(0);
            
        }


        if (rManager.currentRound > gameRoundsToEnd)
        {

            if (scoreShowd == false)
            {
                //* öffne das HighscorePanel, es überblendet den ganzen Bildschirm
                //* berechne die Punktanzahl
                //* zeige Punkte im Panel an
                //* Überprüfe ob die erreichten Punkte ein neuer Highscore sind
                //* wenn ja, speicher sie neu ab. Wenn nein, dann mach nichts weiter.

                backgroundGrass.SetActive(false);
                panel.SetActive(false);

                scorePanel.SetActive(true);
                scoreBoardTitleText.text = "Done! Here is your Score";
                CalculateScore();


                MaybeHighscore();
                highscoreText.text = actScore.ToString();
                newHighscore.enabled = true;
                scoreShowd = true;
            }
        }
        else if (rManager.currentRound < gameRoundsToEnd && pManager.humans < 1)
        {
            if (scoreShowd == false)
            {

                backgroundGrass.SetActive(false);
                panel.SetActive(false);

                scorePanel.SetActive(true);
                scoreBoardTitleText.text = "GameOver - Your score";
                CalculateScore();


                MaybeHighscore();
                highscoreText.text = actScore.ToString();
                newHighscore.enabled = true;
                scoreShowd = true;
            }
        }

    }// END Update


    void CalculateScore()
    {
        int actScoreBuildings = 0;
        int actScoreRessources = 0;

        foreach(GameObject buildings in build.buildingsWhichAreBuilt)
        {
            Tile thisTile = buildings.GetComponent<Tile>();

            switch (thisTile.buildingType)
            { 
                case BUILDINGS.Farm:
                    actScoreBuildings += multiFarm;
                    break;

                case BUILDINGS.House:
                    actScoreBuildings += multiHouse;
                    break;
                case BUILDINGS.Mine:
                    actScoreBuildings += multiMine;
                    break;
                case BUILDINGS.Quarry:
                    actScoreBuildings += multiQuarry;
                    break;
                case BUILDINGS.Warehouse:
                    actScoreBuildings += multiStorage;
                    break;
                case BUILDINGS.Well:
                    actScoreBuildings += multiWell;
                    break;
                case BUILDINGS.Woodcutter:
                    actScoreBuildings += multiLumberjack;
                    break;
            }
        }

        actScoreRessources = (multiHuman * pManager.humans) + (multiWater * pManager.water) + (multiFood * pManager.food) + (multiStone * pManager.stone) + (multiOre * pManager.ore) + (multiWood * pManager.wood);
        
        actScore = actScoreBuildings + actScoreRessources;
        //Debug.Log("buildings: " + actScoreBuildings);
        //Debug.Log("ressources: " + actScoreRessources);

    } // END CalculateScore

    void MaybeHighscore()
    {

        float savedHighscore = PlayerPrefs.GetFloat("Highscore", 0f);

        Debug.Log("alter Score" + savedHighscore);
        Debug.Log("neuer Score" + actScore);
        

        if (actScore > savedHighscore)
        {
            PlayerPrefs.SetFloat("Highscore", actScore);
            newHighscore.enabled = true;
        }
        else
        {
            Debug.Log("Kein neuer Highscore");
        }


    } // END MaybeHighscore


} // END Class
