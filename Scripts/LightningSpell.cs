using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class LightningSpell : MonoBehaviour
{
    public int damage;
    // will it damage or not
    public bool willDamage;
    // will it spread or not
    public bool willSpread;
    // amount of lightnings it will cast per Burst
    public int lightningsPerBurst;
    // amount of bursts
    public int burstAmount;
    // when hit 
    bool hit;

    bool lightningPlus;
    public float shockingTime;

    public GameObject lightningPrefab;

    //upgrade
    //public bool doubleSpread;
    //public bool extraAmount;
    //public bool energyCost;
    private void Start()
    {
        if (PlayerPrefs.HasKey("lightningSpell_plus"))
        {
            if (PlayerPrefs.GetInt("lightningSpell_plus") == 1)
            {
                lightningPlus = true;
                burstAmount = 20;
            }
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "wall" && !hit)
        {

            Destroy(gameObject);


        }

        if (collision.tag == "totem" && !hit)
        {
            hit = true;
            if(willDamage)
            {
                collision.GetComponent<TotemObs>().totemHealth-=damage;
                Destroy(gameObject);
            }
            else
            {
                gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
                gameObject.transform.position = collision.transform.position;
                StartCoroutine(Shocker(collision.gameObject));
            }
          


        }

        if (collision.tag == "skely" && !hit)
        {

            hit = true;
            if (willDamage)
            {
                collision.GetComponent<Enemy>().enemyHealth -= damage;
                Destroy(gameObject);
            }
            else
            {
                gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
                gameObject.transform.position = collision.transform.position;
                StartCoroutine(Shocker(collision.gameObject));
            }

        }
        if (collision.tag == "bug" && !hit)
        {
            hit = true;
            if (willDamage)
            {
                collision.GetComponent<Enemy>().enemyHealth -= damage;
                Destroy(gameObject);
            }
            else
            {
                gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
                gameObject.transform.position = collision.transform.position;
                StartCoroutine(Shocker(collision.gameObject));
            }



        }

        if (collision.tag == "pot" && !hit)
        {

            //  gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0.0f, 0.0f);
            collision.GetComponent<potObs>().health -= damage;
            Destroy(gameObject);

        }



    }

     IEnumerator Shocker(GameObject target)
    {
        
        gameObject.GetComponent<Animator>().SetTrigger("shocked");
        yield return null;
        gameObject.transform.SetParent(target.transform);
        yield return new WaitForSeconds(0.5f);
        for(int i=0;i<burstAmount;i++)
        {
            shootLightning();
            if(lightningPlus)
            {
                shootLightning();
            }
            yield return new WaitForSeconds(1.0f);
        }
        yield return null;
        Destroy(gameObject);
        yield return null;
    }


    public void shootLightning()
    {
        float originOffset = 0.8f;
        int speed = 5;
        float[] angle =    { 0     , 45   , 90    , 135   , 180   , -45  , -90  , -135   };
        int[] directionX = { 0    , -speed, -speed, -speed, 0     , speed, speed,  speed };
        int[] directionY = { speed, speed , 0     , -speed, -speed, speed, 0    , -speed };
        float[] originX = { 0            , -originOffset, -originOffset, -originOffset, 0            , originOffset, originOffset, originOffset };
        float[] originY = { +originOffset, +originOffset, 0            , -originOffset, -originOffset, originOffset, 0           , -originOffset };
        int index = Random.Range(0, 8);

        GameObject smallLightning = Instantiate(lightningPrefab, new Vector3(transform.position.x + originX[index], transform.position.y + originY[index], 0), Quaternion.identity);
        smallLightning.transform.DORotate(new Vector3(0, 0, angle[index]), 0);
        smallLightning.GetComponent<LightningSpell>().willDamage = true;
        smallLightning.GetComponent<Rigidbody2D>().velocity = new Vector2(directionX[index], directionY[index]);

    }



}

    


