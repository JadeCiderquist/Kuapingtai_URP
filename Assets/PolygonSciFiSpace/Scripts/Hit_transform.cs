using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hit_transform : MonoBehaviour

{
    public float Speed01 = 1.0f;
    public float Speed02 = 1.0f;
    public bool ifLeft = true;
    float TimeSpeed = 0.0f;
    float LR = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        if (!ifLeft)
        {
            LR = -1.0f;
        }
    }

    // Update is called once per frame
    void Update()
    {

        float LocationL = Time.deltaTime * Speed01;
        float LocationR = Time.deltaTime * Speed02;
        TimeSpeed += Time.deltaTime;
        //◊Û”“¿¥ªÿ“∆∂Ø
        if (TimeSpeed <= 0.5f )
        {
            transform.Translate(Vector3.right * LocationL * LR);
        }
        else if (TimeSpeed > 0.5f && TimeSpeed < 2.5f )
        {
            transform.Translate(Vector3.right * -LocationR * LR);
        }
        else
        {
            TimeSpeed = 0;
        }
    }
}
