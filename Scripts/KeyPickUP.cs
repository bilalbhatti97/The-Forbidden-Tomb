using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyPickUP : MonoBehaviour
{
    public ItemBag itemBag;
    
    // Start is called before the first frame update
    private void Start()
    {
        itemBag = GameObject.FindObjectOfType<ItemBag>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("picked up Key");
        if (collision.tag == "Player")
        {

            itemBag.PickUpKey();
            //Play sound here
            Destroy(gameObject);

        }
    }

}
