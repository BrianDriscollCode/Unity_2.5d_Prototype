using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFunctions : MonoBehaviour
{

    [SerializeField] public Transform target;
    [SerializeField] public Vector3 offset;

    [SerializeField] private int positionX = 1;
    [SerializeField] private float positionY = 1.8f;
    [SerializeField] private int positionZ = -5;

    [SerializeField] float timeElapsed;
    [SerializeField] float lerpDuration = 2;

    [SerializeField] bool activateZoomOut = false;
    [SerializeField] bool activateZoomIn = false;

    void Start()
    {

        offset = new Vector3(positionX, positionY, positionZ);
    }

    void Update()
    {
        transform.position = target.position + offset;

        if (activateZoomOut)
        {
            zoomOut(-9);
        }

        if (activateZoomIn) 
        {
            zoomIn(-5);
        }


    }

    public void zoomOut(float newZPosition) 
    {
        Debug.Log("zoom out called");
        if (timeElapsed < lerpDuration)
        {
            newZPosition = Mathf.Lerp(positionZ, newZPosition, timeElapsed / lerpDuration);
            timeElapsed += Time.deltaTime;
        }
        else 
        {
            activateZoomOut = false;
            timeElapsed = 0;
        }
        offset = new Vector3(positionX, positionY, newZPosition);
    }

    public void zoomIn(float newZPosition)
    {
        Debug.Log("zoom in called");
        if (timeElapsed < lerpDuration)
        {
            newZPosition = Mathf.Lerp(-9, newZPosition, timeElapsed / lerpDuration);
            timeElapsed += Time.deltaTime;
        }
        else
        {
            activateZoomIn = false;
            timeElapsed = 0;
        }
        offset = new Vector3(positionX, positionY, newZPosition);
    }

    public void activateZoom(string type) 
    {
        if (type == "in")
        {
            activateZoomIn = true;
        }
        else
        {
            activateZoomOut = true;
            timeElapsed = 0;
        }
    }
}
