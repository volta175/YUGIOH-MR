using UnityEngine;
using System.Collections;
using DG.Tweening;

public class CreatureAttackVisual : MonoBehaviour
{
    private OneCreatureManager manager;
    private WhereIsTheCardOrCreature w;

   // private CardAsset ca;
   // private GameObject gobj1;
   // private GameObject target;

   // MouseManager mm;

    void Awake()
    {
        manager = GetComponent<OneCreatureManager>();
        w = GetComponent<WhereIsTheCardOrCreature>();

      //  mm = GetComponent<MouseManager>();
      //  ca = GetComponent<CardAsset>();
    }
/*
    void Attack()
    {
        gobj1 = mm.GetComponent<MouseManager>().selectedObject;

        if (gobj1 != null)
        {
            target = null;
            RaycastHit[] hits;
            // TODO: raycast here anyway, store the results in 
            hits = Physics.RaycastAll(origin: Camera.main.transform.position,
                direction: (-Camera.main.transform.position + this.transform.position).normalized,
                maxDistance: 30f);
        }
       
    }
*/

    
    public void AttackTarget(int targetUniqueID, int damageTakenByTarget, int damageTakenByAttacker, int attackerHealthAfter, int targetHealthAfter)
    {
        Debug.Log(targetUniqueID);
        manager.CanAttackNow = true;
        GameObject target = IDHolder.GetGameObjectWithID(targetUniqueID);

        // bring this creature to front sorting-wise.
        w.BringToFront();
        VisualStates tempState = w.VisualState;
        w.VisualState = VisualStates.Transition;

        transform.DOMove(target.transform.position, 0.5f).SetLoops(2, LoopType.Yoyo).SetEase(Ease.InCubic).OnComplete(() =>
        {
            if (damageTakenByTarget > 0)
                DamageEffect.CreateDamageEffect(target.transform.position, damageTakenByTarget);
            if (damageTakenByAttacker > 0)
                DamageEffect.CreateDamageEffect(transform.position, damageTakenByAttacker);

            if (targetUniqueID == GlobalSettings.Instance.LowPlayer.PlayerID || targetUniqueID == GlobalSettings.Instance.TopPlayer.PlayerID)
            {
                // target is a player
                target.GetComponent<PlayerPortraitVisual>().HealthText.text = targetHealthAfter.ToString();
            }
            else
              //  target.GetComponent<OneCreatureManager>().HealthText.text = targetHealthAfter.ToString();

            w.SetTableSortingOrder();
            w.VisualState = tempState;

          //  manager.HealthText.text = attackerHealthAfter.ToString();
            Sequence s = DOTween.Sequence();
            s.AppendInterval(1f);
            s.OnComplete(Command.CommandExecutionComplete);
            //Command.CommandExecutionComplete();
        });
    }

}
