using UnityEngine;

public class Mover : MonoBehaviour
{
    public int speed;

    private Rigidbody2D rg2d;

    private void Awake()
    {
        rg2d = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        rg2d.velocity = Vector2.left * speed;
    }
}
