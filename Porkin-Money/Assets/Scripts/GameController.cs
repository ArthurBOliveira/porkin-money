using System.Collections;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject platformS;
    public GameObject platformM;
    public GameObject platformL;

    public GameObject coin;

    private void Start()
    {
        StartCoroutine(SpawnWaves());
    }

    private IEnumerator SpawnWaves()
    {
        int rndPlat, rndY, fixedX = 5;
        GameObject platform = new GameObject();
        Vector2 position, position1;

        while (true)
        {
            rndPlat = Random.Range(0, 90);
            rndY = Random.Range(0, 3);

            #region Platform Y
            switch (rndY)
            {
                case 0:
                    position = new Vector2(fixedX, -4.5f);
                    break;
                case 1:
                    position = new Vector2(fixedX, -3f);
                    break;
                case 2:
                    position = new Vector2(fixedX, 0);
                    break;
                case 3:
                    position = new Vector2(fixedX, 2.5f);
                    break;
                default:
                    position = new Vector2(fixedX, -4.5f);
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

            GameObject.Destroy(platform, 50);

            yield return new WaitForSeconds(1.5f);
        }
    }
}
