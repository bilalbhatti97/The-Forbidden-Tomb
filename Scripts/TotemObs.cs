using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TotemObs : MonoBehaviour
{
    public AudioClip sfx_shootingFire;
    public AudioClip sfx_destroyed;
    public GameObject SensorPrefab;
    public GameObject fireballPrefab;
    public bool inRange = false;
    public Transform target;
    bool shot;
    bool damaged;
    bool destroyed;
    public int totemHealth;
    public float timeInBetweenFireShoot = 2.0f;

   
    // Start is called before the first frame update
    void Start()
    {
        GameObject sensor = Instantiate(SensorPrefab, transform.position, Quaternion.identity);
        sensor.transform.SetParent(gameObject.transform);
    }

    // Update is called once per frame
    void Update()
    {
        ShootFire();
        if(!damaged && totemHealth == 1)
        {
            damaged = true;
            gameObject.GetComponent<Animator>().SetTrigger("Damaged");
            
        }
        if(totemHealth<1 && !destroyed)
        {// Destroy(gameObject);
            destroyed = true;
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            StartCoroutine(isDestroyed());
        }
    }

    public void ShootFire()
    {
        if (inRange && totemHealth>0)
        {
            StartCoroutine(shootfire());
        }
    }
    IEnumerator isDestroyed()
    {
        gameObject.GetComponent<AudioSource>().clip = sfx_destroyed;
        gameObject.GetComponent<AudioSource>().Play();
        gameObject.GetComponent<Animator>().SetTrigger("destroyed");
        gameObject.GetComponent<coinBurst>().CoinOnDeath();
        yield return new WaitForSeconds(1.0f);
        Destroy(gameObject);
        yield return null;
    }

    IEnumerator shootfire()
    {
        if (!shot)
        {
            GameObject fire = Instantiate(fireballPrefab, transform.position, Quaternion.identity);
            gameObject.GetComponent<AudioSource>().clip = sfx_shootingFire;
            gameObject.GetComponent<AudioSource>().Play();
            shot = true;
            //float distance = Vector3.Distance(fire.transform.position, target.position);
            //bool tooClose = distance < minRange;
            //Vector3 direction = tooClose ? Vector3.back : Vector3.forward;
            //transform.Translate(direction * Time.deltaTime);

            Vector2 dir = ( target.transform.position - transform.position ).normalized;
            //Debug.DrawLine(pos, pos + dir * 10, Color.red, Mathf.Infinity);

            fire.GetComponent<Rigidbody2D>().velocity = dir*3.0f;
            //fire.transform.DOMove(target.position, 1);
            yield return new WaitForSeconds(timeInBetweenFireShoot);
            shot = false;
            yield return null;
            Destroy(fire, 2.0f);
        }
    }



}
