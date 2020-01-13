using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Summon : SummonAction
{
    private int savedHandSlot;
    private WhereIsTheCardOrCreature whereIsCard;
    private IDHolder idScript;
    private VisualStates tempState;
    private OneCardManager manager;

    void Awake()
    {
        whereIsCard = GetComponent<WhereIsTheCardOrCreature>();
        manager = GetComponent<OneCardManager>();
    }

    public override void OnSummon()
    {
        
          /*  int tablePos = playerOwner.PArea.tableVisual.TablePosForNewCreature(Camera.main.ScreenToWorldPoint(
                  new Vector3(Input.mousePosition.x, Input.mousePosition.y, transform.position.z - Camera.main.transform.position.z)).x);
          */      
            int tablePos = 0;
            playerOwner.PlayACreatureFromHand(GetComponent<IDHolder>().UniqueID, tablePos);
        
     /*   else
        {
            whereIsCard.SetHandSortingOrder();
            whereIsCard.VisualState = tempState;

            HandVisual playerHand = playerOwner.PArea.handVisual;
            Vector3 oldCardPos = playerHand.slots.Children[savedHandSlot].transform.localPosition;
            transform.DOLocalMove(oldCardPos, 1f);
        }*/
    }
    protected override bool SummonSuccessfull()
    {
        bool tableNotFull = (playerOwner.table.CreaturesOnTable.Count < 6);

        return TableVisual.CursorOverSomeTable && tableNotFull;
    }

    
}
