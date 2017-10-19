using System.Collections;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject platformS;
    public GameObject platformM;
    public GameObject platformL;

    public GameObject coin;

    private int coins;

    private void Start()
    {
        coins = 0;
        StartCoroutine(SpawnWaves());
    }

    private IEnumerator SpawnWaves()
    {
        int rndPlat, rndY, rndCoin, fixedX = 5;
        GameObject platform = new GameObject();
        Vector2 position, position1;

        while (true)
        {
            rndPlat = Random.Range(0, 90);
            rndY = Random.Range(0, 3);
            rndCoin = Random.Range(0, 2);

            #region Platform Y
            switch (rndY)
            {
                case 0:
                    position = new Vector2(fixedX, -4.5f);
                    position1 = new Vector2(fixedX, -4f);
                    break;
                case 1:
                    position = new Vector2(fixedX, -3f);
                    position1 = new Vector2(fixedX, -2.5f);
                    break;
                case 2:
                    position = new Vector2(fixedX, 0);
                    position1 = new Vector2(fixedX, 0.5f);
                    break;
                case 3:
                    position = new Vector2(fixedX, 2f);
                    position1 = new Vector2(fixedX, 2.5f);
                    break;
                default:
                    position = new Vector2(fixedX, -4.5f);
                    position1 = new Vector2(fixedX, -4f);
                    break;
            }

            #endregion

            #region Platform Size
            if (rndPlat < 30)
            {
                platform = Instantiate(platformS, position, Quaternion.identity);
            }
            else if (rndPlat >= 60)
            {
                platform = Instantiate(platformM, position, Quaternion.identity);
            }
            else
            {
                platform = Instantiate(platformL, position, Quaternion.identity);
            }
            #endregion

            #region Coin Spawn
            Instantiate(coin, position1, Quaternion.identity);
            #endregion

            GameObject.Destroy(platform, 50);

            yield return new WaitForSeconds(2f);     
        }
    }

    #region Public
    public int GetCoins()
    {
        return coins;
    }

    public void addCoins(int a)
    {
        coins += a;
    }
    #endregion
}
