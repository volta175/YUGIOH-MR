using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class HoverPreview2 : MonoBehaviour
{
    // PUBLIC FIELDS
    public GameObject TurnThisOffWhenPreviewing;  // if this is null, will not turn off anything 
    public Vector3 TargetPosition;
    public float TargetScale;
    public GameObject previewGameObject;
    public GameObject previewGameObject2;
    public bool ActivateInAwake = false;

    private MouseManager mm;
    // PRIVATE FIELDS
    private static HoverPreview2 currentlyViewing = null;
    private static HoverPreview2 currentlyViewing2 = null;

    // PROPERTIES WITH UNDERLYING PRIVATE FIELDS
    private static bool _PreviewsAllowed = true;
    public static bool PreviewsAllowed
    {
        get { return _PreviewsAllowed; }

        set
        {
            //Debug.Log("Hover Previews Allowed is now: " + value);
            _PreviewsAllowed = value;
            if (!_PreviewsAllowed)
                StopAllPreviews();
        }
    }

    private bool _thisPreviewEnabled = false;
    public bool ThisPreviewEnabled
    {
        get { return _thisPreviewEnabled; }

        set
        {
            _thisPreviewEnabled = value;
            if (!_thisPreviewEnabled)
                StopThisPreview();
        }
    }

    public bool OverCollider { get; set; }

    // MONOBEHVIOUR METHODS
    void Awake()
    {
        ThisPreviewEnabled = ActivateInAwake;
        mm = GameObject.Find("MouseManager").GetComponent<MouseManager>();

    }



    void OnMouseEnter()
    {

        OverCollider = true;

        // Debug.Log("cursor");
        //if (PreviewsAllowed && ThisPreviewEnabled && mm.selectedObject.transform.parent.tag == "Hand")
        if (PreviewsAllowed && ThisPreviewEnabled && mm.selectedObject.name == "MonsterCard(Clone)")
        {
            if (mm.selectedObject.transform.parent.tag == "Hand")
            {
                PreviewThisObject();
                previewGameObject2.SetActive(false);
            }
            else if (mm.selectedObject.transform.parent.tag == "Table")
            {
                previewGameObject2.SetActive(true);

                PreviewThisObject2();
                previewGameObject.SetActive(false);
            }
        }
        else if (PreviewsAllowed && ThisPreviewEnabled && mm.selectedObject.name == "SpellCards(Clone)" || mm.selectedObject.name == "TrapCard(Clone)")
        {
            PreviewThisObject();
        }
        //else if (PreviewsAllowed && ThisPreviewEnabled && mm.selectedObject.transform.parent.tag == "Table")


        //getcomponentinparent.tag == hand + manggil object 
    }

    void OnMouseExit()
    {
        OverCollider = false;

        if (!PreviewingSomeCard())
        {
            StopAllPreviews();
            StopAllPreviews2();

        }

    }


    #region PriviewThisObjectt
    // OTHER METHODS
    void PreviewThisObject()
    {
        // 1) clone this card 
        // first disable the previous preview if there is one already
        StopAllPreviews();
        // 2) save this HoverPreview as curent
        currentlyViewing = this;
        // 3) enable Preview game object
        previewGameObject.SetActive(true);
        // 4) disable if we have what to disable
        /*    if (TurnThisOffWhenPreviewing!=null)
                TurnThisOffWhenPreviewing.SetActive(false); */
        // 5) tween to target position
        previewGameObject.transform.localPosition = Vector3.zero;
        previewGameObject.transform.localScale = Vector3.one;

        previewGameObject.transform.DOLocalMove(TargetPosition, 1f).SetEase(Ease.OutQuint);
        previewGameObject.transform.DOScale(TargetScale, 1f).SetEase(Ease.OutQuint);
    }


    void StopThisPreview()
    {
        previewGameObject.SetActive(false);
        previewGameObject.transform.localScale = Vector3.one;
        previewGameObject.transform.localPosition = Vector3.zero;
        if (TurnThisOffWhenPreviewing != null)
            TurnThisOffWhenPreviewing.SetActive(true);
    }

    // STATIC METHODS
    private static void StopAllPreviews()
    {
        if (currentlyViewing != null)
        {
            currentlyViewing.previewGameObject.SetActive(false);
            currentlyViewing.previewGameObject.transform.localScale = Vector3.one;
            currentlyViewing.previewGameObject.transform.localPosition = Vector3.zero;
            if (currentlyViewing.TurnThisOffWhenPreviewing != null)
                currentlyViewing.TurnThisOffWhenPreviewing.SetActive(true);
        }

    }
    #endregion

    #region Preview gameobject2
    void PreviewThisObject2()
    {
        // 1) clone this card 
        // first disable the previous preview if there is one already
        StopAllPreviews2();
        // 2) save this HoverPreview as curent
        currentlyViewing2 = this;
        // 3) enable Preview game object
        previewGameObject2.SetActive(true);
        // 4) disable if we have what to disable
        /*    if (TurnThisOffWhenPreviewing!=null)
                TurnThisOffWhenPreviewing.SetActive(false); */

        // 5) tween to target position
        previewGameObject2.transform.localPosition = Vector3.zero;
        previewGameObject2.transform.localScale = Vector3.one;

        previewGameObject2.transform.DOLocalMove(TargetPosition, 1f).SetEase(Ease.OutQuint);
        previewGameObject2.transform.DOScale(TargetScale, 1f).SetEase(Ease.OutQuint);
    }


    void StopThisPreview2()
    {
        previewGameObject2.SetActive(false);
        previewGameObject2.transform.localScale = Vector3.one;
        previewGameObject2.transform.localPosition = Vector3.zero;
        if (TurnThisOffWhenPreviewing != null)
            TurnThisOffWhenPreviewing.SetActive(true);
    }

    // STATIC METHODS
    private static void StopAllPreviews2()
    {
        if (currentlyViewing2 != null)
        {
            currentlyViewing2.previewGameObject2.SetActive(false);
            currentlyViewing2.previewGameObject2.transform.localScale = Vector3.one;
            currentlyViewing2.previewGameObject2.transform.localPosition = Vector3.zero;
            if (currentlyViewing2.TurnThisOffWhenPreviewing != null)
                currentlyViewing2.TurnThisOffWhenPreviewing.SetActive(true);
        }

    }
    #endregion


    private static bool PreviewingSomeCard()
    {
        if (!PreviewsAllowed)
            return false;

        HoverPreview[] allHoverBlowups = GameObject.FindObjectsOfType<HoverPreview>();

        foreach (HoverPreview hb in allHoverBlowups)
        {
            if (hb.OverCollider && hb.ThisPreviewEnabled)
                return true;
        }

        return false;
    }
}
