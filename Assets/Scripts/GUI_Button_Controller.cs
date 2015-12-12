using UnityEngine;
using System.Collections;

using BUILDINGS = Buildings.BUILDINGS;
using RESSOURCES = Player.RESSOURCES;


public class GUI_Button_Controller: MonoBehaviour {

    public Buildings buildings;
    public BUILDINGS buildingType = BUILDINGS.NONE;
    public int changeAssignedBuildingAmount = 0;


    public void Click_ChooseBuildingToBuild()
    {
        buildings.ChooseBuildingToBuild(buildingType);
    }


    public void Click_ChangeAssignedHumans()
    { 

    }


}
