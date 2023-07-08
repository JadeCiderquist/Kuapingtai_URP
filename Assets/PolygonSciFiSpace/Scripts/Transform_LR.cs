using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transform_LR : MonoBehaviour
    
{
    public float Speed = 1.1f;
    public float PingpangTime = 3.0f;
    public bool ifLR = true;
    public bool ifLeft = false;
    public bool ifup = true;
    float TimeSpeed = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        if(ifLeft && ifLR)
        {
            TimeSpeed = PingpangTime;
        }
        if (ifup && !ifLR)
        {
            TimeSpeed = PingpangTime;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
        

    }

    void FixedUpdate()
    {
        float Location = Time.deltaTime * Speed;
        TimeSpeed += Time.deltaTime;
        //左右来回移动
        if (TimeSpeed > PingpangTime && TimeSpeed <= PingpangTime * 2 && ifLR)
        {
            transform.Translate(Vector3.right * Location);
        }
        else if (TimeSpeed <= PingpangTime && ifLR)
        {
            transform.Translate(Vector3.right * -Location);
        }
        else if (ifLR)
        {
            TimeSpeed = 0;
        }

        //上下来回移动

        if (TimeSpeed > PingpangTime && TimeSpeed <= PingpangTime * 2 && !ifLR)
        {
            transform.Translate(Vector3.up * Location);
        }
        else if (TimeSpeed <= PingpangTime && !ifLR)
        {
            transform.Translate(Vector3.up * -Location);
        }
        else if (!ifLR)
        {
            TimeSpeed = 0;
        }
    }
}
