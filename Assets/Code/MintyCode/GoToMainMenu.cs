using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToMainMenu : MonoBehaviour
{
    private void Update()
    {
        // Check if the Escape key is pressed
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // Go back to the main menu scene
            SceneManager.LoadScene("MainMenu"); // Replace "MainMenuScene" with the actual name of your main menu scene
        }
    }
}
