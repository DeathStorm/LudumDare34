using UnityEngine;
using System.Collections;

public class GUI_Button_Controller: MonoBehaviour {

    public Buildings buildings;
    public Buildings.BUILDINGS buildingType = Buildings.BUILDINGS.NONE;


    public void Click_ChooseBuildingToBuild()
    {
        buildings.ChooseBuildingToBuild(buildingType);
    }
    


}
