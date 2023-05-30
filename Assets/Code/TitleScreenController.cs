using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreenController : MonoBehaviour
{
    public int mainMenuSceneIndex = 1; // Replace with the build index of your main menu scene

    private void Update()
    {
        if (Input.anyKeyDown || Input.GetMouseButtonDown(0))
        {
            LoadMainMenu();
        }
    }

    private void LoadMainMenu()
    {
        SceneManager.LoadScene(mainMenuSceneIndex);
    }
}
