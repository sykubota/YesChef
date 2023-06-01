using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialButton : MonoBehaviour
{
    public string tutorialSceneName; // The name of your tutorial scene

    public void LoadTutorialScene()
    {
        SceneManager.LoadScene(tutorialSceneName);
    }
}
