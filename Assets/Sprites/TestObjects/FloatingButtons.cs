using UnityEngine;
using System.Collections;

public class FloatingButtons : MonoBehaviour {


    //
    // ----- Methods
	void Start () 
    {
	
	} // END Start
	
    void Update () 
    {
	
	} // END Update


    void OnMouseDown()
    {

        if (this.name == "ButtonStart")
        {

            Application.LoadLevel(1);
        }
        else if (this.name == "ButtonExit")
        {
            Application.Quit();
        }
        else
        {
            Debug.Log("Mir fleucht als wäre hier ein Button Name nicht korrekt.");
        }

    
    } // END OnMouseDown



} // END Class
