using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randomize : MonoBehaviour
{
    public Sprite[] sprites;

    void Start()
    {
        GetComponent<SpriteRenderer>().sprite = sprites[UnityEngine.Random.Range(0, sprites.Length)];
    }

}
