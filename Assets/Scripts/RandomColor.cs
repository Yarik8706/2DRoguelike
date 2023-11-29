using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomColor : MonoBehaviour
{
    public Color[] colors;
    private UnityEngine.Rendering.Universal.Light2D light2D;
    // Start is called before the first frame update
    void Start()
    {
        light2D = GetComponent<UnityEngine.Rendering.Universal.Light2D>();
        light2D.color = colors[Random.Range(0, colors.Length)];
    }

}
