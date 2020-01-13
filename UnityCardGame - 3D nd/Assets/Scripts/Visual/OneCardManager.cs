using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OneCardManager : MonoBehaviour
{
    public CardAsset cardAsset;
    public GameObject buttonPanel;
 //   public OneCardManager previwManager;
    [Header("Text Componenet References")]
    public Text NameText;
    public Text DecrText;
    public Text AtkPoint;
    public Text DefPoint;

    public int Star;
    public Transform PosAnimation;
    public Transform EnPosAnimation;
    public GameObject ShapeAnimation;

    public int CardPosition;
    public int AtkFor1Turn = 1;

    [Header("Image Refrences")]
    public GameObject CardTitle;
    public GameObject CardType;
    public Image CardFrame;
    public Image cardImage;
    public Image cardAttribute;

    public enum TypeKartu { Monster, }

    void Start()
    {
        buttonPanel.SetActive(false);
    }

    void Awake()
    {
        
        if (cardAsset != null)
            readCardFromAsset();
    }

    void Update()
    {
        
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
        

        if (cardAsset.cardType1Num == 1)
        {
            AtkPoint.text = cardAsset.ATK.ToString();
            DefPoint.text = cardAsset.DEF.ToString();
            cardAttribute.sprite = cardAsset.monsterAttributePic;

            ShapeAnimation = cardAsset.Animation;

        //    PosAnimation.rotation = Quaternion.Euler(-90, -90, -90);
        //    EnPosAnimation.rotation = Quaternion.Euler(90, -90, -90);



            Star = cardAsset.level;
            /*Star = 0;
            for (int i = 0; i < cardAsset.level; i++)
            {
                Star++;
            }*/
        }

        /*
        if (previwManager != null)
        {
            previwManager.cardAsset = cardAsset;
            previwManager.readCardFromAsset();
        }
        */
    }
}
