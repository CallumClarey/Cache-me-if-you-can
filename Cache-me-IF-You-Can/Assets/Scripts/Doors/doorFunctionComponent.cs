using UnityEngine;
using UnityEngine.Serialization;

public class DoorFunctionComponent : MonoBehaviour
{
    //--------------------------------
    //All Base class attributes
    //--------------------------------
    //Used to get the door bounding box
    public BoxCollider2D boundingBox;
    //used to get the movement of the player
    private GameObject _player;

    //------------------------------------------------
    //Code used to let the player go through the door
    //--------------------------------------------------
    public void PlayerDoorTrigger(GameObject collided)
    {
        //sets the player to collided Object
        _player = collided;
        
        //gets the box size of the bounding Box
        var boxSize = boundingBox.size;

        //the position of the colliding player
        var playerPos = new Vector2(collided.transform.position.x, collided.transform.position.y);

        //checks to see for vertical movement
        if (_player.GetComponent<PlayerMovement>().getMovement() == 0) return;
        
        //checks to see if collision happens at bottom
        if (playerPos.y < boundingBox.transform.position.y){ BelowBoundingBox(collided,boxSize,playerPos); }
        //checks to see if collision happens at the bottom
        else if (playerPos.y > boundingBox.transform.position.y){ AboveBoundingBox(collided,boxSize,playerPos); }
    }

    //----------------------------------------------------
    //Code for player moving to the top of bounding box
    //---------------------------------------------------
    private void BelowBoundingBox(GameObject collided,Vector2 boxSize, Vector2 playerPos)
    {
        //translated the player if the movement is going down
        if (_player.GetComponent<PlayerMovement>().getMovement() > -1)
        {   
            //translates the player to the bounding box edge
            collided.transform.position = new Vector2(boundingBox.transform.position.x, playerPos.y + boxSize.y + 1);
        }
    }

    //----------------------------------------------------
    //Code for player moving to the bottom of bounding box
    //---------------------------------------------------
    private void AboveBoundingBox(GameObject collided, Vector2 boxSize, Vector2 playerPos)
    {
        //translates player if movement is going up
        if (_player.GetComponent<PlayerMovement>().getMovement() < 1)
        {
            //translates the player to the bounding box edge
            collided.transform.position = new Vector2(boundingBox.transform.position.x, playerPos.y - boxSize.y - 1);
        }
    }
}
