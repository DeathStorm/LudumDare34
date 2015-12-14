using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

using Random = UnityEngine.Random;
using System.Reflection;

public class EventScript : MonoBehaviour
{

    private Player player;
    private Buildings buildings;
    private Round_Manager roundManager;
    private GUI_Controller guiController;

    public GameObject EventPanel;
    public Text textEventText;

    public String EventText;
    public Image eventImage;

    public Sprite spriteRatsInYourStorage;
    public Sprite spriteNewSettlerArrives;
    public Sprite spriteFireInYourWoodStorage;
    public Sprite spritePoisonInYourWater;
    public Sprite spriteStoneIsSandStone;
    public Sprite spriteYourMineCrashed;
    public Sprite spriteSupportOfYourMotherland;
    public Sprite spriteAFriendlyCraftsmanVisitYourColony;



    // Use this for initialization
    void Start()
    {
        player = gameObject.GetComponent<Player>();
        buildings = gameObject.GetComponent<Buildings>();
        roundManager = gameObject.GetComponent<Round_Manager>();
        guiController = gameObject.GetComponent<GUI_Controller>();

    }


    public void GenerateEvent()
    {

        if (Random.Range(1, 101) <= 75)
        {
            int rnd = Random.Range(1, 101);

            Debug.Log("Event Number = " + rnd.ToString());
            if (rnd <= 0 || rnd >= 101) { }
            else if (rnd >= 1 && rnd <= 4) { if (Event_RatsInYourStorage()) ShowEvent(); }
            else if (rnd >= 5 && rnd <= 9) { if (false) ShowEvent(); }
            else if (rnd >= 10 && rnd <= 12) { if (Event_NewSettlerArrives()) ShowEvent(); }
            else if (rnd >= 13 && rnd <= 14) { if (false) ShowEvent(); }
            else if (rnd >= 15 && rnd <= 18) { if (Event_FireInYourWoodStorage()) ShowEvent(); }
            else if (rnd >= 19 && rnd <= 22) { if (Event_StoneIsSandstone()) ShowEvent(); }
            else if (rnd >= 23 && rnd <= 26) { if (Event_PoisonInYourWater()) ShowEvent(); }
            else if (rnd >= 27 && rnd <= 36) { if (Event_SupportOfYourMotherland()) ShowEvent(); }
            else if (rnd >= 37 && rnd <= 46) { if (Event_AFriendlyCraftsmanVisitsYourColony()) ShowEvent(); }
            else if (rnd >= 47 && rnd <= 50) { if (Event_YourMineCrashed()) ShowEvent(); }
            else if (rnd >= 13 && rnd <= 14) { if (false) ShowEvent(); }
            else if (rnd >= 13 && rnd <= 14) { if (false) ShowEvent(); }
            else { }
        }
        else
        { Debug.Log("No Event happend"); }

    }



    private void ShowEvent()
    {

        textEventText.text = EventText;
        guiController.UpdateGUIRessources();
        guiController.UpdateGUIAssignements();
        EventPanel.SetActive(true);

    }


    private bool Event_NewSettlerArrives()
    {
        if (player.humans < roundManager.humanMax)
        {
            EventText = "Your Colony has such a nice reputation, that a new settler joins your colony.";
            eventImage.sprite = spriteNewSettlerArrives;
            player.humans = Mathf.Clamp(player.humans + 1, player.humans, roundManager.humanMax);
            return true;
        }
        return false;
    }

    private bool Event_RatsInYourStorage()
    {
        if (player.food > 0)
        {
            EventText = "Rats have arrived your colony. Unfortunately they ate the half of your food.";
            eventImage.sprite = spriteRatsInYourStorage;
            player.food = (int)(player.food / 2);
            return true;
        }
        return false;
    }

    private bool Event_FireInYourWoodStorage()
    {
        if (player.wood > 0)
        {
            EventText = "Your Wood Storage has caught fire, the half of your wood has burnt.";
            eventImage.sprite = spriteFireInYourWoodStorage;
            player.wood = (int)(player.wood / 2);
            return true;
        }
        return false;
    }

    private bool Event_StoneIsSandstone()
    {
        if (player.stone > 0)
        {
            EventText = "You wanted to use your stone to expand your company, but the mason has falsely mined sandstone. The half of your stone storage is useless.";
            eventImage.sprite = spriteStoneIsSandStone;
            player.stone = (int)(player.stone / 2);
            return true;
        }
        return false;
    }

    private bool Event_PoisonInYourWater()
    {
        if (player.water > 0)
        {
            EventText = "Some of you colonists recognized a bad taste in your water. The half of your water is poisoned.";
            eventImage.sprite = spritePoisonInYourWater;
            player.water = (int)(player.water / 2);
            return true;
        }
        return false;
    }

    private bool Event_YourMineCrashed()
    {
        if (player.ore > 0)
        {
            EventText = "After an accident in your mines. One tunnel has collapsed and buried the half of your ore.";
            eventImage.sprite = spriteYourMineCrashed;
            player.ore = (int)(player.ore / 2);
            return true;
        }
        return false;
    }

    private bool Event_SupportOfYourMotherland()
    {
        EventText = "A support cart of your motherland has arrived. You receive some ressources.";
        eventImage.sprite = spriteSupportOfYourMotherland;
        player.food = Mathf.Clamp(player.food + 5, 0, roundManager.storageCur);
        player.water = Mathf.Clamp(player.water + 5, 0, roundManager.storageCur);
        player.ore = Mathf.Clamp(player.ore + 5, 0, roundManager.storageCur);
        player.wood = Mathf.Clamp(player.wood + 5, 0, roundManager.storageCur);
        player.stone = Mathf.Clamp(player.stone + 5, 0, roundManager.storageCur);
        return true;
    }

    private bool Event_AFriendlyCraftsmanVisitsYourColony()
    {
        if (buildings.buildingList.Count > 0)
        {
            EventText = "A friendly craftsman visits your colony. And helps you to build at your current Projects.";
            eventImage.sprite = spriteAFriendlyCraftsmanVisitYourColony;
            GameObject curBuilding = buildings.buildingList[0];
            Tile curTile = curBuilding.GetComponent<Tile>(); 

            curTile.roundsToBuild--;
            curTile.RefreshBuildStatus();

            if (curTile.roundsToBuild <= 0)
            {
                buildings.buildingsWhichAreBuilt.Add(curBuilding);
                buildings.buildingList.RemoveAt(0);
                curBuilding = null;
            }
            roundManager.ReCalculateLimits();
            return true;
        }
        return false;
    }


}
