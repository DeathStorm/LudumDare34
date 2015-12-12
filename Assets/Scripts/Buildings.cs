using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Buildings : MonoBehaviour
{


    public enum BUILDINGS { NONE, Farm, Well }

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


    public BUILDINGS choosenBuildingToBuild = BUILDINGS.NONE;
    public Sprite choosenBuildingSprite = null;


    public Dictionary<BUILDINGS, BUILDING> buildingList = new Dictionary<BUILDINGS, BUILDING>();


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
        else choosenBuildingSprite = buildingList[buildingType].sprite;
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
        buildingList.Add(BUILDINGS.Farm, building);


        building = new BUILDING();
        building.name = "Well";
        building.sprite = spriteWell;
        building.roundsToBeBuild = 2;
        building.costFood = 0;
        building.costWater = 0;
        building.costWood = 2;
        building.costStone = 6;
        building.costOre = 0;
        buildingList.Add(BUILDINGS.Well, building);


    }

}
