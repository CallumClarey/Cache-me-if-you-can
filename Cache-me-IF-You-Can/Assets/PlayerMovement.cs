using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //------------------------------
    //Class attributes 
    //-----------------------------
    //Determines player movement speed
    public float movementSpeed;

    //referance to the player rigid body
    public Rigidbody2D body;

    //referance to the player animation controller
    public Animator animator;

    //Vector to store movement values 
    Vector2 movement;

    // Update is called once per frame
    void Update()
    {
        //returns a value between -1 and 1 on both axis 
        movement.x =Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        //All code used to handle animations
        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);
    }

    private void FixedUpdate()
    {
        body.MovePosition(body.position + movement * movementSpeed * Time.fixedDeltaTime);
    }
}
