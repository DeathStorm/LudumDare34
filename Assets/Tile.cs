using UnityEngine;
using System.Collections;

public class Tile : MonoBehaviour
{
    public Sprite tmpImage;

    private SpriteRenderer spriteRenderer;
    private Sprite standardSprite;

    // Use this for initialization
    void Start()
    {
        spriteRenderer = this.GetComponent<SpriteRenderer>();
        standardSprite = spriteRenderer.sprite;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnMouseEnter()
    {
        spriteRenderer.sprite = tmpImage;
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
