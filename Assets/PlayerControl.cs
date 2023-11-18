using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public int speed;
    
    private void Update()
    {
        if (Input.GetKey("w"))
        {
            transform.position += Vector3.up * speed * Time.deltaTime;
        } 
        else if (Input.GetKey("s"))
        {
            transform.position += Vector3.down * speed * Time.deltaTime;
        }
        
        if (Input.GetKey("a"))
        {
            transform.position += -Vector3.right * speed * Time.deltaTime;
        }
        else if (Input.GetKey("d"))
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
        }
    }
}
