using UnityEngine;
using UnityEngine.UI;

public class Coin : MonoBehaviour
{
    public int value;

    private GameController gc;
    private Text txtCoins;

    private void Awake()
    {
        gc = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<GameController>();
        txtCoins = GameObject.FindGameObjectWithTag("txtCoins").GetComponent<Text>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            gc.addCoins(value);
            int coins = gc.GetCoins();
            txtCoins.text = coins.ToString();

            GameObject.Destroy(gameObject);
        }
    }
}
