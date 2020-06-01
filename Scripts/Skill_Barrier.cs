using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Skill_Barrier : MonoBehaviour
{
    // Start is called before the first frame update
    public Image skill_Image;
    public float coolDown=30;
    bool isCooldown;
    public float energyCost=15;
    public GameObject player;
    public GameObject manaBar;
    public GameObject Shield;
    public float EffectTime=10.0f;

    bool skillUnlocked;

    // Start is called before the first frame update
    private void Start()
    {
        if(PlayerPrefs.HasKey("barrier_base"))
        {
            if (PlayerPrefs.GetInt("barrier_base") == 1)
            {
                skillUnlocked = true;
                skill_Image.enabled = true;
            }
            else
            {
                skill_Image.enabled = false;
            }
        }
        else
        {

            skill_Image.enabled = false;
        }
        if (PlayerPrefs.HasKey("barrier_EC"))
        {
            if (PlayerPrefs.GetInt("barrier_EC") == 1)
                energyCost = 5;
        }
        if (PlayerPrefs.HasKey("barrier_EF"))
        {
            if (PlayerPrefs.GetInt("barrier_EF") == 1)
                EffectTime = 20.0f;
        }
        if(PlayerPrefs.HasKey("barrier_CDT"))
        {
            if (PlayerPrefs.GetInt("barrier_CDT") == 1)
            {
                coolDown = 20;
            }
        }



    }


    // Update is called once per frame
    void Update()
    {
        if (skillUnlocked)
        {
            if (!isCooldown && Input.GetKeyDown(KeyCode.Alpha3) && manaBar.GetComponent<ManabarUIHandler>().currentMana >= energyCost)
            {
                isCooldown = true;
                manaBar.GetComponent<ManabarUIHandler>().UseMana(energyCost);
                skill_Image.fillAmount = 0;
                StartCoroutine(ShieldUP());
            }

            if (isCooldown)
            {
                skill_Image.fillAmount += 1 / coolDown * Time.deltaTime;

                if (skill_Image.fillAmount >= 1)
                {
                    isCooldown = false;
                }
            }
        }

    }

    

   IEnumerator ShieldUP()
    {
        Shield.SetActive(true);
        yield return new WaitForSeconds(EffectTime);
        Shield.SetActive(false);
        yield return null;
    }
}
