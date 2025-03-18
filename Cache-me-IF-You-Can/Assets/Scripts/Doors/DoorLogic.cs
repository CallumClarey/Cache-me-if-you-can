using UnityEngine;


/// <summary>
/// All logic used to move the player between the rooms
/// code requires optimisations to the calculations
/// </summary>
public class DoorLogic : MonoBehaviour
{
    //--------------------------------
    //All class attributes
    //--------------------------------
    //Used to get the door bounding box
    public BoxCollider2D boundingBox;
    //used to get the movement of the player
    public GameObject Player;

    private bool passedThrough = false;

    //------------------------------------------
    //Code Used to handle door collision/Trigger
    //------------------------------------------
    private void OnTriggerStay2D(Collider2D collision)
    {
        //checks to see if the player has just left the door
        if (passedThrough) { return; };

        GameObject collided = collision.gameObject;

        //checks to see if the object is the player
        if (collision.gameObject.tag == "Player")
        {
            //gets the box size of the bounding Box
            Vector2 boxSize = boundingBox.size;

            //checks to see for vertical movement
            if (Player.GetComponent<PlayerMovement>().getMovement() != 0)
            {
                //checks to see if collision happens at top or bottom
                if (collided.transform.position.y < boundingBox.transform.position.y)
                {
                    //translates the player to the bounding box edge
                    collided.transform.position = new Vector2(boundingBox.transform.position.x, collided.transform.position.y + boxSize.y + 1);
                }
                else if (collided.transform.position.y > boundingBox.transform.position.y)
                {
                    //translates the player to the bounding box edge
                    collided.transform.position = new Vector2(boundingBox.transform.position.x, collided.transform.position.y - boxSize.y - 1);
                }
                passedThrough= true;
            }
        }
        //used to handle any NPC interacting with a door
        else if (collision.gameObject.tag == "NPC")
        {
            //Insert code for NPC here
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        passedThrough= false;
    }
}
