using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GUI_Controller : MonoBehaviour {

    private Buildings buildings;
    private Player player;

    public Text textWood;
    public Text textHuman;
    public Text textFood;
    public Text textWater;
    public Text textStone;
    public Text textOre;
    

    private bool isInitialLoaded = false;

	// Use this for initialization
	void Start () 
    {
        buildings = gameObject.GetComponent<Buildings>();
        player = gameObject.GetComponent<Player>();

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

}
