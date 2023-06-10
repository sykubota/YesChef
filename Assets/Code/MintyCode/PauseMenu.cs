using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuUI;
    public GameObject confirmationUI;

    private bool isPaused = false;
    private bool isConfirming = false;

    private void Update()
    {
        if (!isConfirming && Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void ShowConfirmation()
    {
        isConfirming = true;
        pauseMenuUI.SetActive(false);
        confirmationUI.SetActive(true);
        // Automatically highlight the "No" button
        UnityEngine.EventSystems.EventSystem.current.SetSelectedGameObject(confirmationUI.transform.GetChild(1).gameObject);
    }

    public void ConfirmQuit()
    {
        // Replace the code below with your confirmation logic
        Debug.Log("Are you sure you want to quit?");
        SceneManager.LoadScene("MainMenu");
    }

    public void CancelQuit()
    {
        isConfirming = false;
        confirmationUI.SetActive(false);
        pauseMenuUI.SetActive(true);
    }
}
