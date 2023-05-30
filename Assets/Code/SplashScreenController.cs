using UnityEngine;
using UnityEngine.SceneManagement;

public class SplashScreenController : MonoBehaviour
{
    public int titleScreenSceneIndex = 0; // Replace with the build index of your title screen scene
    public int mainMenuSceneIndex = 1; // Replace with the build index of your main menu scene

    private AsyncOperation titleScreenLoadOperation;

    void Start()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
        Invoke("LoadTitleScreen", 6f); // Delay before loading the title screen, adjusted to 6 seconds
    }

    void LoadTitleScreen()
    {
        titleScreenLoadOperation = SceneManager.LoadSceneAsync(titleScreenSceneIndex, LoadSceneMode.Additive);
        titleScreenLoadOperation.completed += TitleScreenLoadCompleted;
    }

    void TitleScreenLoadCompleted(AsyncOperation asyncOperation)
    {
        SceneManager.SetActiveScene(SceneManager.GetSceneByBuildIndex(titleScreenSceneIndex));
    }

    void Update()
    {
        if (titleScreenLoadOperation.isDone && Input.anyKeyDown)
        {
            LoadMainMenu();
        }
    }

    void LoadMainMenu()
    {
        SceneManager.LoadScene(mainMenuSceneIndex);
    }
}
