using UnityEngine;

public class ButtonHandler : MonoBehaviour
{
    public CharacterSwitcher characterSwitcher;
    public int characterIndex;
    public string characterName;

    public void OnButtonClick()
    {
        characterSwitcher.SwitchCharacter(characterIndex, characterName);
    }
}
