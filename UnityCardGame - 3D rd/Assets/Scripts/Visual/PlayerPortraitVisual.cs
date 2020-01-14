using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using DG.Tweening;

public class PlayerPortraitVisual : MonoBehaviour {

    // TODO : get ID from players when game starts


    public CharacterAsset charAsset; //{ get; set;}

    [Header("Text Component References")]
 //   public Text NameText;
    public Text HealthText;

    [Header("Properties")]
    public Slider HealthSLider;

    [Header("Image References")]   
    public Image PortraitImage;
    public Image PortraitBackgroundImage;

    void Awake()
    {
        if (charAsset != null)
        {
            ApplyLookFromAsset();
        }
    }

    public void ApplyLookFromAsset()
    {       
     //   HealthText.text = charAsset.MaxHealth.ToString();
        PortraitImage.sprite = charAsset.AvatarImage;
        PortraitBackgroundImage.sprite = charAsset.AvatarBGImage;
    }
/*
    public void TakeDamage(int amount, int healthAfter)
    {
        if (amount > 0)
        {
            DamageEffect.CreateDamageEffect(transform.position, amount);
            HealthText.text = healthAfter.ToString();
        }
    }
*/

    public void Explode()
    {
        /*
        Instantiate(GlobalSettings.Instance.ExplosionPrefab, transform.position, Quaternion.identity);
        Sequence s = DOTween.Sequence();
        s.PrependInterval(2f);
        s.OnComplete(() => GlobalSettings.Instance.GameOverCanvas.SetActive(true));
        */
    }



}
