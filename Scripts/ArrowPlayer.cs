using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowPlayer : MonoBehaviour
{
    public bool isStuck = false;
    public AudioClip StuckOnWood;
    public AudioClip PickedUP;
    public AudioClip StuckOnWall;

    public GameObject player;
   

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //private void OnTriggerStay2D(Collider2D collision)
    //{
    //    if (collision.tag == "Player")
    //    {
    //        if (isStuck)
    //        {
    //            collision.GetComponent<Shooter_projctile>().PickUpArrows();
    //            gameObject.GetComponent<AudioSource>().clip = PickedUP;
    //            gameObject.GetComponent<AudioSource>().Play();
    //            Destroy(gameObject, 0.2f);
    //        }
    //    }
    //}


    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Hit Wall");
        if (collision.tag == "wall")
        {

            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0.0f,0.0f);
            isStuck = true;
            gameObject.GetComponent<AudioSource>().clip = StuckOnWall;
            gameObject.GetComponent<AudioSource>().Play();
        }
        if (collision.tag == "totem")
        {

            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0.0f, 0.0f);
            collision.GetComponent<TotemObs>().totemHealth--;
            isStuck = true;
            gameObject.GetComponent<AudioSource>().clip = StuckOnWood;
            gameObject.GetComponent<AudioSource>().Play();
        }
        if (collision.tag=="Player")
        {
            if (isStuck)
            {
                collision.GetComponent<Shooter_projctile>().PickUpArrows();
                gameObject.GetComponent<AudioSource>().clip = PickedUP;
                gameObject.GetComponent<AudioSource>().Play();
                Destroy(gameObject,0.2f);
            }
        }
        if (collision.tag == "skely")
        {
            if (!isStuck)
            {
                gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0.0f, 0.0f);
                collision.GetComponent<Enemy>().enemyHealth--;
                collision.GetComponent<Animator>().ResetTrigger("Damaged");
                collision.GetComponent<Animator>().SetTrigger("Damaged");
                isStuck = true;
                gameObject.GetComponent<AudioSource>().clip = StuckOnWood;
                gameObject.GetComponent<AudioSource>().Play();
            }
        }
        if (collision.tag == "bug")
        {
            if (!isStuck)
            {
                gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0.0f, 0.0f);
                collision.GetComponent<Enemy>().enemyHealth--;
                isStuck = true;
                gameObject.GetComponent<AudioSource>().clip = StuckOnWood;
                gameObject.GetComponent<AudioSource>().Play();
            }
        }
        if (collision.tag == "pot")
        {
            if (!isStuck)
            {
                gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0.0f, 0.0f);
                collision.GetComponent<potObs>().health--;
                isStuck = true;
               // gameObject.GetComponent<AudioSource>().clip = StuckOnWood;
              //  gameObject.GetComponent<AudioSource>().Play();
            }
        }


        if (collision.tag == "barrier")
        {
            
                if (!isStuck)
                {
                    gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0.0f, 0.0f);
                    isStuck = true;
                    gameObject.GetComponent<AudioSource>().clip = StuckOnWall;
                    gameObject.GetComponent<AudioSource>().Play();
                }
            
        }


        //else if (collision.tag == "trapdoor")
        //{
        //    Destroy(gameObject);
        //}
    }
}
