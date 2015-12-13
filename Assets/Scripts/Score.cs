using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Score : MonoBehaviour {

    //
    // --- Component Variables
    Round_Manager rManager;
    Player pManager;

    //
    // --- Public Variables
    public GameObject panelCanvas;
    public Text highscoreBoard;
    public Text newHighscore;
    public int gameRoundsToEnd = 100;
    public float multiFarm = 2f;
    public float multiWell = 2f;
    public float multiHouse = 2f;
    public float multiLumberjack = 2f;
    public float multiQuarry = 2f;
    public float multiMine = 2f;
    public float multiStorage = 2f;

    public float multiHuman = 2f;
    public float multiFood = 2f;
    public float multiWater = 2f;
    public float multiWood = 2f;
    public float multiStone = 2f;
    public float multiOre = 2f;



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
	} // END Start


    void Update()
    {


        if (rManager.currentRound > gameRoundsToEnd)
        {

            if (scoreShowd == false)
            {
                //* öffne das HighscorePanel, es überblendet den ganzen Bildschirm
                //* berechne die Punktanzahl
                //* zeige Punkte im Panel an
                //* Überprüfe ob die erreichten Punkte ein neuer Highscore sind
                //* wenn ja, speicher sie neu ab. Wenn nein, dann mach nichts weiter.



                panelCanvas.SetActive(true);
                CalculateScore();

                MaybeHighscore();
                highscoreBoard.text = actScore.ToString();
                newHighscore.enabled = true;
                scoreShowd = true;
            }
        }

    }// END Update


    void CalculateScore()
    {
        float actScoreBuildings = 0f;
        float actScoreRessources = 0f;
        actScoreBuildings = (multiFarm * (float)rManager.farmCur) + (multiHouse * (float)rManager.houseCur) + (multiLumberjack * (float)rManager.woodcutterCur) + (multiMine + (float)rManager.mineCur) + (multiWell * (float)rManager.wellCur) + (multiQuarry * (float)rManager.quarryCur) + (multiStorage * (float)rManager.storageCur);
        actScoreRessources = (multiHuman * (float)pManager.humans) + (multiWater * (float)pManager.water) + (multiFood * (float)pManager.food) + (multiStone * (float)pManager.stone) + (multiOre * (float)pManager.ore) + (multiWood * (float)pManager.wood);
        actScore = actScoreBuildings + actScoreRessources;

    } // END CalculateScore

    void MaybeHighscore()
    {

        float savedHighscore = PlayerPrefs.GetFloat("Highscore", 0f);
        Debug.Log(savedHighscore);
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
