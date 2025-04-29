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
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        waypoints = new Transform[waypointParent.childCount];

        for(int i = 0; i < waypointParent.childCount; i++)
        {
            waypoints[i] = waypointParent.GetChild(i);
        }
    }

    // Update is called once per frame
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

        transform.position = Vector2.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);

        if(Vector2.Distance(transform.position, target.position) < 0.1f)
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
