using UnityEngine;

/// <summary>
/// Component used to handle hackable doors
/// Note: Requires doorFunctionComponent
/// </summary>
public class hackDoorTriggerComponent : MonoBehaviour
{
    //-----------------------------------------------------------------
    //Code called for the hackable door
    //----------------------------------------------------------------
    public void OnTriggerStay2D(Collider2D collision)
    {
        //checks to see if the player has just left the door
        if (this.GetComponent<doorFunctionComponent>().passedThrough) { return; };

        GameObject collided = collision.gameObject;

        //checks to see if the object is the player
        if (collision.gameObject.tag == "Player")
        {
            //TODOD:Implement Hack check here door System here
            if (true)
            {
                this.GetComponent<doorFunctionComponent>().playerDoorTrigger(collided);
            }
        }

        //used to handle any NPC interacting with a door
        else if (collision.gameObject.tag == "NPC")
        {
            //Insert code for NPC here
        }
    }
}

