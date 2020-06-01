using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasureManager : MonoBehaviour
{

    public Sprite ChestOpened;
    public ItemBag itembag;
    public bool isLooted = false;
    // Start is called before the first frame update
    void Start()
    {
        itembag = FindObjectOfType < ItemBag >();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("exit");
        if (collision.tag == "Player")
        {
            bool opend=itembag.UseKey();
            if (opend)
            {
                gameObject.GetComponent<SpriteRenderer>().sprite = ChestOpened;
                if (!isLooted)
                {
                    itembag.pickupHP();
                    isLooted = true;
                }
            }

        }
    }


}
