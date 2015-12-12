using UnityEngine;
using System.Collections;

public class Tile : MonoBehaviour
{
    public Buildings buildings;



    private SpriteRenderer spriteRenderer;
    private Sprite standardSprite;

    // Use this for initialization
    void Start()
    {
        spriteRenderer = this.GetComponent<SpriteRenderer>();
        standardSprite = spriteRenderer.sprite;

        buildings = GameObject.Find("Game_Properties").GetComponent<Buildings>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnMouseEnter()
    {
        spriteRenderer.sprite = buildings.choosenBuildingSprite;
    }

    void OnMouseExit()
    {
        spriteRenderer.sprite = standardSprite;
    }


    void OnMouseDown()
    {
        Debug.Log("Fick dich geh weg.....");
    }

}
