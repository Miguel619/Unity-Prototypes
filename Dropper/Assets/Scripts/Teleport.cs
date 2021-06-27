using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public GameObject teleportSpot;

    void OnTriggerEnter(Collider other)
    {
        other.transform.position = teleportSpot.transform.position;
    }
}
