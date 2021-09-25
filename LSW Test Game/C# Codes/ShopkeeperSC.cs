using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopkeeperSC : MonoBehaviour
{
    public GameObject UserInterface;
    public UIBehaviorSC UserInterfaceBehavior;
    public InteractionSC ShopInteraction;
    public GameObject Interactor;
    public GameObject ShopUI;
    private GameObject Shop;

    // Start is called before the first frame update
    void Start()
    {
        if(UserInterfaceBehavior == null)
        {
            UserInterfaceBehavior = UserInterface.GetComponent<UIBehaviorSC>();
        }
        if (UserInterface == null)
        {
            UserInterface = GameObject.FindGameObjectWithTag("User Interface");
        }
        if (ShopInteraction == null)
        {
         ShopInteraction =   this.gameObject.GetComponent<InteractionSC>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void TalkToCharacter()
    {
        Interactor = ShopInteraction.Interactor;
        UserInterfaceBehavior.Chat("Welcome! Want to see what we got for sale?");
        UserInterfaceBehavior.Option1ButtonActive(true);
        UserInterfaceBehavior.Option2ButtonActive(true);
    }

    public void OpenShop()
    {
        UserInterfaceBehavior.EndChat();
        Shop = Instantiate(ShopUI);
        Shop.GetComponent<ShopSC>().Character = Interactor;
    }
}
