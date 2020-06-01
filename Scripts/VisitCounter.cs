using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisitCounter : MonoBehaviour
{
    // counts how many times the person has entered the tile
    public int NoOfTimesEntered = 0;
    // the obstaacle prefab
    public GameObject ObstaclePrefab,t1Prefab,t2Prefab,t3Prefab,t4Prefab,t5Prefab;
    public bool unSpawnableTile = false;

    // dont know hwats this for:
    bool sp = false;
    // saves current threat level of the tile.
    public int threat = 0;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!Input.GetKey("n"))
        {
            Debug.Log("Hit");
            NoOfTimesEntered++;
        }

    }

    public void SpawnObstacles(int threat)
    {
        if (!unSpawnableTile)
        {

            switch (threat)
            {
                case 1:
                    {
                        sp = true;
                        Instantiate(t1Prefab, gameObject.transform.position, Quaternion.identity);
                        break;
                    }
                case 2:
                    {
                        sp = true;
                        Instantiate(t2Prefab, gameObject.transform.position, Quaternion.identity);
                        break;
                    }
                case 3:
                    {
                        sp = true;
                        Instantiate(t3Prefab, gameObject.transform.position, Quaternion.identity);
                        break;
                    }
                case 4:
                    {
                        sp = true;
                        Instantiate(t4Prefab, gameObject.transform.position, Quaternion.identity);
                        break;
                    }
                case 5:
                    {
                        sp = true;
                        Instantiate(t5Prefab, gameObject.transform.position, Quaternion.identity);
                        break;
                    }
            }
        }
    }
}



