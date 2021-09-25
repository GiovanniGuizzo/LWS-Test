using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSelectSC : MonoBehaviour
{
    public string SaveName;
    public int ItemID;
    public int ObjectDirection;
    public SpriteRenderer ItemToSelect;
    public Sprite[] ItemSpritesFront;
    public Sprite[] ItemSpritesBack;
    public Sprite[] ItemSpritesLeft;
    public Sprite[] ItemSpritesRight;

    // Start is called before the first frame update
    void Start()
    {
        if(PlayerPrefs.HasKey(SaveName))
        {
            ItemID = PlayerPrefs.GetInt(SaveName);
            SetItem(ItemID);
        }
        else
        {
            PlayerPrefs.SetInt(SaveName, ItemID);
            PlayerPrefs.Save();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetDirection(int Direction)
    {
        if (ObjectDirection == 0)
        {
            ItemToSelect.sprite = ItemSpritesFront[Direction];
        }
        else if (ObjectDirection == 1)
        {
            ItemToSelect.sprite = ItemSpritesBack[Direction];
        }
        else if (ObjectDirection == 2)
        {
            ItemToSelect.sprite = ItemSpritesLeft[Direction];
        }
        else
        {
            ItemToSelect.sprite = ItemSpritesRight[Direction];
        }
    }

    public void SetItem(int NewID)
    {
        ItemID = NewID;
        if(ObjectDirection == 0)
        {
            ItemToSelect.sprite = ItemSpritesFront[NewID];
        }
        else if(ObjectDirection == 1)
        {
            ItemToSelect.sprite = ItemSpritesBack[NewID];
        }
        else if(ObjectDirection == 2)
        {
            ItemToSelect.sprite = ItemSpritesLeft[NewID];
        }
        else
        {
            ItemToSelect.sprite = ItemSpritesRight[NewID];
        }

    }

    public void SaveItem()
    {
        PlayerPrefs.SetInt(SaveName, ItemID);
        PlayerPrefs.Save();
    }
}
