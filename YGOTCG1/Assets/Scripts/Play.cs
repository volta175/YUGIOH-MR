using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Play : MonoBehaviour
{
    public Animate launch;
    public int i = 0;

    private void OnGUI()
    {
        launch = GameObject.Find("Red Eyes 1(Clone)").GetComponent<Animate>();
        //launch = GameObject.Find("Red Eyes 1").GetComponentInChildren<Animate>();

        if (Input.GetMouseButtonDown(0))
        {
            launch.go();
            i++;
        }
        else if (Input.GetMouseButtonDown(1))
        {
            launch.stop();
            i--;
        }
    }

    
    // Update is called once per frame
    void Update()
    {
        
    }
}
