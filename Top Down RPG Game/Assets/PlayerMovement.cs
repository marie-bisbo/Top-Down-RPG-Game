using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float movementSpeed = 5f;

    public Rigidbody2D rigidbody;
    public Animator animator;

    Vector2 movement;

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);

        SetPlayerDirection();

    }

    void FixedUpdate()
    {
        rigidbody.MovePosition(rigidbody.position + movement.normalized * movementSpeed * Time.fixedDeltaTime);
    }

    void SetPlayerDirection ()
    {
        Vector3 playerDirection = transform.localScale;
        if (Input.GetAxisRaw("Horizontal") < 0)
        {
            playerDirection.x = -1;
        }
        if (Input.GetAxisRaw("Horizontal") > 0)
        {
            playerDirection.x = 1;
        }
        transform.localScale =playerDirection;
    }
}
