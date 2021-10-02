using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitionTaskDirector : TaskDirector
{
    
    public GameObject target;
    
    void OnMouseUpAsButton() {
        if (IsActive()) {
            Vector3 targetPosition = (target.GetComponent(typeof(Transform)) as Transform).position;
            cam.transform.position = new Vector3(targetPosition.x, targetPosition.y, cam.transform.position.z);
        }
    }
    
    protected override void ResetTask() {
        Tasker[] taskers = target.GetComponentsInChildren<Tasker>();
        foreach (Tasker tasker in taskers) {
            tasker.Reset();
        }
    }
    
    public void UpdateProgress(float progress) {
        if (progress >= 1.0f) {
            Complete();
        }
    }
    
}
