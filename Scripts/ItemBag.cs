using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemBag : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UseHealthPotion();
    }

    public bool bagIsFull = false;
    public Image item;
    public bool HealthPotion = false;
    public bool Key = false;

    public Sprite keyimage;
    public Sprite HealthPotionImage;

    public void PickUpKey()
    {
        if (!bagIsFull)
        {
            Key = true;
            bagIsFull = true;
            item.sprite = keyimage;
            var tempcolor = item.color;
            tempcolor.a = 1f;
            item.color = tempcolor;
        }
    }

    public void pickupHP()
    {
        if (!bagIsFull)
        {
            HealthPotion = true;
            bagIsFull = true;
            item.sprite = HealthPotionImage;
            var tempcolor = item.color;
            tempcolor.a = 1f;
            item.color = tempcolor;
        }
    }

    public void UseHealthPotion()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (HealthPotion)
            {
                gameObject.GetComponent<Health>().health += 5;
                HealthPotion = false;
                var tempcolor = item.color;
                tempcolor.a = 0f;
                item.color = tempcolor;
                bagIsFull = false;

                //increase health
            }
        }
    }

    public bool UseKey()
    {
        if (Key)
        {
            Key = false;
            var tempcolor = item.color;
            tempcolor.a = 0f;
            item.color = tempcolor;
            bagIsFull = false;
            //open chest
            return true;
        }
        return false;
    }
}
