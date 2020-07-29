using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuadUtility : MonoBehaviour
{
    public Camera mainCamera;
    public LineRenderer lineRenderer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    
    public void ResetQuadPosition()
    {
        float forwardDist = 3.0f; // position away from the camera
        Vector3 camForward = mainCamera.transform.forward;
        Vector3 camPos = mainCamera.transform.position;

        Vector3 projectedForward = Vector3.ProjectOnPlane(camForward, Vector3.up).normalized * forwardDist;

        Vector3 quadPos = projectedForward + camPos + new Vector3(0, -1.2f, 0);
        float quadBottom = quadPos.y - this.gameObject.transform.localScale.y/2;

        //make sure it doesn't go below the global floor
        //This has to be adjusted to raycast to find the plane underneath instead of using global zero
        if(quadBottom < 0)
        {
            quadPos.y = this.gameObject.transform.localScale.y/2;
        }

        lineRenderer.SetPositions(new Vector3[] { camPos, quadPos });

        this.gameObject.transform.position = quadPos;
        this.gameObject.transform.LookAt(camPos);
        this.gameObject.transform.Rotate(this.gameObject.transform.up, 180.0f, Space.World);
        //this.gameObject.transform.LookAt(camPos);
    }
}
