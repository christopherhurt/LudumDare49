using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transition : MonoBehaviour
{
    public Camera cam;
    public float targetX;
    public float targetY;

    void OnMouseDown()
    {
        cam.transform.position = new Vector3(targetX, targetY, cam.transform.position.z);
    }
}
