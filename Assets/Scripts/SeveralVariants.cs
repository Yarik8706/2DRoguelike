using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeveralVariants : MonoBehaviour
{
    public GameObject lamp;
    public Sprite[] sprites;
    public bool isTurnX;
    public bool isTurnY;

    private void Start()
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = sprites[Random.Range(0, sprites.Length)];
        if (isTurnX && Random.Range(0, 2) == 1)
        {
            spriteRenderer.flipX = true;
        }

        if (isTurnY && Random.Range(0, 2) == 1)
        {
            spriteRenderer.flipY = true;
        }
        
        if (lamp != null && Random.Range(0, 2) == 1)
        {
            Instantiate(lamp, transform.position, Quaternion.identity);
        }
    }
}
