using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop_purschaseManager : MonoBehaviour
{
    public List<System.Action> method_list = new List<System.Action>();
   // public GameObject player_gameobject;
    // Start is called before the first frame update
    void Start()
    {
        putInList();
    }

    void putInList()
    {
        method_list.Add(Heart_purchase);
        method_list.Add(Arrow_pruchase);
        method_list.Add(FireSpell_Purchase);
        method_list.Add(FirePlus_Purchase);
        method_list.Add(FireEC_Purchase);
        method_list.Add(IceSpell_Purchase);
        method_list.Add(IcePlus_Purchase);
        method_list.Add(IceEC_Purchase);
        method_list.Add(LightningSpell_Purchase);
        method_list.Add(LightningPlus_Purchase);
        method_list.Add(LightningEC_Purchase);
        method_list.Add(SoftWalking_Purchase);
        method_list.Add(SWEC_Purchase);
        method_list.Add(SWEF_Purchase);
        method_list.Add(SWCDT_Purchase);
        method_list.Add(GlowingOrb_Purchase);
        method_list.Add(GOEC_Purchase);
        method_list.Add(GOEF_Purchase);
        method_list.Add(GOCDT_Purchase);
        method_list.Add(Barrier_Purchase);
        method_list.Add(BEC_Purchase);
        method_list.Add(BEF_Purchase);
        method_list.Add(BCDT_Purchase);
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    public void Heart_purchase()
    {
       // player_gameobject.GetComponent<Health>().MAX_HEALTH += 1;
        PlayerPrefs.SetInt("maxHealth", 6);
        PlayerPrefs.SetInt("Health", 6);
    }

    public void Arrow_pruchase()
    {
       // player_gameobject.GetComponent<Shooter_projctile>().MAX_ARROWS += 1;
        PlayerPrefs.SetInt("maxArrows", 6);
        PlayerPrefs.SetInt("Arrows", 6);
    }
    //**********************************
    public void FireSpell_Purchase()
    {
        PlayerPrefs.SetInt("fireSpell_base", 1);

    }

    public void FirePlus_Purchase()
    {
        PlayerPrefs.SetInt("fireSpell_plus", 1);
    }

    public void FireEC_Purchase()
    {
        PlayerPrefs.SetInt("fireSpell_EC", 1);
    }

    //*********************************
    public void IceSpell_Purchase()
    {
        PlayerPrefs.SetInt("iceSpell_base", 1);

    }

    public void IcePlus_Purchase()
    {
        PlayerPrefs.SetInt("iceSpell_plus", 1);
    }

    public void IceEC_Purchase()
    {
        PlayerPrefs.SetInt("iceSpell_EC", 1);
    }
    //************************************

    public void LightningSpell_Purchase()
    {
        PlayerPrefs.SetInt("lightningSpell_base", 1);

    }

    public void LightningPlus_Purchase()
    {
        PlayerPrefs.SetInt("lightningSpell_plus", 1);
    }

    public void LightningEC_Purchase()
    {
        PlayerPrefs.SetInt("lightningSpell_EC", 1);
    }

    //*********************************


    public void SoftWalking_Purchase()
    {
        PlayerPrefs.SetInt("softWalking_base", 1);

    }

    public void SWEC_Purchase()
    {
        PlayerPrefs.SetInt("softWalking_EC", 1);

    }
    public void SWEF_Purchase()
    {
        PlayerPrefs.SetInt("softWalking_EF", 1);

    }
    public void SWCDT_Purchase()
    {
        PlayerPrefs.SetInt("softWalking_CDT", 1);

    }

    //*********************************


    public void GlowingOrb_Purchase()
    {
        PlayerPrefs.SetInt("glowingOrb_base", 1);

    }

    public void GOEC_Purchase()
    {
        PlayerPrefs.SetInt("glowingOrb_EC", 1);

    }
    public void GOEF_Purchase()
    {
        PlayerPrefs.SetInt("glowingOrb_EF", 1);

    }
    public void GOCDT_Purchase()
    {
        PlayerPrefs.SetInt("glowingOrb_CDT", 1);

    }

    //*********************************


    public void Barrier_Purchase()
    {
        PlayerPrefs.SetInt("barrier_base", 1);

    }

    public void BEC_Purchase()
    {
        PlayerPrefs.SetInt("barrier_EC", 1);

    }
    public void BEF_Purchase()
    {
        PlayerPrefs.SetInt("barrier_EF", 1);

    }
    public void BCDT_Purchase()
    {
        PlayerPrefs.SetInt("barrier_CDT", 1);

    }








}
