using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangePosMons : MonoBehaviour
{
    private Animation animate;
    private ParticleSystem fire;

    // Start is called before the first frame update
    void Start()
    {
        animate = GetComponent<Animation>();
        fire = GetComponentInChildren<ParticleSystem>();
    }

    public void go()
    {
        animate.Play();
        fire.Play();
    }

    public void stop()
    {
        //animate.Stop();
        fire.Stop();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
