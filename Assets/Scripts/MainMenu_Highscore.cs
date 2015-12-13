using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MainMenu_Highscore : MonoBehaviour {


    //
    // --- Public Variables
    public Text highscoreTextboard;
    
    //
    // --- Private Variables
    float highscore = 0f;

    // 
    // ----- Methods
	void Start () 
    {

        
        highscore = PlayerPrefs.GetInt("Highscore", 0);
        SetHighscoreBeShowend();

	} // END Start

    void SetHighscoreBeShowend()
    { 
    
        highscoreTextboard.text = "Your Highscore - " + highscore.ToString();

    
    } //END SetHighscoreBeShowend


} // END Class
