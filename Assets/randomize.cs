using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 using System;
 using System.Collections.Generic;
 using System.Security.Cryptography;
 using UnityEngine;
 using UnityEngine.UI;

public class randomize : MonoBehaviour
{
    public Sprite[] sprites;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<SpriteRenderer>().sprite = sprites[UnityEngine.Random.Range(0, sprites.Length)];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
