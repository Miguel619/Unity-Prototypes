using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public MeshRenderer Renderer;
    private Material material;
    private Color[] colors = {Color.red, Color.blue, Color.green, Color.yellow, Color.cyan, Color.magenta};
    private float startTime = 0f;
    public float coolDown = 1f;
    
    void Start()
    {
        transform.position = new Vector3(7, 8.5f, -0.5f);
        transform.localScale = Vector3.one;
        
        material = Renderer.material;
        
        material.color = new Color(0.5f, 1.0f, 0.3f, 0.4f);
    }
    
    void Update()
    {
        if(Time.time > startTime + coolDown){
            transform.Rotate(Random.Range(10f, 360f) * Time.deltaTime, Random.Range(10f, 360f) * Time.deltaTime, 0.0f);
            material.color = colors[Random.Range(0, colors.Length)];
            transform.localScale = new Vector3(Random.Range(0.1f, 3f), Random.Range(0.1f, 3f), Random.Range(0.1f, 3f));
            startTime = Time.time;
        }
        
    }
}
