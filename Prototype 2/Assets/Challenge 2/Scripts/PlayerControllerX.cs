using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public GameObject dogPrefab;
    private float shootStart = 0f;
    private float cooldown = 2f;

    // Update is called once per frame
    void Update()
    {
        // On spacebar press, send dog
        if (Input.GetKeyDown(KeyCode.Space) && Time.time > cooldown + shootStart)
        {
            Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);
            shootStart = Time.time;
        }
    }
}
