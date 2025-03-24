using UnityEngine;

/// <summary>
/// Used to handle normal door collision 
/// Note: Requires doorFunctionComponent
/// </summary>
public class doorTriggerComponent : MonoBehaviour
{
    public void OnTriggerStay2D(Collider2D collision)
    {

        GameObject collided = collision.gameObject;

        //checks to see if the object is the player
        if (collision.gameObject.tag == "Player") 
        { 
            this.GetComponent<doorFunctionComponent>().playerDoorTrigger(collided); 
        }

        //used to handle any NPC interacting with a door
        else if (collision.gameObject.tag == "NPC")
        {
            //Insert code for NPC here
        }
    }
}

