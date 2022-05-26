using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuCamRotator : MonoBehaviour
{
    public float rotSpeed = 0;
    
    // Update is called once per frame
    void Update()
    {
        this.transform.Rotate(new Vector3(0,rotSpeed,0));
    }
}
