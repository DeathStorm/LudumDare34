using UnityEngine;
using System.Collections;


public class Round_Manager : MonoBehaviour
{

    public enum ASSIGNMENTS { NONE, Farm, Well, Mine, House, Wood, Quarry, Building };

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

    // Use this for initialization
    void Start()
    {
        guiController = gameObject.GetComponent<GUI_Controller>();
        player = gameObject.GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {

    }


    public void ReCalculateLimits()
    { 

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
