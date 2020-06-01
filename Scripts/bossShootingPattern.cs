using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class bossShootingPattern : MonoBehaviour
{

    public GameObject missile;
    public float speed=1;

    private void Start()
    {
        StartCoroutine(Shoot());
    }

    private void Update()
    {
        
        
    }

    IEnumerator Shoot()
    {
        for(int i=0; i<100;i++)
        {
            Scatter();
            yield return new WaitForSeconds(0.2f);
        }

        yield return null;
       
    }




    public void Scatter()
    {
        GameObject smallFire1 = Instantiate(missile, transform.position, Quaternion.identity);
        smallFire1.transform.DORotate(new Vector3(0, 0, 0), 0);
        smallFire1.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 5)*speed;

        GameObject smallFire2 = Instantiate(missile, transform.position, Quaternion.identity);
        smallFire2.transform.DORotate(new Vector3(0, 0, 45), 0);
        smallFire2.GetComponent<Rigidbody2D>().velocity = new Vector2(-5, 5) * speed;

        GameObject smallFire3 = Instantiate(missile, transform.position, Quaternion.identity);
        smallFire3.transform.DORotate(new Vector3(0, 0, 90), 0);
        smallFire3.GetComponent<Rigidbody2D>().velocity = new Vector2(-5, 0) * speed;

        GameObject smallFire4 = Instantiate(missile, transform.position, Quaternion.identity);
        smallFire4.transform.DORotate(new Vector3(0, 0, 135), 0);
        smallFire4.GetComponent<Rigidbody2D>().velocity = new Vector2(-5, -5) * speed;

        GameObject smallFire5 = Instantiate(missile, transform.position, Quaternion.identity);
        smallFire5.transform.DORotate(new Vector3(0, 0, 180), 0);
        smallFire5.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -5) * speed;

        GameObject smallFire6 = Instantiate(missile, transform.position, Quaternion.identity);
        smallFire6.transform.DORotate(new Vector3(0, 0, -45), 0);
        smallFire6.GetComponent<Rigidbody2D>().velocity = new Vector2(5, -5) * speed;

        GameObject smallFire7 = Instantiate(missile, transform.position, Quaternion.identity);
        smallFire7.transform.DORotate(new Vector3(0, 0, -90), 0);
        smallFire7.GetComponent<Rigidbody2D>().velocity = new Vector2(5, 0) * speed;

        GameObject smallFire8 = Instantiate(missile, transform.position, Quaternion.identity);
        smallFire8.transform.DORotate(new Vector3(0, 0, -135), 0);
        smallFire8.GetComponent<Rigidbody2D>().velocity = new Vector2(5, 5) * speed;
    }



}
