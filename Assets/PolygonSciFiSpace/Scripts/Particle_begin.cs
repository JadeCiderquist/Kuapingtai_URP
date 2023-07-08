using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particle_begin : MonoBehaviour
{
    // Start is called before the first frame update
    public ParticleSystem Block;
    public GameObject player;
    void Start()
    {
        var em = Block.emission;
        em.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
