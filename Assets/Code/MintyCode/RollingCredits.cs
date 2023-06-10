using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class RollingCredits : MonoBehaviour
{
    public float scrollSpeed = 80f; // Adjust the scrolling speed as desired
    public float targetYPosition = 8459f; // The y position at which the scrolling should stop
    public float delayBeforeScroll = 2f; // Add a delay before the credits start scrolling

    public Image[] imagesToRoll; // Array of UI images to roll along with the credits

    private RectTransform textRectTransform;
    private RectTransform[] imageRectTransforms;

    private void Start()
    {
        textRectTransform = GetComponent<RectTransform>();

        // Get the RectTransform components of the images
        imageRectTransforms = new RectTransform[imagesToRoll.Length];
        for (int i = 0; i < imagesToRoll.Length; i++)
        {
            imageRectTransforms[i] = imagesToRoll[i].GetComponent<RectTransform>();
        }

        Invoke("StartScrolling", delayBeforeScroll);
    }

    private void StartScrolling()
    {
        StartCoroutine(ScrollCredits());
    }

    private IEnumerator ScrollCredits()
    {
        while (textRectTransform.anchoredPosition.y < targetYPosition)
        {
            float yOffset = scrollSpeed * Time.deltaTime;

            // Scroll the text
            textRectTransform.anchoredPosition += Vector2.up * yOffset;

            // Scroll the images
            for (int i = 0; i < imageRectTransforms.Length; i++)
            {
                imageRectTransforms[i].anchoredPosition += Vector2.up * yOffset;
            }

            yield return null;
        }
    }
}
