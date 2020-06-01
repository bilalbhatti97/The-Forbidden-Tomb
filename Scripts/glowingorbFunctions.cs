using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class glowingorbFunctions : MonoBehaviour
{
    public GameObject confusionIconPrefab;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag=="ghost")
        {
            

            if (collision.transform.childCount>0)
            {
                //Destroy();

            }
            else
            {
                CastBlind(collision.transform.gameObject);
            }
        }
    }

    //IEnumerator Blind(GameObject target)
    //{
    //    target.GetComponent<Enemy>().alertRange = -10;
    //    GameObject c = (Instantiate(confusionIconPrefab, target.transform.position, Quaternion.identity));
    //    c.transform.SetParent(target.transform);
       
    //    yield return new WaitForSeconds(10.0f);
    //    target.GetComponent<Enemy>().alertRange = 10;
        
    //    yield return null;
    //}

    public void CastBlind(GameObject target)
    {
        GameObject c = (Instantiate(confusionIconPrefab, target.transform.position, Quaternion.identity));
        c.transform.SetParent(target.transform);
        c.name = "confusionMarker";
    }
}
