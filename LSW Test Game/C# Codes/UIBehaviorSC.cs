using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIBehaviorSC : MonoBehaviour
{
    public string UIAcceptInput = "Submit";
    public string UIDenyInput = "Cancel";
    public GameObject TextChatObject;
    public Text TextChat;
    public GameObject Option1Button;
    public GameObject Option2Button;
    public bool Chating;
    public GameObject Character;
    private CharacterSC CharacterScript;
    public bool ChatWithOption;
    public Text MoneyText;
    // Start is called before the first frame update
    void Start()
    {
        CharacterScript = Character.GetComponent<CharacterSC>();
        Chating = false;
        TextChatObject.SetActive(false);
        Option1Button.SetActive(false);
        Option2Button.SetActive(false);
        ChatWithOption = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown(UIDenyInput))
        {
            if(Chating)
            {
                EndChat();
                ActivateCharacterControl(true);
            }
            if(ChatWithOption)
            {
                Option1ButtonActive(false);
                Option2ButtonActive(false);
            }
        }
    }

    public void Chat(string Dialogue)
    {
        Chating = true;
        TextChatObject.SetActive(true);
        TextChat.text = Dialogue;
        ActivateCharacterControl(false);
    }
    public void EndChat()
    {
        TextChatObject.SetActive(false);
        TextChat.text = "";     
        Chating = false;
    }

    public void ActivateCharacterControl(bool Condition)
    {
        CharacterScript.CanControlCharacter = Condition;
    }

    public void Option1ButtonActive(bool Condition)
    {
        Option1Button.SetActive(Condition);
        if(Condition == true)
        {
            ChatWithOption = true;
        }      
    }

    public void Option2ButtonActive(bool Condition)
    {
        Option2Button.SetActive(Condition);
        if (Condition == true)
        {
            ChatWithOption = true;
        }
    }

    public void UpdateMoneyText(string NewText)
    {
        MoneyText.text = NewText;
    }
}
