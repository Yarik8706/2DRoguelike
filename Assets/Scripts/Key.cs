using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.attachedRigidbody.gameObject.tag == "Player")
        {
            col.attachedRigidbody.GetComponent<PlayerControl>().AddKey();
            Destroy(gameObject);
        }
    }
}
