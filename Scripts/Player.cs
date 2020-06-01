using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Player : MonoBehaviour
{
    VolumeManager vM;
    public float speed;
    LayerMask obstacleMask;
    Vector2 targetPos;
    Transform GFX;
    float flipX;
    bool isMoving;
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        obstacleMask = LayerMask.GetMask("Wall");
        GFX = GetComponentInChildren<SpriteRenderer>().transform;
        flipX = GFX.localScale.x;
       // vM.setSettingsFromPrefab();

    }

    // Update is called once per frame
    void Update()
    {
        

        Move();
    }

    void Move()
    {
        if(gameObject.GetComponent<Health>().health>0)
        { 
        animator.SetBool("isMoving", isMoving);
        float horz = System.Math.Sign(Input.GetAxisRaw("Horizontal"));
        float vert = System.Math.Sign(Input.GetAxisRaw("Vertical"));

        if(Mathf.Abs(horz) >0 || Mathf.Abs(vert)>0)
        {
            if(Mathf.Abs(horz)>0)
            {
                GFX.localScale = new Vector2(flipX * horz, GFX.localScale.y);
            }
                if (!isMoving)
                {
                    if (Mathf.Abs(horz) > 0)
                    {
                        targetPos = new Vector2(transform.position.x + horz, transform.position.y);

                    }
                    else if (Mathf.Abs(vert) > 0)
                    {
                        targetPos = new Vector2(transform.position.x, transform.position.y + vert);
                    }

                    Vector2 hitSize = Vector2.one * 0.8f;
                    Collider2D hit = Physics2D.OverlapBox(targetPos, hitSize, 0, obstacleMask);

                    if (!hit)
                    {
                        animator.SetBool("isMoving", isMoving);
                        // transform.DOMove(targetPos, 1);
                        StartCoroutine(SmoothMove());

                    }

                    // animator.SetTrigger("smoothMoving");
                }
            }
        }
    }
    IEnumerator SmoothMove()
    {
        isMoving = true;
        

        while (Vector2.Distance(transform.position, targetPos) > 0.01f)
        {
            transform.position = Vector2.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
            yield return null;
        }
        transform.position = targetPos;
        isMoving = false;
        
    }
}
