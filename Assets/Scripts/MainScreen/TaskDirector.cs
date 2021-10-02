using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TaskDirector : MonoBehaviour
{
    
    public TaskManager manager;
    public Camera cam;
    public Transform origin;
    public TaskManager.TaskType type;
    public float timeout;

    private bool active;

    void Start() {
        active = false;
    }

    public void Activate() {
        active = true;
        // TODO: update main screen image
        // TODO: play sound
    }
    
    public bool IsActive() {
        return active;
    }
    
    public void Complete() {
        active = false;
        // TODO: update main screen image
        // TODO: play sound
        cam.transform.position = new Vector3(origin.position.x, origin.position.y, cam.transform.position.z);
        ResetTask();
        manager.MarkComplete(type);
    }
    
    protected abstract void ResetTask();
    
}
