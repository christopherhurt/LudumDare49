using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratorCrank : Tasker
{
    
    public Camera cam;
    public float expectedCranks;
    
    private float totalRotation;
    private Vector3 referencePos;
    private bool dragStarted;
    
    public override void Reset() {
        transform.parent.rotation = Quaternion.Euler(0, 0, 0);
        totalRotation = 0.0f;
        dragStarted = false;
    }
    
    void OnMouseDown() {
        if (director.IsActive()) {
            referencePos = Input.mousePosition;
            dragStarted = true;
        }
    }
    
    void OnMouseUp() {
        dragStarted = false;
    }
    
    void OnMouseDrag() {
        if (director.IsActive() && dragStarted) {
            Vector3 originWorld = new Vector3(transform.parent.position.x, transform.parent.position.y, 0.0f);
            Vector3 origin = cam.WorldToScreenPoint(originWorld);
            float oldX = referencePos.x - origin.x;
            float oldY = referencePos.y - origin.y;
            float newX = Input.mousePosition.x - origin.x;
            float newY = Input.mousePosition.y - origin.y;
            float determinant = oldX * newY - oldY * newX;
            if (determinant < 0.0f) {
                totalRotation -= Mathf.Rad2Deg * Mathf.Acos((oldX * newX + oldY * newY)
                    / (Mathf.Sqrt(oldX * oldX + oldY * oldY) * Mathf.Sqrt(newX * newX + newY * newY)));
                transform.parent.rotation = Quaternion.Euler(0, 0, totalRotation);
            }
            if (Mathf.Abs(totalRotation) >= expectedCranks * 360.0) {
                director.UpdateProgress(1.0f);
            }
            referencePos = Input.mousePosition;
        } else {
            dragStarted = false;
        }
    }
    
}
