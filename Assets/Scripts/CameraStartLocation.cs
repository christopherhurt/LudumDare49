using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraStartLocation : MonoBehaviour
{
    
    public Transform startLocation;
    
    void Start()
    {
        Transform transform = gameObject.GetComponent(typeof(Transform)) as Transform;
        transform.position = new Vector3(startLocation.position.x, startLocation.position.y, transform.position.z);
    }

}
