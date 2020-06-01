using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeObs : MonoBehaviour
{
    public GameObject Player;
    public Animator anim;
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
        if(collision.tag=="Player" && !collision.GetComponent<Skill_Manager>().isSoftWalking)
        {
            anim.ResetTrigger("Active");
            anim.SetTrigger("Active");
            gameObject.GetComponent<AudioSource>().Play();
            Player.GetComponent<Health>().healthdamag(Damage);
            Destroy(gameObject, 1);
        }
    }
}
