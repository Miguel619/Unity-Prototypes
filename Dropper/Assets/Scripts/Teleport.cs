using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public Camera oldCamera;
    public Camera newCamera;
    public GameObject teleportSpot;

    void OnTriggerEnter(Collider other)
    {
        other.transform.position = teleportSpot.transform.position;
        oldCamera.enabled = !oldCamera.enabled;
        newCamera.enabled = !newCamera.enabled;
    }
}
