using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Binding : MonoBehaviour
{
    GameObject papa;
    // Start is called before the first frame update
    void Start()
    {
        papa = gameObject.transform.parent.transform.gameObject;
        StartCoroutine(Blind());
    }

    // Update is called once per frame
  IEnumerator Blind()
    {
        papa.GetComponent<Enemy>().alertRange = -10;
        yield return new WaitForSeconds(10.0f);
        papa.GetComponent<Enemy>().alertRange = 10;
        Destroy(gameObject);
        yield return null;
    }
}
