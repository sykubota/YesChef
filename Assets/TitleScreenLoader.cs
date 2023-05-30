using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreenLoader : MonoBehaviour
{
    IEnumerator Start()
    {
        yield return new WaitForSecondsRealtime(6f); // Adjust the delay as needed

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("Title", LoadSceneMode.Single);

        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }
}
