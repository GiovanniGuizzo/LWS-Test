using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStatusSC : MonoBehaviour
{
    public GameObject Character;
    public UIBehaviorSC UserInterfaceBehavior;
    public float Money = 1000;
    public string MoneySave = "MoneySave";
    // Start is called before the first frame update
    void Start()
    {
        if(PlayerPrefs.HasKey(MoneySave))
        {
            Money = PlayerPrefs.GetFloat(MoneySave);
        }
        else
        {
            PlayerPrefs.SetFloat(MoneySave, Money);
            PlayerPrefs.Save();
        }
        UserInterfaceBehavior.MoneyText.text = "Money: " + Money + "$";
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.LeftShift) && Input.GetButtonDown("Cancel"))
        {
            print("Exit");
            Application.Quit();
        }
    }
    public void GiveMoney(float GivenMoney)
    {
        Money = Money - GivenMoney;
        UserInterfaceBehavior.UpdateMoneyText("Money: " + Money + "$");
        PlayerPrefs.SetFloat(MoneySave, Money);
        PlayerPrefs.Save();
    }

    public void GetMoney(float GotMoney)
    {
        Money = Money + GotMoney;
        UserInterfaceBehavior.UpdateMoneyText("Money: " + Money + "$");
        PlayerPrefs.SetFloat(MoneySave, Money);
        PlayerPrefs.Save();
    }
}
