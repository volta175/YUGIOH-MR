using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode]
public class Star : MonoBehaviour
{
    //public CardAsset cardasset;
    public int starCount;

    public Image[] Level;
  
    private int totalStar;
    public int CounterStar
    {
        get { return totalStar; }

        set
        {
            if (value > Level.Length)
            {
                totalStar = Level.Length;
            }
            else if (value < 0 )
            {
                totalStar = 0;
            }
            else
            {
                totalStar = value;
            }

            for (int i = Level.Length; i > 0; i--)
            {
                if (i > (Level.Length - totalStar))
                {
                    if (Level[i-1].color == Color.clear)
                    {
                        Level[i-1].color = Color.white;
                    }
                }
                else
                {
                    Level[i-1].color = Color.clear;
                }
            }
        }
    }

    void Update()
    {
        CounterStar = GetComponentInParent<OneCardManager>().Star;
       // Debug.Log(CounterStar);
    /*    
        //fungsi hanya berlaku untuk mengedit game, bukan saat menjalankan game
        if (Application.isEditor && !Application.isPlaying)
        {
            CounterStar = starCount;
        }*/
    }
    
}
