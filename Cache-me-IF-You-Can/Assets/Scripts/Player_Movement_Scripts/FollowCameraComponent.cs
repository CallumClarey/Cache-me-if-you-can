using UnityEngine;

/// <summary>
/// Component used to make the camera follow the player
/// Note: Attatched to the player
/// </summary>
public class FollowCameraComponent : MonoBehaviour
{
    //-------------------------------
    //Class attributes
    //-------------------------------
    //Speed that the camera follows the player 
    public float followSpeed;
    //the game object to retrive the transform component from
    public GameObject playerTarget;
    //the private transform component to follow
    private Transform followTarget;


    //-------------------------------
    //Runs on the start frame
    //---------------------------------
    private void Start() { followTarget = playerTarget.transform; }

    //-----------------------------------
    //Update function called every frame
    //------------------------------------
    void Update()
    {
        //creates new vector from a player position
        Vector3 newPos = new Vector3(followTarget.position.x,followTarget.position.y,- 10f);
        //transforms the position of the camera to the player using a spherical lerp
        transform.position = Vector3.Slerp(transform.position, newPos ,followSpeed);
    }
}
