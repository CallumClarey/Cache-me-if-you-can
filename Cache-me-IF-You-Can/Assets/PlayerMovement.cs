using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //------------------------------
    //Class attributes 
    //-----------------------------
    public float movementSpeed;

    public Rigidbody2D body;

    Vector2 movement;

    // Update is called once per frame
    void Update()
    {
        //returns a value between -1 and 1 on both axis 
        movement.x =Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate()
    {
        body.MovePosition(body.position + movement * movementSpeed * Time.fixedDeltaTime);
    }
}
