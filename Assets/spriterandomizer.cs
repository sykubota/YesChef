using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class spriterandomizer: MonoBehaviour
{
    public Image image; // Reference to the UI Image component
    public List<Sprite> spriteList; // List of sprites from your project

    private void Start()
    {
        if (spriteList.Count > 0)
        {
            int randomIndex = Random.Range(0, spriteList.Count);
            image.sprite = spriteList[randomIndex];
        }
        else
        {
            Debug.LogError("Sprite List is empty!");
        }
    }
}