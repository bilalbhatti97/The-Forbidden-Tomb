using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Skill_OrbGlowing : MonoBehaviour
{

   
    public Image skill_Image;
    public float coolDown=15;
    bool isCooldown;
    public float energyCost=15;
    public GameObject player;
    public GameObject manaBar;
    public GameObject OrbPrefab;
    public float EffectTime=15.0f;

    bool skillUnlocked;
    // Start is called before the first frame update
    private void Start()
    {
        if (PlayerPrefs.HasKey("glowingOrb_base"))
        {
            if (PlayerPrefs.GetInt("glowingOrb_base") == 1)
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
        if (PlayerPrefs.HasKey("glowingOrb_EC"))
        {
            if (PlayerPrefs.GetInt("glowingOrb_EC") == 1)
                energyCost = 5;
        }
        if (PlayerPrefs.HasKey("glowingOrb_EF"))
        {
            if (PlayerPrefs.GetInt("glowingOrb_EF") == 1)
                EffectTime = 25.0f;
        }
        if (PlayerPrefs.HasKey("glowingOrb_CDT"))
        {
            if (PlayerPrefs.GetInt("glowingOrb_CDT") == 1)
            {
                coolDown = 5;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (skillUnlocked)
        {
            if (!isCooldown && Input.GetKeyDown(KeyCode.Alpha2) && manaBar.GetComponent<ManabarUIHandler>().currentMana >= energyCost)
            {
                isCooldown = true;
                manaBar.GetComponent<ManabarUIHandler>().UseMana(energyCost);
                skill_Image.fillAmount = 0;
                SummonOrb();

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

    //IEnumerator Skill_activated()
    //{
    //    player.GetComponent<Skill_Manager>().isSoftWalking = true;
    //    yield return new WaitForSeconds(3.0f);
    //    player.GetComponent<Skill_Manager>().isSoftWalking = false;
    //    yield return null;
    //}

    public void SummonOrb()
    {
        GameObject orb = Instantiate(OrbPrefab,new Vector3(player.transform.position.x, player.transform.position.y+0.5f, player.transform.position.z), Quaternion.identity);
        orb.transform.SetParent(player.transform);
        Destroy(orb, EffectTime);
    }
}


