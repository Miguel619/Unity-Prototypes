using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelRoll : MonoBehaviour
{
    public GameObject parent;
    public float spinSpeed;
    public float speed;

    // Update is called once per frame
    void Update()
    {
        parent.transform.Translate(Vector3.back * Time.deltaTime * speed);
        transform.Rotate(Vector3.up, spinSpeed * Time.deltaTime);
    }
}
