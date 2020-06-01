using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class FireSpell : MonoBehaviour
{
    public int damage;
    bool hit;
    public GameObject smallFireBallPrefab;
    bool firePlus;

    private void Start()
    {
        if (PlayerPrefs.HasKey("fireSpell_plus"))
        {
            if(PlayerPrefs.GetInt("fireSpell_plus")==1)
            {
                firePlus = true;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag=="wall" && !hit)
        {
            hit = true;
            if (firePlus)
            {
                StartCoroutine(explode());
            }
            else
            {
                Destroy(gameObject);
            }
            
               


            
        }

        if (collision.tag == "totem")
        {

           
            collision.GetComponent<TotemObs>().totemHealth-=damage;

            Destroy(gameObject);
        }
      
        if (collision.tag == "skely")
        {
          
              
                collision.GetComponent<Enemy>().enemyHealth -= damage;
                collision.GetComponent<Animator>().ResetTrigger("Damaged");
                collision.GetComponent<Animator>().SetTrigger("Damaged");

            Destroy(gameObject);

        }
        if (collision.tag == "bug")
        {
          
                
                collision.GetComponent<Enemy>().enemyHealth -= damage;

            Destroy(gameObject);

        }
        if (collision.tag == "pot")
        {
           
              //  gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0.0f, 0.0f);
                collision.GetComponent<potObs>().health -= damage;

          
        }

    }

    public void Scatter()
    {
        GameObject smallFire1 = Instantiate(smallFireBallPrefab, transform.position, Quaternion.identity);
        smallFire1.transform.DORotate(new Vector3(0,0,0), 0);
        smallFire1.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 5);

        GameObject smallFire2 = Instantiate(smallFireBallPrefab, transform.position, Quaternion.identity);
        smallFire2.transform.DORotate(new Vector3(0, 0, 45), 0);
        smallFire2.GetComponent<Rigidbody2D>().velocity = new Vector2(-5, 5);

        GameObject smallFire3 = Instantiate(smallFireBallPrefab, transform.position, Quaternion.identity);
        smallFire3.transform.DORotate(new Vector3(0, 0, 90), 0);
        smallFire3.GetComponent<Rigidbody2D>().velocity = new Vector2(-5, 0);

        GameObject smallFire4 = Instantiate(smallFireBallPrefab, transform.position, Quaternion.identity);
        smallFire4.transform.DORotate(new Vector3(0, 0, 135), 0);
        smallFire4.GetComponent<Rigidbody2D>().velocity = new Vector2(-5, -5);

        GameObject smallFire5 = Instantiate(smallFireBallPrefab, transform.position, Quaternion.identity);
        smallFire5.transform.DORotate(new Vector3(0, 0, 180), 0);
        smallFire5.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -5);

        GameObject smallFire6 = Instantiate(smallFireBallPrefab, transform.position, Quaternion.identity);
        smallFire6.transform.DORotate(new Vector3(0, 0, -45), 0);
        smallFire6.GetComponent<Rigidbody2D>().velocity = new Vector2(5, -5);

        GameObject smallFire7 = Instantiate(smallFireBallPrefab, transform.position, Quaternion.identity);
        smallFire7.transform.DORotate(new Vector3(0, 0, -90), 0);
        smallFire7.GetComponent<Rigidbody2D>().velocity = new Vector2(5, 0);

        GameObject smallFire8 = Instantiate(smallFireBallPrefab, transform.position, Quaternion.identity);
        smallFire8.transform.DORotate(new Vector3(0, 0, -135), 0);
        smallFire8.GetComponent<Rigidbody2D>().velocity = new Vector2(5, 5);
    }

    IEnumerator explode()
    {
        Scatter();
        yield return null;
        Destroy(gameObject);
        yield return null;
    }
   

  
}