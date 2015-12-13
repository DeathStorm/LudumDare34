using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Buildings : MonoBehaviour
{
    public enum BUILDINGS { NONE, Farm, Well, Woodcutter, House, Mine, Quarry, Warehouse}

    public struct BUILDING
    {
        public string name;
        public Sprite sprite;


        public int roundsToBeBuild;
        public int costFood;
        public int costWater;
        public int costWood;
        public int costStone;
        public int costOre;

    }

    public Sprite spriteFarm = null;
    public Sprite spriteWell = null;
    public Sprite spriteWoodcutter = null;
    public Sprite spriteHouse = null;
    public Sprite spriteMine = null;
    public Sprite spriteQuarry = null;
    public Sprite spriteWarehouse = null;


    public BUILDINGS choosenBuildingToBuild = BUILDINGS.NONE;
    public Sprite choosenBuildingSprite = null;


    public Dictionary<BUILDINGS, BUILDING> listOfAllBuildings = new Dictionary<BUILDINGS, BUILDING>();
    public List<GameObject> buildingList = new List<GameObject>();
    public List<GameObject> buildingsWhichAreBuilt = new List<GameObject>();

    private Player player;
    private GUI_Controller guiController;

    // Use this for initialization
    void Start()
    {
        player = gameObject.GetComponent<Player>();
        guiController = gameObject.GetComponent<GUI_Controller>();

        CreateBuildings();

        //guiController.UpdateGUIRessources();
    }

    // Update is called once per frame
    void Update()
    {

    }


    public void ChooseBuildingToBuild(BUILDINGS buildingType = BUILDINGS.NONE)
    {
        choosenBuildingToBuild = buildingType;
        if (buildingType == BUILDINGS.NONE) choosenBuildingSprite = null;
        else choosenBuildingSprite = listOfAllBuildings[buildingType].sprite;
    }


    public void BuildBuilding(GameObject tileObject)
    {
        BUILDING building = listOfAllBuildings[choosenBuildingToBuild];
        Tile tile = tileObject.GetComponent<Tile>();

        if (
            player.wood >= building.costWood &&
            player.food >= building.costWood &&
            player.water >= building.costWood &&
            player.ore >= building.costWood &&
            player.stone >= building.costWood
            )
        {
            tile.isOccupied = true;

            player.wood -= building.costWood;
            player.food -= building.costWood;
            player.water -= building.costWood;
            player.ore -= building.costWood;
            player.stone -= building.costWood;

            buildingList.Add(tileObject);
            
            tile.buildingType = choosenBuildingToBuild;
            //tile.standardSprite = tile.spriteRenderer.sprite;
            tile.standardSprite = choosenBuildingSprite;
            tile.spriteRenderer.sprite = tile.standardSprite;
            tile.roundsToBuild = building.roundsToBeBuild;
            tile.RefreshBuildStatus();

            guiController.UpdateGUIRessources();
        
        }
    }

    private void CreateBuildings()
    {
        BUILDING building;

        building = new BUILDING();
        building.name = "Farm House";
        building.sprite = spriteFarm;
        building.roundsToBeBuild = 4;
        building.costFood = 4;
        building.costWater = 1;
        building.costWood = 4;
        building.costStone = 2;
        building.costOre = 0;
        listOfAllBuildings.Add(BUILDINGS.Farm, building);


        building = new BUILDING();
        building.name = "Well";
        building.sprite = spriteWell;
        building.roundsToBeBuild = 2;
        building.costFood = 0;
        building.costWater = 0;
        building.costWood = 2;
        building.costStone = 6;
        building.costOre = 0;
        listOfAllBuildings.Add(BUILDINGS.Well, building);

        building = new BUILDING();
        building.name = "Woodcutter";
        building.sprite = spriteWoodcutter;
        building.roundsToBeBuild = 2;
        building.costFood = 2;
        building.costWater = 2;
        building.costWood = 6;
        building.costStone = 0;
        building.costOre = 2;
        listOfAllBuildings.Add(BUILDINGS.Woodcutter, building);

        building = new BUILDING();
        building.name = "House";
        building.sprite = spriteHouse;
        building.roundsToBeBuild = 4;
        building.costFood = 4;
        building.costWater = 4;
        building.costWood = 4;
        building.costStone = 2;
        building.costOre = 0;
        listOfAllBuildings.Add(BUILDINGS.House, building);

        building = new BUILDING();
        building.name = "Quarry";
        building.sprite = spriteQuarry;
        building.roundsToBeBuild = 6;
        building.costFood = 2;
        building.costWater = 2;
        building.costWood = 2;
        building.costStone = 2;
        building.costOre = 6;
        listOfAllBuildings.Add(BUILDINGS.Quarry, building);

        building = new BUILDING();
        building.name = "Mine";
        building.sprite = spriteMine;
        building.roundsToBeBuild = 4;
        building.costFood = 2;
        building.costWater = 2;
        building.costWood = 6;
        building.costStone = 0;
        building.costOre = 2;
        listOfAllBuildings.Add(BUILDINGS.Mine, building);

        building = new BUILDING();
        building.name = "Warehouse";
        building.sprite = spriteWarehouse;
        building.roundsToBeBuild = 6;
        building.costFood = 0;
        building.costWater = 0;
        building.costWood = 10;
        building.costStone = 2;
        building.costOre = 0;
        listOfAllBuildings.Add(BUILDINGS.Warehouse, building);


    }

}
