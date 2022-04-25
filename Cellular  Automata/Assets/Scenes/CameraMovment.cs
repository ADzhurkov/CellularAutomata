using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovment : MonoBehaviour
{

    public float CameraSpeed = 20f;
    
    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;
        //float size = ;
        if (Input.GetKey("w"))
        {
            pos.y += CameraSpeed * Time.deltaTime;
        }
        if (Input.GetKey("s"))
        {
            pos.y -= CameraSpeed * Time.deltaTime;
        }
        if(Input.GetKey("a"))
        {
            pos.x -= CameraSpeed * Time.deltaTime;
        }
        if(Input.GetKey("d"))
        {
            pos.x += CameraSpeed * Time.deltaTime;
        }
        float scroll = Input.GetAxis("Mouse ScrollWheel");
            UnityEngine.Camera.main.orthographicSize -= 100f * scroll * CameraSpeed * Time.deltaTime;

        transform.position = pos;
    }
}
