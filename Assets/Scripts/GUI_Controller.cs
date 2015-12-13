using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GUI_Controller : MonoBehaviour {

    private Buildings buildings;
    private Player player;
    private Round_Manager roundManager;

    public Text textWood;
    public Text textHuman;
    public Text textFood;
    public Text textWater;
    public Text textStone;
    public Text textOre;

    public Text textAssignHumanSet;
    public Text textAssignHumanAvailable;
    public Text textAssignHumanPossible;

    public Text textAssignFarmCur;
    public Text textAssignFarmMax;

    public Text textAssignWellCur;
    public Text textAssignWellMax;

    public Text textAssignMineCur;
    public Text textAssignMineMax;

    public Text textAssignHouseCur;
    public Text textAssignHouseMax;

    public Text textAssignWoodcutterCur;
    public Text textAssignWoodcutterMax;

    public Text textAssignQuarryCur;
    public Text textAssignQuarryMax;

    public Text textAssignBuildingCur;
    public Text textAssignBuildingMax;

    private bool isInitialLoaded = false;

	// Use this for initialization
	void Start () 
    {
        buildings = gameObject.GetComponent<Buildings>();
        player = gameObject.GetComponent<Player>();
        roundManager = gameObject.GetComponent<Round_Manager>();

	}
	
	// Update is called once per frame
	void Update () 
    {
        if (!isInitialLoaded) UpdateGUIRessources();

        if (Input.GetMouseButton(1))
        {
            buildings.ChooseBuildingToBuild();
        }
	}


    public void UpdateGUIRessources()
    {
        textFood.text = player.food.ToString();
        textWater.text = player.water.ToString();
        textHuman.text = player.humans.ToString();
        textOre.text = player.ore.ToString();
        textStone.text = player.stone.ToString();
        textWood.text = player.wood.ToString();
    }

    public void UpdateGUIAssignements()
    {
        textAssignHumanSet.text = roundManager.humanSet.ToString();
        textAssignHumanAvailable.text = player.humans.ToString();
        textAssignHumanPossible.text = roundManager.humanMax.ToString();

        textAssignFarmCur.text = roundManager.farmCur.ToString();
        textAssignFarmMax.text = roundManager.farmMax.ToString();

        textAssignWellCur.text = roundManager.wellCur.ToString();
        textAssignWellMax.text = roundManager.wellMax.ToString();

        textAssignMineCur.text = roundManager.mineCur.ToString();
        textAssignMineMax.text = roundManager.mineMax.ToString();

        textAssignHouseCur.text = roundManager.houseCur.ToString();
        textAssignHouseMax.text = roundManager.houseMax.ToString();

        textAssignWoodcutterCur.text = roundManager.woodcutterCur.ToString();
        textAssignWoodcutterMax.text = roundManager.woodcutterMax.ToString();

        textAssignQuarryCur.text = roundManager.quarryCur.ToString();
        textAssignQuarryMax.text = roundManager.quarryMax.ToString();

        textAssignBuildingCur.text = roundManager.buildingCur.ToString();
        textAssignBuildingMax.text = roundManager.buildingMax.ToString();


    }

}
