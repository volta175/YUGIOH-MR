using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animate : MonoBehaviour
{
    private Animation anim;
    private ParticleSystem fire;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animation>();
        fire = GetComponentInChildren<ParticleSystem>();
    }

    public void go()
    {
        anim.Play();
        fire.Play();
    }

    public void stop()
    {
        anim.Stop();
        fire.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
