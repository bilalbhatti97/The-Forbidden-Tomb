
    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //experimental bool

    [HideInInspector] public bool freezed; 

    public Vector2 dmgRange;
    public float chaseSpeed;
    public float alertRange;
    public Vector2 patrolInterval;
    public float flipX;

    public int enemyHealth;
    public float attackTime;


    Player player;
    GameObject playerStuff;
    LayerMask obstacleMask, walkableMask;
    Vector2 targetPos;
    List<Vector2> availableMovementList = new List<Vector2>();
    List<Node> nodesList = new List<Node>();
    bool isMoving;
    bool isdead = false;
    void Start()
    {
        playerStuff = GameObject.FindGameObjectWithTag("Player");
        player = FindObjectOfType<Player>();
        obstacleMask = LayerMask.GetMask("Wall", "Enemy", "Player");
        walkableMask = LayerMask.GetMask("Wall", "Enemy");
        targetPos = transform.position;
        flipX = gameObject.transform.localScale.x;
        StartCoroutine(Movement());
    }

    private void Update()
    {
        if(enemyHealth<1)
        {
            if (!isdead)
            {
                isdead = true;
                gameObject.GetComponent<BoxCollider2D>().enabled = false;
                StartCoroutine(Ondeath());
            }
        }
    }

    IEnumerator Ondeath()
    {
        
        gameObject.GetComponent<Animator>().ResetTrigger("death");
        gameObject.GetComponent<Animator>().SetTrigger("death");
        gameObject.GetComponent<coinBurst>().CoinOnDeath();
        yield return new WaitForSeconds(1.5f);
        Destroy(gameObject);
        //yield return null;
    }

    void Patrol()
    {
        availableMovementList.Clear();
        Vector2 size = Vector2.one * 0.8f;
        Collider2D hitUp = Physics2D.OverlapBox(targetPos + Vector2.up, size, 0, obstacleMask);
        if (!hitUp) { availableMovementList.Add(Vector2.up); }

        Collider2D hitRight = Physics2D.OverlapBox(targetPos + Vector2.right, size, 0, obstacleMask);
        if (!hitRight) { availableMovementList.Add(Vector2.right); }

        Collider2D hitBottom = Physics2D.OverlapBox(targetPos + Vector2.down, size, 0, obstacleMask);
        if (!hitBottom) { availableMovementList.Add(Vector2.down); }

        Collider2D hitLeft = Physics2D.OverlapBox(targetPos + Vector2.left, size, 0, obstacleMask);
        if (!hitLeft) { availableMovementList.Add(Vector2.left); }

        if (availableMovementList.Count > 0)
        {
            int randomIndex = Random.Range(0, availableMovementList.Count);
            targetPos += availableMovementList[randomIndex];
        }
        StartCoroutine(SmoothMove(Random.Range(patrolInterval.x, patrolInterval.y)));
    }

    void Attack()
    {
        // Add Health, attack
        //int roll = Random.Range(0, 100);
        //if (roll > 50)
        //{
        //    float dmgAmount = Mathf.Ceil(Random.Range(dmgRange.x, dmgRange.y));
        //    Debug.Log(name + " attack and hit for " + dmgAmount + " points of damage");
        //}
        //else
        //{
        //    Debug.Log(name + " attacked and missed");
        //}
        StartCoroutine(attackDelay());
    }

    IEnumerator attackDelay()
    {
        gameObject.GetComponent<AudioSource>().Play();
        gameObject.GetComponent<Animator>().ResetTrigger("attack");
        gameObject.GetComponent<Animator>().SetTrigger("attack");
        playerStuff.GetComponent<Health>().healthdamag(1);
        yield return new WaitForSeconds(1.0f);
        


    }
    void CheckNode(Vector2 chkPoint, Vector2 parent)
    {
        Vector2 size = Vector2.one * 0.5f;
        Collider2D hit = Physics2D.OverlapBox(chkPoint, size, 0, walkableMask);
        if (!hit)
        {
            nodesList.Add(new Node(chkPoint, parent));
        }
    }

    Vector2 FindNextStep(Vector2 startPos, Vector2 targetPos)
    {
        int listIndex = 0;
        Vector2 myPos = startPos;
        nodesList.Clear();
        nodesList.Add(new Node(startPos, startPos));
        while (myPos != targetPos && listIndex < 1000 && nodesList.Count > 0)
        {
            //check up, down, left, right (if walkable, add to the list)

            CheckNode(myPos + Vector2.up, myPos);
            CheckNode(myPos + Vector2.right, myPos);
            CheckNode(myPos + Vector2.down, myPos);
            CheckNode(myPos + Vector2.left, myPos);

            listIndex++;
            if (listIndex < nodesList.Count)
            {
                myPos = nodesList[listIndex].position;
            }
        }

        if (myPos == targetPos)
        {
            nodesList.Reverse(); // crawl backwards through nodes list
            for (int i = 0; i < nodesList.Count; i++)
            {
                if (myPos == nodesList[i].position)
                {
                    if (nodesList[i].parent == startPos)
                    {
                        return myPos;
                    }
                    myPos = nodesList[i].parent;
                }
            }
        }

        return startPos;
    }

    IEnumerator SmoothMove(float speed)
    {
        isMoving = true;

        while (Vector2.Distance(transform.position, targetPos) > 0.01f)
        {
            transform.position = Vector2.MoveTowards(transform.position, targetPos, 5f * Time.deltaTime);
            yield return null;
        }
        transform.position = targetPos;
        yield return new WaitForSeconds(speed);

        isMoving = false;
    }

    IEnumerator Movement()
    {
        while (enemyHealth>0)
        {
            yield return new WaitForSeconds(0.1f);
            if (!freezed)
            {
                if (!isMoving)
                {
                    float dist = Vector2.Distance(transform.position, player.transform.position);
                    if (dist <= alertRange)
                    {
                        if (dist <= 1.1f)
                        {
                            Attack();
                            yield return new WaitForSeconds(attackTime);
                        }
                        else
                        {
                            Vector2 newPos = FindNextStep(transform.position, player.transform.position);
                            if (newPos != targetPos)
                            {
                                //ye code ajeeb sa hai
                                // transform.localScale = new Vector2(flipX *newPos.x-targetPos.x , transform.localScale.y);
                                //chase
                                targetPos = newPos;
                                StartCoroutine(SmoothMove(chaseSpeed));
                            }
                            else
                            {
                                Patrol();
                            }
                        }
                    }
                    else
                    {
                        Patrol();
                    }
                }
            }
        }
    }
}

