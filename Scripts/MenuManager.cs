using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    // Start is called before the first frame update
    public void PlayNewGame()
    {
        File.Delete(Path.Combine(Application.dataPath, "Tiles.xml"));
        File.Delete(Path.Combine(Application.dataPath, "ShopPurchases.xml"));
        DeletePlayerPrefs();
        
        Delete_Skill_Playerprefs();
        //SceneManager.getActiveScene().buildIndex + 1   to get next scene in queue
        SceneManager.LoadScene("Cutscene_1");
    }

    public void DeletePlayerPrefs()
    {
        PlayerPrefs.DeleteKey("Round");
        PlayerPrefs.DeleteKey("Health");
        PlayerPrefs.DeleteKey("turns");
        PlayerPrefs.DeleteKey("Arrows");
        PlayerPrefs.DeleteKey("LevelSeed");
        PlayerPrefs.DeleteKey("coins");
        
    }

    public void Delete_Skill_Playerprefs()
    {
        PlayerPrefs.DeleteKey("maxHealth");
        PlayerPrefs.DeleteKey("maxArrows");
        PlayerPrefs.DeleteKey("fireSpell_base");
        PlayerPrefs.DeleteKey("fireSpell_plus");
        PlayerPrefs.DeleteKey("fireSpell_EC");
        PlayerPrefs.DeleteKey("iceSpell_base");
        PlayerPrefs.DeleteKey("iceSpell_plus");
        PlayerPrefs.DeleteKey("iceSpell_EC");
        PlayerPrefs.DeleteKey("lightningSpell_base");
        PlayerPrefs.DeleteKey("lightningSpell_plus");
        PlayerPrefs.DeleteKey("lightningSpell_EC");
        PlayerPrefs.DeleteKey("softWalking_base");
        PlayerPrefs.DeleteKey("softWalking_EC");
        PlayerPrefs.DeleteKey("softWalking_EF");
        PlayerPrefs.DeleteKey("softWalking_CDT");
        PlayerPrefs.DeleteKey("glowingOrb_base");
        PlayerPrefs.DeleteKey("glowingOrb_EC");
        PlayerPrefs.DeleteKey("glowingOrb_EF");
        PlayerPrefs.DeleteKey("glowingOrb_CDT");
        PlayerPrefs.DeleteKey("barrier_base");
        PlayerPrefs.DeleteKey("barrier_EC");
        PlayerPrefs.DeleteKey("barrier_EF");
        PlayerPrefs.DeleteKey("barrier_CDT");
    }

    public void Continue()
    {
        File.Delete(Path.Combine(Application.dataPath, "Tiles.xml"));
        DeletePlayerPrefs();
        Delete_Skill_Playerprefs();
        ReadInfo();
        int round=1;
        if (PlayerPrefs.HasKey("Round"))
        {

            round = PlayerPrefs.GetInt("Round");
        }
        switch (round)
        {
            case 1:
                {
                    SceneManager.LoadScene("Round1");
                    break;
                }
            case 2:
                {
                    SceneManager.LoadScene("Shop");
                    break;
                }
            case 3:
                {
                    SceneManager.LoadScene("Shop");
                    break;
                }
            case 4:
                {
                    SceneManager.LoadScene("EndGame");
                    break;
                }

        }
    }


    public void QuitGame()
    {
        Application.Quit();
    }

    public void GoBackToMainMenu()
    {
        SceneManager.LoadScene("StartMenu");
    }

    public void SaveAndExit()
    {
        int round = 1;
        File.Delete(Path.Combine(Application.dataPath, "Tiles.xml"));
        if (PlayerPrefs.HasKey("Round"))
        {

            round = PlayerPrefs.GetInt("Round");
        }
        int coins = PlayerPrefs.GetInt("coins", 0);

        PlayerPrefs.DeleteAll();
        round++;
        writeInfo(round,coins);
        SceneManager.LoadScene("StartMenu");
    }

    public void SaveAndContinue()
    {
        int round=1;
        File.Delete(Path.Combine(Application.dataPath, "Tiles.xml"));
        if (PlayerPrefs.HasKey("Round"))
        {
            
            round = PlayerPrefs.GetInt("Round");
        }
        int coins = PlayerPrefs.GetInt("coins",0);


        DeletePlayerPrefs();
        round++;
        writeInfo(round ,coins);

        PlayerPrefs.SetInt("Round", round);
        PlayerPrefs.SetInt("coins", coins);
        switch (round)
        {
            case 1:
                {
                    SceneManager.LoadScene("Round1");
                    break;
                }
            case 2:
                {
                    SceneManager.LoadScene("Shop");
                    break;
                }
            case 3:
                {
                    SceneManager.LoadScene("Shop");
                    break;
                }
            case 4:
                {
                    SceneManager.LoadScene("EndGame");
                    break;
                }

        }


    }
    public void writeInfo(int round,int coins)
    {

        xmlRR excuter = new xmlRR();
        //excuter.tile.Clear();

        //for (int i = 0; i < Tiles.Count; i++)
        //{
        //    til Tile = new til();
        //    Tile.timeEntered = Tiles[i].GetComponent<VisitCounter>().NoOfTimesEntered;
        //    Tile.threat = Tiles[i].GetComponent<VisitCounter>().threat;
        //    excuter.tile.Add(Tile);

        //}
        excuter.Round = round;
        excuter.Coins = coins;

        excuter.Save(Path.Combine(Application.dataPath, "Round.xml"));


    }
    public void ReadInfo()
    {
       
        if (File.Exists(Path.Combine(Application.dataPath, "Round.xml")))
        {
            var  roundinfo= xmlRR.Load(Path.Combine(Application.dataPath, "Round.xml"));
            PlayerPrefs.SetInt("Round", roundinfo.Round);
            PlayerPrefs.SetInt("coins", roundinfo.Coins);
        }
    }
}
