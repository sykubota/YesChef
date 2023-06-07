using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CharacterCycler : MonoBehaviour
{
    public CharacterSwitcher characterSwitcher;
    public GameObject[] characterImages;
    public string[] characterNames;
    public Button chooseButton;
    public TextMeshProUGUI buttonText;

    private int currentIndex = 0;
    private string defaultButtonText;

    private void Start()
    {
        defaultButtonText = buttonText.text;
        UpdateCharacter();
    }

    public void CycleLeft()
    {
        currentIndex--;
        if (currentIndex < 0)
            currentIndex = characterImages.Length - 1;
        
        UpdateCharacter();
    }

    public void CycleRight()
    {
        currentIndex++;
        if (currentIndex >= characterImages.Length)
            currentIndex = 0;

        UpdateCharacter();
    }

    private void UpdateCharacter()
    {
        characterSwitcher.SwitchCharacter(currentIndex, characterNames[currentIndex]);

        if (characterNames[currentIndex] == "Theodore")
        {
            buttonText.text = defaultButtonText;
            chooseButton.interactable = true;
        }
        else
        {
            buttonText.text = "Coming Soon";
            chooseButton.interactable = false;
        }
    }

    public void ChooseCharacter()
    {
        // Add your code here for what happens when the "Choose" button is clicked
        Debug.Log("Character chosen: " + characterNames[currentIndex]);
    }
}
