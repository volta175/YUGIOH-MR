using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using DG.Tweening;
using System;
using UnityEngine.Windows.Speech;

public class MouseManager : MonoBehaviour {

	public GameObject selectedObject;
    public GameObject Target;

    public int SummonCounter;

    OneCardManager OneCM;

    private int SelectedCardPos;
    private int TargetCardPos;
    /* 0 = ATK/aktif
     * 1 = Def tertutup
     * 2 = Def terbuka
     * 3 = set spell/trap
     */

    [Header ("Player 1")]
    public Transform MonsterZone;
    public Transform MonsterZone2;
    public Transform MonsterZone3;
    public Transform MonsterZone4;
    public Transform MonsterZone5;
    public Transform SpellZone;
    public Transform SpellZone2;
    public Transform SpellZone3;
    public Transform SpellZone4;
    public Transform SpellZone5;
    public Transform Graveyard;

    [Header ("Enemy")]
    public Transform EnMonsterZone;
    public Transform EnMonsterZone2;
    public Transform EnMonsterZone3;
    public Transform EnMonsterZone4;
    public Transform EnMonsterZone5;
    public Transform EnSpellZone;
    public Transform EnSpellZone2;
    public Transform EnSpellZone3;
    public Transform EnSpellZone4;
    public Transform EnSpellZone5;
    public Transform EnGraveyard;

    [Header("Player Properties")]
    public GameObject Player1;
    public GameObject Player2;

    public CharacterAsset charAssetP1;
    public CharacterAsset charAssetP2;

    public Slider HealthP1;
    public Slider HealthP2;

    [Header("Speech Properties")]
    public Text results;
    public string[] keyword = new string[] {"attack", "summon", "set"};
    public ConfidenceLevel confidence = ConfidenceLevel.Medium;

    protected PhraseRecognizer recognizer;
    protected string word = "Attack";

    // Use this for initialization
    void Start ()
    {
        selectedObject = null;
        Target = null;
        
        if (keyword != null)
        {
            recognizer = new KeywordRecognizer(keyword, confidence);
            recognizer.OnPhraseRecognized += Recognizer_OnPhraseRecognized;
            recognizer.Start();
        }
	}

    private void Recognizer_OnPhraseRecognized(PhraseRecognizedEventArgs args)
    {
        word = args.text;
        results.text = "You said: <b>" + word + "</b>";
    }

    private void Awake()
    {
        charAssetP1.MaxHealth = 8000;
        charAssetP2.MaxHealth = 8000;
        SummonCounter = 1;
    }

    // Update is called once per frame
    void Update ()
    {
        Save();

        switch (word)
        {
            case "attack":
                AtkDecision();
                break;
            case "summon":
                SummMonsDecision();
                break;
            case "set":
                SetMonstDecision();
                break;
        }
    }


    void Save()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit hitInfo;

            if (Physics.Raycast(ray, out hitInfo))
            {
                if (selectedObject == null)
                {
                    GameObject hitObject = hitInfo.transform.gameObject;
                    SelectObject(hitObject);
                }
                
                else if (selectedObject != null && Target == null)
                {
                    GameObject hitObjc = hitInfo.transform.gameObject;
                    Targets(hitObjc);
                    //attack();
                }
                
            }
            else
            {
                ClearSelection();
            }
        }
    }

    /*
    void fillTarget()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit hitInfo;

        if (selectedObject != null && Target == null)
        {
            if (Physics.Raycast(ray, out hitInfo))
            {
                GameObject hitObjc = hitInfo.transform.gameObject;
                Targets(hitObjc);
                
            }
        }
    }
    */

    public void SummonMons ()
    {
        
        OneCM = selectedObject.GetComponent<OneCardManager>();

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit hitInfo;
        if (Physics.Raycast(ray, out hitInfo))
        {
            if (hitInfo.collider.name == "MonsterCard(Clone)" && selectedObject != null)              
            {
                selectedObject.transform.parent = MonsterZone.transform;
                Sequence s = DOTween.Sequence();                
                s.Append(selectedObject.transform.DORotate(new Vector3(90, 0, 0), 1f));
                s.Append(selectedObject.transform.DOMove(MonsterZone.position, 1f));
                s.AppendInterval(1f);
                s.OnComplete(() =>
                {
                    GameObject Monster3D = Instantiate (OneCM.ShapeAnimation, OneCM.PosAnimation.position, OneCM.PosAnimation.rotation = Quaternion.Euler(180, 180, 180), transform.parent = selectedObject.transform);
                    Monster3D.tag = "3D";
                    ClearSelection();
                   // selectedObject = null;
                });

                if (MonsterZone.transform.childCount > 1)
                {

                    selectedObject.transform.parent = MonsterZone2.transform;
                    Sequence s2 = DOTween.Sequence();
                    s2.Append(selectedObject.transform.DORotate(new Vector3(90, 0, 0), 1f));
                    s2.Append(selectedObject.transform.DOMove(MonsterZone2.position, 1f));                    
                    s2.AppendInterval(1f);
                    s2.OnComplete(() =>
                    {
                        GameObject Monster3D = Instantiate(OneCM.ShapeAnimation, OneCM.PosAnimation.position, OneCM.PosAnimation.rotation = Quaternion.Euler(180, 180, 180), transform.parent = selectedObject.transform);
                        Monster3D.tag = "3D";
                        ClearSelection();
                        // selectedObject = null;
                    });
                }

                if (MonsterZone2.transform.childCount > 1)
                {

                    selectedObject.transform.parent = MonsterZone3.transform;
                    Sequence s2 = DOTween.Sequence();
                    s2.Append(selectedObject.transform.DORotate(new Vector3(90, 0, 0), 1f));
                    s2.Append(selectedObject.transform.DOMove(MonsterZone3.position, 1f));
                    s2.AppendInterval(1f);
                    s2.OnComplete(() =>
                    {
                        GameObject Monster3D = Instantiate(OneCM.ShapeAnimation, OneCM.PosAnimation.position, OneCM.PosAnimation.rotation = Quaternion.Euler(180, 180, 180), transform.parent = selectedObject.transform);
                        Monster3D.tag = "3D";
                        ClearSelection();
                        //  selectedObject = null;
                    });
                }

                if (MonsterZone3.transform.childCount > 1)
                {

                    selectedObject.transform.parent = MonsterZone4.transform;
                    Sequence s2 = DOTween.Sequence();
                    s2.Append(selectedObject.transform.DORotate(new Vector3(90, 0, 0), 1f));
                    s2.Append(selectedObject.transform.DOMove(MonsterZone4.position, 1f));
                    s2.AppendInterval(1f);
                    s2.OnComplete(() =>
                    {
                        GameObject Monster3D = Instantiate(OneCM.ShapeAnimation, OneCM.PosAnimation.position, OneCM.PosAnimation.rotation = Quaternion.Euler(180, 180, 180), transform.parent = selectedObject.transform);
                        Monster3D.tag = "3D";
                        ClearSelection();
                        //  selectedObject = null;
                    });
                }

                if (MonsterZone4.transform.childCount > 1)
                {

                    selectedObject.transform.parent = MonsterZone5.transform;
                    Sequence s2 = DOTween.Sequence();
                    s2.Append(selectedObject.transform.DORotate(new Vector3(90, 0, 0), 1f));
                    s2.Append(selectedObject.transform.DOMove(MonsterZone5.position, 1f));
                    s2.AppendInterval(1f);
                    s2.OnComplete(() =>
                    {
                        GameObject Monster3D = Instantiate(OneCM.ShapeAnimation, OneCM.PosAnimation.position, OneCM.PosAnimation.rotation = Quaternion.Euler(180, 180, 180), transform.parent = selectedObject.transform);
                        Monster3D.tag = "3D";
                        ClearSelection();
                        //  selectedObject = null;
                    });
                }
            }
           

        }
    }

    public void SetMons()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit hitInfo;

        if (Physics.Raycast(ray, out hitInfo))
        {
            //  Debug.Log("Mouse is over: " + hitInfo.collider.name );
            if (hitInfo.collider.name == "MonsterCard(Clone)" && selectedObject != null)
            {
                selectedObject.transform.parent = MonsterZone.transform;
                Sequence s = DOTween.Sequence();
                s.Append(selectedObject.transform.DORotate(new Vector3(-90, 180, -90), 1f));
                s.Append(selectedObject.transform.DOMove(MonsterZone.position, 1f));
                s.AppendInterval(1f);
                s.OnComplete(() =>
                {
                    ClearSelection();
                    //  selectedObject = null;
                });

                if (MonsterZone.transform.childCount > 1)
                {
                    selectedObject.transform.parent = MonsterZone2.transform;
                    Sequence s2 = DOTween.Sequence();
                    s2.Append(selectedObject.transform.DORotate(new Vector3(-90, 180, -90), 1f));
                    s2.Append(selectedObject.transform.DOMove(MonsterZone2.position, 1f));
                    s2.AppendInterval(1f);
                    s2.OnComplete(() =>
                    {
                        ClearSelection();
                        //  selectedObject = null;
                    });
                }

                if (MonsterZone2.transform.childCount > 1)
                {
                    selectedObject.transform.parent = MonsterZone3.transform;
                    Sequence s2 = DOTween.Sequence();
                    s2.Append(selectedObject.transform.DORotate(new Vector3(-90, 180, -90), 1f));
                    s2.Append(selectedObject.transform.DOMove(MonsterZone3.position, 1f));
                    s2.AppendInterval(1f);
                    s2.OnComplete(() =>
                    {
                        ClearSelection();
                        //   selectedObject = null;
                    });
                }

                if (MonsterZone3.transform.childCount > 1)
                {
                    selectedObject.transform.parent = MonsterZone4.transform;
                    Sequence s2 = DOTween.Sequence();
                    s2.Append(selectedObject.transform.DORotate(new Vector3(-90, 180, -90), 1f));
                    s2.Append(selectedObject.transform.DOMove(MonsterZone4.position, 1f));
                    s2.AppendInterval(1f);
                    s2.OnComplete(() =>
                    {
                        ClearSelection();
                        //   selectedObject = null;
                    });
                }

                if (MonsterZone4.transform.childCount > 1)
                {
                    selectedObject.transform.parent = MonsterZone5.transform;
                    Sequence s2 = DOTween.Sequence();
                    s2.Append(selectedObject.transform.DORotate(new Vector3(-90, 180, -90), 1f));
                    s2.Append(selectedObject.transform.DOMove(MonsterZone5.position, 1f));
                    s2.AppendInterval(1f);
                    s2.OnComplete(() =>
                    {
                        ClearSelection();
                        //   selectedObject = null;
                    });
                }
            }
        }

    }

    public void ActiveSTCard()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit hitInfo;
        if (Physics.Raycast(ray, out hitInfo))
        {
            if (hitInfo.collider.name == "SpellCards(Clone)" && selectedObject != null)
            {
                selectedObject.transform.parent = SpellZone.transform;
                Sequence s = DOTween.Sequence();
                s.Append(selectedObject.transform.DORotate(new Vector3(90, 0, 0), 1f));
                s.Append(selectedObject.transform.DOMove(SpellZone.position, 1f));
                s.AppendInterval(1f);
                s.OnComplete(() =>
                {
                    ClearSelection();
                    //  selectedObject = null;
                });

                if (SpellZone.transform.childCount > 1)
                {
                    selectedObject.transform.parent = SpellZone2.transform;
                    Sequence s2 = DOTween.Sequence();
                    s2.Append(selectedObject.transform.DORotate(new Vector3(90, 0, 0), 1f));
                    s2.Append(selectedObject.transform.DOMove(SpellZone2.position, 1f));
                    s2.AppendInterval(1f);
                    s2.OnComplete(() =>
                    {
                        ClearSelection();
                        //  selectedObject = null;
                    });
                }

                if (SpellZone2.transform.childCount > 1)
                {
                    selectedObject.transform.parent = SpellZone3.transform;
                    Sequence s2 = DOTween.Sequence();
                    s2.Append(selectedObject.transform.DORotate(new Vector3(90, 0, 0), 1f));
                    s2.Append(selectedObject.transform.DOMove(SpellZone3.position, 1f));
                    s2.AppendInterval(1f);
                    s2.OnComplete(() =>
                    {
                        ClearSelection();
                        // selectedObject = null;
                    });
                }

                if (SpellZone3.transform.childCount > 1)
                {
                    selectedObject.transform.parent = SpellZone4.transform;
                    Sequence s2 = DOTween.Sequence();
                    s2.Append(selectedObject.transform.DORotate(new Vector3(90, 0, 0), 1f));
                    s2.Append(selectedObject.transform.DOMove(SpellZone4.position, 1f));
                    s2.AppendInterval(1f);
                    s2.OnComplete(() =>
                    {
                        ClearSelection();
                        // selectedObject = null;
                    });
                }

                if (SpellZone4.transform.childCount > 1)
                {
                    selectedObject.transform.parent = SpellZone5.transform;
                    Sequence s2 = DOTween.Sequence();
                    s2.Append(selectedObject.transform.DORotate(new Vector3(90, 0, 0), 1f));
                    s2.Append(selectedObject.transform.DOMove(SpellZone5.position, 1f));
                    s2.AppendInterval(1f);
                    s2.OnComplete(() =>
                    {
                        ClearSelection();
                        //  selectedObject = null;
                    });
                }

            }
            else if (hitInfo.collider.name == "TrapCard(Clone)" && selectedObject != null)
            {
                selectedObject.transform.parent = SpellZone.transform;
                Sequence s = DOTween.Sequence();
                s.Append(selectedObject.transform.DORotate(new Vector3(90, 0, 0), 1f));
                s.Append(selectedObject.transform.DOMove(SpellZone.position, 1f));
                s.AppendInterval(1f);
                s.OnComplete(() => 
                {
                    ClearSelection();
                    // selectedObject = null;
                });

                if (SpellZone.transform.childCount > 1)
                {
                    selectedObject.transform.parent = SpellZone2.transform;
                    Sequence s2 = DOTween.Sequence();
                    s2.Append(selectedObject.transform.DORotate(new Vector3(90, 0, 0), 1f));
                    s2.Append(selectedObject.transform.DOMove(SpellZone2.position, 1f));
                    s2.AppendInterval(1f);
                    s2.OnComplete(() =>
                    {
                        ClearSelection();
                        //  selectedObject = null;
                    });
                }

                if (SpellZone2.transform.childCount > 1)
                {
                    selectedObject.transform.parent = SpellZone3.transform;
                    Sequence s2 = DOTween.Sequence();
                    s2.Append(selectedObject.transform.DORotate(new Vector3(90, 0, 0), 1f));
                    s2.Append(selectedObject.transform.DOMove(SpellZone3.position, 1f));
                    s2.AppendInterval(1f);
                    s2.OnComplete(() =>
                    {
                        ClearSelection();
                        //  selectedObject = null;
                    });
                }

                if (SpellZone3.transform.childCount > 1)
                {
                    selectedObject.transform.parent = SpellZone4.transform;
                    Sequence s2 = DOTween.Sequence();
                    s2.Append(selectedObject.transform.DORotate(new Vector3(90, 0, 0), 1f));
                    s2.Append(selectedObject.transform.DOMove(SpellZone4.position, 1f));
                    s2.AppendInterval(1f);
                    s2.OnComplete(() =>
                    {
                        ClearSelection();
                        //  selectedObject = null;
                    });
                }

                if (SpellZone4.transform.childCount > 1)
                {
                    selectedObject.transform.parent = SpellZone5.transform;
                    Sequence s2 = DOTween.Sequence();
                    s2.Append(selectedObject.transform.DORotate(new Vector3(90, 0, 0), 1f));
                    s2.Append(selectedObject.transform.DOMove(SpellZone5.position, 1f));
                    s2.AppendInterval(1f);
                    s2.OnComplete(() =>
                    {
                        ClearSelection();
                        //  selectedObject = null;
                    });
                }
            }
        }
    }

    public void SetSTCard()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit hitInfo;
        if (Physics.Raycast(ray, out hitInfo))
        {
            if (hitInfo.collider.name == "SpellCards(Clone)" && selectedObject != null)
            {
                selectedObject.transform.parent = SpellZone.transform;
                Sequence s = DOTween.Sequence();
                s.Append(selectedObject.transform.DORotate(new Vector3(270, 90, 90), 1f));
                s.Append(selectedObject.transform.DOMove(SpellZone.position, 1f));
                s.AppendInterval(1f);
                s.OnComplete(() => {
                    ClearSelection();
                    // selectedObject = null;
                });

                if (SpellZone.transform.childCount > 1)
                {
                    selectedObject.transform.parent = SpellZone2.transform;
                    Sequence s2 = DOTween.Sequence();
                    s2.Append(selectedObject.transform.DORotate(new Vector3(270, 90, 90), 1f));
                    s2.Append(selectedObject.transform.DOMove(SpellZone2.position, 1f));
                    s2.AppendInterval(1f);
                    s2.OnComplete(() =>
                    {
                        ClearSelection();
                        //  selectedObject = null;
                    });
                }

                if (SpellZone2.transform.childCount > 1)
                {
                    selectedObject.transform.parent = SpellZone3.transform;
                    Sequence s2 = DOTween.Sequence();
                    s2.Append(selectedObject.transform.DORotate(new Vector3(270, 90, 90), 1f));
                    s2.Append(selectedObject.transform.DOMove(SpellZone3.position, 1f));
                    s2.AppendInterval(1f);
                    s2.OnComplete(() =>
                    {
                        ClearSelection();
                        //  selectedObject = null;
                    });
                }

                if (SpellZone3.transform.childCount > 1)
                {
                    selectedObject.transform.parent = SpellZone4.transform;
                    Sequence s2 = DOTween.Sequence();
                    s2.Append(selectedObject.transform.DORotate(new Vector3(270, 90, 90), 1f));
                    s2.Append(selectedObject.transform.DOMove(SpellZone4.position, 1f));
                    s2.AppendInterval(1f);
                    s2.OnComplete(() =>
                    {
                        ClearSelection();
                        //   selectedObject = null;
                    });
                }

                if (SpellZone4.transform.childCount > 1)
                {
                    selectedObject.transform.parent = SpellZone5.transform;
                    Sequence s2 = DOTween.Sequence();
                    s2.Append(selectedObject.transform.DORotate(new Vector3(270, 90, 90), 1f));
                    s2.Append(selectedObject.transform.DOMove(SpellZone5.position, 1f));
                    s2.AppendInterval(1f);
                    s2.OnComplete(() =>
                    {
                        ClearSelection();
                        //  selectedObject = null;
                    });
                }

            }
            else if (hitInfo.collider.name == "TrapCard(Clone)" && selectedObject != null)
            {
                selectedObject.transform.parent = SpellZone.transform;
                Sequence s = DOTween.Sequence();
                s.Append(selectedObject.transform.DORotate(new Vector3(270, 90, 90), 1f));
                s.Append(selectedObject.transform.DOMove(SpellZone.position, 1f));
                s.AppendInterval(1f);
                s.OnComplete(() => {
                    ClearSelection();
                    // selectedObject = null;
                });

                if (SpellZone.transform.childCount > 1)
                {
                    selectedObject.transform.parent = SpellZone2.transform;
                    Sequence s2 = DOTween.Sequence();
                    s2.Append(selectedObject.transform.DORotate(new Vector3(270, 90, 90), 1f));
                    s2.Append(selectedObject.transform.DOMove(SpellZone2.position, 1f));
                    s2.AppendInterval(1f);
                    s2.OnComplete(() =>
                    {
                        ClearSelection();
                        //  selectedObject = null;
                    });
                }

                if (SpellZone2.transform.childCount > 1)
                {
                    selectedObject.transform.parent = SpellZone3.transform;
                    Sequence s2 = DOTween.Sequence();
                    s2.Append(selectedObject.transform.DORotate(new Vector3(270, 90, 90), 1f));
                    s2.Append(selectedObject.transform.DOMove(SpellZone3.position, 1f));
                    s2.AppendInterval(1f);
                    s2.OnComplete(() =>
                    {
                        ClearSelection();
                        //  selectedObject = null;
                    });
                }

                if (SpellZone3.transform.childCount > 1)
                {
                    selectedObject.transform.parent = SpellZone4.transform;
                    Sequence s2 = DOTween.Sequence();
                    s2.Append(selectedObject.transform.DORotate(new Vector3(270, 90, 90), 1f));
                    s2.Append(selectedObject.transform.DOMove(SpellZone4.position, 1f));
                    s2.AppendInterval(1f);
                    s2.OnComplete(() =>
                    {
                        ClearSelection();
                        //  selectedObject = null;
                    });
                }

                if (SpellZone4.transform.childCount > 1)
                {
                    selectedObject.transform.parent = SpellZone5.transform;
                    Sequence s2 = DOTween.Sequence();
                    s2.Append(selectedObject.transform.DORotate(new Vector3(270, 90, 90), 1f));
                    s2.Append(selectedObject.transform.DOMove(SpellZone5.position, 1f));
                    s2.AppendInterval(1f);
                    s2.OnComplete(() =>
                    {
                        ClearSelection();
                        //  selectedObject = null;
                    });
                }
            }
        }
    }


    public void EnSummonMons()
    {
        {
            OneCM = selectedObject.GetComponent<OneCardManager>();

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit hitInfo;

            if (Physics.Raycast(ray, out hitInfo))
            {
                if (hitInfo.collider.name == "MonsterCard(Clone)" && selectedObject != null)
                {
                    selectedObject.transform.parent = EnMonsterZone.transform;
                    Sequence s = DOTween.Sequence();
                    s.Append(selectedObject.transform.DORotate(new Vector3(90, 0, 0), 1f));
                    s.Append(selectedObject.transform.DOMove(EnMonsterZone.position, 1f));
                    s.AppendInterval(1f);
                    s.OnComplete(() => {
                        GameObject Monster3D = Instantiate(OneCM.ShapeAnimation, OneCM.PosAnimation.position, OneCM.PosAnimation.rotation = Quaternion.Euler(180, 0, 180), transform.parent = selectedObject.transform);
                        Monster3D.tag = "3D";
                        ClearSelection();
                        // selectedObject = null;
                    });

                    if (EnMonsterZone.transform.childCount > 1)
                    {
                        selectedObject.transform.parent = EnMonsterZone2.transform;
                        Sequence s2 = DOTween.Sequence();
                        s2.Append(selectedObject.transform.DORotate(new Vector3(90, 0, 0), 1f));
                        s2.Append(selectedObject.transform.DOMove(EnMonsterZone2.position, 1f));
                        s2.AppendInterval(1f);
                        s2.OnComplete(() => {
                            GameObject Monster3D = Instantiate(OneCM.ShapeAnimation, OneCM.PosAnimation.position, OneCM.PosAnimation.rotation = Quaternion.Euler(180, 0, 180), transform.parent = selectedObject.transform);
                            Monster3D.tag = "3D";
                            ClearSelection();
                            //  selectedObject = null;
                        });
                    }

                    if (EnMonsterZone2.transform.childCount > 1)
                    {
                        selectedObject.transform.parent = EnMonsterZone3.transform;
                        Sequence s2 = DOTween.Sequence();
                        s2.Append(selectedObject.transform.DORotate(new Vector3(90, 0, 0), 1f));
                        s2.Append(selectedObject.transform.DOMove(EnMonsterZone3.position, 1f));
                        s2.AppendInterval(1f);
                        s2.OnComplete(() => {
                            GameObject Monster3D = Instantiate(OneCM.ShapeAnimation, OneCM.PosAnimation.position, OneCM.PosAnimation.rotation = Quaternion.Euler(180, 0, 180), transform.parent = selectedObject.transform);
                            Monster3D.tag = "3D";
                            ClearSelection();
                            //  selectedObject = null;
                        });
                    }

                    if (EnMonsterZone3.transform.childCount > 1)
                    {
                        selectedObject.transform.parent = EnMonsterZone4.transform;
                        Sequence s2 = DOTween.Sequence();
                        s2.Append(selectedObject.transform.DORotate(new Vector3(90, 0, 0), 1f));
                        s2.Append(selectedObject.transform.DOMove(EnMonsterZone4.position, 1f));
                        s2.AppendInterval(1f);
                        s2.OnComplete(() => {
                            GameObject Monster3D = Instantiate(OneCM.ShapeAnimation, OneCM.PosAnimation.position, OneCM.PosAnimation.rotation = Quaternion.Euler(180, 0, 180), transform.parent = selectedObject.transform);
                            Monster3D.tag = "3D";
                            ClearSelection();
                            //  selectedObject = null;
                        });
                    }

                    if (EnMonsterZone4.transform.childCount > 1)
                    {
                        selectedObject.transform.parent = EnMonsterZone5.transform;
                        Sequence s2 = DOTween.Sequence();
                        s2.Append(selectedObject.transform.DORotate(new Vector3(90, 0, 0), 1f));
                        s2.Append(selectedObject.transform.DOMove(EnMonsterZone5.position, 1f));
                        s2.AppendInterval(1f);
                        s2.OnComplete(() => {
                            GameObject Monster3D = Instantiate(OneCM.ShapeAnimation, OneCM.PosAnimation.position, OneCM.PosAnimation.rotation = Quaternion.Euler(180, 0, 180), transform.parent = selectedObject.transform);
                            Monster3D.tag = "3D";
                            ClearSelection();
                            //  selectedObject = null;
                        });
                    }


                }
            }

        }
    }

    public void EnSetMons()
    {

        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit hitInfo;

            if (Physics.Raycast(ray, out hitInfo))
            {
                if (hitInfo.collider.name == "MonsterCard(Clone)" && selectedObject != null)
                {
                    selectedObject.transform.parent = EnMonsterZone.transform;
                    Sequence s = DOTween.Sequence();
                    s.Append(selectedObject.transform.DORotate(new Vector3(-90, 180, -90), 1f));
                    s.Append(selectedObject.transform.DOMove(EnMonsterZone.position, 1f));
                    s.AppendInterval(1f);
                    s.OnComplete(() =>
                    {
                        ClearSelection();
                        //  selectedObject = null;
                    });

                    if (EnMonsterZone.transform.childCount > 1)
                    {
                        selectedObject.transform.parent = EnMonsterZone2.transform;
                        Sequence s2 = DOTween.Sequence();
                        s2.Append(selectedObject.transform.DORotate(new Vector3(-90, 180, -90), 1f));
                        s2.Append(selectedObject.transform.DOMove(EnMonsterZone2.position, 1f));
                        s2.AppendInterval(1f);
                        s2.OnComplete(() =>
                        {
                            ClearSelection();
                            //  selectedObject = null;
                        });
                    }

                    if (EnMonsterZone2.transform.childCount > 1)
                    {
                        selectedObject.transform.parent = EnMonsterZone3.transform;
                        Sequence s2 = DOTween.Sequence();
                        s2.Append(selectedObject.transform.DORotate(new Vector3(-90, 180, -90), 1f));
                        s2.Append(selectedObject.transform.DOMove(EnMonsterZone3.position, 1f));
                        s2.AppendInterval(1f);
                        s2.OnComplete(() =>
                        {
                            ClearSelection();
                            //   selectedObject = null;
                        });
                    }

                    if (EnMonsterZone3.transform.childCount > 1)
                    {
                        selectedObject.transform.parent = EnMonsterZone4.transform;
                        Sequence s2 = DOTween.Sequence();
                        s2.Append(selectedObject.transform.DORotate(new Vector3(-90, 180, -90), 1f));
                        s2.Append(selectedObject.transform.DOMove(EnMonsterZone4.position, 1f));
                        s2.AppendInterval(1f);
                        s2.OnComplete(() =>
                        {
                            ClearSelection();
                            //   selectedObject = null;
                        });
                    }

                    if (EnMonsterZone4.transform.childCount > 1)
                    {
                        selectedObject.transform.parent = EnMonsterZone5.transform;
                        Sequence s2 = DOTween.Sequence();
                        s2.Append(selectedObject.transform.DORotate(new Vector3(-90, 180, -90), 1f));
                        s2.Append(selectedObject.transform.DOMove(EnMonsterZone5.position, 1f));
                        s2.AppendInterval(1f);
                        s2.OnComplete(() =>
                        {
                            ClearSelection();
                            //   selectedObject = null;
                        });
                    }
                }
            }

        }
    }

    public void EnActiveSTCard()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit hitInfo;

        if (Physics.Raycast(ray, out hitInfo))
        {
            if (hitInfo.collider.name == "SpellCards(Clone)" && selectedObject != null)
            {
                selectedObject.transform.parent = EnSpellZone.transform;
                Sequence s = DOTween.Sequence();
                s.Append(selectedObject.transform.DORotate(new Vector3(90, 0, 0), 1f));
                s.Append(selectedObject.transform.DOMove(EnSpellZone.position, 1f));
                s.AppendInterval(1f);
                s.OnComplete(() => {
                    ClearSelection();
                    //  selectedObject = null;
                });

                if (EnSpellZone.transform.childCount > 1)
                {
                    selectedObject.transform.parent = EnSpellZone2.transform;
                    Sequence s2 = DOTween.Sequence();
                    s2.Append(selectedObject.transform.DORotate(new Vector3(90, 0, 0), 1f));
                    s2.Append(selectedObject.transform.DOMove(SpellZone2.position, 1f));
                    s2.AppendInterval(1f);
                    s2.OnComplete(() => {
                        ClearSelection();
                        //  selectedObject = null;
                    });
                }

                if (EnSpellZone2.transform.childCount > 1)
                {
                    selectedObject.transform.parent = EnSpellZone3.transform;
                    Sequence s2 = DOTween.Sequence();
                    s2.Append(selectedObject.transform.DORotate(new Vector3(90, 0, 0), 1f));
                    s2.Append(selectedObject.transform.DOMove(EnSpellZone3.position, 1f));
                    s2.AppendInterval(1f);
                    s2.OnComplete(() => {
                        ClearSelection();
                        //  selectedObject = null;
                    });
                }

                if (EnSpellZone3.transform.childCount > 1)
                {
                    selectedObject.transform.parent = EnSpellZone4.transform;
                    Sequence s2 = DOTween.Sequence();
                    s2.Append(selectedObject.transform.DORotate(new Vector3(90, 0, 0), 1f));
                    s2.Append(selectedObject.transform.DOMove(EnSpellZone4.position, 1f));
                    s2.AppendInterval(1f);
                    s2.OnComplete(() => {
                        ClearSelection();
                        //  selectedObject = null;
                    });
                }

                if (EnSpellZone4.transform.childCount > 1)
                {
                    selectedObject.transform.parent = EnSpellZone5.transform;
                    Sequence s2 = DOTween.Sequence();
                    s2.Append(selectedObject.transform.DORotate(new Vector3(90, 0, 0), 1f));
                    s2.Append(selectedObject.transform.DOMove(EnSpellZone5.position, 1f));
                    s2.AppendInterval(1f);
                    s2.OnComplete(() => {
                        ClearSelection();
                        //  selectedObject = null;
                    });
                }

            }
            else if (hitInfo.collider.name == "TrapCard(Clone)" && selectedObject != null)
            {
                selectedObject.transform.parent = EnSpellZone.transform;
                Sequence s = DOTween.Sequence();
                s.Append(selectedObject.transform.DORotate(new Vector3(90, 0, 0), 1f));
                s.Append(selectedObject.transform.DOMove(EnSpellZone.position, 1f));
                s.AppendInterval(1f);
                s.OnComplete(() => {
                    ClearSelection();
                    // selectedObject = null;
                });

                if (EnSpellZone.transform.childCount > 1)
                {
                    selectedObject.transform.parent = EnSpellZone2.transform;
                    Sequence s2 = DOTween.Sequence();
                    s2.Append(selectedObject.transform.DORotate(new Vector3(90, 0, 0), 1f));
                    s2.Append(selectedObject.transform.DOMove(EnSpellZone2.position, 1f));
                    s2.AppendInterval(1f);
                    s2.OnComplete(() => {
                        ClearSelection();
                        // selectedObject = null;
                    });
                }

                if (EnSpellZone2.transform.childCount > 1)
                {
                    selectedObject.transform.parent = SpellZone3.transform;
                    Sequence s2 = DOTween.Sequence();
                    s2.Append(selectedObject.transform.DORotate(new Vector3(90, 0, 0), 1f));
                    s2.Append(selectedObject.transform.DOMove(SpellZone3.position, 1f));
                    s2.AppendInterval(1f);
                    s2.OnComplete(() => {
                        ClearSelection();
                        //  selectedObject = null;
                    });
                }

                if (EnSpellZone3.transform.childCount > 1)
                {
                    selectedObject.transform.parent = EnSpellZone4.transform;
                    Sequence s2 = DOTween.Sequence();
                    s2.Append(selectedObject.transform.DORotate(new Vector3(90, 0, 0), 1f));
                    s2.Append(selectedObject.transform.DOMove(EnSpellZone4.position, 1f));
                    s2.AppendInterval(1f);
                    s2.OnComplete(() => {
                        ClearSelection();
                        //  selectedObject = null;
                    });
                }

                if (EnSpellZone4.transform.childCount > 1)
                {
                    selectedObject.transform.parent = EnSpellZone5.transform;
                    Sequence s2 = DOTween.Sequence();
                    s2.Append(selectedObject.transform.DORotate(new Vector3(90, 0, 0), 1f));
                    s2.Append(selectedObject.transform.DOMove(EnSpellZone5.position, 1f));
                    s2.AppendInterval(1f);
                    s2.OnComplete(() => {
                        ClearSelection();
                        //  selectedObject = null;
                    });
                }
            }
        }
            
    }

    public void EnSetSTCard()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit hitInfo;

        if (Physics.Raycast(ray, out hitInfo))
        {
            if (hitInfo.collider.name == "SpellCards(Clone)" && selectedObject != null)
            {
                selectedObject.transform.parent = EnSpellZone.transform;
                Sequence s = DOTween.Sequence();
                s.Append(selectedObject.transform.DORotate(new Vector3(270, 90, 90), 1f));
                s.Append(selectedObject.transform.DOMove(EnSpellZone.position, 1f));
                s.AppendInterval(1f);
                s.OnComplete(() => {
                    ClearSelection();
                    // selectedObject = null;
                });

                if (EnSpellZone.transform.childCount > 1)
                {
                    selectedObject.transform.parent = EnSpellZone2.transform;
                    Sequence s2 = DOTween.Sequence();
                    s2.Append(selectedObject.transform.DORotate(new Vector3(270, 90, 90), 1f));
                    s2.Append(selectedObject.transform.DOMove(EnSpellZone2.position, 1f));
                    s2.AppendInterval(1f);
                    s2.OnComplete(() =>
                    {
                        ClearSelection();
                        // selectedObject = null;
                    });
                }

                if (EnSpellZone2.transform.childCount > 1)
                {
                    selectedObject.transform.parent = EnSpellZone3.transform;
                    Sequence s2 = DOTween.Sequence();
                    s2.Append(selectedObject.transform.DORotate(new Vector3(270, 90, 90), 1f));
                    s2.Append(selectedObject.transform.DOMove(EnSpellZone3.position, 1f));
                    s2.AppendInterval(1f);
                    s2.OnComplete(() =>
                    {
                        ClearSelection();
                        //  selectedObject = null;
                    });
                }

                if (EnSpellZone3.transform.childCount > 1)
                {
                    selectedObject.transform.parent = EnSpellZone4.transform;
                    Sequence s2 = DOTween.Sequence();
                    s2.Append(selectedObject.transform.DORotate(new Vector3(270, 90, 90), 1f));
                    s2.Append(selectedObject.transform.DOMove(EnSpellZone4.position, 1f));
                    s2.AppendInterval(1f);
                    s2.OnComplete(() =>
                    {
                        ClearSelection();
                        // selectedObject = null;
                    });
                }

                if (EnSpellZone4.transform.childCount > 1)
                {
                    selectedObject.transform.parent = EnSpellZone5.transform;
                    Sequence s2 = DOTween.Sequence();
                    s2.Append(selectedObject.transform.DORotate(new Vector3(270, 90, 90), 1f));
                    s2.Append(selectedObject.transform.DOMove(EnSpellZone5.position, 1f));
                    s2.AppendInterval(1f);
                    s2.OnComplete(() =>
                    {
                        ClearSelection();
                        // selectedObject = null;
                    });
                }

            }
            else if (hitInfo.collider.name == "TrapCard(Clone)" && selectedObject != null)
            {
                selectedObject.transform.parent = EnSpellZone.transform;
                Sequence s = DOTween.Sequence();
                s.Append(selectedObject.transform.DORotate(new Vector3(270, 90, 90), 1f));
                s.Append(selectedObject.transform.DOMove(EnSpellZone.position, 1f));
                s.AppendInterval(1f);
                s.OnComplete(() => {
                    ClearSelection();
                    // selectedObject = null;
                });

                if (EnSpellZone.transform.childCount > 1)
                {
                    selectedObject.transform.parent = EnSpellZone2.transform;
                    Sequence s2 = DOTween.Sequence();
                    s2.Append(selectedObject.transform.DORotate(new Vector3(270, 90, 90), 1f));
                    s2.Append(selectedObject.transform.DOMove(EnSpellZone2.position, 1f));
                    s2.AppendInterval(1f);
                    s2.OnComplete(() =>
                    {
                        ClearSelection();
                        // selectedObject = null;
                    });
                }

                if (EnSpellZone2.transform.childCount > 1)
                {
                    selectedObject.transform.parent = EnSpellZone3.transform;
                    Sequence s2 = DOTween.Sequence();
                    s2.Append(selectedObject.transform.DORotate(new Vector3(270, 90, 90), 1f));
                    s2.Append(selectedObject.transform.DOMove(SpellZone3.position, 1f));
                    s2.AppendInterval(1f);
                    s2.OnComplete(() =>
                    {
                        ClearSelection();
                        // selectedObject = null;
                    });
                }

                if (EnSpellZone3.transform.childCount > 1)
                {
                    selectedObject.transform.parent = EnSpellZone4.transform;
                    Sequence s2 = DOTween.Sequence();
                    s2.Append(selectedObject.transform.DORotate(new Vector3(270, 90, 90), 1f));
                    s2.Append(selectedObject.transform.DOMove(EnSpellZone4.position, 1f));
                    s2.AppendInterval(1f);
                    s2.OnComplete(() =>
                    {
                        ClearSelection();
                        //  selectedObject = null;
                    });
                }

                if (EnSpellZone4.transform.childCount > 1)
                {
                    selectedObject.transform.parent = EnSpellZone5.transform;
                    Sequence s2 = DOTween.Sequence();
                    s2.Append(selectedObject.transform.DORotate(new Vector3(270, 90, 90), 1f));
                    s2.Append(selectedObject.transform.DOMove(EnSpellZone5.position, 1f));
                    s2.AppendInterval(1f);
                    s2.OnComplete(() =>
                    {
                        ClearSelection();
                        //  selectedObject = null;
                    });
                }
            }
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        PlayerPortraitVisual pl1, pl2;

        int ATK;
        int DEF;
        int enATK;
        int enDEF;
        int dmgLeft;

        int TargetATK;

        int playerHealth1 = charAssetP1.MaxHealth;
        int playerHealth2 = charAssetP2.MaxHealth;

        if (charAssetP1.MaxHealth <= 0)
        {
            charAssetP1.MaxHealth = 0;
        }

        if (charAssetP2.MaxHealth <= 0)
        {
            charAssetP2.MaxHealth = 0;
        }

        ATK = (Convert.ToInt32(selectedObject.GetComponent<OneCardManager>().AtkPoint.text));
        DEF = (Convert.ToInt32(selectedObject.GetComponent<OneCardManager>().DefPoint.text));

        pl1 = Player1.GetComponent<PlayerPortraitVisual>();
        pl2 = Player2.GetComponent<PlayerPortraitVisual>();

        //Direct Attack
        if (other.gameObject.tag == "Player1" /*&& EnMonsterZone.parent == null && EnMonsterZone2.parent == null && EnMonsterZone3.parent == null
            && EnMonsterZone4.parent == null && EnMonsterZone5.parent == null*/) //tambah syarat kartu d field harus kosong
        {
            Debug.Log("collision player 1");

            int i;
            int j;
            int x;

            j = ATK;
            Debug.Log(j);

            i = playerHealth1;
            Debug.Log(i);

            x = i - j;
            Debug.Log(x);

            pl1.HealthText.text = x.ToString();
            charAssetP1.MaxHealth = x;
            HealthP1.value = x;
        }

        else if (other.gameObject.tag == "Player2" /*&& EnMonsterZone.parent == null && EnMonsterZone2.parent == null && EnMonsterZone3.parent == null && EnMonsterZone4.parent == null && EnMonsterZone5.parent == null*/) //tambah syarat kartu d field harus kosong
        {
            Debug.Log("collision player 2");

            int i;
            int j;
            int x;

            j = ATK;
            Debug.Log(j);

            i = playerHealth2;
            Debug.Log(i);

            x = i - j;
            Debug.Log(x);

            pl2.HealthText.text = x.ToString();
            charAssetP2.MaxHealth = x;
            HealthP2.value = x;
        }

        //Attack monster/card
        else if (other.gameObject.tag == "TopCard")
        {
            Debug.Log("Top Card Collision");

            enATK = (Convert.ToInt32(Target.GetComponent<OneCardManager>().AtkPoint.text));
            enDEF = (Convert.ToInt32(Target.GetComponent<OneCardManager>().DefPoint.text));

            TargetATK = Target.GetComponent<OneCardManager>().CardPosition;

            if (TargetATK == 0)
            {
                Debug.Log("serangan 1");
                dmgLeft = ATK - enATK;
                Debug.Log(dmgLeft);

                if (dmgLeft > 0)
                {
                    int x;

                    x = playerHealth2 - dmgLeft;
                    pl2.HealthText.text = x.ToString();
                    charAssetP2.MaxHealth = x;
                    HealthP2.value = x;

                    TargetToP2Graveyard();
                }
                else if (dmgLeft < 0)
                {
                    int x;

                    x = playerHealth1 + dmgLeft;
                    pl1.HealthText.text = x.ToString();
                    charAssetP1.MaxHealth = x;
                    HealthP1.value = x;

                    SelectedToP1Graveyard();
                }
                else if (dmgLeft == 0)
                {
                    TargetToP2Graveyard();
                    SelectedToP1Graveyard();
                }
            }

            else if (TargetATK == 1)
            {
                Debug.Log("serangan 2");
                dmgLeft = ATK - enDEF;
                Debug.Log(dmgLeft);

                if (dmgLeft > 0)
                {
                    FlipAttcked();
                    TargetToP2Graveyard();
                }
                else if (dmgLeft < 0)
                {
                    FlipAttcked();
                    int x;

                    x = playerHealth1 + dmgLeft;
                    pl1.HealthText.text = x.ToString();
                    charAssetP1.MaxHealth = x;
                    HealthP1.value = x;
                }
                else if (dmgLeft == 0)
                {
                    FlipAttcked();
                }

            }
            else if (TargetATK == 2)
            {
                Debug.Log("serangan 3");
                dmgLeft = ATK - enDEF;
                Debug.Log(dmgLeft);

                if (dmgLeft > 0)
                {
                    TargetToP2Graveyard();
                }
                else if (dmgLeft < 0)
                {
                    int x;

                    x = playerHealth1 + dmgLeft;
                    pl1.HealthText.text = x.ToString();
                    charAssetP1.MaxHealth = x;
                    HealthP1.value = x;
                }
                else if (dmgLeft == 0)
                {
                    
                }
            }

        }
        else if (other.gameObject.tag == "LowCard")
        {
            Debug.Log("Low Card Collision");

            enATK = (Convert.ToInt32(Target.GetComponent<OneCardManager>().AtkPoint.text));
            enDEF = (Convert.ToInt32(Target.GetComponent<OneCardManager>().DefPoint.text));

            TargetATK = Target.GetComponent<OneCardManager>().CardPosition;

            if (TargetATK == 0)
            {
                dmgLeft = ATK - enATK;
                Debug.Log(dmgLeft);

                if (dmgLeft > 0)
                {
                    int x;

                    x = playerHealth1 - dmgLeft;
                    pl1.HealthText.text = x.ToString();
                    charAssetP1.MaxHealth = x;
                    HealthP1.value = x;

                    TargetToP1Graveyard();
                }
                else if (dmgLeft < 0)
                {
                    int x;

                    x = playerHealth2 + dmgLeft;
                    pl2.HealthText.text = x.ToString();
                    charAssetP2.MaxHealth = x;
                    HealthP2.value = x;

                    SelectedToP2Graveyard();
                }
                else if (dmgLeft == 0)
                {
                    TargetToP1Graveyard();
                    SelectedToP2Graveyard();
                }
            }

            else if (TargetATK == 1)
            {

                dmgLeft = ATK - enDEF;
                Debug.Log(dmgLeft);

                if (dmgLeft > 0)
                {
                    FlipAttcked();
                    TargetToP1Graveyard();
                }
                else if (dmgLeft < 0)
                {
                    FlipAttcked();
                    int x;

                    x = playerHealth2 + dmgLeft;
                    pl2.HealthText.text = x.ToString();
                    charAssetP2.MaxHealth = x;
                    HealthP2.value = x;
                }
                else if (dmgLeft == 0)
                {
                    FlipAttcked();
                }

            }
            else if (TargetATK == 2)
            {
                dmgLeft = ATK - enDEF;
                Debug.Log(dmgLeft);

                if (dmgLeft > 0)
                {
                    TargetToP1Graveyard();
                }
                else if (dmgLeft < 0)
                {
                    int x;

                    x = playerHealth2 + dmgLeft;
                    pl2.HealthText.text = x.ToString();
                    charAssetP2.MaxHealth = x;
                    HealthP2.value = x;
                }
                else if (dmgLeft == 0)
                {

                }
            }
        }    
    }

    public void Attack()
    {
        
        Animate launch;
        launch = selectedObject.GetComponentInChildren<Animate>();

        int selectATK;
        selectATK = selectedObject.GetComponent<OneCardManager>().CardPosition;

        int canATK;
        canATK = selectedObject.GetComponent<OneCardManager>().AtkFor1Turn;
        
        if(selectATK == 0 && canATK == 1)
        {
            canATK -= 1;
            Debug.Log(canATK);
            selectedObject.GetComponent<OneCardManager>().AtkFor1Turn = canATK;

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit hitInfo;

            if (Physics.Raycast(ray, out hitInfo))
            {
                // Debug.Log("Mouse is over: " + hitInfo.collider.name );
                Debug.Log("Attack!!!");

                if (hitInfo.collider.name == "MonsterCard(Clone)" && selectedObject != null)
                {
                    if (Target != null)
                    {
                        Sequence s = DOTween.Sequence();
                        s.AppendInterval(1f);
                        s.Append(selectedObject.transform.DOMove(Target.transform.position, 0.5f).SetLoops(2, LoopType.Yoyo).SetEase(Ease.InCubic).OnComplete(() =>
                        {
                            OnTriggerEnter(Target.GetComponent<Collider>());
                            launch.go();
                            ClearSelection();
                        }));
                    }

                }
            }
        }
        else if (selectATK == 1 || selectATK == 2)
        {
            Debug.Log("Cannot Attack in Defense Mode");
        }
        else if (canATK == 0)
        {
            Debug.Log("Monster Already Attacked");
        }
        
    }

    public void TargetToP1Graveyard()
    {
        Target.transform.parent = Graveyard.transform;
        Sequence s = DOTween.Sequence();
        s.AppendInterval(1f);
        s.Append(Target.transform.DOMove(Graveyard.position, 1f));
        s.Append(Target.transform.DORotate(new Vector3(90, 0, 0), 1f));
        s.OnComplete(() => {
          //  Target = null;
        });
        
        Transform Mons3D = Target.transform.GetChild(5);
        Debug.Log(Mons3D.name);
        Destroy(Mons3D.gameObject);

    }

    public void TargetToP2Graveyard()
    {
        Target.transform.parent = EnGraveyard.transform;
        Sequence s = DOTween.Sequence();
        s.AppendInterval(1f);
        s.Append(Target.transform.DOMove(EnGraveyard.position, 1f));
        s.Append(Target.transform.DORotate(new Vector3(90, 0, 0), 1f));
        s.OnComplete(() => {
          //  Target = null;
        });
        Transform Mons3D = Target.transform.GetChild(5);
        Debug.Log(Mons3D.name);
        Destroy(Mons3D.gameObject);
    }

    public void SelectedToP1Graveyard()
    {
        selectedObject.transform.parent = Graveyard.transform;
        Sequence s = DOTween.Sequence();
        s.AppendInterval(1f);
        s.Append(selectedObject.transform.DOMove(Graveyard.position, 1f));
        s.Append(Target.transform.DORotate(new Vector3(90, 0, 0), 1f));
        s.OnComplete(() => {
            //selectedObject = null;
        });
        Transform Mons3D = selectedObject.transform.GetChild(5);
        Debug.Log(Mons3D.name);
        Destroy(Mons3D.gameObject);
    }

    public void SelectedToP2Graveyard()
    {
        selectedObject.transform.parent = EnGraveyard.transform;
        Sequence s = DOTween.Sequence();
        s.AppendInterval(1f);
        s.Append(selectedObject.transform.DOMove(EnGraveyard.position, 1f));
        s.Append(Target.transform.DORotate(new Vector3(90, 0, 0), 1f));
        s.OnComplete(() => {
           // selectedObject = null;
        });
        Transform Mons3D = selectedObject.transform.GetChild(5);
        Debug.Log(Mons3D.name);
        Destroy(Mons3D.gameObject);
    }

    public void FlipAttcked()
    {
        SelectedCardPos = 2;
        selectedObject.GetComponent<OneCardManager>().CardPosition = SelectedCardPos;
        Sequence s = DOTween.Sequence();
        s.Append(Target.transform.DORotate(new Vector3(90, -180, -90), 1f));
        s.OnComplete(() => {
            OneCM = Target.GetComponent<OneCardManager>();
            GameObject Monster3D = Instantiate(OneCM.ShapeAnimation, OneCM.PosAnimation.position, OneCM.PosAnimation.rotation = Quaternion.Euler(180, 0, 180), transform.parent = selectedObject.transform);
            Monster3D.tag = "3D";
            Target = null;
        });
    }

    public void FlipSummon()
    {
        SelectedCardPos = 0;
        selectedObject.GetComponent<OneCardManager>().CardPosition = SelectedCardPos;
        Sequence s = DOTween.Sequence();
        s.Append(selectedObject.transform.DORotate(new Vector3(90, 0, 0), 1f));
        s.OnComplete(() =>
        {
            OneCM = selectedObject.GetComponent<OneCardManager>();
            GameObject Monster3D = Instantiate(OneCM.ShapeAnimation, OneCM.PosAnimation.position, OneCM.PosAnimation.rotation = Quaternion.Euler(180, 180, 180), transform.parent = selectedObject.transform);
            Monster3D.tag = "3D";
            ClearSelection();
        });
    }

    public void SwPos()
    {
        int SelectSw;
        SelectSw = selectedObject.GetComponent<OneCardManager>().CardPosition;

        if(SelectSw == 2)
        {
            SelectedCardPos = 0;
            selectedObject.GetComponent<OneCardManager>().CardPosition = SelectedCardPos;
            Sequence s = DOTween.Sequence();
            s.Append(selectedObject.transform.DORotate(new Vector3(90, 0, 0), 1f));
            s.OnComplete(() =>
            {

            });
        }
        else if (SelectSw == 0)
        {
            SelectedCardPos = 2;
            selectedObject.GetComponent<OneCardManager>().CardPosition = SelectedCardPos;
            Sequence s = DOTween.Sequence();
            s.Append(selectedObject.transform.DORotate(new Vector3(90, -180, -90), 1f));
            s.OnComplete(() =>
            {

            });
        }
    }


    public void SummMonsDecision()
    {
        WhereIsTheCardOrCreature w;
        w = selectedObject.GetComponent<WhereIsTheCardOrCreature>();

        SelectedCardPos = 0;
        selectedObject.GetComponent<OneCardManager>().CardPosition = SelectedCardPos;

        if (w.VisualState == VisualStates.LowHand)
            SummonMons();
        else
            EnSummonMons();           
    }

    public void SetMonstDecision()
    {
        WhereIsTheCardOrCreature w;
        w = selectedObject.GetComponent<WhereIsTheCardOrCreature>();
        SelectedCardPos = 1;
        selectedObject.GetComponent<OneCardManager>().CardPosition = SelectedCardPos;
        
        if (w.VisualState == VisualStates.LowHand)
            SetMons();
        else
            EnSetMons();
    }

    public void ActiveSTDecision()
    {
        WhereIsTheCardOrCreature w;
        w = selectedObject.GetComponent<WhereIsTheCardOrCreature>();
        SelectedCardPos = 0;
        selectedObject.GetComponent<OneCardManager>().CardPosition = SelectedCardPos;
        if (w.VisualState == VisualStates.LowHand)
            ActiveSTCard();
        else
            EnActiveSTCard();
    }

    public void SetSTDecision()
    {
        SelectedCardPos = 3;
        selectedObject.GetComponent<OneCardManager>().CardPosition = SelectedCardPos;
        WhereIsTheCardOrCreature w;
        w = selectedObject.GetComponent<WhereIsTheCardOrCreature>();

        if (w.VisualState == VisualStates.LowHand)
            SetSTCard();
        else
            EnSetSTCard();
    }

    public void AtkDecision()
    {
        WhereIsTheCardOrCreature w;
        w = selectedObject.GetComponent<WhereIsTheCardOrCreature>();

      //  fillTarget();
        
        //bawah didisable dulu
        if (w.VisualState == VisualStates.LowHand)
            Attack();
        else
            Attack(); 
            
    }


    void SelectObject(GameObject obj)
    {
        if (selectedObject != null)
        {
            if (obj == selectedObject)

                return;

          //  ClearSelection();
        }
        selectedObject = obj;       
    }

    void Targets(GameObject obj)
    {
        if (selectedObject != null)
        {
            if (obj == selectedObject)

                return;

          //  ClearSelection();
        }
       Target = obj;
    }

    void ClearSelection()
    {
      /*  if (selectedObject == null)
            return;
      */

        selectedObject = null;
        Target = null;
    }

    private void OnApplicationQuit()
    {
        if (recognizer != null && recognizer.IsRunning)
        {
            recognizer.OnPhraseRecognized -= Recognizer_OnPhraseRecognized;
            recognizer.Stop();
        }
    }
}
