using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hit_rotation : MonoBehaviour
{
    public float X = 0.0f;
    public float Y = 0.0f;
    public float Z = 0.0f;
    float TimeSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        TimeSpeed += Time.deltaTime;
        transform.Rotate(X, Y, Z * Time.deltaTime);
   
    }
    void FixedUpdate()
    {

    }
}
