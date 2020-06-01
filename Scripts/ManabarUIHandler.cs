using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManabarUIHandler : MonoBehaviour
{
    public Image img_manaBar;
    public float totalMana;
    public float currentMana;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
     if(Input.GetKeyDown(KeyCode.R))
        {
            RefillBar();
        }
    }
    public void UseMana(float amount)
    {
        currentMana -= amount;
        gameObject.GetComponent<Animator>().SetFloat("currentMana", currentMana);
        img_manaBar.fillAmount = currentMana / totalMana;

    }

    public void RefillBar()
    {
        currentMana = totalMana;
        gameObject.GetComponent<Animator>().SetFloat("currentMana", currentMana);
        img_manaBar.fillAmount = 1f;
    }


}
