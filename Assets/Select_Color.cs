using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Select_Color : MonoBehaviour
{
    public int ColorCount = 0;
    public MeshFilter meshFilter;
    public MeshRenderer meshRender;
    public MeshCollider meshCollider;

    public Mesh[] mesh;
    public Material[] material;
    void Start()
    {
        ColorCount = PlayerPrefs.GetInt("colorCount");
        meshFilter.mesh = mesh[ColorCount];
       // meshCollider.sharedMesh = mesh[ColorCount];
        meshRender.material = material[ColorCount];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
