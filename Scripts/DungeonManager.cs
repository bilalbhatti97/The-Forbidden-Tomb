
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonManager : MonoBehaviour
{
    public GameObject floorPrefab, wallPrefab, tilePrefab, ExitPrefab,treasurePrefab,KeyPrefab, potPrefab;
    public int totalFloorCount;
    public Random.State LS;
    public int seed;
   

    public float minX, maxX, minY, maxY;

    List<Vector3> floorList = new List<Vector3>();

    
    // Start is called before the first frame update
    void Start()
    {
        RandomWalker();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void RandomWalker()
    {
        if(PlayerPrefs.HasKey("LevelSeed"))
        {
            int levelseed = PlayerPrefs.GetInt("LevelSeed");
            Debug.Log("Seed=" + levelseed);
            Random.InitState(levelseed);
        }
        else
        {
            int seed = System.Environment.TickCount;
            Debug.Log("Seed="+seed);
            Random.InitState(seed);
            PlayerPrefs.SetInt("LevelSeed", seed);
        }
        Vector3 curPos = Vector3.zero;
        floorList.Add(curPos);

        //LS = Random.state;
        //seed = Random.seed;
        //Random.InitState(LevelSeed);

        Debug.Log(seed);
        
        while(floorList.Count < totalFloorCount)
        {
            switch(Random.Range(1,5))
            {
                case 1:
                    curPos += Vector3.up;
                    break;
                case 2:
                    curPos += Vector3.right;
                    break;
                case 3:
                    curPos += Vector3.down;
                    break;
                case 4:
                    curPos += Vector3.left;
                    break;
            }

            bool inFloorList = false;
            for(int i=0;i< floorList.Count; i++)
            {
                if(Vector3.Equals(curPos,floorList[i]))
                {
                    inFloorList = true;
                    break;
                }
            }

            if(!inFloorList)
            {
                floorList.Add(curPos);
            }
        }

        for (int  i =0;i<floorList.Count; i++)
        {
            GameObject goTile = Instantiate(tilePrefab, floorList[i], Quaternion.identity) as GameObject;
            goTile.name = tilePrefab.name;
            goTile.transform.SetParent(transform);
        }

        StartCoroutine(DelayProgress());

    }

    IEnumerator DelayProgress()
    {
        while(FindObjectsOfType<TileSpawner>().Length >0)
        {
            yield return null;
        }
        ExitDoorway();
        TreasureAndKey();
        PotPlacer();
        try
        {
            gameObject.GetComponent<DecisionMaker>().ReadInfo();
        }
        catch(System.Exception ex)
        {

        }
        yield return null;
        
        
        gameObject.GetComponent<DecisionMaker>().spawningDecision();
    }

    void ExitDoorway()
    {
        Vector3 doorPos = floorList[floorList.Count - 1];
        GameObject goDoor = Instantiate(ExitPrefab, doorPos, Quaternion.identity);
        goDoor.name = ExitPrefab.name;
        goDoor.transform.SetParent(transform);
    }

    void TreasureAndKey()
    {
        int Randomizer = Random.Range(1, 51);

        int tindex = floorList.Count / 2 - 1 + Randomizer;
        Vector3 TreasurePos = floorList[tindex];

        int keyRandomizer = Random.Range(-75,50);
        Vector3 KeyPos = floorList[tindex+keyRandomizer];

        GameObject goTreasure = Instantiate(treasurePrefab, TreasurePos, Quaternion.identity);
        goTreasure.name = treasurePrefab.name;
        goTreasure.transform.SetParent(transform);

        GameObject gokey = Instantiate(KeyPrefab, KeyPos, Quaternion.identity);
        gokey.name = KeyPrefab.name;
        gokey.transform.SetParent(transform);

    }

    void PotPlacer()
    {
        for(int i=20;i<floorList.Count;i++)
        {
            int possible = Random.Range(0, 9);
            if(possible>7)
            {
                Instantiate(potPrefab, floorList[i], Quaternion.identity);
            }
        }
    }

   


}
