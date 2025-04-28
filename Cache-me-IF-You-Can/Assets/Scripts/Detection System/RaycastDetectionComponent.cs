using System;
using System.Collections;
using UnityEngine;

public class RaycastDetectionComponent : MonoBehaviour
{
    //-----------------------------
    //Class attributes
    //-------------------------------
    //the distance of the raycast
    [SerializeField] private float raycastDistance;
    //results of the raycast
    //3 Raycast to occur
    private RaycastHit2D[] _hits = new RaycastHit2D[3];
    private Vector2 _direction;

    
    //------------------------------------
    //Code used to get forward direction
    //------------------------------------
    private void Start()
    {
        //Calculates direction
        _direction = transform.rotation == Quaternion.Euler(0f, 0f, 0f) ? Vector2.left : Vector2.right;
    }

    //calls a raycast on every frame 
    //TODO: Move the raycast instead of casting a new one each frame
    void FixedUpdate()
    {
        //performs raycast
        PerformRaycast();
    }

    private void PerformRaycast()
    {
        //performs raycast
        //Will limit the size of the raycast result to 3 
        _hits = Physics2D.RaycastAll(transform.position, _direction, raycastDistance);
        
        //Checks for empty 
        if (_hits.Length < 2) return;
        
        //checks to see if the player has hit the raycast
        if ((bool)_hits[1].collider.gameObject?.CompareTag("Player"))
        {
            Debug.Log("Hit: " + _hits[1].collider.gameObject.name);
            // Perform actions based on the hit, such as interacting with the object
        }
        else
        {
            Debug.Log("No hit");
        }
    }
    
    
    
    void OnDrawGizmos() // Optional: Visualize the raycast in the editor
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, _direction * raycastDistance);
    }
    
    
}
