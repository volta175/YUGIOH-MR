using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OneCardManager : MonoBehaviour
{
    public CardAsset cardAsset;
    public OneCardManager previwManager;
    [Header("Text Componenet References")]
    public Text NameText;
    public Text DecrText;
    public Text AtkPoint;
    public Text DefPoint;
    public int Star;
    public Transform PosAnimation;
    private GameObject ShapeAnimation;
    

    [Header("Image Refrences")]
    //public GameObject CardTitle;
    //public GameObject CardType;
    public Image CardFrame;
    public Image cardImage;
    public Image cardAttribute;

    void Awake()
    {
        if (cardAsset != null)
            readCardFromAsset();

        // yang dipakai hanya line yang diatas
        // dibawah ini untuk manggil monster
        Instantiate(ShapeAnimation, PosAnimation.position, PosAnimation.rotation);
        //ShapeAnimation.transform.parent = PosAnimation.transform;

        /*if (Input.GetMouseButtonDown(0))
        {
            GetComponentInChildren<ChangePosMons>().ChangePos();
        }*/
    }

    private bool canBePlayedNow = false;

    public bool CanBePlayedNow
    {
        get
        {
            return canBePlayedNow;
        }

        set
        {
            canBePlayedNow = value;
        }
    }

    public void readCardFromAsset()
    {
        NameText.text = cardAsset.name;
        DecrText.text = cardAsset.Description;
        cardImage.sprite = cardAsset.CardImage;
        cardAttribute.sprite = cardAsset.monsterAttributePic;

        //menentukan posisi monster
        ShapeAnimation = cardAsset.Animation;
        PosAnimation.rotation = Quaternion.Euler(0, 90, 0);
        //sampai sini saja

        if (cardAsset.cardType1Num == 1)
        {
            AtkPoint.text = cardAsset.ATK.ToString();
            DefPoint.text = cardAsset.DEF.ToString();

            Star = 0;
            for (int i=0; i<cardAsset.level; i++)
            {
                Star++;
            }
        }

        if (previwManager != null)
        {
            previwManager.cardAsset = cardAsset;
            previwManager.readCardFromAsset();
        }
    }

    public void Update()
    {
        /*if (Input.GetMouseButtonDown(0))
        {
            GetComponentInChildren<ChangePosMons>().ChangePos();
        }*/
    }

    /* public void Spawnanimation()
     {
         Instantiate(ShapeAnimation, PosAnimation.position, PosAnimation.rotation);
     }*/
}
