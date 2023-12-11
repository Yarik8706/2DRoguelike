using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Potion : MonoBehaviour
{
    public Slider healthBar;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.attachedRigidbody.gameObject.tag == "Player")
        {
            healthBar.value += 10;
            Destroy(gameObject);
        }
    }
}
