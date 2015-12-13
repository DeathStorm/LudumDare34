using UnityEngine;
using System.Collections;

using BUILDING = Buildings.BUILDING;
using BUILDINGS = Buildings.BUILDINGS;
using TEXTMODE = ToolTip.TEXTMODE;

public class ShowToolTip : MonoBehaviour
{

    public enum TOOLTIPMODE { ShowNothing, ShowNameAndCost, ShowText }

    public TOOLTIPMODE toolTipMode = TOOLTIPMODE.ShowNothing;
    public BUILDINGS buildingType = BUILDINGS.NONE;
    public TEXTMODE textmode = TEXTMODE.TwoColumns;

    public string textField1 = "";
    public string textField2 = "";
    public string textFieldMerged = "";

    public bool addBuildingList = false;

    public ToolTip toolTip;
    public Buildings buildings;

    // Use this for initialization
    void Start()
    {
        buildings = GameObject.Find("Game_Properties").GetComponent<Buildings>();
        toolTip = GameObject.Find("ToolTip").GetComponent<ToolTip>();
    }

    public void OnMouseExit()
    {
        toolTip.showToolTip = false;
    }

    public void OnMouseEnter()
    {
        if (toolTipMode == TOOLTIPMODE.ShowText)
        {
            toolTip.textmode = textmode;
            toolTip.toolTip1.text = textField1;
            toolTip.toolTip2.text = textField2;
            toolTip.toolTipMerged.text = textFieldMerged;

            //if (addBuildingList)
            //{
            //    foreach (GameObject buildingObject in buildings.buildingList)
            //    {
            //        Tile tile = buildingObject.GetComponent<Tile>();
            //        toolTip.toolTipMerged.text += buildings.listOfAllBuildings[tile.buildingType].name + " [" + tile.roundsToBuild.ToString() + "]";
            //    }
            //}
            toolTip.showToolTip = true;


        }
        else if (toolTipMode == TOOLTIPMODE.ShowNameAndCost)
        {
            toolTip.textmode = TEXTMODE.TwoColumns;

            BUILDING building = buildings.listOfAllBuildings[buildingType];


            toolTip.toolTip1.text = building.name + "\n";
            toolTip.toolTip1.text += "Food: " + building.costFood.ToString() + "\n";
            toolTip.toolTip1.text += "Wood: " + building.costWood.ToString() + "\n";
            toolTip.toolTip1.text += "Ore: " + building.costOre.ToString() + "\n";

            toolTip.toolTip2.text = "\n";
            toolTip.toolTip2.text += "Water: " + building.costWater.ToString() + "\n";
            toolTip.toolTip2.text += "Stone: " + building.costStone.ToString() + "\n";
            toolTip.toolTip2.text += "\n";

            toolTip.showToolTip = true;
        }

    }

    // Update is called once per frame
    void Update()
    {

    }
}
