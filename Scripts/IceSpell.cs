using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceSpell : MonoBehaviour
{
    public int damage;
    bool hit;
    bool icePlus;
    public GameObject icePrefab;

    private void Start()
    {
        if (PlayerPrefs.HasKey("iceSpell_plus"))
        {
            if (PlayerPrefs.GetInt("iceSpell_plus") == 1)
            {
                icePlus = true;
            }
        }
    }
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "wall" && !hit)
        {
            Destroy(gameObject);
           






        }

        if (collision.tag == "totem")
        {


            collision.GetComponent<TotemObs>().totemHealth -= damage;


            Destroy(gameObject);
        }

        if (collision.tag == "skely")
        {
            

            if (icePlus)
            {
                freezeEnemy(collision.transform.gameObject);
            }
            else
            {
                Destroy(gameObject);
            }

        }
        if (collision.tag == "bug")
        {

          
            // collision.GetComponent<Enemy>().enemyHealth -= damage;
            freezeEnemy(collision.transform.gameObject);
           

        }
        if (collision.tag == "pot")
        {

            //  gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0.0f, 0.0f);
            collision.GetComponent<potObs>().health -= damage;


        }
    }

    public void freezeEnemy(GameObject target)
    {

        //if(!icePlus)
        //{
        //    gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        //}
        GameObject iceClone = Instantiate(icePrefab, gameObject.transform.position, Quaternion.identity);
        iceClone.transform.SetParent(target.transform);
        iceClone.GetComponent<Animator>().SetTrigger("freeze");
        target.GetComponent<Enemy>().freezed = true;
        iceClone.GetComponent<BoxCollider2D>().enabled = false;
        if(!icePlus)
        {
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            Destroy(gameObject);
        }
        //Vector2 velo = gameObject.GetComponent<Rigidbody2D>().velocity;
        //gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        //gameObject.GetComponent<Animator>().SetTrigger("freeze");
        //target.GetComponent<Enemy>().freezed = true;
        //gameObject.GetComponent<BoxCollider2D>().enabled = false;
        //gameObject.transform.SetParent(target.transform);

        //if(icePlus)
        //{
        //    GameObject iceClone = Instantiate(icePrefab, gameObject.transform);
        //    iceClone.GetComponent<Rigidbody2D>().velocity = velo;
        //}

    }


}
