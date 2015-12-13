using UnityEngine;
using System.Collections;

using BUILDING = Buildings.BUILDING;

public class Tile : MonoBehaviour
{

    private GameObject gameProperties;
    private Buildings buildings;
    private Player player;

    public SpriteRenderer spriteRenderer;
    public Sprite standardSprite;

    public bool isOccupied = false;
    public int roundsToBuild = 0;

    public Building_Progress buildingProgress;

    // Use this for initialization
    void Start()
    {
        spriteRenderer = this.GetComponent<SpriteRenderer>();
        standardSprite = spriteRenderer.sprite;

        gameProperties = GameObject.Find("Game_Properties");

        buildingProgress = gameObject.GetComponentInChildren<Building_Progress>();

        buildings = gameProperties.GetComponent<Buildings>();
        player = gameProperties.GetComponent<Player>();

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void RefreshBuildStatus()
    {
        SpriteRenderer buildingSprite = null;
        buildingSprite = buildingProgress.gameObject.GetComponent<SpriteRenderer>();

        if (roundsToBuild > 0  && roundsToBuild <= 6)
        {
            buildingSprite.sprite = buildingProgress.buildingSprites[roundsToBuild - 1];
        }
        else if (roundsToBuild > 0)
        {
            buildingSprite.sprite = buildingProgress.buildingSprites[5];
        }
    }


    void OnMouseEnter()
    {
        if (!isOccupied) spriteRenderer.sprite = buildings.choosenBuildingSprite;
    }

    void OnMouseExit()
    {
        if (!isOccupied) spriteRenderer.sprite = standardSprite;
    }


    void OnMouseDown()
    {
        if (!isOccupied && buildings.choosenBuildingToBuild != Buildings.BUILDINGS.NONE)
        {

            buildings.BuildBuilding(gameObject);

            //BUILDING building = buildings.listOfAllBuildings[buildings.choosenBuildingToBuild];

            //if (
            //    player.wood >= building.costWood &&
            //    player.food >= building.costWood &&
            //    player.water >= building.costWood &&
            //    player.ore >= building.costWood &&
            //    player.stone >= building.costWood
            //    )
            //{
            //    player.wood -= building.costWood;
            //    player.food -= building.costWood;
            //    player.water -= building.costWood;
            //    player.ore -= building.costWood;
            //    player.stone -= building.costWood;

            //    buildings.buildingList.Add(gameObject);
            //    isOccupied = true;
            //    standardSprite = spriteRenderer.sprite;
            //}
        }
        else
        { Debug.Log("Fick dich geh weg.....\nHier ist besetzt."); }

    }

}
