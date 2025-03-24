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

    //------------------------------------------------
    //Code used to let the player go through the door
    //--------------------------------------------------
    public void playerDoorTrigger(GameObject collided)
    {
        //gets the box size of the bounding Box
        Vector2 boxSize = boundingBox.size;

        //the position of the colliding player
        Vector2 playerPos = new Vector2(collided.transform.position.x, collided.transform.position.y);

        //checks to see for vertical movement
        if (Player.GetComponent<PlayerMovement>().getMovement() != 0)
        {
            //checks to see if collision happens at bottom
            if (playerPos.y < boundingBox.transform.position.y){ belowBoundingbox(collided,boxSize,playerPos); }
            //checks to see if collision happens at the bottom
            else if (playerPos.y > boundingBox.transform.position.y){ aboveBoundingBox(collided,boxSize,playerPos); }
        }    
    }

    //----------------------------------------------------
    //Code for player moving to the top of bounding box
    //---------------------------------------------------
    private void belowBoundingbox(GameObject collided,Vector2 boxSize, Vector2 playerPos)
    {
        //translated the player if the movement is going down
        if (Player.GetComponent<PlayerMovement>().getMovement() > -1)
        {   
            //translates the player to the bounding box edge
            collided.transform.position = new Vector2(boundingBox.transform.position.x, playerPos.y + boxSize.y + 1);
        }
    }

    //----------------------------------------------------
    //Code for player moving to the bottom of bounding box
    //---------------------------------------------------
    private void aboveBoundingBox(GameObject collided, Vector2 boxSize, Vector2 playerPos)
    {
        //translates player if movement is going up
        if (Player.GetComponent<PlayerMovement>().getMovement() < 1)
        {
            //translates the player to the bounding box edge
            collided.transform.position = new Vector2(boundingBox.transform.position.x, playerPos.y - boxSize.y - 1);
        }
    }
}
