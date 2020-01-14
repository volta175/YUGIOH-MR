using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;

public class dragDrop : MonoBehaviour
{
    //Initialize Variables
    public GameObject selectedCard;
    
    GameObject kartu;
    CardAsset ca;

    bool isMouseDragging;
    Vector3 offsetValue;
    Vector3 positionOfScreen;
    public Transform CardZone;
    public Transform SpellZone;
 //   public Transform CardZone2;

    // Use this for initialization
    void Start()
        {

        }

    void Update()
    {

            //Mouse Button Press Down
            if (Input.GetMouseButtonDown(0))
            {
                
                RaycastHit hitInfo;               
                
                kartu = ReturnClickedObject(out hitInfo);
                if (kartu != null)
                {
                    isMouseDragging = true;


                //   Debug.Log("hit"+this.gameObject.name);

                // kartu.transform.parent = gameObject.;

            /*    
             //   if (ca.cardType1Num == 1)
             //   {
                    Sequence s = DOTween.Sequence();

                    s.Append(kartu.transform.DOMove(CardZone.position, 1f));                  
                    s.Insert(0f, kartu.transform.DORotate(Vector3.one, 1f));
                    s.AppendInterval(1f);
                    s.OnComplete(() => { });
             //   } else if (ca.cardType1Num == 4)

             /*   {
                    Sequence s = DOTween.Sequence();
                    s.Append(kartu.transform.DOMove(SpellZone.position, 1f));
                    s.Insert(0f, kartu.transform.DORotate(Vector3.one, 1f));
                    s.AppendInterval(1f);
                    s.OnComplete(() => { });
                }
                else if (ca.cardType1Num == 5)

                {
                    Sequence s = DOTween.Sequence();
                    s.Append(kartu.transform.DOMove(SpellZone.position, 1f));
                    s.Insert(0f, kartu.transform.DORotate(Vector3.one, 1f));
                    s.AppendInterval(1f);
                    s.OnComplete(() => { });
                }*/




                //Converting world position to screen position.
                //    positionOfScreen = Camera.main.WorldToScreenPoint(kartu.transform.position);
                //    offsetValue = kartu.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, positionOfScreen.z));

            }


            }

            //Mouse Button Up
            if (Input.GetMouseButtonUp(0))
            {
                isMouseDragging = false;
            }

            /*
            //Is mouse Moving
            if (isMouseDragging)
            {
                //tracking mouse position.
                Vector3 currentScreenSpace = new Vector3(Input.mousePosition.x, Input.mousePosition.y, positionOfScreen.z);

                //converting screen position to world position with offset changes.
                Vector3 currentPosition = Camera.main.ScreenToWorldPoint(currentScreenSpace) + offsetValue;

                //It will update target gameobject's current postion.
                kartu.transform.position = currentPosition;
            }
            */

    }

        //Method to Return Clicked Object
    GameObject ReturnClickedObject(out RaycastHit hit)
    {
            GameObject target = null;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray.origin, ray.direction * 10, out hit))
            {
                GameObject hitobject = hit.transform.gameObject;
                selectCard(hitobject);
                target = hit.collider.gameObject;
            }
            return target;
    }

    void selectCard(GameObject obj)
    {
        if (selectedCard != null)
        {
            if (obj == selectedCard)
                return;
        }

        selectedCard = obj;

        Renderer[] rs = selectedCard.GetComponentsInChildren<Renderer>();
        foreach (Renderer r in rs)
        {
            Material m = r.material;
            m.color = Color.green;
            r.material = m;
        }
    }
    void ClearSelection()
    {
        if (selectedCard == null)
            return;

        Renderer[] rs = selectedCard.GetComponentsInChildren<Renderer>();
        foreach (Renderer r in rs)
        {
            Material m = r.material;
            m.color = Color.white;
            r.material = m;
        }

        selectedCard = null;
    }
}
