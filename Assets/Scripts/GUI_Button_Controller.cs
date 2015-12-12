using UnityEngine;
using System.Collections;

using BUILDINGS = Buildings.BUILDINGS;
using ASSIGNMENTS = Round_Manager.ASSIGNMENTS;


public class GUI_Button_Controller: MonoBehaviour {

    public Buildings buildings;
    public BUILDINGS buildingType = BUILDINGS.NONE;

    public ASSIGNMENTS changeAssigned = ASSIGNMENTS.NONE;
    public int changeAssignedAmount = 0;


    public void Click_ChooseBuildingToBuild()
    {
        buildings.ChooseBuildingToBuild(buildingType);
    }


    public void Click_ChangeAssignedHumans()
    { 

    }


}
