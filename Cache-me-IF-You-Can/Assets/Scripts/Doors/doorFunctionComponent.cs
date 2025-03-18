using UnityEngine;

public class doorFunctionComponent : MonoBehaviour
{
    //--------------------------------
    //All Base class attributes
    //--------------------------------
    //Used to get the door bounding box
    public BoxCollider2D boundingBox;
    //used to get the movement of the player
    public GameObject Player;
    //Protected bool so check pass through
    public bool passedThrough = false;

    //sets the passed through to false
    public void OnTriggerExit2D(Collider2D collision) { passedThrough = false; }

    //Code used to let the player go through the door  
    public void playerDoorTrigger(GameObject collided)
    {
        //gets the box size of the bounding Box
        Vector2 boxSize = boundingBox.size;

        //the position of the colliding player
        Vector2 playerPos = new Vector2(collided.transform.position.x, collided.transform.position.y);

        //checks to see for vertical movement
        if (Player.GetComponent<PlayerMovement>().getMovement() != 0)
        {
            //checks to see if collision happens at top or bottom
            if (playerPos.y < boundingBox.transform.position.y)
            {
                //translates the player to the bounding box edge
                collided.transform.position = new Vector2(boundingBox.transform.position.x, playerPos.y + boxSize.y + 1);
            }
            else if (playerPos.y > boundingBox.transform.position.y)
            {
                //translates the player to the bounding box edge
                collided.transform.position = new Vector2(boundingBox.transform.position.x, playerPos.y - boxSize.y - 1);
            }
            passedThrough = true;
        }
    }
}
