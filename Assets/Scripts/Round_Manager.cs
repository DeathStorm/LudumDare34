using UnityEngine;
using System.Collections;
using UnityEngine.UI;

using BUILDINGS = Buildings.BUILDINGS;

public class Round_Manager : MonoBehaviour
{

    public enum ASSIGNMENTS { NONE, Farm, Well, Mine, House, Wood, Quarry, Building };

    public int currentRound = 1;

    public int storageCur = 0;
    public int storageBonus = 20;

    public int humanMaxBonus = 4;

    public int humanSet = 0;
    public int humanMax = 0;

    public int farmCur = 0;
    public int farmMax = 0;

    public int wellCur = 0;
    public int wellMax = 0;

    public int mineCur = 0;
    public int mineMax = 0;

    public int houseCur = 0;
    public int houseMax = 0;

    public int woodcutterCur = 0;
    public int woodcutterMax = 0;

    public int quarryCur = 0;
    public int quarryMax = 0;

    public int buildingCur = 0;
    public int buildingMax = 99;


    private GUI_Controller guiController;
    private Player player;
    private Buildings buildings;

    private bool cautionFood = false;
    private bool cautionWater = false;

    public Text textRoundCur;
    public Text textStorageCur;

    private bool initReCalculate = false;

    // Use this for initialization
    void Start()
    {
        guiController = gameObject.GetComponent<GUI_Controller>();
        player = gameObject.GetComponent<Player>();
        buildings = gameObject.GetComponent<Buildings>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!initReCalculate)
        {
            ReCalculateLimits();
            initReCalculate = true;
        }
    }


    public void ReCalculateLimits()
    {
        farmMax = 0;
        mineMax = 0;
        quarryMax = 0;
        wellMax = 0;
        houseMax = 0;
        woodcutterMax = 0;

        storageCur = storageBonus;
        humanMax = humanMaxBonus;


        foreach (GameObject curBuilding in buildings.buildingsWhichAreBuilt)
        {
            Debug.Log("Current Building = " + curBuilding);
            Tile curTile = curBuilding.GetComponent<Tile>();
            switch (curTile.buildingType)
            {
                case BUILDINGS.Farm:
                    farmMax += 2;
                    break;
                case BUILDINGS.Well:
                    wellMax += 2;
                    break;
                case BUILDINGS.Mine:
                    mineMax += 2;
                    break;
                case BUILDINGS.Warehouse:
                    storageCur += 20;
                    break;
                case BUILDINGS.Woodcutter:
                    woodcutterMax += 2;
                    break;
                case BUILDINGS.Quarry:
                    quarryMax += 2;
                    break;
                case BUILDINGS.House:
                    houseMax += 2;
                    humanMax += 2;
                    break;
            }
        }
        Debug.Log(farmMax);

        textStorageCur.text = storageCur.ToString();
        guiController.UpdateGUIAssignements();
    }


    public void EndRound()
    {
        ReCalculateLimits();

        player.food = Mathf.Clamp(player.food + (farmCur * 3), 0, storageCur);
        player.water = Mathf.Clamp(player.water + (wellCur * 3), 0, storageCur); ;
        player.ore = Mathf.Clamp(player.ore + (mineCur * 2), 0, storageCur); ;
        player.wood = Mathf.Clamp(player.wood + (woodcutterCur*2), 0, storageCur); ;
        player.stone = Mathf.Clamp(player.stone + (quarryCur * 2), 0, storageCur); ;

        player.humans = Mathf.Clamp(player.humans + (int)(houseCur / 2), 0, humanMax);

        if (buildingCur > 0)
        {
            int buildingPoints = buildingCur;
            GameObject curBuilding = null;
            Tile curTile = null;

            while (buildingPoints > 0)
            {
                if (curBuilding == null)
                {
                    if (buildings.buildingList.Count == 0) break;

                    curBuilding = buildings.buildingList[0];
                    curTile = curBuilding.GetComponent<Tile>();
                }
                curTile.roundsToBuild--;
                buildingPoints--;

                curTile.RefreshBuildStatus();

                if (curTile.roundsToBuild <= 0)
                {
                    buildings.buildingsWhichAreBuilt.Add(curBuilding);
                    buildings.buildingList.RemoveAt(0);
                    curBuilding = null;
                }
            }
        }

        player.food -= player.humans;
        if (player.food < 0 && cautionFood)
        {
            player.humans--;
            RemoveAWorkerBecauseOfDying();
            player.food = 0;
            cautionFood = true;
        }
        else if (player.food < 0 && !cautionFood)
        {
            player.food = 0;
            cautionFood = true;
        }
        else if (player.food >= 0)
        { cautionFood = false; }

        player.water -= player.humans;
        if (player.water < 0 && cautionWater)
        {
            player.humans--;
            RemoveAWorkerBecauseOfDying();
            player.water = 0;
            cautionWater = true;
        }
        else if (player.water < 0 && !cautionWater)
        {
            player.water = 0;
            cautionWater = true;
        }
        else if (player.water >= 0)
        { cautionWater = false; }

        currentRound++;
        textRoundCur.text = currentRound.ToString();

        ReCalculateLimits();

        guiController.UpdateGUIAssignements();
        guiController.UpdateGUIRessources();
    }

    private void RemoveAWorkerBecauseOfDying()
    {
        if (farmCur > 0)
        {
            farmCur--;
            humanSet--;
        }
        else if (wellCur > 0)
        {
            wellCur--;
            humanSet--;
        }
        else if (mineCur > 0)
        {
            mineCur--;
            humanSet--;
        }
        else if (houseCur > 0)
        {
            houseCur--;
            humanSet--;
        }
        else if (woodcutterCur > 0)
        {
            woodcutterCur--;
            humanSet--;
        }
        else if (quarryCur > 0)
        {
            quarryCur--;
            humanSet--;
        }
        else if (buildingCur > 0)
        {
            buildingCur--;
            humanSet--;
        }

    }


    public void ChangeAssignement(ASSIGNMENTS assignement, int amount)
    {
        if (
            (amount > 0 && humanSet < player.humans) |
            (amount < 0)
            )
        {
            switch (assignement)
            {
                case ASSIGNMENTS.Farm:
                    if (amount > 0 && farmCur < farmMax)
                    {
                        farmCur++;
                        humanSet++;
                    }
                    else if (amount < 0 && farmCur > 0)
                    {
                        farmCur--;
                        humanSet--;
                    }
                    break;
                case ASSIGNMENTS.Well:
                    if (amount > 0 && wellCur < wellMax)
                    {
                        wellCur++;
                        humanSet++;
                    }
                    else if (amount < 0 && wellCur > 0)
                    {
                        wellCur--;
                        humanSet--;
                    }
                    break;
                case ASSIGNMENTS.Mine:
                    if (amount > 0 && mineCur < mineMax)
                    {
                        mineCur++;
                        humanSet++;
                    }
                    else if (amount < 0 && mineCur > 0)
                    {
                        mineCur--;
                        humanSet--;
                    }
                    break;
                case ASSIGNMENTS.House:
                    if (amount > 0 && houseCur < houseMax)
                    {
                        houseCur++;
                        humanSet++;
                    }
                    else if (amount < 0 && houseCur > 0)
                    {
                        houseCur--;
                        humanSet--;
                    }
                    break;
                case ASSIGNMENTS.Wood:
                    if (amount > 0 && woodcutterCur < woodcutterMax)
                    {
                        woodcutterCur++;
                        humanSet++;
                    }
                    else if (amount < 0 && woodcutterCur > 0)
                    {
                        woodcutterCur--;
                        humanSet--;
                    }
                    break;
                case ASSIGNMENTS.Quarry:
                    if (amount > 0 && quarryCur < quarryMax)
                    {
                        quarryCur++;
                        humanSet++;
                    }
                    else if (amount < 0 && quarryCur > 0)
                    {
                        quarryCur--;
                        humanSet--;
                    }
                    break;
                case ASSIGNMENTS.Building:
                    if (amount > 0 && buildingCur < buildingMax)
                    {
                        buildingCur++;
                        humanSet++;
                    }
                    else if (amount < 0 && buildingCur > 0)
                    {
                        buildingCur--;
                        humanSet--;
                    }
                    break;

            }
            guiController.UpdateGUIAssignements();
        }
    }

}
