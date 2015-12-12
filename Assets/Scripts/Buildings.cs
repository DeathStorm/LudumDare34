using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Buildings : MonoBehaviour
{


    public enum BUILDINGS { NONE, Farm, Well, Woodcutter, House, Mine, Quarry}

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


    public BUILDINGS choosenBuildingToBuild = BUILDINGS.NONE;
    public Sprite choosenBuildingSprite = null;


    public Dictionary<BUILDINGS, BUILDING> listOfAllBuildings = new Dictionary<BUILDINGS, BUILDING>();

    public List<GameObject> buildingList = new List<GameObject>();


    // Use this for initialization
    void Start()
    {
        CreateBuildings();
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


    }

}
