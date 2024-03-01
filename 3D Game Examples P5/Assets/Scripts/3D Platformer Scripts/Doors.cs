using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doors : MonoBehaviour
{
    Vector3 _pivotPoint;
    bool _isDoorOpen;
    bool _canDoorOpen;

    // Start is called before the first frame update
    void Start()
    {
        _pivotPoint = transform.position;
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player") && !_isDoorOpen && _canDoorOpen)
        {
            transform.RotateAround(_pivotPoint, Vector3.up, -90);
            _isDoorOpen = true;
            //GameObject.Find("Main Camera").GetComponent<CameraFollow>().MoveToSpotTwo();
        }
    }

    public void OpenTheDoor()
    {
        transform.RotateAround(_pivotPoint, Vector3.up, -90);
        _isDoorOpen = true;
    }

    public void DoorCanBeOpened()
    {
        _canDoorOpen = true;
    }
}