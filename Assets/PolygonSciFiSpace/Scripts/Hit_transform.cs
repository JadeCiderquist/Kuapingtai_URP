using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hit_transform : MonoBehaviour

{
    public float Speed = 1.0f;
    public bool ifLeft = true;
    Vector3 StartPos;
    float TimeSpeed = 0.0f;
    float LR = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        StartPos = this.transform.localPosition;
        if (!ifLeft)
        {
            LR = -1.0f;
        }
    }

    // Update is called once per frame
    void Update()
    {

        float LocationL = Time.deltaTime * Speed;
        TimeSpeed += Time.deltaTime;
        //◊Û”“¿¥ªÿ“∆∂Ø
        if (TimeSpeed <= 1 )
        {
            transform.Translate(Vector3.right * LocationL * LR);
        }
        else if (TimeSpeed > 1)
        {
            this.transform.localPosition = StartPos;
            TimeSpeed = 0;
        }
    }
}
