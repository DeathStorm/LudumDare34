using UnityEngine;
using System.Collections;

public class GUI_Controller : MonoBehaviour {

    private Buildings buildings;




	// Use this for initialization
	void Start () 
    {
        buildings = gameObject.GetComponent<Buildings>();
	}
	
	// Update is called once per frame
	void Update () 
    {

        if (Input.GetMouseButton(1))
        {
            buildings.ChooseBuildingToBuild();
        }
	}
}
