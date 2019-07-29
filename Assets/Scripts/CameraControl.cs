using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    //time before camera refocuses
    public float dampTime = 0.2f;

    //space between top/bottom most target and edge screen
    public float screenEdgeBuffer = 4f;

    //smallest orthograhpic size camera can be
    public float minSize = 6.5f;

    //targets the camera needs to include
    public Transform[] m_Targets;

    private Camera gameCamera;

    //speed for smooth damping of orthographic size
    private float zoomSpeed;

    //velocity of smooth damping
    private Vector3 moveVelocity;

    //position camera is moving towards
    private Vector3 desiredPosition;
    
    // Start is called before the first frame update
    void Start()
    {
        gameCamera = GetComponentInChildren<Camera>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        //move camera to desired position
        Move();

        //change size of camera
        Zoom();
    }
    private void Move()
    {
        //find average postion of targets
        FindAveragePosition();

        //smoothly transition to position
        transform.position = Vector3.SmoothDamp(transform.position, desiredPosition, ref moveVelocity, dampTime);
    }

    private void FindAveragePosition()
    {
        Vector3 averagePos = new Vector3();

        int numTagets = 0;

        for (int i = 0; i < m_Targets.Length; i++) 
        {
            if (!m_Targets[i].gameObject.activeSelf)
            {
                continue;
            }
               

            averagePos += m_Targets[i].position;
            numTagets++;
        }

        if(numTagets > 0)
        {
            averagePos /= numTagets;
        }

        averagePos.y = transform.position.y;

        desiredPosition = averagePos;
    }

    private void Zoom()
    {
        float requiredSize = FindRequiredSize();

        gameCamera.orthographicSize = Mathf.SmoothDamp(gameCamera.orthographicSize, requiredSize, ref zoomSpeed, dampTime);
    }

    private float FindRequiredSize()
    {
        Vector3 desiredLocalPos = transform.InverseTransformPoint(desiredPosition);

        float size = 0f;

        for (int i = 0; i < m_Targets.Length; i++)
        {
            if (!m_Targets[i].gameObject.activeSelf)
                continue;

            Vector3 targetLocalPos = transform.InverseTransformPoint(m_Targets[i].position);

            Vector3 desiredLocalPosToTarget = targetLocalPos - desiredLocalPos;

            size = Mathf.Max(size, Mathf.Abs(desiredLocalPosToTarget.y));

            size = Mathf.Max(size, Mathf.Abs(desiredLocalPosToTarget.x) / gameCamera.aspect);
        }

        size += screenEdgeBuffer;

        size = Mathf.Max(size, minSize);

        return size;
    }

    public void SetStartPositionAndSize()
    {
        FindAveragePosition();

        transform.position = desiredPosition;

        gameCamera.orthographicSize = FindRequiredSize();
    }
}
