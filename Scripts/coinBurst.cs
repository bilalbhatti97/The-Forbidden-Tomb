using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coinBurst : MonoBehaviour
{
    public GameObject coinPrefab;
    public int minCoin;
    public int maxCoin;
    // Start is called before the first frame update
    public void CoinOnDeath()
    {
        int amount = Random.Range(minCoin, maxCoin);
        for (int i = 0; i < amount; i++)
        {
            float xposition = transform.position.x + Random.Range(-0.4f, 0.4f);
            float yposition = transform.position.y + Random.Range(-0.4f, 0.4f);
            GameObject c = GameObject.Instantiate(coinPrefab, new Vector3(xposition, yposition, 0), Quaternion.identity);
            //c.GetComponent<Rigidbody2D>().velocity = new Vector2(Random.Range(-2, 2), Random.Range(-2, 2));
        }
    }
}
