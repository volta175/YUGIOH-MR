using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2TurnMaker : TurnMaker
{
    public override void OnTurnStart()
    {
        base.OnTurnStart();
        // dispay a message that it is player`s turn
        new ShowMessageCommand("Player 2 Turn!", 2.0f).AddToQueue();
        p.DrawACard();
    }
}
