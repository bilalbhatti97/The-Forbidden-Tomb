using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Shielding : MonoBehaviour
{
    // Start is called before the first frame update
   

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            gameObject.transform.DORotate(new Vector3(0, 180, 0), 0.1f);
        }
        else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            gameObject.transform.DORotate(new Vector3(0, 0, 0), 0.1f);
        }

    }
}
