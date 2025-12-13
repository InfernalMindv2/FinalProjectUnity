using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class characterManager : MonoBehaviour
{
    public characterDatabase characterDatabase;
    public Image artworkSprite;

    private int selectedOption;
    void Start()
    {
        selectedOption = 0;
    }



    public void NextOption()
    {
        selectedOption= (selectedOption+1)%characterDatabase.characterCount;
        UpdateCharacter(selectedOption);
    }
    public void PrevOption()
    {
        selectedOption--;
        if(selectedOption<0)
            selectedOption = characterDatabase.characterCount - 1;
        UpdateCharacter(selectedOption);
    }
    private void UpdateCharacter(int selectedOption)
    {
        CharatcterScript charatcterScript = characterDatabase.GetCharatcter(selectedOption);
        artworkSprite.sprite = charatcterScript.characterSprite;
    }
}
