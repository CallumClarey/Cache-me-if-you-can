using UnityEngine;

/// <summary>
/// Component used to handle hackable doors
/// Note: Requires doorFunctionComponent
/// </summary>
public class HackDoorTriggerComponent : MonoBehaviour
{
    //-----------------------------------------------------------------
    //Code called for the hackable door
    //----------------------------------------------------------------
    public void OnTriggerStay2D(Collider2D collision)
    {
        GameObject collided = collision.gameObject;

        //checks to see if the object is the player
        if (collision.gameObject.CompareTag("Player"))
        {
            //TODOD:Implement Hack check here door System here
            if (true)
            {
                this.GetComponent<DoorFunctionComponent>().PlayerDoorTrigger(collided);
            }
        }

        //used to handle any NPC interacting with a door
        else if (collision.gameObject.CompareTag("NPC"))
        {
            //Insert code for NPC here
        }
    }
}

