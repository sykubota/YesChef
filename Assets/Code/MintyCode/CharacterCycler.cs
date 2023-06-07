using UnityEngine;
using TMPro;

public class CharacterCycler : MonoBehaviour
{
    public CharacterSwitcher characterSwitcher;
    public GameObject[] characterImages;
    public string[] characterNames;

    private int currentIndex = 0;

    private void Start()
    {
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
    }
}
