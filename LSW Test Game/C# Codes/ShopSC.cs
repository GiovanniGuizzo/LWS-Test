using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopSC : MonoBehaviour
{
    [System.Serializable]
    public class ItemStatus
    {
        public string ItemName;
        public int ItemType;
        public int ItemID;
        public float Itemprice;
        public Sprite ItemImage;
        public bool PurchasedItem;
    }


    public string CharacterStatusTag = "Player Controller";
    public GameObject Character;
    public CharacterStatusSC CharacterStatus;    
    public Text CurrentMoneyText;
    public Text ItemPriceText;   
    public Text BuyButtonText;
    public Text SellButtonText;
    public int ShopItemID;
    public Image ShopItemImage;
    public Text ShopItemName;
    public ItemStatus[] ShopItem;
    //public string[] TargetTypesNames;


    private void Start()
    {
        if(CharacterStatus == null)
        {
            CharacterStatus = GameObject.FindGameObjectWithTag(CharacterStatusTag).GetComponent<CharacterStatusSC>();
        }
        CurrentMoneyText.text = "Current Money: " + CharacterStatus.Money + "$";
        for (int i = 0; i < ShopItem.Length; i++)
        {  
            if(PlayerPrefs.HasKey(ShopItem[i].ItemName + "Save"))
            {
                if (PlayerPrefs.GetInt(ShopItem[i].ItemName + "Save") == 1)
                {
                    ShopItem[i].PurchasedItem = true;
                }
            }
            else
            {
                PlayerPrefs.SetInt(ShopItem[i].ItemName + "Save", 0);
                PlayerPrefs.Save();
            }
        }
        SelectItem(0);
    }

    public void SelectItem(int NewShopItemID)
    {
        ShopItemID = NewShopItemID;
        ItemPriceText.text = "Price: " + ShopItem[NewShopItemID].Itemprice + "$";
        ShopItemImage.sprite = ShopItem[NewShopItemID].ItemImage;
        ShopItemName.text = ShopItem[NewShopItemID].ItemName;
        if(ShopItem[NewShopItemID].PurchasedItem == true)
        {
            BuyButtonText.text = "Use";
            SellButtonText.text = "Sell";
        }
        else
        {
            BuyButtonText.text = "Buy";
            SellButtonText.text = "Not Owned";
        }
    }

    public void BuyItem()
    {
        if(ShopItem[ShopItemID].PurchasedItem == false)
        {
            if (CharacterStatus.Money >= ShopItem[ShopItemID].Itemprice)
            {
                ShopItem[ShopItemID].PurchasedItem = true;
                PlayerPrefs.SetInt(ShopItem[ShopItemID].ItemName + "Save", 1);
                PlayerPrefs.Save();
                CharacterStatus.GiveMoney(ShopItem[ShopItemID].Itemprice);
                CurrentMoneyText.text = "Current Money: " + CharacterStatus.Money + "$";
                BuyButtonText.text = "Use";
                SellButtonText.text = "Sell";
                Character.GetComponent<CharacterSC>().ChangeOutfit(ShopItem[ShopItemID].ItemType, ShopItem[ShopItemID].ItemID);
                //GameObject.Find(TargetTypesNames[ShopItem[ShopItemID].ItemType]).GetComponent<ItemSelectSC>().SetItem(ShopItem[ShopItemID].ItemID);
                //GameObject.Find(TargetTypesNames[ShopItem[ShopItemID].ItemType]).GetComponent<ItemSelectSC>().SaveItem();
            }
        }
        else
        {
            Character.GetComponent<CharacterSC>().ChangeOutfit(ShopItem[ShopItemID].ItemType, ShopItem[ShopItemID].ItemID);
            // GameObject.Find(TargetTypesNames[ShopItem[ShopItemID].ItemType]).GetComponent<ItemSelectSC>().SetItem(ShopItem[ShopItemID].ItemID);
            // GameObject.Find(TargetTypesNames[ShopItem[ShopItemID].ItemType]).GetComponent<ItemSelectSC>().SaveItem();
        }
    }

    public void SellItem()
    {
        if(ShopItem[ShopItemID].PurchasedItem == true)
        {
            ShopItem[ShopItemID].PurchasedItem = false;
            CharacterStatus.GetMoney(ShopItem[ShopItemID].Itemprice);
            PlayerPrefs.SetInt(ShopItem[ShopItemID].ItemName + "Save", 0);
            PlayerPrefs.Save();
            CurrentMoneyText.text = "Current Money: " + CharacterStatus.Money + "$";
            BuyButtonText.text = "Buy";
            SellButtonText.text = "Not Owned";
        }
    }

    public void CloseShop()
    {
        Character.GetComponent<CharacterSC>().CanControlCharacter = true;
        Destroy(this.gameObject);
    }
}
