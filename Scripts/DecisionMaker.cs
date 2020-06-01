using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;
using System.Xml.Serialization;

public class DecisionMaker : MonoBehaviour
{
   


    public List<GameObject> Tiles = new List<GameObject>();
    // Use this for initialization
    void Start()
    {
        
       // ReadInfo();
        //StartCoroutine(readplease());
        
       // spawningDecision();
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown("p"))
        //{
        //    //writeInfo();
        //    spawningDecision();
        //}
    }

    //______________________________________________________________________________________________



    public void writeInfo()
    {
        /*
                string path = "Assets/Resources/test.txt";
                File.WriteAllText(path, "");
                //Write some text to the test.txt file
                StreamWriter writer = new StreamWriter(path, true);
                // writer.WriteLine("sTest");

                for (int i = 0; i < Tiles.Count; i++)
                {
                    int no = Tiles[i].GetComponent<VisitCounter>().NoOfTimesEntered;
                    writer.WriteLine(no);
                }
                writer.Close();

                //Re-import the file to update the reference in the editor
                AssetDatabase.ImportAsset(path);
                TextAsset asset = (TextAsset)Resources.Load("test");

                //Print the text from the file
                Debug.Log(asset.text);
                */
        xmlslayer excuter = new xmlslayer();
        excuter.tile.Clear();
        
        for (int i = 0; i < Tiles.Count; i++)
        {
            til Tile = new til();
            Tile.timeEntered = Tiles[i].GetComponent<VisitCounter>().NoOfTimesEntered;
            Tile.threat = Tiles[i].GetComponent<VisitCounter>().threat;
            excuter.tile.Add(Tile);
            
        }
        excuter.Save(Path.Combine(Application.dataPath, "Tiles.xml"));
        

    }



        


    //public void writeThreat()
    //{

    //    string path = "Assets/Resources/threat.txt";
    //    File.WriteAllText(path, "");
    //    //Write some text to the test.txt file
    //    StreamWriter writer = new StreamWriter(path, true);
    //    // writer.WriteLine("sTest");

    //    for (int i = 0; i < Tiles.Count; i++)
    //    {
    //        int no = Tiles[i].GetComponent<VisitCounter>().threat;
    //        writer.WriteLine(no);
    //    }
    //    writer.Close();

    //    //Re-import the file to update the reference in the editor
    //    AssetDatabase.ImportAsset(path);
    //    TextAsset asset = (TextAsset)Resources.Load("test");

    //    //Print the text from the file
    //    //Debug.Log(asset.text);
    //}

    //[MenuItem("Tools/Read file")]
   

    //_______________________________________________________________________________________
  


    public void ReadInfo()
    {
        /*
        string path = "Assets/Resources/test.txt";

        
            StreamReader reader = new StreamReader(path,true);
            string contents = reader.ReadToEnd();
        Debug.Log("unsplitted List"+contents);
            string[] lst = contents.Split('\n');
        Debug.Log("Splitted List"+lst.Length);
            List<int> infoArr = new List<int>();
            for (int i = 0; i < lst.Length; i++)
            {
            int f;
            if (int.TryParse(lst[i],out f ))
            {
                Debug.Log(lst[i]);
                int CC = int.Parse(lst[i]);
                infoArr.Add(CC);
            }
            }
            for (int i = 0; i < Tiles.Count; i++)
            {
                Tiles[i].GetComponent<VisitCounter>().NoOfTimesEntered = infoArr[i];
            }
       

        */
        if (File.Exists(Path.Combine(Application.dataPath, "Tiles.xml")))
        {
            var TileCollection = xmlslayer.Load(Path.Combine(Application.dataPath, "Tiles.xml"));
            for (int i = 0; i < Tiles.Count; i++)
            {
                Tiles[i].GetComponent<VisitCounter>().NoOfTimesEntered = TileCollection.tile[i].timeEntered;
                Tiles[i].GetComponent<VisitCounter>().threat = TileCollection.tile[i].threat;
            }
        }
    }

    //public void ReadThreat()
    //{
    //    string path = "Assets/Resources/threat.txt";
        

    //    StreamReader reader = new StreamReader(path, true);
        
    //    string contents = reader.ReadToEnd();
    //    Debug.Log("unsplitted List" + contents);
    //    string[] lst = contents.Split('\n');
    //    Debug.Log("Splitted List" + lst.Length);
    //    List<int> infoArr = new List<int>();
    //    for (int i = 0; i < lst.Length; i++)
    //    {
    //        int f;
    //        if (int.TryParse(lst[i], out f))
    //        {
    //            Debug.Log(lst[i]);
    //            int CC = int.Parse(lst[i]);
    //            infoArr.Add(CC);
    //        }
    //    }
    //    for (int i = 0; i < Tiles.Count; i++)
    //    {
    //        Tiles[i].GetComponent<VisitCounter>().threat = infoArr[i];
    //    }



    //}




    public List<int> infoArr = new List<int>();
    // public void spawningDecision(List<GameObject> PathData)




    public void spawningDecision()
    {
        for(int i=0;i<50;i++)
        {
            Tiles[i].GetComponent<VisitCounter>().unSpawnableTile = true;
        }
        Tiles[Tiles.Count-1].GetComponent<VisitCounter>().unSpawnableTile = true;
        infoArr.Clear();
        for (int i = 0; i < Tiles.Count; i++)
        {
            int no = Tiles[i].GetComponent<VisitCounter>().NoOfTimesEntered;
            infoArr.Add(no);
        }
        int average = AvgFinder(infoArr);
        int mode = ModeFinder(infoArr);
        Debug.Log("Average=" + average);
        Debug.Log("mode =" + mode);


        bool simplePath = true;

        if (Mathf.Abs(mode - average) <= 2)
        {
            simplePath = true;
        }
        else
        {

            simplePath = false;
        }
        if (simplePath)
        {
            Debug.Log("simple");
            int st = 1;
            for (int i = 0; i < Tiles.Count; i++)
            {
                if (infoArr[i] != 0)
                {

                    if (infoArr[i] > average)
                    {
                        int diff = (infoArr[i] - average);
                        float dd = diff / 10;
                        float chance = Random.Range(dd, 1.0f) * st;
                        Debug.Log("infoArr=" + infoArr[i] + "chance=" + chance + "vs 0.50 with st =" + st);
                        if (chance >= 1.0f)
                        {
                            int T = ++Tiles[i].GetComponent<VisitCounter>().threat;
                            Tiles[i].GetComponent<VisitCounter>().SpawnObstacles(T);
                            st = 1;
                        }
                        else
                        {
                            st = st + 2;

                        }
                    }
                    else if (infoArr[i] <= average)
                    {

                        float chance = Random.Range(0, 0.50f) * st;
                        Debug.Log("infoArr=" + infoArr[i] + "chance=" + chance + "vs 0.1 with st =" + st);
                        if (chance >= 1.5f)
                        {

                            int T = ++Tiles[i].GetComponent<VisitCounter>().threat;
                            Tiles[i].GetComponent<VisitCounter>().SpawnObstacles(T);
                            st = 1;
                        }
                        else
                        {
                            st++;
                        }

                    }
                }
            }

        }
        else if (!simplePath)
        {
            int st = 1;
            bool averageOriented = true;
            if (mode > average)
            {
                averageOriented = false;

            }

            if (averageOriented)
            {
                Debug.Log("average oriented");
                for (int i = 0; i < Tiles.Count; i++)
                {
                    if (infoArr[i] != 0)
                    {
                        if (infoArr[i] > average + (average - mode))
                        {
                            int diff = (infoArr[i] - average);
                            float dd = diff / 10;
                            float chance = Random.Range(dd, 1) * st;
                            Debug.Log("chance=" + chance + "vs 0.50 with st =" + st);
                            if (chance >= 1.0f)
                            {
                                Tiles[i].GetComponent<VisitCounter>().threat++;
                                int T = ++Tiles[i].GetComponent<VisitCounter>().threat;
                                Tiles[i].GetComponent<VisitCounter>().SpawnObstacles(T);
                                st = 1;
                            }
                            else
                            {
                                int T = ++Tiles[i].GetComponent<VisitCounter>().threat;
                                Tiles[i].GetComponent<VisitCounter>().SpawnObstacles(T);
                                st = 1;

                            }
                        }
                        else if (infoArr[i] >= average)
                        {
                            int diff = (infoArr[i] - average);
                            float dd = diff / 10;
                            float chance = Random.Range(dd, 1) * st;
                            Debug.Log("chance=" + chance + "vs 0.50 with st =" + st);
                            if (chance >= 1.0f)
                            {

                                int T = ++Tiles[i].GetComponent<VisitCounter>().threat;
                                Tiles[i].GetComponent<VisitCounter>().SpawnObstacles(T);
                                st = 1;
                            }
                            else
                            {

                                st = st + 2;

                            }
                        }
                        else if (infoArr[i] < average)
                        {

                            float chance = Random.Range(0, 1) * st;
                            Debug.Log("chance=" + chance + "vs 0.1 with st =" + st);
                            if (chance >= 1.5f)
                            {

                                int T = ++Tiles[i].GetComponent<VisitCounter>().threat;
                                Tiles[i].GetComponent<VisitCounter>().SpawnObstacles(T);
                                st = 1;
                            }
                            else
                            {

                                st++;

                            }
                        }
                    }
                }
            }
            else
            {
                Debug.Log("mode oriented");
                for (int i = 0; i < Tiles.Count; i++)
                {
                    if (infoArr[i] != 0)
                    {
                        if (infoArr[i] > mode)
                        {
                            int diff = infoArr[i] - mode;
                            float dd = diff / 10;
                            float chance = Random.Range(dd, 1) * st;
                            Debug.Log("chance=" + chance + "vs 0.50 with st =" + st);
                            if (chance >= 1f)
                            {
                                //Tiles[i].GetComponent<spawners>().threat++;
                                int T = ++Tiles[i].GetComponent<VisitCounter>().threat;
                                Tiles[i].GetComponent<VisitCounter>().SpawnObstacles(T);
                                st = 1;
                            }
                            else
                            {

                                st = st + 2;

                            }
                        }
                        else if (infoArr[i] <= mode)
                        {

                            float chance = Random.Range(0, 1) * st;
                            Debug.Log("chance=" + chance + "vs 0.1 with st =" + st);
                            if (chance >= 1.5f)
                            {

                                int T = ++Tiles[i].GetComponent<VisitCounter>().threat;
                                Tiles[i].GetComponent<VisitCounter>().SpawnObstacles(T);
                                st = 1;
                            }
                            else
                            {

                                st++;

                            }
                        }

                    }
                }
            }

        }
        //#
        //for (int i = 0; i < Tiles.Count; i++)
        //{
        //    if (infoArr[i] != 0)
        //    {

        //        if (infoArr[i] >= average - 3 || infoArr[i] <= average + 3)
        //        {
        //            float s = Random.Range(0.0f, 0.75f);
        //            if (st * s > 0.80f)
        //            {
        //                Tiles[i].GetComponent<spawners>().SpawnObstacles(1);
        //                st = 0;



        //            }
        //            else
        //            {
        //                st = st + 1;
        //            }
        //        }
        //        else
        //        {
        //            st = st + 0.5f;
        //        }SS
        //    }
        //}
        //#
    }

    public int AvgFinder(List<int> info)
    {
        int add = 0;
        for (int i = 0; i < info.Count; i++)
        {
            add = info[i] + add;



        }
        add = Mathf.CeilToInt(add / info.Count);

        return add;
    }

    public int ModeFinder(List<int> info)
    {
        //'fr' is the list containg the unique number and number of times it has repeated through out the list
        //the reason it has a list in alist is becuase the list contains the unique number and the amount it has been repeated
        //this has been put into a list so that it doesnt get mixed with another data inside the list
        // hence 'fr' is a list of list of integers :)
        List<List<int>> fr = new List<List<int>>();
        int mode = 0;



        // 'dd' is a temp list we use to make a list of the unique number before putting in 'fr', since 'fr' is a list of list , we need to 
        // put a list inside 'fr' instead of a normal number hence we first make a list then we insert the list into 'fr'


        for (int i = 0; i < info.Count; i++)
        {
            int f = info[i];
            bool found = false;
            if (fr.Count != 0)
            {
                foreach (List<int> sublist in fr)
                {
                    if (sublist[0] == f)
                    {
                        sublist[1]++;
                        found = true;
                        Debug.Log("Incrementing = " + sublist[0] + " = " + sublist[1]);
                        break;
                    }
                }
            }

            if (!found)
            {
                fr.Add(new List<int> { f, 1 });
                Debug.Log("ADDing new Uniqe number = " + f + " = " + 1);
            }

        }
        // now we make a list called max where the list which has the most repeated value is inserted. 
        List<int> max = new List<int>();
        max = fr[0];

        for (int i = 1; i < fr.Count; i++)
        {
            var sublist = fr[i];
            if (sublist[1] > max[1])
            {
                max = fr[i];
            }
        }

        mode = max[0];
        Debug.Log("MODE = " + max[0] + " = " + max[1]);


        return mode;
    }


}
