using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ButtonHandler : MonoBehaviour
{
    public CharacterSwitcher characterSwitcher;
    public int characterIndex;
    public string characterName;
    public Button chooseButton;
    public TextMeshProUGUI buttonText;
    private string defaultButtonText;

    public void OnButtonClick()
    {
        characterSwitcher.SwitchCharacter(characterIndex, characterName);


        if (characterIndex == 0)
        {
            buttonText.text = "Choose";
            chooseButton.interactable = true;
        }
        else
        {
            buttonText.text = "Coming Soon";
            chooseButton.interactable = false;
        }
        
    }
}
