using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSC : MonoBehaviour
{
    public CircleCollider2D CharacterCollider;
    public Rigidbody2D CharacterRigidBody;
    public GameObject[] CharacterTriggers;
    public string InteractiveTag;
    public bool CanControlCharacter;
    public CharacterStatusSC CharacterStatus;
    public string HorizontalInput = "Horizontal";
    public string VerticalInput = "Vertical";
    public string InteractionInput = "Interact";
    private Vector2 CharacterMoveDirection;
    public float CharacterSpeed;
    private bool CanInteract = true;
    private bool InteractionReady = false;
    private GameObject InteractiveObject;
    public int UperBodyOutfit;
    public int LowerBodyOutfit;
    public GameObject[] CharacterDirections;
    public OutfitControlSC[] UperBodyOutfits;
    public OutfitControlSC[] LowerBodyOutfits;
    public Animator CharacterAnimations;

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < CharacterDirections.Length; i++)
        {
            if(i == 0)
            {
                CharacterDirections[i].SetActive(true);
            }
            else
            {
                CharacterDirections[i].SetActive(false);
            }
        }

        for(int i = 0; i < UperBodyOutfits.Length; i++)
        {
            UperBodyOutfits[i].ChangeOutfit(UperBodyOutfit);
        }
        for (int i = 0; i < LowerBodyOutfits.Length; i++)
        {
            LowerBodyOutfits[i].ChangeOutfit(LowerBodyOutfit);
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Check if character can be controlled
        if(CanControlCharacter)
        {
            //Check if character is moving
            if (Input.GetAxis(HorizontalInput) != 0 || Input.GetAxis(VerticalInput) != 0)
            {
                CharacterMoveDirection = new Vector2(Input.GetAxis(HorizontalInput), Input.GetAxis(VerticalInput));
                CharacterRigidBody.MovePosition(CharacterRigidBody.position + CharacterMoveDirection * Time.deltaTime * CharacterSpeed);
                //Check which direction is moving: Select active trigger
                if (Input.GetAxis(HorizontalInput) > 0 && Mathf.Abs(Input.GetAxis(HorizontalInput)) > Mathf.Abs(Input.GetAxis(VerticalInput)))
                {
                    for (int i = 0; i < CharacterTriggers.Length; i++)
                    {
                        if (i == 3)
                        {
                            if (!CharacterTriggers[3].activeSelf)
                            {
                                CharacterTriggers[3].SetActive(true);
                            }
                            if(CharacterDirections[3].activeSelf == false)
                            {
                                CharacterDirections[3].SetActive(true);
                            }
                        }
                        else
                        {
                            if(CharacterTriggers[i].activeSelf == true)
                            {
                                CharacterTriggers[i].SetActive(false);
                            }
                            if(CharacterDirections[i].activeSelf == true)
                            {
                                CharacterDirections[i].SetActive(false);
                            }
                        }
                    }
                }
                if (Input.GetAxis(HorizontalInput) < 0 && Mathf.Abs(Input.GetAxis(HorizontalInput)) > Mathf.Abs(Input.GetAxis(VerticalInput)))
                {
                    for (int i = 0; i < CharacterTriggers.Length; i++)
                    {
                        if (i == 2)
                        {
                            if (!CharacterTriggers[2].activeSelf)
                            {
                                CharacterTriggers[2].SetActive(true);
                            }
                            if (CharacterDirections[2].activeSelf == false)
                            {
                                CharacterDirections[2].SetActive(true);
                            }
                        }
                        else
                        {
                            if (CharacterTriggers[i].activeSelf == true)
                            {
                                CharacterTriggers[i].SetActive(false);
                            }
                            if (CharacterDirections[i].activeSelf == true)
                            {
                                CharacterDirections[i].SetActive(false);
                            }
                        }
                    }
                }
                if (Input.GetAxis(VerticalInput) > 0 && Mathf.Abs(Input.GetAxis(HorizontalInput)) < Mathf.Abs(Input.GetAxis(VerticalInput)))
                {
                    for (int i = 0; i < CharacterTriggers.Length; i++)
                    {
                        if (i == 1)
                        {
                            if (!CharacterTriggers[1].activeSelf)
                            {
                                CharacterTriggers[1].SetActive(true);
                            }
                            if (CharacterDirections[1].activeSelf == false)
                            {
                                CharacterDirections[1].SetActive(true);
                            }
                        }
                        else
                        {
                            if (CharacterTriggers[i].activeSelf == true)
                            {
                                CharacterTriggers[i].SetActive(false);
                            }
                            if (CharacterDirections[i].activeSelf == true)
                            {
                                CharacterDirections[i].SetActive(false);
                            }
                        }
                    }
                }
                if (Input.GetAxis(VerticalInput) < 0 && Mathf.Abs(Input.GetAxis(HorizontalInput)) < Mathf.Abs(Input.GetAxis(VerticalInput)))
                {
                    for (int i = 0; i < CharacterTriggers.Length; i++)
                    {
                        if (i == 0)
                        {
                            if (!CharacterTriggers[0].activeSelf)
                            {
                                CharacterTriggers[0].SetActive(true);
                            }
                            if (CharacterDirections[0].activeSelf == false)
                            {
                                CharacterDirections[0].SetActive(true);
                            }
                        }
                        else
                        {
                            if (CharacterTriggers[i].activeSelf == true)
                            {
                                CharacterTriggers[i].SetActive(false);
                            }
                            if (CharacterDirections[i].activeSelf == true)
                            {
                                CharacterDirections[i].SetActive(false);
                            }
                        }
                    }
                }
                CharacterAnimations.SetFloat("Speed", Mathf.Abs(Input.GetAxis(HorizontalInput)) + Mathf.Abs(Input.GetAxis(VerticalInput)));
            }
            else
            {
                CharacterAnimations.SetFloat("Speed", 0);
            }
            if (InteractionReady)
            {
                if(Input.GetButtonDown(InteractionInput))
                {
                    InteractiveObject.GetComponent<InteractionSC>().CallEvent(this.gameObject);
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == InteractiveTag && CanInteract)
        {
            InteractiveObject = collision.gameObject;
            InteractionReady = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == InteractiveTag)
        {
            InteractionReady = false;
            InteractiveObject = null;
        }
    }

    public void ChangeOutfit(int OutfitType, int OutfitID)
    {
        if(OutfitType == 0)
        {
            UperBodyOutfit = OutfitID;
            for(int i = 0; i < UperBodyOutfits.Length; i++)
            {
                UperBodyOutfits[i].ChangeOutfit(UperBodyOutfit);
            }
        }
        else if(OutfitType == 1)
        {
            LowerBodyOutfit = OutfitID;
            for (int i = 0; i < LowerBodyOutfits.Length; i++)
            {
                LowerBodyOutfits[i].ChangeOutfit(LowerBodyOutfit);
            }
        }
    }
}
