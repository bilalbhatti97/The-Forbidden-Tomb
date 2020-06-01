using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class smolFire : MonoBehaviour
{
    public int damage;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "wall")
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

            Destroy(gameObject);
        }
    }
    //private void OnTriggerStay2D(Collider2D collision)
    //{
    //    if (collision.tag == "wall")
    //    {
    //        Debug.Log("olaola");
    //        Destroy(gameObject);
    //    }
    //}
}
