using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class NextLevelButton : MonoBehaviour
{
    public TextMeshProUGUI buttonText;
    public string nextLevelSceneName;
    public string retrySceneName;
    public AudioSource audioSource;
    public AudioClip buttonClickSound;

    private Button button;

    private void Start()
    {
        button = GetComponent<Button>();

        if (GlobalGameManager.instance.levelPassed)
        {
            buttonText.text = "Next Level";
        }
        else
        {
            buttonText.text = "Retry";
        }
    }

    public void OnNextLevelButtonClick()
    {
        if (GlobalGameManager.instance.levelPassed)
        {
            SceneManager.LoadScene(nextLevelSceneName);
        }
        else
        {
            SceneManager.LoadScene(retrySceneName);
        }

        // Play the button click sound
        if (audioSource != null && buttonClickSound != null)
        {
            audioSource.PlayOneShot(buttonClickSound);
        }
    }
}
