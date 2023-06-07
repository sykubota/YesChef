using UnityEngine;
using TMPro;

public class CharacterSwitcher : MonoBehaviour
{
    public GameObject[] characterImages;
    public TextMeshProUGUI nameText;

    public void SwitchCharacter(int characterIndex, string characterName)
    {
        for (int i = 0; i < characterImages.Length; i++)
        {
            bool isActive = (i == characterIndex);
            characterImages[i].SetActive(isActive);
        }

        if (nameText != null)
        {
            nameText.text = characterName;
        }
    }
}
