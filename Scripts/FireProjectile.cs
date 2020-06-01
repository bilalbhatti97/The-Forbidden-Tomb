using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireProjectile : MonoBehaviour
{
    public GameObject Player;
    public int Damage;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            Player.GetComponent<Health>().healthdamag(Damage);
                Player.GetComponent<Health>().GetDamagedSoundPlay();
            //Destroy(gameObject);
            StartCoroutine(Hit());

        
        }
        if (collision.tag == "wall")
        {
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            StartCoroutine(Hit());
            //Destroy(gameObject);



        }

        if(collision.tag=="shield")
        {
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            StartCoroutine(Hit());
            //Destroy(gameObject);
        }

    }

    IEnumerator Hit()
    {
       
        gameObject.GetComponent<Animator>().SetTrigger("hit");
        yield return new WaitForSeconds(0.4f);
        Destroy(gameObject);
        yield return null;
    }
}
