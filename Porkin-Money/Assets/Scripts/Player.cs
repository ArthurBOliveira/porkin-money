using UnityEngine;

public class Player : MonoBehaviour
{
    public int jumpForce;
    public int currJumpForce;

    public bool grounded;

    private Rigidbody2D rg2d;
    private Animator anim;

    private void Awake()
    {
        rg2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void Start()
    {
        currJumpForce = jumpForce;
    }

    private void Update()
    {
        if (grounded) currJumpForce = jumpForce;

        if (Input.GetKey(KeyCode.Space))
        {
            //anim.SetTrigger("jump");
            rg2d.AddForce(Vector2.up * currJumpForce);
            currJumpForce = currJumpForce > 0 ? currJumpForce - 1 : 0;
        }
    }

    private void OnCollisionStay2D(Collision2D collider)
    {
        GroundCheck();
    }

    private void OnCollisionExit2D(Collision2D collider)
    {
        grounded = false;
    }

    private void GroundCheck()
    {
        RaycastHit2D[] hits;

        //We raycast down 1 pixel from this position to check for a collider
        Vector2 positionToCheck = transform.position;
        hits = Physics2D.RaycastAll(positionToCheck, new Vector2(0, -1), 0.01f);

        //if a collider was hit, we are grounded
        if (hits.Length > 0)
        {
            grounded = true;
        }
    }
}
