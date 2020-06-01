using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    
    public GameObject SceneTransitor;
    // Start is called before the first frame update
    public int health;
    public int numOfHearts;
    public Animator anim;
    public Image[] hearts;
    public Sprite fullHeart;
   
    public Sprite emptyHeart;
    bool immunity = true;
    bool isdead;
    public int MAX_HEALTH;

  

    public AudioClip sfx_GetDamaged;

    private void Start()
    {
        if(PlayerPrefs.HasKey("maxHealth"))
        {
            MAX_HEALTH = PlayerPrefs.GetInt("maxHealth");
            if(MAX_HEALTH>=6)
            {
                hearts[5].enabled = true;
            }
        }
        if(PlayerPrefs.HasKey("Health"))
        {
            health = PlayerPrefs.GetInt("Health");
        }
        StartCoroutine(LevelStartImmunity());
        
    }

    public void GameOver()
    {
        
        
        
    }
    IEnumerator LevelStartImmunity()
    {
        yield return new WaitForSeconds(1.0f);
        immunity = false;
        yield return null;
    }


    IEnumerator Death()
    {
        anim.ResetTrigger("Dead");
        anim.SetTrigger("Dead");
        yield return new WaitForSeconds(2f);
        SceneTransitor.GetComponent<SceneTransition>().EndScene("GameOver");
        yield return null;
    }

    public void GetDamagedSoundPlay()
    {
        gameObject.GetComponent<AudioSource>().clip = sfx_GetDamaged;
        gameObject.GetComponent<AudioSource>().Play();
    }

    public void healthdamag(int damage)
    {
        if (!immunity)
        {
            SceneTransitor.GetComponent<SceneTransition>().Dmaged();
            health -= damage;
        }
    }

    private void Update()
    {
        if(health>MAX_HEALTH)
        {
            health = MAX_HEALTH;
        }
        if(health<1 && !isdead)
        {
            isdead = true;
            StartCoroutine(Death());
        }
        else
        {
            for (int i = 0; i < MAX_HEALTH; i++)
            {
                //double d = (double)(i + 1) / 2;
                //int index = Mathf.CeilToInt((float)d) - 1;
                //Debug.Log(index);
                if (i < health)
                {
                    //if (i + 1 == health)
                    //{
                    //    if (health % 2 == 0)
                    //    {
                    //        hearts[index].sprite = fullHeart;
                    //    }
                    //    else
                    //    {
                    //        hearts[index].sprite = crackedHeart;
                    //    }
                    //}
                    //else
                    //{
                    hearts[i].sprite = fullHeart;
                    //}

                }
                else
                {
                    hearts[i].sprite = emptyHeart;
                }




            }

        }
    }
}
