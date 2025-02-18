﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileSpawner : MonoBehaviour
{
    DungeonManager dungMan;
    DecisionMaker decider;

    private void Awake()
    {

        dungMan = FindObjectOfType<DungeonManager>();
        decider = FindObjectOfType<DecisionMaker>();
        GameObject goFloor = Instantiate(dungMan.floorPrefab, transform.position, Quaternion.identity) as GameObject;
        goFloor.name = dungMan.floorPrefab.name;
        goFloor.transform.SetParent(dungMan.transform);
        decider.Tiles.Add(goFloor);

        if (transform.position.x > dungMan.maxX)
        {
            dungMan.maxX = transform.position.x;
        }
        if (transform.position.x < dungMan.minX)
        {
            dungMan.minX = transform.position.x;
        }
        if (transform.position.y > dungMan.maxY)
        {
            dungMan.maxY = transform.position.y;
        }
        if (transform.position.y < dungMan.minY)
        {
            dungMan.minY = transform.position.y;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        LayerMask envMask = LayerMask.GetMask("Wall", "Floor");
        Vector2 hitSize = Vector2.one * 0.8f;

        for(int x=-1;x<=1;x++)
        {
            for(int y=-1;y<=1;y++)
            {
                Vector2 targetPos = new Vector2(transform.position.x + x, transform.position.y + y);
                Collider2D hit = Physics2D.OverlapBox(targetPos, hitSize, 0, envMask);
                if (!hit)
                {
                    //add a wall



                    GameObject goWall = Instantiate(dungMan.wallPrefab, targetPos, Quaternion.identity) as GameObject;
                    goWall.name = dungMan.wallPrefab.name;
                    goWall.transform.SetParent(dungMan.transform);


            }   }
        }

        Destroy(gameObject);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawCube(transform.position, Vector3.one);
    }
}
