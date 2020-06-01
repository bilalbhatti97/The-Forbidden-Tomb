using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;



public class SpellManager : MonoBehaviour
{
    public bool[] spellUnlocked = {false,false,false};

    // 0=ice, 1=fire, 2=lightning
    int spellIndex = 0;
    public float IceSpeed;
    public float IceEnergyCost;
    public float fireSpeed;
    public float fireEnergyCost;
    public float lightningSpeed;
    public float lightningEnergyCost;
    public Image spellHighlighter;
    float[] spellIconPositions = { 56.2f + 33, 56.2f, 56.2f-33 };

    public Animator anim;
    public GameObject fireBallPrefab, IcePrefab, LightningPrefab;
    public GameObject ManaBar;

    public Image[] spellIcons;
    // Start is called before the first frame update

    void Start()
    {
        CheckOnStartUp();
    }

    void CheckOnStartUp()
    {
        if (PlayerPrefs.HasKey("fireSpell_base"))
        {
            if (PlayerPrefs.GetInt("fireSpell_base")==1)
            {
                spellUnlocked[1] = true;
                spellIcons[1].enabled = true;
            }
        }
        if (PlayerPrefs.HasKey("fireSpell_EC"))
        {
            if (PlayerPrefs.GetInt("fireSpell_EC") == 1)
            {
                fireEnergyCost = 15;
            }
        }


        if (PlayerPrefs.HasKey("iceSpell_base"))
        {
            if (PlayerPrefs.GetInt("iceSpell_base") == 1)
            {
                spellUnlocked[0] = true;
                spellIcons[0].enabled = true;
            }
        }
        if (PlayerPrefs.HasKey("iceSpell_EC"))
        {
            if (PlayerPrefs.GetInt("iceSpell_EC") == 1)
            {
                IceEnergyCost = 5;
            }
        }
        if (PlayerPrefs.HasKey("lightningSpell_base"))
        {
            if (PlayerPrefs.GetInt("lightningSpell_base") == 1)
            {
                spellUnlocked[2] = true;
                spellIcons[2].enabled = true;
            }
        }
        if (PlayerPrefs.HasKey("lightningSpell_EC"))
        {
            if (PlayerPrefs.GetInt("lightningSpell_EC") == 1)
            {
                lightningEnergyCost = 10;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            SpellSelection();
        }
        if (Input.GetKey(KeyCode.LeftShift) && Input.GetKeyDown(KeyCode.L))
        {
            Cast(4);
        }
        if (Input.GetKey(KeyCode.LeftShift) && Input.GetKeyDown(KeyCode.I))
        {
            Cast(1);
        }
        if (Input.GetKey(KeyCode.LeftShift) && Input.GetKeyDown(KeyCode.J))
        {
            Cast(2);
        }
        if (Input.GetKey(KeyCode.LeftShift) && Input.GetKeyDown(KeyCode.K))
        {
            Cast(3);
        }
    }

    public void SpellSelection()
    {
        spellIndex++;
        if(spellIndex>=3)
        {
            spellIndex = 0;
        }
        spellHighlighter.transform.DOLocalMoveY(spellIconPositions[spellIndex], 0.3f);

        //spellHighlighter.rectTransform.DOLocalMove(spellIconPositions[spellIndex], 0.5f);
        //spellHighlighter.rectTransform. = spellIconPositions[spellIndex];
        
    }

    public void Cast(int direction)
    {
        if (spellUnlocked[spellIndex])
        {
            StartCoroutine(castSpell(direction, spellIndex));
        }
    }

    private IEnumerator castSpell(int direction,int spellType)
    {
        float spellSpeed=5.0f;
        float energyCost = 0;
        GameObject spellPrefab=IcePrefab;

        switch(spellType)
        {
            case 0:
                {
                    spellPrefab = IcePrefab;
                    spellSpeed = IceSpeed;
                    energyCost = IceEnergyCost;
                    break;
                }
            case 1:
                {
                    spellPrefab = fireBallPrefab;
                    spellSpeed = fireSpeed;
                    energyCost = fireEnergyCost;
                    break;
                }
            case 2:
                {
                    spellPrefab = LightningPrefab;
                    spellSpeed = lightningSpeed;
                    energyCost = lightningEnergyCost;
                    break;
                }
        }
        anim.ResetTrigger("isCasting");
        anim.SetTrigger("isCasting");
        yield return new WaitForSeconds(0.3f);

        if (ManaBar.GetComponent<ManabarUIHandler>().currentMana >= energyCost)
        {
            ManaBar.GetComponent<ManabarUIHandler>().UseMana(energyCost);
            GameObject ElementalBall = Instantiate(spellPrefab, transform.position, Quaternion.identity);
            switch (direction)
            {
                case 1:
                    {
                        //up
                        //arrow.transform.DORotate(new Vector3(0, 0, -90), 0.5f);
                        ElementalBall.GetComponent<Rigidbody2D>().velocity = new Vector2(0.0f, spellSpeed);
                        //arrow.transform.
                        break;
                    }
                case 2:
                    {
                        ElementalBall.transform.DORotate(new Vector3(0, 0, 90), 0.1f);
                        ElementalBall.GetComponent<Rigidbody2D>().velocity = new Vector2(-spellSpeed, 0.0f);
                        //left
                        break;
                    }
                case 3:
                    {
                        ElementalBall.transform.DORotate(new Vector3(0, 0, 180), 0.1f);
                        ElementalBall.GetComponent<Rigidbody2D>().velocity = new Vector2(0.0f, -spellSpeed);
                        //down
                        break;
                    }
                case 4:
                    {
                        ElementalBall.transform.DORotate(new Vector3(0, 0, -90), 0.1f);
                        ElementalBall.GetComponent<Rigidbody2D>().velocity = new Vector2(spellSpeed, 0.0f);
                        //right
                        break;
                    }

            }
        }
        yield return null;
    }
}


