using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    public float SpeedX = 0.0f;
    public float SpeedY = 0.0f;
    public float SpeedZ = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void FixedUpdate()
    {
        transform.Rotate(SpeedX, SpeedY, SpeedZ);
    }
}
