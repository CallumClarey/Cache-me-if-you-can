using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    // Public variables to control movement speed, Rigidbody, and player direction
    public float moveSpeed;
    public Rigidbody2D rb2d;
    private Vector2 moveInput;

    // Flags to check player movement directions
    public bool movingRight;
    public bool movingLeft;
    public bool movingUp;
    public bool movingDown;

    // Integer to track player's facing direction (not being used currently in this script)
    public int playerDirection;

    // GameObjects to represent different character faces (for animations based on direction)
    public GameObject faceR; // Face for moving right
    public GameObject faceD; // Face for moving down
    public GameObject faceL; // Face for moving left
    public GameObject faceU; // Face for moving up

    // Animator to handle player animations
    public Animator playerAnimations;

    // Start is called before the first frame update
    void Start()
    {
        // No initialization needed for now
    }

    // Update is called once per frame
    void Update()
    {
        // Get input from player (horizontal and vertical movement)
        moveInput.x = Input.GetAxisRaw("Horizontal"); // Horizontal axis input (A/D or Left/Right arrows)
        moveInput.y = Input.GetAxisRaw("Vertical"); // Vertical axis input (W/S or Up/Down arrows)

        // Normalize input to prevent diagonal movement from being faster
        moveInput.Normalize();

        // Determine if horizontal or vertical movement is greater and set player movement accordingly
        if (Mathf.Abs(moveInput.x) > Mathf.Abs(moveInput.y))
        {
            moveInput.y = 0; // Set vertical input to zero if moving mostly horizontally
            rb2d.linearVelocity = moveInput * moveSpeed; // Apply horizontal movement to Rigidbody
        }
        else
        {
            moveInput.x = 0; // Set horizontal input to zero if moving mostly vertically
            rb2d.linearVelocity = moveInput * moveSpeed; // Apply vertical movement to Rigidbody
        }

        // Handle movement to the right (x > 0)
        if (moveInput.x > 0)
        {
            movingRight = true; // Set movingRight flag to true
            faceR.SetActive(true); // Activate the faceR object to show the player facing right
            faceL.SetActive(false); // Deactivate the faceL object
            faceD.SetActive(false); // Deactivate the faceD object
            faceU.SetActive(false); // Deactivate the faceU object
            playerAnimations.Play("walkR"); // Play the "walkR" animation
        }
        else
        {
            movingRight = false; // Reset movingRight flag if no right movement
        }

        // Handle movement to the left (x < 0)
        if (moveInput.x < 0)
        {
            movingLeft = true; // Set movingLeft flag to true
            faceR.SetActive(false); // Deactivate the faceR object
            faceL.SetActive(true); // Activate the faceL object to show the player facing left
            faceD.SetActive(false); // Deactivate the faceD object
            faceU.SetActive(false); // Deactivate the faceU object
            playerAnimations.Play("walkL"); // Play the "walkL" animation
        }
        else
        {
            movingLeft = false; // Reset movingLeft flag if no left movement
        }

        // Handle movement upwards (y > 0)
        if (moveInput.y > 0)
        {
            movingUp = true; // Set movingUp flag to true
            faceR.SetActive(false); // Deactivate all face objects
            faceL.SetActive(false);
            faceD.SetActive(false);
            faceU.SetActive(true); // Activate the faceU object to show the player facing up
            playerAnimations.Play("walkU"); // Play the "walkU" animation
        }
        else
        {
            movingUp = false; // Reset movingUp flag if no upward movement
        }

        // Handle movement downwards (y < 0)
        if (moveInput.y < 0)
        {
            movingDown = true; // Set movingDown flag to true
            faceR.SetActive(false); // Deactivate all face objects
            faceL.SetActive(false);
            faceD.SetActive(true); // Activate the faceD object to show the player facing down
            faceU.SetActive(false);
            playerAnimations.Play("walkD"); // Play the "walkD" animation
        }
        else
        {
            movingDown = false; // Reset movingDown flag if no downward movement
        }

        // If there is no movement (both x and y inputs are zero), play idle animation
        if (moveInput.y == 0 && moveInput.x == 0)
        {
            playerAnimations.Play("PlayerIdle"); // Play idle animation
        }
    }
}
