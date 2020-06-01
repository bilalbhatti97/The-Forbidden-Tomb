using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.IO;
using UnityEngine.SceneManagement;

public class Shop_UI_Handler : MonoBehaviour
{
    public TMP_Text desc_txt;

    public Sprite fireSpellUnlocked;
    public Sprite iceSpellUnlocked;
    public Sprite lightningSpellUnlocked;
    public Sprite softWalkingSkillUnlocked;
    public Sprite glowingOrbSkillUnlocked;
    public Sprite barrierSkillUnlocked;
    public Sprite heartsUnlocked;
    public Sprite energyCostUnlocked;
    public Sprite effectTimeUnlocked;
    public Sprite coolDownTimeUnlocked;
    public Sprite arrowUnlocked;


    public GameObject btn_heart;
    public GameObject btn_arrow;
    public GameObject btn_FireSpell;
    public GameObject btn_FirePlus;
    public GameObject btn_FireEC;
    public GameObject btn_IceSpell;
    public GameObject btn_IcePlus;
    public GameObject btn_IceEC;
    public GameObject btn_LightningSpell;
    public GameObject btn_LightningPlus;
    public GameObject btn_LightningEC;
    public GameObject btn_SoftWalking;
    public GameObject btn_SWEC;
    public GameObject btn_SWEF;
    public GameObject btn_SWCDT;
    public GameObject btn_Gorb;
    public GameObject btn_GOEC;
    public GameObject btn_GOEF;
    public GameObject btn_GOCDT;
    public GameObject btn_Barrier;
    public GameObject btn_BEC;
    public GameObject btn_BEF;
    public GameObject btn_BCDT;

    public List<Image> Lino;
    public List<int> lino_activated;
    public List<int> btn_Pressed;
    List<GameObject> btns_lst;
    List<Sprite> Sprites_lst;
    public Color32 goldy = new Color32(0xF8,0xC7,0x30,0xFF);

    public AudioSource Line_SFX;
    public AudioSource btn_SFX;
    
    int currentGold;
    public TMP_Text txt_coin;
    public GameObject purchaseManager;
   // public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        ReadInfo();
        btns_lst = new List<GameObject>();
        Sprites_lst = new List<Sprite>();

        putBtnsInList();

        if (PlayerPrefs.HasKey("coins"))
        {
            
            showCoinsinGUI(PlayerPrefs.GetInt("coins"));
        }
        LoadShopState();

    }
    
    public void putBtnsInList()
    {
        btns_lst.Add(btn_heart);
        btns_lst.Add(btn_arrow);
        btns_lst.Add(btn_FireSpell);
        btns_lst.Add(btn_FirePlus);
        btns_lst.Add(btn_FireEC);
        btns_lst.Add(btn_IceSpell);
        btns_lst.Add(btn_IcePlus);
        btns_lst.Add(btn_IceEC);
        btns_lst.Add(btn_LightningSpell);
        btns_lst.Add(btn_LightningPlus); 
        btns_lst.Add(btn_LightningEC);
        btns_lst.Add(btn_SoftWalking);
        btns_lst.Add(btn_SWEC);
        btns_lst.Add(btn_SWEF);
        btns_lst.Add(btn_SWCDT);
        btns_lst.Add(btn_Gorb);
        btns_lst.Add(btn_GOEC);
        btns_lst.Add(btn_GOEF);
        btns_lst.Add(btn_GOCDT);
        btns_lst.Add(btn_Barrier);
        btns_lst.Add(btn_BEC);
        btns_lst.Add(btn_BEF);
        btns_lst.Add(btn_BCDT);


        Sprites_lst.Add(heartsUnlocked);
        Sprites_lst.Add(arrowUnlocked);
        Sprites_lst.Add(fireSpellUnlocked);
        Sprites_lst.Add(fireSpellUnlocked);
        Sprites_lst.Add(energyCostUnlocked);
        Sprites_lst.Add(iceSpellUnlocked);
        Sprites_lst.Add(iceSpellUnlocked);
        Sprites_lst.Add(energyCostUnlocked);
        Sprites_lst.Add(lightningSpellUnlocked);
        Sprites_lst.Add(lightningSpellUnlocked);
        Sprites_lst.Add(energyCostUnlocked);
        Sprites_lst.Add(softWalkingSkillUnlocked);
        Sprites_lst.Add(energyCostUnlocked);
        Sprites_lst.Add(effectTimeUnlocked);
        Sprites_lst.Add(coolDownTimeUnlocked);
        Sprites_lst.Add(glowingOrbSkillUnlocked);
        Sprites_lst.Add(energyCostUnlocked);
        Sprites_lst.Add(effectTimeUnlocked);
        Sprites_lst.Add(coolDownTimeUnlocked);
        Sprites_lst.Add(barrierSkillUnlocked);
        Sprites_lst.Add(energyCostUnlocked);
        Sprites_lst.Add(effectTimeUnlocked);
        Sprites_lst.Add(coolDownTimeUnlocked);
    }            
    /*
     * btn list order
     * 0:Hearts
     * 1:Arrows
     * 2:fire base
     * 3:fire plus
     * 4:fire EC
     * 5:Ice base
     * 6:Ice plus
     * 7:Ice EC
     * 8:Lightning base
     * 9:Lightning plus
     * 10:Lightning EC
     * 11:SW
     * 12:SW ec
     * 13:SW EF
     * 14:SW CDT
     * 15:GO 
     * 16:GO EC
     * 17:GO EF
     * 18:GO CDT
     * 19:B
     * 20:B EC
     * 21:B EF
     * 22:B CDT
     */
    void LoadShopState()
    {
        for(int i=0;i<lino_activated.Count;i++)
        {
            if(lino_activated[i]>0)
            {
                Lino[i].enabled = true;
                if(lino_activated[i]==2)
                {
                    Lino[i].color = goldy;
                }

            }
        }

        for(int i=0;i<btns_lst.Count;i++)
        {
            if(btn_Pressed[i]>0)
            {
                btns_lst[i].SetActive(true);
            }
            if(btn_Pressed[i]==2)
            {
                btns_lst[i].GetComponent<Button>().enabled = false;
                btns_lst[i].GetComponent<Image>().sprite = Sprites_lst[i];
                btns_lst[i].GetComponentInChildren<TMP_Text>().enabled = false;
                purchaseManager.GetComponent<Shop_purschaseManager>().method_list[i].Invoke();
            }
        }

    }

    void showCoinsinGUI(int coins)
    {
        currentGold = coins;
        txt_coin.text = currentGold.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    #region hearts
    public void Desc_heart()
    {
        desc_txt.text = "Hearts: Increases your max life.";
    }
    public void UpgradeHearts()
    {
        if (currentGold >= 50)
        {
            btn_Pressed[0] = 2;
            purchaseManager.GetComponent<Shop_purschaseManager>().Heart_purchase();
            showCoinsinGUI(currentGold - 50);
            btn_SFX.Play();
            btn_heart.GetComponent<Button>().enabled = false;
            btn_heart.GetComponent<Image>().sprite = heartsUnlocked;
            StartCoroutine(FirstBranchUnlock());
        }
        else
        {
            desc_txt.text = "Not Enough Gold";
        }
       // Line_Solidification_Arrow();
    }
    IEnumerator FirstBranchUnlock()
    {
        yield return new WaitForSeconds(0.3f);
        Lino[0].enabled = true;
        lino_activated[0] = 1;
        Lino[15].enabled = true;
        lino_activated[15] = 1;
        Lino[14].enabled = true;
        lino_activated[14] = 1;
        Line_SFX.Play();
        yield return new WaitForSeconds(0.3f);
        btn_arrow.SetActive(true);
        btn_Pressed[1] = 1;
        Line_SFX.Play();
        yield return new WaitForSeconds(0.1f);
        Lino[1].enabled = true;
        lino_activated[1] = 1;
        Lino[16].enabled = true;
        lino_activated[16] = 1;
        Line_SFX.Play();
        yield return new WaitForSeconds(0.3f);
        Lino[2].enabled = true;
        lino_activated[2] = 1;
        Lino[17].enabled = true;
        lino_activated[17] = 1;
        Line_SFX.Play();
        yield return new WaitForSeconds(0.3f);
        Lino[3].enabled = true;
        lino_activated[3] = 1;
        Line_SFX.Play();
        yield return new WaitForSeconds(0.1f);
        btn_FireSpell.SetActive(true);
        btn_Pressed[2] = 1;
        Line_SFX.Play();
        yield return new WaitForSeconds(0.1f);
        Lino[18].enabled = true;
        lino_activated[18] = 1;
        Line_SFX.Play();
        yield return new WaitForSeconds(0.1f);
        btn_Gorb.SetActive(true);
        btn_Pressed[15] = 1;
        Line_SFX.Play();
        yield return new WaitForSeconds(0.1f);
        Lino[7].enabled = true;
        lino_activated[7] = 1;
        Lino[19].enabled = true;
        lino_activated[19] = 1;
        Lino[4].enabled = true;
        lino_activated[4] = 1;
        Lino[22].enabled = true;
        lino_activated[22] = 1;
        Line_SFX.Play();
        yield return new WaitForSeconds(0.3f);
        Lino[6].enabled = true;
        lino_activated[6] = 1;
        Lino[20].enabled = true;
        lino_activated[20] = 1;
        Lino[5].enabled = true;
        lino_activated[5] = 1;
        Lino[21].enabled = true;
        lino_activated[21] = 1;
        Line_SFX.Play();
        yield return new WaitForSeconds(0.3f);
        btn_SoftWalking.SetActive(true);
        btn_Pressed[11] = 1;
        btn_LightningSpell.SetActive(true);
        btn_Pressed[8] = 1;
        btn_IceSpell.SetActive(true);
        btn_Pressed[5] = 1;
        btn_Barrier.SetActive(true);
        btn_Pressed[19] = 1;
        Line_SFX.Play();
        yield return new WaitForSeconds(0.1f);
        yield return null;
    }
    #endregion


    #region Arrows
    public void Desc_arrows()
    {
        desc_txt.text = "Arrows: Increases the number of arrows you can have.";
    }
    public void UpgradArrows()
    {
        if (currentGold >= 50)
        {
            purchaseManager.GetComponent<Shop_purschaseManager>().Arrow_pruchase();
            btn_Pressed[1] = 2;
            showCoinsinGUI(currentGold - 50);
            btn_SFX.Play();
            btn_arrow.GetComponent<Button>().enabled = false;
            StartCoroutine(ArrowAnimation());
        }
        else
        {
            desc_txt.text = "Not Enough Gold.";
        }
    }
    IEnumerator ArrowAnimation()
    {
        //  anim.SetTrigger("arrow");
        Lino[14].color = goldy;
        lino_activated[14] = 2;
        yield return new WaitForSeconds(0.3f);
        btn_arrow.GetComponent<Image>().sprite = arrowUnlocked;
        //yield return null;
        
        yield return null;
    }
    #endregion

    #region Fire
    public void Desc_FireSpell()
    {
        desc_txt.text = "FireBall: Cast A Powerful fireball from your hand that deals massive damage. Press 'Q' to select. Press 'Shift' + ' i/j/k/l ' to cast.";
    }
    public void UpgradFireSpell()
    {
        if (currentGold >= 50)
        {
            purchaseManager.GetComponent<Shop_purschaseManager>().FireSpell_Purchase();
            btn_Pressed[2] = 2;
            showCoinsinGUI(currentGold - 50);
            btn_SFX.Play();
            btn_FireSpell.GetComponent<Button>().enabled = false;
            StartCoroutine(FireSpellAnimation());
        }
        else
        {
            desc_txt.text = "Not Enough Gold.";
        }
    }
    IEnumerator FireSpellAnimation()
    {
        Lino[0].color = goldy;
        lino_activated[0] = 2;
        Line_SFX.Play();
        yield return new WaitForSeconds(0.3f);
        Lino[1].color = goldy;
        lino_activated[1] = 2;
        Line_SFX.Play();
        yield return new WaitForSeconds(0.3f);
        Lino[2].color = goldy;
        lino_activated[2] = 2;
        Line_SFX.Play();
        yield return new WaitForSeconds(0.3f);
        Lino[3].color = goldy;
        lino_activated[3] = 2;
        Line_SFX.Play();
        yield return new WaitForSeconds(0.3f);
        btn_FireSpell.GetComponent<Image>().sprite = fireSpellUnlocked;
        btn_FireSpell.GetComponentInChildren<TMP_Text>().enabled = false;
        yield return new WaitForSeconds(0.3f);
        Lino[8].enabled = true;
        lino_activated[8] = 1;
        Lino[9].enabled = true;
        lino_activated[9] = 1;
        Line_SFX.Play();
        yield return new WaitForSeconds(0.3f);
        btn_FirePlus.SetActive(true);
        btn_Pressed[3] = 1;
        btn_FireEC.SetActive(true);
        btn_Pressed[4] = 1;
        Line_SFX.Play();
        yield return null;
    }

    
    public void Desc_firePlus()
    {
        desc_txt.text = "Fire Ball ULTRA: Take your Fireball spell to the NEXT LEVEL. When hit on a wall, the Fireball will scatter into tiny little fireballs and fly into all directions.";
    }
    public void UpgradFirePlus()
    {
        if (currentGold >= 100)
        {
            purchaseManager.GetComponent<Shop_purschaseManager>().FirePlus_Purchase();
            btn_Pressed[3] = 2;
            showCoinsinGUI(currentGold - 100);
            btn_SFX.Play();
            btn_FirePlus.GetComponent<Button>().enabled = false;
            StartCoroutine(FirePlusAnimation());
        }
        else
        {
            desc_txt.text = "Not Enough Gold.";
        }
    }
    IEnumerator FirePlusAnimation()
    {
        Lino[8].color = goldy;
        lino_activated[8] = 2;
        Line_SFX.Play();
        yield return new WaitForSeconds(0.3f);
        btn_FirePlus.GetComponent<Image>().sprite = fireSpellUnlocked;
        btn_FirePlus.GetComponentInChildren<TMP_Text>().enabled = false;
        yield return null;
    }
    public void Desc_fireEC()
    {
        desc_txt.text = "Energy Cost Down: Decreases the energy cost of the Fireball spell.";
    }
    public void UpgradFireEC()
    {
        if (currentGold >= 50)
        {
            purchaseManager.GetComponent<Shop_purschaseManager>().FireEC_Purchase();
            btn_Pressed[4] = 2;
            showCoinsinGUI(currentGold - 50);
            btn_SFX.Play();
            btn_FireEC.GetComponent<Button>().enabled = false;
            StartCoroutine(FireECAnimation());
        }
        else
        {
            desc_txt.text = "Not Enough Gold.";
        }
    }
    IEnumerator FireECAnimation()
    {
        Lino[9].color = goldy;
        lino_activated[9] = 2;
        Line_SFX.Play();
        yield return new WaitForSeconds(0.3f);
        btn_FireEC.GetComponent<Image>().sprite = energyCostUnlocked;
        btn_FireEC.GetComponentInChildren<TMP_Text>().enabled = false;
        yield return null;
        
    }
    #endregion

    #region ice
    public void Desc_icespell()
    {
        desc_txt.text = "Ice Shard: Cast an Ice Shard from your hand that freezes your enemies. Press 'Q' to select. Press 'Shift' + ' i/j/k/l ' to cast.  ";
    }
    public void UpgradeIceSpell()
    {
        if (currentGold >= 50)
        {
            purchaseManager.GetComponent<Shop_purschaseManager>().IceSpell_Purchase();
            btn_Pressed[5] = 2;
            showCoinsinGUI(currentGold - 50);
            btn_SFX.Play();
            btn_IceSpell.GetComponent<Button>().enabled = false;
            StartCoroutine(IceSpellAnimation());
        }
        else
        {
            desc_txt.text = "Not Enough Gold.";
        }
    }
    IEnumerator IceSpellAnimation()
    {
        Lino[0].color = goldy;
        lino_activated[0] = 2;
        Line_SFX.Play();
        yield return new WaitForSeconds(0.3f);
        Lino[1].color = goldy;
        lino_activated[1] = 2;
        Line_SFX.Play();
        yield return new WaitForSeconds(0.3f);
        Lino[2].color = goldy;
        lino_activated[2] = 2;
        Line_SFX.Play();
        yield return new WaitForSeconds(0.3f);
        Lino[4].color = goldy;
        lino_activated[4] = 2;
        Line_SFX.Play();
        yield return new WaitForSeconds(0.3f);
        Lino[5].color = goldy;
        lino_activated[5] = 2;
        Line_SFX.Play();
        yield return new WaitForSeconds(0.3f);
        btn_IceSpell.GetComponent<Image>().sprite = iceSpellUnlocked;
        btn_IceSpell.GetComponentInChildren<TMP_Text>().enabled = false;
        yield return new WaitForSeconds(0.3f);
        Lino[13].enabled = true;
        lino_activated[13] = 1;
        Lino[12].enabled = true;
        lino_activated[12] = 1;
        Line_SFX.Play();
        yield return new WaitForSeconds(0.3f);
        btn_IcePlus.SetActive(true);
        btn_Pressed[6] = 1;
        btn_IceEC.SetActive(true);
        btn_Pressed[7] = 1;
        Line_SFX.Play();
        yield return null;
      
    }
    public void Desc_icePlus()
    {
        desc_txt.text = "Ice Shard ULTRA: Take your Ice Shard Spell to the NEXT LEVEL. Your Ice Shard now pierces through enemies, freezing them along the way. ";
    }
    public void UpgradeIcePlus()
    {
        purchaseManager.GetComponent<Shop_purschaseManager>().IcePlus_Purchase();
        if (currentGold >= 100)
        {
            btn_Pressed[6] = 2;
            showCoinsinGUI(currentGold - 100);
            btn_SFX.Play();
            btn_IcePlus.GetComponent<Button>().enabled = false;
            StartCoroutine(IcePlusAnimation());
        }
        else
        {
            desc_txt.text = "Not Enough Gold.";
        }
    }
    IEnumerator IcePlusAnimation()
    {
        Lino[13].color = goldy;
        lino_activated[13] = 2;
        Line_SFX.Play();
        yield return new WaitForSeconds(0.3f);
        btn_IcePlus.GetComponent<Image>().sprite = iceSpellUnlocked;
        btn_IcePlus.GetComponentInChildren<TMP_Text>().enabled = false;
        yield return null;
        
    }
    public void Desc_ice_EC()
    {
        desc_txt.text = "Energy Cost Down: Decrease the cost of energy required to cast Ice Shard.";
    }
    public void UpgradeIceEC()
    {
        if (currentGold >= 50)
        {
            purchaseManager.GetComponent<Shop_purschaseManager>().IceEC_Purchase();
            btn_Pressed[7] = 2;
            showCoinsinGUI(currentGold-50);
            btn_SFX.Play();
            btn_IceEC.GetComponent<Button>().enabled = false;
            StartCoroutine(IceECAnimation());
        }
        else
        {
            desc_txt.text = "Not Enough Gold.";
        }
    }
    IEnumerator IceECAnimation()
    {
        Lino[12].color = goldy;
        lino_activated[12] = 2;
        Line_SFX.Play();
        yield return new WaitForSeconds(0.3f);
        btn_IceEC.GetComponent<Image>().sprite = energyCostUnlocked;
        btn_IceEC.GetComponentInChildren<TMP_Text>().enabled = false;
        yield return null;
        
    }
    #endregion

    #region Lightning
    public void Desc_Lightning()
    {
        desc_txt.text = "Lightning Bolt: Cast Lightning that latchs on to your enemies, shocking it self and the enemies near it. Press 'Q' to select. Press 'Shift' + ' i/j/k/l ' to cast.";
    }
    public void UpgradLightningSpell()
    {
        if (currentGold >= 50)
        {
            purchaseManager.GetComponent<Shop_purschaseManager>().LightningSpell_Purchase();
            btn_Pressed[8] = 2;
            showCoinsinGUI(currentGold - 50);
            btn_SFX.Play();
            btn_LightningSpell.GetComponent<Button>().enabled = false;
            StartCoroutine(LightningSpellAnimation());
        }
        else
        {
            desc_txt.text = "Not Enough Gold.";
        }
    }
    IEnumerator LightningSpellAnimation()
    {
        Lino[0].color = goldy;
        lino_activated[0] = 2;
        Line_SFX.Play();
        yield return new WaitForSeconds(0.3f);
        Lino[1].color = goldy;
        lino_activated[1] = 2;
        Line_SFX.Play();
        yield return new WaitForSeconds(0.3f);
        Lino[2].color = goldy;
        lino_activated[2] = 2;
        Line_SFX.Play();
        yield return new WaitForSeconds(0.3f);
        Lino[7].color = goldy;
        lino_activated[7] = 2;
        Line_SFX.Play();
        yield return new WaitForSeconds(0.3f);
        Lino[6].color = goldy;
        lino_activated[6] = 2;
        Line_SFX.Play();
        yield return new WaitForSeconds(0.3f);
        btn_LightningSpell.GetComponent<Image>().sprite = lightningSpellUnlocked;
        btn_LightningSpell.GetComponentInChildren<TMP_Text>().enabled = false;
        yield return new WaitForSeconds(0.3f);
        Lino[11].enabled = true;
        lino_activated[11] = 1;
        Lino[10].enabled = true;
        lino_activated[10] = 1;
        Line_SFX.Play();
        yield return new WaitForSeconds(0.3f);
        btn_LightningPlus.SetActive(true);
        btn_Pressed[9] = 1;
        btn_LightningEC.SetActive(true);
        btn_Pressed[10] = 1;
        Line_SFX.Play();
        yield return null;
        
    }
    public void Desc_LightningPlus()
    {
        desc_txt.text = "Lightning Bolt ULTRA: Take your Lightning Bolt to the NEXT LEVEL. The lightning now bursts out of its victim more frequently.";
    }
    public void UpgradLightningPLus()
    {
        if (currentGold >= 100)
        {
            purchaseManager.GetComponent<Shop_purschaseManager>().LightningPlus_Purchase();
            btn_Pressed[9] = 2;
            showCoinsinGUI(currentGold - 100);
            btn_SFX.Play();
            btn_LightningPlus.GetComponent<Button>().enabled = false;
            StartCoroutine(LightningPlusAnimation());
        }
        else
        {
            desc_txt.text = "Not Enough Gold.";
        }
    }
    IEnumerator LightningPlusAnimation()
    {
        Lino[10].color = goldy;
        lino_activated[10] = 2;
        Line_SFX.Play();
        yield return new WaitForSeconds(0.3f);
        btn_LightningPlus.GetComponent<Image>().sprite = lightningSpellUnlocked;
        btn_LightningPlus.GetComponentInChildren<TMP_Text>().enabled = false;
        yield return null;
        
    }
    public void Desc_LightningEC()
    {
        desc_txt.text = "Energy Cost Down: Decrease the energy required to cast Lightning Bolt.";
    }
    public void UpgradLightningEC()
    {
        if (currentGold >= 50)
        {
            purchaseManager.GetComponent<Shop_purschaseManager>().LightningEC_Purchase();
            btn_Pressed[10] = 2;
            showCoinsinGUI(currentGold - 50);
            btn_SFX.Play();
            btn_LightningEC.GetComponent<Button>().enabled = false;
            StartCoroutine(LightningECAnimation());
        }
        else
        {
            desc_txt.text = "Not Enough Gold.";
        }
    }
    IEnumerator LightningECAnimation()
    {
        Lino[11].color = goldy;
        lino_activated[11] = 2;
        Line_SFX.Play();
        yield return new WaitForSeconds(0.3f);
        btn_LightningEC.GetComponent<Image>().sprite = energyCostUnlocked;
        btn_LightningEC.GetComponentInChildren<TMP_Text>().enabled = false;
        yield return null;
        
    }
    #endregion

    #region SoftWalking
    public void Desc_SW()
    {
        desc_txt.text = "Soft Walking: Walk softly to not trigger traps. Press '1' to use.";
    }
    public void UpgradSoftWalkingSkill()
    {
        if (currentGold >= 50)
        {
            purchaseManager.GetComponent<Shop_purschaseManager>().SoftWalking_Purchase();
            btn_Pressed[11]= 2;
            showCoinsinGUI(currentGold - 50);
            btn_SFX.Play();
            btn_SoftWalking.GetComponent<Button>().enabled = false;
            StartCoroutine(SWAnimation());
        }
        else
        {
            desc_txt.text = "Not Enough Gold.";
        }
    }
    IEnumerator SWAnimation()
    {
        Lino[15].color = goldy;
        lino_activated[15] = 2;
        Line_SFX.Play();
        yield return new WaitForSeconds(0.3f);
        Lino[16].color = goldy;
        lino_activated[16] = 2;
        Line_SFX.Play();
        yield return new WaitForSeconds(0.3f);
        Lino[17].color = goldy;
        lino_activated[17] = 2;
        Line_SFX.Play();
        yield return new WaitForSeconds(0.3f);
        Lino[19].color = goldy;
        lino_activated[19] = 2;
        Line_SFX.Play();
        yield return new WaitForSeconds(0.3f);
        Lino[20].color = goldy;
        lino_activated[20] = 2;
        Line_SFX.Play();
        yield return new WaitForSeconds(0.3f);
        btn_SoftWalking.GetComponent<Image>().sprite = softWalkingSkillUnlocked;
        btn_SoftWalking.GetComponentInChildren<TMP_Text>().enabled = false;
        yield return new WaitForSeconds(0.3f);
        Lino[26].enabled = true;
        lino_activated[26] = 1;
        Lino[27].enabled = true;
        lino_activated[27] = 1;
        Lino[28].enabled = true;
        lino_activated[28] = 1;
        Line_SFX.Play();
        yield return new WaitForSeconds(0.3f);
        btn_SWEC.SetActive(true);
        btn_Pressed[12] = 1;
        btn_SWEF.SetActive(true);
        btn_Pressed[13] = 1;
        btn_SWCDT.SetActive(true);
        btn_Pressed[14] = 1;
        Line_SFX.Play();
        yield return null;

    }
    public void Desc_SW_EC()
    {
        desc_txt.text = "Energy Cost Down: Decreases the energy required to use the Soft Walking skill.";
    }
    public void UpgradSW_EC()
    {
        if (currentGold >= 50)
        {
            purchaseManager.GetComponent<Shop_purschaseManager>().SWEC_Purchase();
            btn_Pressed[12] = 2;
            showCoinsinGUI(currentGold - 50);
            btn_SFX.Play();
            btn_SWEC.GetComponent<Button>().enabled = false;
            StartCoroutine(SW_ECAnimation());
        }
        else
        {
            desc_txt.text = "Not Enough Gold.";
        }
    }
    IEnumerator SW_ECAnimation()
    {
        Lino[26].color = goldy;
        lino_activated[26] = 2;
        Line_SFX.Play();
        yield return new WaitForSeconds(0.3f);
        btn_SWEC.GetComponent<Image>().sprite = energyCostUnlocked;
        btn_SWEC.GetComponentInChildren<TMP_Text>().enabled = false;
        yield return null;

    }
    public void Desc_SW_EF()
    {
        desc_txt.text = "Effect Time Increase: Increases the effect time of the Soft Walking skill.";
    }
    public void UpgradSW_EF()
    {
        if (currentGold >= 50)
        {
            purchaseManager.GetComponent<Shop_purschaseManager>().SWEF_Purchase();
            btn_Pressed[13] = 2;
            showCoinsinGUI(currentGold - 50);
            btn_SFX.Play();
            btn_SWEF.GetComponent<Button>().enabled = false;
            StartCoroutine(SW_EFAnimation());
        }
        else
        {
            desc_txt.text = "Not Enough Gold.";
        }
    }
    IEnumerator SW_EFAnimation()
    {
        Lino[27].color = goldy;
        lino_activated[27] = 2;
        Line_SFX.Play();
        yield return new WaitForSeconds(0.3f);
        btn_SWEF.GetComponent<Image>().sprite = effectTimeUnlocked;
        btn_SWEF.GetComponentInChildren<TMP_Text>().enabled = false;
        yield return null;

    }
    public void Desc_SW_CDT()
    {
        desc_txt.text = "Cool Down Time Decrease: Decreases the cool down time for the Soft Walking skill.";
    }
    public void UpgradSW_CDT()
    {
        if (currentGold >= 50)
        {
            purchaseManager.GetComponent<Shop_purschaseManager>().SWCDT_Purchase();
            btn_Pressed[14] = 2;
            showCoinsinGUI(currentGold - 50);
            btn_SFX.Play();
            btn_SWCDT.GetComponent<Button>().enabled = false;
            StartCoroutine(SW_CDTAnimation());
        }
        else
        {
            desc_txt.text = "Not Enough Gold.";
        }
    }
    IEnumerator SW_CDTAnimation()
    {
        Lino[28].color = goldy;
        lino_activated[28] = 2;
        Line_SFX.Play();
        yield return new WaitForSeconds(0.3f);
        btn_SWCDT.GetComponent<Image>().sprite = coolDownTimeUnlocked;
        btn_SWCDT.GetComponentInChildren<TMP_Text>().enabled = false;
        yield return null;

    }
    #endregion

    #region GlowingOrb
    public void Desc_GO()
    {
        desc_txt.text = "Glowing Orb: Summon a Glowing Orb that will blind Ghosts that are around you. Press '2' to use.";
    }
    public void UpgradGlowingOrbSkill()
    {
        if (currentGold >= 50)
        {
            purchaseManager.GetComponent<Shop_purschaseManager>().GlowingOrb_Purchase();
            btn_Pressed[15] = 2;
            showCoinsinGUI(currentGold - 50);
            btn_SFX.Play();
            btn_Gorb.GetComponent<Button>().enabled = false;
            StartCoroutine(GOAnimation());
        }
        else
        {
            desc_txt.text = "Not Enough Gold.";
        }
    }
    IEnumerator GOAnimation()
    {
        Lino[15].color = goldy;
        lino_activated[15] = 2;
        Line_SFX.Play();
        yield return new WaitForSeconds(0.3f);
        Lino[16].color = goldy;
        lino_activated[16] = 2;
        Line_SFX.Play();
        yield return new WaitForSeconds(0.3f);
        Lino[17].color = goldy;
        lino_activated[17] = 2;
        Line_SFX.Play();
        yield return new WaitForSeconds(0.3f);
        Lino[18].color = goldy;
        lino_activated[18] = 2;
        Line_SFX.Play();
        yield return new WaitForSeconds(0.3f);
        
        btn_Gorb.GetComponent<Image>().sprite = glowingOrbSkillUnlocked;
        btn_Gorb.GetComponentInChildren<TMP_Text>().enabled = false;
        yield return new WaitForSeconds(0.3f);
        Lino[24].enabled = true;
        lino_activated[24] = 1;
        Lino[23].enabled = true;
        lino_activated[23] = 1;
        Lino[25].enabled = true;
        lino_activated[25] = 1;
        Line_SFX.Play();
        yield return new WaitForSeconds(0.3f);
        btn_GOEC.SetActive(true);
        btn_Pressed[16] = 1;
        btn_GOEF.SetActive(true);
        btn_Pressed[17] = 1;
        btn_GOCDT.SetActive(true);
        btn_Pressed[18] = 1;
        Line_SFX.Play();
        yield return null;

    }
    public void Desc_GO_EC()
    {
        desc_txt.text = "Energy Cost Down: Decreases the energy required to use the Glowing Orb skill.";
    }
    public void UpgradGO_EC()
    {
        if (currentGold >= 50)
        {
            purchaseManager.GetComponent<Shop_purschaseManager>().GOEC_Purchase();
            btn_Pressed[16] = 2;
            showCoinsinGUI(currentGold - 50);
            btn_SFX.Play();
            btn_GOEC.GetComponent<Button>().enabled = false;
            StartCoroutine(GO_ECAnimation());
        }
        else
        {
            desc_txt.text = "Not Enough Gold.";
        }
    }
    IEnumerator GO_ECAnimation()
    {
        Lino[24].color = goldy;
        lino_activated[24] = 2;
        Line_SFX.Play();
        yield return new WaitForSeconds(0.3f);
        btn_GOEC.GetComponent<Image>().sprite = energyCostUnlocked;
        btn_GOEC.GetComponentInChildren<TMP_Text>().enabled = false;
        yield return null;

    }
    public void Desc_GO_EF()
    {
        desc_txt.text = "Effect Time Increase: Increases the effect time of the Glowing Orb skill.";
    }
    public void UpgradGO_EF()
    {
        if (currentGold >= 50)
        {
            purchaseManager.GetComponent<Shop_purschaseManager>().GOEF_Purchase();
            btn_Pressed[17] = 2;
            showCoinsinGUI(currentGold - 50);
            btn_SFX.Play();
            btn_GOEF.GetComponent<Button>().enabled = false;
            StartCoroutine(GO_EFAnimation());
        }
        else
        {
            desc_txt.text = "Not Enough Gold.";
        }
    }
    IEnumerator GO_EFAnimation()
    {
        Lino[23].color = goldy;
        lino_activated[23] = 2;
        Line_SFX.Play();
        yield return new WaitForSeconds(0.3f);
        btn_GOEF.GetComponent<Image>().sprite = effectTimeUnlocked;
        btn_GOEF.GetComponentInChildren<TMP_Text>().enabled = false;
        yield return null;

    }
    public void Desc_GO_CDT()
    {
        desc_txt.text = "Cool Down Time Decrease: Decreases the cool down time for the Glowing Orb skill.";
    }
    public void UpgradGO_CDT()
    {
        if (currentGold >= 50)
        {
            purchaseManager.GetComponent<Shop_purschaseManager>().GOCDT_Purchase();
            btn_Pressed[18] = 2;
            showCoinsinGUI(currentGold - 50);
            btn_SFX.Play();
            btn_GOCDT.GetComponent<Button>().enabled = false;
            StartCoroutine(GO_CDTAnimation());
        }
        else
        {
            desc_txt.text = "Not Enough Gold.";
        }
    }
    IEnumerator GO_CDTAnimation()
    {
        Lino[25].color = goldy;
        lino_activated[25] = 2;
        Line_SFX.Play();
        yield return new WaitForSeconds(0.3f);
        btn_GOCDT.GetComponent<Image>().sprite = coolDownTimeUnlocked;
        btn_GOCDT.GetComponentInChildren<TMP_Text>().enabled = false;
        yield return null;

    }
    #endregion


    #region Barrier
    public void Desc_B()
    {
        desc_txt.text = "Barrier: Summon a Barrier that will protect you from oncoming fire projectiles. Press '3' to use.";
    }
    public void UpgradBarriergSkill()
    {
        if (currentGold >= 50)
        {
            purchaseManager.GetComponent<Shop_purschaseManager>().Barrier_Purchase();
            btn_Pressed[19] = 2;
            showCoinsinGUI(currentGold - 50);
            btn_SFX.Play();
            btn_Barrier.GetComponent<Button>().enabled = false;
            StartCoroutine(BAnimation());
        }
        else
        {
            desc_txt.text = "Not Enough Gold.";
        }
    }
    IEnumerator BAnimation()
    {
        Lino[15].color = goldy;
        lino_activated[15] = 2;
        Line_SFX.Play();
        yield return new WaitForSeconds(0.3f);
        Lino[16].color = goldy;
        lino_activated[16] = 2;
        Line_SFX.Play();
        yield return new WaitForSeconds(0.3f);
        Lino[17].color = goldy;
        lino_activated[17] = 2;
        Line_SFX.Play();
        yield return new WaitForSeconds(0.3f);
        Lino[22].color = goldy;
        lino_activated[22] = 2;
        Line_SFX.Play();
        yield return new WaitForSeconds(0.3f);
        Lino[21].color = goldy;
        lino_activated[21] = 2;
        Line_SFX.Play();
        yield return new WaitForSeconds(0.3f);
        btn_Barrier.GetComponent<Image>().sprite = barrierSkillUnlocked;
        btn_Barrier.GetComponentInChildren<TMP_Text>().enabled = false;
        yield return new WaitForSeconds(0.3f);
        Lino[29].enabled = true;
        lino_activated[29] = 1;
        Lino[30].enabled = true;
        lino_activated[30] = 1;
        Lino[31].enabled = true;
        lino_activated[31] = 1;
        Line_SFX.Play();
        yield return new WaitForSeconds(0.3f);
        btn_BEC.SetActive(true);
        btn_Pressed[20] = 1;
        btn_BEF.SetActive(true);
        btn_Pressed[21] = 1;
        btn_BCDT.SetActive(true);
        btn_Pressed[22] = 1;
        Line_SFX.Play();
        yield return null;

    }
    public void Desc_B_EC()
    {
        desc_txt.text = "Energy Cost Down: Decreases the energy required to use the Barrier skill.";
    }
    public void UpgradB_EC()
    {
        if (currentGold >= 50)
        {
            purchaseManager.GetComponent<Shop_purschaseManager>().BEC_Purchase();
            btn_Pressed[20] = 2;
            showCoinsinGUI(currentGold - 50);
            btn_SFX.Play();
            btn_BEC.GetComponent<Button>().enabled = false;
            StartCoroutine(B_ECAnimation());
        }
        else
        {
            desc_txt.text = "Not Enough Gold.";
        }
    }
    IEnumerator B_ECAnimation()
    {
        Lino[31].color = goldy;
        lino_activated[31] = 2;
        Line_SFX.Play();
        yield return new WaitForSeconds(0.3f);
        btn_BEC.GetComponent<Image>().sprite = energyCostUnlocked;
        btn_BEC.GetComponentInChildren<TMP_Text>().enabled = false;
        yield return null;

    }
    public void Desc_B_EF()
    {
        desc_txt.text = "Effect Time Increase: Increases the effect time of the Barrier skill.";
    }
    public void UpgradB_EF()
    {
        if (currentGold >= 50)
        {
            purchaseManager.GetComponent<Shop_purschaseManager>().BEF_Purchase();
            btn_Pressed[21] = 2;
            showCoinsinGUI(currentGold - 50);
            btn_SFX.Play();
            btn_BEF.GetComponent<Button>().enabled = false;
            StartCoroutine(B_EFAnimation());
        }
        else
        {
            desc_txt.text = "Not Enough Gold.";
        }
    }
    IEnumerator B_EFAnimation()
    {
        Lino[30].color = goldy;
        lino_activated[30] = 2;
        Line_SFX.Play();
        yield return new WaitForSeconds(0.3f);
        btn_BEF.GetComponent<Image>().sprite = effectTimeUnlocked;
        btn_BEF.GetComponentInChildren<TMP_Text>().enabled = false;
        yield return null;

    }
    public void Desc_B_CDT()
    {
        desc_txt.text = "Cool Down Time Decrease: Decreases the cool down time for the Barrier skill.";
    }
    public void UpgradB_CDT()
    {
        if (currentGold >= 50)
        {
            purchaseManager.GetComponent<Shop_purschaseManager>().BCDT_Purchase();
            btn_Pressed[22] = 2;
            showCoinsinGUI(currentGold - 50);
            btn_SFX.Play();
            btn_BCDT.GetComponent<Button>().enabled = false;
            StartCoroutine(B_CDTAnimation());
        }
        else
        {
            desc_txt.text = "Not Enough Gold.";
        }
    }
    IEnumerator B_CDTAnimation()
    {
        Lino[29].color = goldy;
        lino_activated[29] = 2;
        Line_SFX.Play();
        yield return new WaitForSeconds(0.3f);
        btn_BCDT.GetComponent<Image>().sprite = coolDownTimeUnlocked;
        btn_BCDT.GetComponentInChildren<TMP_Text>().enabled = false;
        yield return null;

    }
    #endregion

    public void ExitBtn()
    {
        PlayerPrefs.SetInt("coins", currentGold);
        writeInfo();
        int round = 1;
        if(PlayerPrefs.HasKey("Round"))
         round = PlayerPrefs.GetInt("Round");
        if(round==1)
        {
            SceneManager.LoadScene("Round1");
        }
        else if (round==2)
        {
            SceneManager.LoadScene("Round2");
        }
        else if (round==3)
        {
            SceneManager.LoadScene("Round3");
        }
    }

    public void writeInfo()
    {

        XmlShopPurchases excuter = new XmlShopPurchases();
        excuter.lino_act.Clear();

        for (int i = 0; i < lino_activated.Count; i++)
        {
            
            
            excuter.lino_act.Add(lino_activated[i]);

        }

        excuter.btns_pressd.Clear();

        for (int i = 0; i < btn_Pressed.Count; i++)
        {


            excuter.btns_pressd.Add(btn_Pressed[i]);

        }


        excuter.Save(Path.Combine(Application.dataPath, "ShopPurchases.xml"));


    }
    public void ReadInfo()
    {

        if (File.Exists(Path.Combine(Application.dataPath, "ShopPurchases.xml")))
        {
            var shopInfo = XmlShopPurchases.Load(Path.Combine(Application.dataPath, "ShopPurchases.xml"));

           

            for (int i = 0; i < lino_activated.Count; i++)
            {

                lino_activated[i]=shopInfo.lino_act[i];
                

            }

            

            for (int i = 0; i < btn_Pressed.Count; i++)
            {

                btn_Pressed[i]=shopInfo.btns_pressd[i];
                

            }

        }
    }
}
