using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class potObs : MonoBehaviour
{
     public int health = 1;
    bool destroyed;
    public GameObject GhostPrefab;
    bool trap;
    
    // Start is called before the first frame update
    void Start()
    {
         if(Random.Range(0,10)>7)
            {
                trap = true;
            }
         else
            {
                trap = false;
            }
    }

    // Update is called once per frame
    void Update()
    {
        if(health<1 && !destroyed)
        {
            destroyed = true;
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            StartCoroutine(onDeath());
        }
    }
    
    public void GhostTrap()
    {
        Instantiate(GhostPrefab, transform.position, Quaternion.identity);
    }

    IEnumerator onDeath()
    {
        gameObject.GetComponent<Animator>().SetTrigger("destroyed");
        gameObject.GetComponent<AudioSource>().Play();
        if(trap)
        {
            GhostTrap();
        }
        else
        {
            gameObject.GetComponent<coinBurst>().CoinOnDeath();
        }
        
        yield return new WaitForSeconds(0.8f);
        Destroy(gameObject);
        yield return null;
    }

}
