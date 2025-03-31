using UnityEngine;
using System.Collections;
using UnityEngine.Splines;

public class SplineAnimComponent : MonoBehaviour
{
    /// <summary>
    /// Spline Container/Movement
    /// </summary>
    public SplineContainer spline;
    public float speed = 1f;
    public bool startAnim = false;
    private bool reverse;


    float distancePercentage;
    float splineLength;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        splineLength = spline.CalculateLength();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space") && startAnim)
        {
            reverse = !reverse;
        }
        else if (Input.GetKeyDown("space"))
        {
            startAnim = true;
        }

        if(startAnim)
        {
            if (reverse)
            {
                ReverseMove();
            }
            else if(!reverse)
            {
                MoveForward();
            }
        }
    }

    /// <summary>
    /// Moves the attatched object along on the spline 
    /// Either in forward or reverse based on distance percentage
    /// </summary>
    public void DirectionAlongSpline()
    {
        //-------------------------------------------------------------------------
        //Evaluates distance percentage to see if reverse or forward is required
        //-------------------------------------------------------------------------
        if (distancePercentage >= 1f)
        {
            reverse = true;
        }
        else if(distancePercentage <= 0f)
        {
            reverse = false;
        }
    
    }


    /// <summary>
    /// Code Not required for the current use 
    /// Handles rotation of the object to the spline
    /// Vector3 nextPosition = spline.EvaluatePosition(distancePercentage + 0.05f);
    /// Vector3 direction = nextPosition - currentPosition;
    /// transform.rotation = Quaternion.LookRotation(direction, transform.up);
    /// </summary>

    public void MoveForward()
    {
        //Updates the distance of percentage down the spline 
        distancePercentage += speed * Time.deltaTime / splineLength;

        //---------------------------------------------------
        // Code evalutes whether a length has been completed
        //---------------------------------------------------

        //----------------------------------------------------------
        // Moves the current position of the Object along the spline
        //----------------------------------------------------------
        Vector3 currentPosition = spline.EvaluatePosition(distancePercentage);
        transform.position = currentPosition;


        //--------------------------------------
        // Checks the distance along the spline
        // yields execution and returns null
        //--------------------------------------
        if (distancePercentage >= 1f) { 
            startAnim = false;
            reverse = true;
            return;
        }

    }

    public void ReverseMove()
    {
        //Updates the distance of percentage down the spline 
        distancePercentage -= speed * Time.deltaTime / splineLength;

        //---------------------------------------------------
        // Code evalutes whether a length has been completed
        //---------------------------------------------------

        //----------------------------------------------------------
        // Moves the current position of the Object along the spline
        //----------------------------------------------------------
        Vector3 currentPosition = spline.EvaluatePosition(distancePercentage);
        transform.position = currentPosition;


        //--------------------------------------
        // Checks the distance along the spline
        // yields execution and returns null
        //--------------------------------------
        if (distancePercentage <= 0f)
        {
            startAnim = false;
            reverse = false;
            return;
        }

    }
}
