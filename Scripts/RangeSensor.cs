using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeSensor : MonoBehaviour
{
    //jisko alert send karega
    public GameObject Alerter;

    // Start is called before the first frame update
    void Start()
    {
        Alerter = gameObject.transform.parent.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Hit Wall");
        if (collision.tag == "Player")
        {
            Alerter.GetComponent<TotemObs>().inRange = true ;
            Alerter.GetComponent<TotemObs>().target = collision.transform;

        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("Hit Wall");
        if (collision.tag == "Player")
        {
            Alerter.GetComponent<TotemObs>().inRange = false;


        }
    }

}
