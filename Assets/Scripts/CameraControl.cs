using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public Transform cameraPos;
    
    private void Start()
    {

    }

    private void Update()
    {
        transform.position = new Vector3(cameraPos.position.x, cameraPos.position.y, -1);
    }
}
