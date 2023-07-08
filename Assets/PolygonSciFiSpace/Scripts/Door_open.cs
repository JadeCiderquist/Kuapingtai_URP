using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door_open : MonoBehaviour
{
    float Speed = 3.5f;
    public bool ifin = false;
    float TimeSpeed = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (ifin)
        {
            transform.Translate(Vector3.up * Speed * Time.deltaTime);
            TimeSpeed += Time.deltaTime;
        }
        if(TimeSpeed >= 1)
        {
            ifin = false;
        }
    }

}
