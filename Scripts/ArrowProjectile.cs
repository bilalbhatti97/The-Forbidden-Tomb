using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ArrowProjectile : MonoBehaviour
{
    public bool isDull = false;
    public GameObject Player;
    public int Damage;
    public AudioClip hitPlayer;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("ArrowMade");
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MoveTowards(Vector3 pos)
    {
        transform.up = pos - transform.position;
        transform.DOMove(pos, 2);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Hit Player");
        if (collision.tag == "Player")
        {
            if (!isDull)
            {
                Player.GetComponent<Health>().healthdamag(Damage);
                Player.GetComponent<Health>().GetDamagedSoundPlay();
                Destroy(gameObject);
                

            }
            else
            {
                Destroy(gameObject);
            }
        }
        
    }
}
