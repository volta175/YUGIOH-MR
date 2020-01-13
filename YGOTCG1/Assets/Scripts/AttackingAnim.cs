using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackingAnim : MonoBehaviour
{
    private ParticleSystem attack;

    // Start is called before the first frame update
    void Start()
    {
        attack = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StartFire()
    {
        attack.Play();
    }

    public void StopFire()
    {
        attack.Stop();
    }
}
