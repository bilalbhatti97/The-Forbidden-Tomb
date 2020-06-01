using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Skill_SoftWalking : MonoBehaviour
{
    public Image skill_Image;
    public float coolDown=15;
    bool isCooldown;
    public float energyCost;
    public GameObject player;
    public GameObject manaBar;
    public float effectTime=5.0f;

    bool skillUnlocked;

    // Start is called before the first frame update
    private void Start()
    {
        if (PlayerPrefs.HasKey("softWalking_base"))
        {
            if (PlayerPrefs.GetInt("softWalking_base") == 1)
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
        if (PlayerPrefs.HasKey("softWalking_EC"))
        {
            if (PlayerPrefs.GetInt("softWalking_EC") == 1)
                energyCost = 5;
        }
        if (PlayerPrefs.HasKey("softWalking_EF"))
        {
            if (PlayerPrefs.GetInt("softWalking_EF") == 1)
                effectTime = 15.0f;
        }
        if (PlayerPrefs.HasKey("softWalking_CDT"))
        {
            if (PlayerPrefs.GetInt("softWalking_CDT") == 1)
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
            if (!isCooldown && Input.GetKeyDown(KeyCode.Alpha1) && manaBar.GetComponent<ManabarUIHandler>().currentMana >= energyCost)
            {
                isCooldown = true;
                manaBar.GetComponent<ManabarUIHandler>().UseMana(energyCost);
                skill_Image.fillAmount = 0;
                StartCoroutine(Skill_activated());

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

    IEnumerator Skill_activated()
    {
        player.GetComponent<Skill_Manager>().isSoftWalking = true;
        player.GetComponent<Skill_Manager>().Softicon.SetActive(true);
        yield return new WaitForSeconds(effectTime);
        player.GetComponent<Skill_Manager>().isSoftWalking = false;
        player.GetComponent<Skill_Manager>().Softicon.SetActive(false);
        yield return null;
    }
}
