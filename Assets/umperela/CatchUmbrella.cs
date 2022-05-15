using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatchUmbrella : MonoBehaviour
{

    public Transform cloasedDest;
    public Transform opendDest;
    public GameObject player;
    public Canvas h_canvas;
    public Canvas f_canvas;
    public GameObject oppenUmperella;

    bool holdingUmbrella;
    bool holdingOppenedUmbrella;

    CatchUmbrella()
    {
        holdingUmbrella = false;
        holdingOppenedUmbrella = false;
    }

    //this listen to any thing hapen in ui
    void OnGUI()
    {

        //this to get current bresd key
        Event e = Event.current;

        if (calculateDestance(this.transform, player.transform) < 1 && !holdingUmbrella) 
        {
            h_canvas.gameObject.SetActive(true);
            if (e.isKey) 
            {
                //listen to if h is pressed
                if (e.keyCode == KeyCode.H)
                {
                    holdingUmbrella = true;
                    h_canvas.gameObject.SetActive(false);
                    this.transform.position = cloasedDest.position;
                    this.transform.parent = GameObject.Find("umbrellaDest").transform;
                }
            }
        }
        else
        {
            h_canvas.gameObject.SetActive(false);
        }
        
        if (holdingUmbrella)
        {
            Debug.Log("have umbrella");
            f_canvas.gameObject.SetActive(true);

            if (e.isKey)
            {
                //listen to if f is pressed
                if (e.keyCode == KeyCode.F && !holdingOppenedUmbrella)
                {
                    holdingOppenedUmbrella = true;
                    oppenUmperella.gameObject.transform.position = opendDest.position;
                    oppenUmperella.transform.parent = GameObject.Find("possitoinOnOppenedU").transform;
                    this.gameObject.SetActive(false);
                    f_canvas.gameObject.SetActive(false);
                    oppenUmperella.gameObject.SetActive(true);
                }
            }

        }
    }

    //calculate Distance petween two opjects
    private float calculateDestance(Transform o1, Transform o2)
    {
        return Vector3.Distance(o1.position, o2.position);
    }

}
