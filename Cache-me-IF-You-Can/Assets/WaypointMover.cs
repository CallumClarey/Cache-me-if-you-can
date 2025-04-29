using System.Collections;
using UnityEngine;

public class WaypointMover : MonoBehaviour
{
    public Transform waypointParent;
    public float moveSpeed = 2f;
    public float waitTime = 2f;
    public bool loopwaypoints = true;

    private Transform[] waypoints;
    private int currentwaypointIndex;
    private bool iswaiting;
    private Rigidbody2D rb; // Reference to Rigidbody2D

    void Start()
    {
        waypoints = new Transform[waypointParent.childCount];
        rb = GetComponent<Rigidbody2D>(); // Get the Rigidbody2D of the NPC

        for (int i = 0; i < waypointParent.childCount; i++)
        {
            waypoints[i] = waypointParent.GetChild(i);
        }
    }

    void Update()
    {
        if (iswaiting)
        {
            return;
        }

        MoveToWaypoint();
    }

    void MoveToWaypoint()
    {
        Transform target = waypoints[currentwaypointIndex];

        // Move NPC towards the waypoint without causing it to pass through the Player
        Vector2 targetPosition = Vector2.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
        rb.MovePosition(targetPosition); // Use Rigidbody2D to move

        if (Vector2.Distance(transform.position, target.position) < 0.1f)
        {
            StartCoroutine(waitAtWaypoint());
        }
    }

    IEnumerator waitAtWaypoint()
    {
        iswaiting = true;
        yield return new WaitForSeconds(waitTime);
        currentwaypointIndex = loopwaypoints ? (currentwaypointIndex + 1) % waypoints.Length : Mathf.Min(currentwaypointIndex + 1, waypoints.Length - 1);
        iswaiting = false;
    }
}

