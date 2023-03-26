using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class CameraController : MonoBehaviour
{
    // Start is called before the first frame update
    public float panSpeed = 0.01f;
    public float mouseBuffer = 10f;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("w") || Input.mousePosition.y >= Screen.height - mouseBuffer)
        {
            transform.Translate(Vector3.forward * panSpeed * Time.deltaTime, Space.World);
        }
        
        if (Input.GetKey("s") || Input.mousePosition.y <= mouseBuffer)
        {
            transform.Translate(Vector3.back * panSpeed * Time.deltaTime, Space.World);
        }
        
        if (Input.GetKey("d") || Input.mousePosition.x >= Screen.width - mouseBuffer)
        {
            transform.Translate(Vector3.right * panSpeed * Time.deltaTime, Space.World);
        }
        
        if (Input.GetKey("a") || Input.mousePosition.x <= mouseBuffer)
        {
            transform.Translate(Vector3.left * panSpeed * Time.deltaTime, Space.World);
        }
    }
}