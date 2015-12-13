using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ToolTip : MonoBehaviour
{

    public bool showToolTip = false;

    public Image curImage;

    public GameObject toolTipObject1;
    public Text toolTip1;

    public GameObject toolTipObject2;
    public Text toolTip2;


    // Use this for initialization
    void Start()
    {
        curImage = gameObject.GetComponent<Image>();

        toolTip1 = toolTipObject1.GetComponent<Text>();
        toolTip2 = toolTipObject2.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {

        if (
            showToolTip == false &&
            (
                curImage.enabled == true ||
                toolTipObject1.activeInHierarchy == true ||
                toolTipObject2.activeInHierarchy == true
            )
           )
        {
            curImage.enabled = false;
            toolTipObject1.SetActive(false);
            toolTipObject2.SetActive(false);
        }
        else if (
                 showToolTip == true &&
                 (
                    curImage.enabled == false ||
                    toolTipObject1.activeInHierarchy == false ||
                    toolTipObject2.activeInHierarchy == false
                 )
                )
        {
            curImage.enabled = true;
            toolTipObject1.SetActive(true);
            toolTipObject2.SetActive(true);
        }



        Debug.Log(Input.mousePosition);

        gameObject.transform.position = Input.mousePosition;
        gameObject.transform.position += new Vector3(0, -10, 0);

    }
}
