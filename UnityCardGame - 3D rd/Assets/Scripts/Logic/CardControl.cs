using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardControl : MonoBehaviour
{
    private Player p, p2;

    private void Awake()
    {
        p = GameObject.Find("Player1 - LOW").GetComponent<Player>();
        p2 = GameObject.Find("Player2 - TOP").GetComponent<Player>();
    }

    public void cardsControl()
    {
        p.OnTurnStart();
        p2.OnTurnStart();
    }
}
