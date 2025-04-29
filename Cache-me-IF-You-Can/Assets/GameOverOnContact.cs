using UnityEngine;
using UnityEditor; // Required for Unity Editor application control

public class GameOverOnContact : MonoBehaviour
{
    // Triggered when something enters the collider
    void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the object that collided is the Player
        if (other.CompareTag("Player"))
        {
            // If the player touches the NPC, trigger game over
            Debug.Log("Player touched Police NPC. Game Over.");

            // Call the method to end the game
            EndGame();
        }
    }

    void EndGame()
    {
        // End the game in the Unity Editor (stops play mode)
#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#endif
    }
}


