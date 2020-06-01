using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class Shooter_projctile : MonoBehaviour
{

    public GameObject arrowPrefab;
    public Image[] UiArrow;
    public int amountOfArrows;
    public int MAX_ARROWS;
    public Animator anim;
    
    // Start is called before the first frame update
    void Start()
    {
        if(PlayerPrefs.HasKey("maxArrows"))
        {
            MAX_ARROWS = PlayerPrefs.GetInt("maxArrows");
        }
        if (PlayerPrefs.HasKey("Arrows"))
        {
            amountOfArrows = PlayerPrefs.GetInt("Arrows");

        }
        for (int i=0;i<MAX_ARROWS;i++)
        {
            if(i<amountOfArrows)
            {
                UiArrow[i].enabled = true;
            }
            else
            {
                UiArrow[i].enabled = false;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(!Input.GetKey(KeyCode.LeftShift) && Input.GetKeyDown(KeyCode.L))
        {
            Shoot(4);
        }
        if (!Input.GetKey(KeyCode.LeftShift) && Input.GetKeyDown(KeyCode.I))
        {
            Shoot(1);
        }
        if (!Input.GetKey(KeyCode.LeftShift) && Input.GetKeyDown(KeyCode.J))
        {
            Shoot(2);
        }
        if (!Input.GetKey(KeyCode.LeftShift) &&  Input.GetKeyDown(KeyCode.K))
        {
            Shoot(3);
        }
    }

    public void PickUpArrows()
    {
        if (amountOfArrows <= MAX_ARROWS)
        {
            UiArrow[amountOfArrows].enabled = true;
            amountOfArrows++;
        }
    }
    //Direction clues 1:Up 2:left 3:down 4:right
    public void Shoot(int direction)
    {
        if (amountOfArrows > 0)
        {
            amountOfArrows--;
            UiArrow[amountOfArrows].enabled = false;
            
            StartCoroutine(shooty(direction));
        }
        //anim.ResetTrigger("isShooting");
        //anim.SetTrigger("isShooting");
        //GameObject arrow =Instantiate(arrowPrefab, transform.position, Quaternion.identity);
        //switch(direction)
        //{
        //    case 1:
        //        {
        //            //up
        //            //arrow.transform.DORotate(new Vector3(0, 0, -90), 0.5f);
        //            arrow.GetComponent<Rigidbody2D>().velocity = new Vector2(0.0f, 5.0f);
        //            break;
        //        }
        //    case 2:
        //        {
        //            arrow.transform.DORotate(new Vector3(0, 0, 90), 0.1f);
        //            arrow.GetComponent<Rigidbody2D>().velocity = new Vector2(-5.0f, 0.0f);
        //            //left
        //            break;
        //        }
        //    case 3:
        //        {
        //            arrow.transform.DORotate(new Vector3(0, 0, 180), 0.1f);
        //            arrow.GetComponent<Rigidbody2D>().velocity = new Vector2(0.0f, -5.0f);
        //            //down
        //            break;
        //        }
        //    case 4:
        //        {
        //            arrow.transform.DORotate(new Vector3(0, 0, -90), 0.1f);
        //            arrow.GetComponent<Rigidbody2D>().velocity = new Vector2(5.0f, 0.0f);
        //            //right
        //            break;
        //        }
        //}
        
    }

    IEnumerator shooty(int direction)
    {
        anim.ResetTrigger("isShooting");
        anim.SetTrigger("isShooting");
        yield return new WaitForSeconds(0.3f);
        GameObject arrow = Instantiate(arrowPrefab, transform.position, Quaternion.identity);
        switch (direction)
        {
            case 1:
                {
                    //up
                    //arrow.transform.DORotate(new Vector3(0, 0, -90), 0.5f);
                    arrow.GetComponent<Rigidbody2D>().velocity = new Vector2(0.0f, 5.0f);
                    //arrow.transform.
                    break;
                }
            case 2:
                {
                    arrow.transform.DORotate(new Vector3(0, 0, 90), 0.1f);
                    arrow.GetComponent<Rigidbody2D>().velocity = new Vector2(-5.0f, 0.0f);
                    //left
                    break;
                }
            case 3:
                {
                    arrow.transform.DORotate(new Vector3(0, 0, 180), 0.1f);
                    arrow.GetComponent<Rigidbody2D>().velocity = new Vector2(0.0f, -5.0f);
                    //down
                    break;
                }
            case 4:
                {
                    arrow.transform.DORotate(new Vector3(0, 0, -90), 0.1f);
                    arrow.GetComponent<Rigidbody2D>().velocity = new Vector2(5.0f, 0.0f);
                    //right
                    break;
                }
        }
        yield return null;
    }


}
