using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{

    public GameObject objectfollow;
    public float speed = 2.0f;
    public Vector3 offset = new Vector3(0, 3, -10);
    
    void Update()
    {
        this.transform.position = Vector3.Lerp(this.transform.position, objectfollow.transform.position + offset, speed + Time.deltaTime);
    }
}
