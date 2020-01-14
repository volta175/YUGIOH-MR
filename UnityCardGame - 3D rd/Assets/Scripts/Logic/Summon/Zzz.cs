using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zzz : MonoBehaviour

{
    private SummonAction sa;
    public MouseManager mm;
    //  private CardLogic cl;

    void Awake()
    {
        sa = GetComponent<SummonAction>();
     //   mm = GetComponentInParent<MouseManager>();
    }

    public void SummonMonster()
    {
        if (mm.SummonCounter == 1)
        {
            mm.SummonCounter -= 1;
            Debug.Log(mm.SummonCounter);
            sa.OnSummon();
            mm.SummMonsDecision();
        }
        else if (mm.SummonCounter == 0)
        {
            Debug.Log("Cannot Summon or Set anymore");
        }
               
    }
    
    public void SetMonster()
    {
        if (mm.SummonCounter == 1)
        {
            mm.SummonCounter -= 1;
            sa.OnSummon();
            mm.SetMonstDecision();
        }
        else if (mm.SummonCounter == 0)
        {
            Debug.Log("Cannot Summon or Set anymore");
        }

    }

    public void ActiveSpellTrap()
    {
        sa.OnSummon();
        mm.ActiveSTDecision();
    }

    public void SetSpellTrap()
    {
        sa.OnSummon();
        mm.SetSTDecision();
    }

    public void SwPosition()
    {
        mm.SwPos();
    }

    public void FlipSummon()
    {
        mm.FlipSummon();
    }

    public void Attack()
    {
        mm.AtkDecision();
    }

}
