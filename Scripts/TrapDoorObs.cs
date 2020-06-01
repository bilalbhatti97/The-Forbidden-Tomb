using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapDoorObs : MonoBehaviour
{
    public Sprite trapPressed;
    public Sprite trapNotPressed;
    public AudioSource audioS;
    public GameObject ArrowPrefab;
    public Camera camera;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Activated Trap");
        if (collision.tag == "Player" && !collision.GetComponent<Skill_Manager>().isSoftWalking)
        {
            
            gameObject.GetComponent<SpriteRenderer>().sprite = trapPressed;
            //play sound
            audioS.Play();
            int Direction = Random.Range(1, 5);
            Vector3 p = new Vector3();
            switch(Direction)
            {
                case 1:
                    {
                        p =new Vector3(transform.position.x-96, 0, 0);
                        break;
                    }
                case 2:
                    {
                        p = new Vector3(transform.position.x + 96, 0, 0);
                        break;
                    }
                case 3:
                    {
                        p = new Vector3(0, transform.position.y - 96, 0);
                        break;
                    }
                case 4:
                    {
                        p = new Vector3(0, transform.position.y + 96, 0);
                        break;
                    }
            }
            GameObject arrow= Instantiate(ArrowPrefab, p, Quaternion.identity);
            arrow.GetComponent<ArrowProjectile>().MoveTowards(transform.position);
            Destroy(arrow, 3.0f);
            //  Vector3 p = camera.ScreenToWorldPoint(new Vector3(0, Screen.height,0));

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("Deactivated Trap");
        if (collision.tag == "Player")
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = trapNotPressed;
            //play sound
            

        }
    }
}
