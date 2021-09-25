using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D.Animation;

public class OutfitControlSC : MonoBehaviour
{
    public CharacterSC MainCharacter;
    public string OutfitCategory;
    public SpriteResolver OutfitResolver;
    public int OutfitLabel;
    public string[] OutfitsLabels;
    // Start is called before the first frame update
    void Start()
    {
        OutfitResolver.SetCategoryAndLabel(OutfitCategory, OutfitsLabels[OutfitLabel]);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnEnable()
    {
        OutfitResolver.SetCategoryAndLabel(OutfitCategory, OutfitsLabels[OutfitLabel]);
    }

    public void ChangeOutfit(int NewOutfitLabel)
    {
        OutfitLabel = NewOutfitLabel;
        OutfitResolver.SetCategoryAndLabel(OutfitCategory, OutfitsLabels[OutfitLabel]);
       // print(OutfitsLabels[OutfitLabel]);
    }
}
