using UnityEngine;
using System.Collections;

using BUILDINGS = Buildings.BUILDINGS;
using ASSIGNMENTS = Round_Manager.ASSIGNMENTS;


public class GUI_Button_Controller: MonoBehaviour {

    public Buildings buildings;
    public BUILDINGS buildingType = BUILDINGS.NONE;

    public ASSIGNMENTS changeAssigned = ASSIGNMENTS.NONE;
    public int changeAssignedAmount = 0;

    private Round_Manager roundManager;

    void Start()
    {
        roundManager = GameObject.Find("Game_Properties").GetComponent<Round_Manager>();
    }

    public void Click_ChooseBuildingToBuild()
    {
        buildings.ChooseBuildingToBuild(buildingType);
    }


    public void Click_ChangeAssignedHumans()
    {
        roundManager.ChangeAssignement(changeAssigned, changeAssignedAmount);
    }


    public void Click_EndRound()
    {
        roundManager.EndRound();
    }

    public void Click_BackToMainMenu()
    {
        Application.LoadLevel(0);
    }

}
