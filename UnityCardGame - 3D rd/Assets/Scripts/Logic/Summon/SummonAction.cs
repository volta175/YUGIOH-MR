using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SummonAction : MonoBehaviour
{
    public abstract void OnSummon();

    protected virtual Player playerOwner
    {
        get
        {

            if (tag.Contains("Low"))
                return GlobalSettings.Instance.LowPlayer;
            else if (tag.Contains("Top"))
                return GlobalSettings.Instance.TopPlayer;
            else
            {
                Debug.LogError("Untagged Card or creature " + transform.parent.name);
                return null;
            }
        }
    }

    protected abstract bool SummonSuccessfull();
}


