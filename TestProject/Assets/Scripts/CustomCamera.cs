using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomCamera : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Ray cameraRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(cameraRay.origin, cameraRay.direction * 100, Color.yellow);
    }
}
