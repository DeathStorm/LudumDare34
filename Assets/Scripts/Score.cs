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
    public int multiFarm = 30;
    public int multiWell = 30;
    public int multiHouse = 40;
    public int multiLumberjack = 40;
    public int multiQuarry = 60;
    public int multiMine = 50;
    public int multiStorage = 70;

    public int multiHuman = 100;
    public int multiFood = 25;
    public int multiWater = 25;
    public int multiWood = 60;
    public int multiStone = 30;
    public int multiOre = 40;

    private ToolTip toolTip;

    //
    // --- Private Variables
    int actScore = 0;
    bool scoreShowd = false;
    
    
    //
    // ----- Methods
	void Start () 
    {
        rManager = this.GetComponent<Round_Manager>();
        pManager = this.GetComponent<Player>();
        build = this.GetComponent<Buildings>();
        toolTip = GameObject.Find("ToolTip").GetComponent<ToolTip>();
	} // END Start


    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.LoadLevel(0);
            
        }


        if (rManager.currentRound > gameRoundsToEnd)
        {
            toolTip.showToolTip = false;

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
            toolTip.showToolTip = false;
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

        int savedHighscore = PlayerPrefs.GetInt("Highscore", 0); // .GetFloat("Highscore", 0f);
        
        Debug.Log("alter Score" + savedHighscore);
        Debug.Log("neuer Score" + actScore);
        

        if (actScore > savedHighscore)
        {
            //PlayerPrefs.SetFloat("Highscore", actScore);
            PlayerPrefs.SetInt("Highscore", actScore);
            newHighscore.enabled = true;
        }
        else
        {
            Debug.Log("Kein neuer Highscore");
        }


    } // END MaybeHighscore


} // END Class
