using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitDoorWay : MonoBehaviour
{
    public GameObject Scenetransition;
    public int Specifiedturns;

    private void Start()
    {
        Scenetransition = GameObject.FindGameObjectWithTag("Environment");
        if(PlayerPrefs.GetInt("Round")==2)
        {
            Specifiedturns = 5;
            SceneName = "Round2";
        }
        else if(PlayerPrefs.GetInt("Round") == 3)
        {
            Specifiedturns = 6;
            SceneName = "Round3";
        }
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Scenetransition.GetComponent<SceneTransition>().EndScene("StartMenu");
        }
    }

    public string SceneName;
    public string NextSceneLoad;

    private void Reset()
    {
        GetComponent<Rigidbody2D>().isKinematic = true;
        BoxCollider2D box = GetComponent<BoxCollider2D>();
        box.size = Vector2.one * 0.1f;
        box.isTrigger = true;
    }
    public DecisionMaker Dd;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("exit");
        if(collision.tag=="Player")
        {
            Dd = FindObjectOfType<DecisionMaker>();
           // Dd.writeThreat();
            Dd.writeInfo();
            PlayerPrefs.SetInt("Health", FindObjectOfType<Health>().health);
            PlayerPrefs.SetInt("Arrows", FindObjectOfType<Shooter_projctile>().amountOfArrows);
            PlayerPrefs.SetInt("coins", collision.GetComponent<UiCoinAmount>().playerCoins);

            if (PlayerPrefs.HasKey("turns"))
            {
                int t = PlayerPrefs.GetInt("turns");
                t++;

                if (t == 3)
                {
                    PlayerPrefs.SetInt("turns", t);
                    Scenetransition.GetComponent<SceneTransition>().EndScene("Shop");
                }
                else if (t < Specifiedturns)
                {
                    PlayerPrefs.SetInt("turns", t);
                    Scenetransition.GetComponent<SceneTransition>().EndScene(SceneName);
                }
                else
                {
                    SceneName = "SaveScreen";
                    Scenetransition.GetComponent<SceneTransition>().EndScene(SceneName);
                }
            }
            else
            {
                PlayerPrefs.SetInt("turns", 1);
                Scenetransition.GetComponent<SceneTransition>().EndScene(SceneName);
            }
        }
    }



}
