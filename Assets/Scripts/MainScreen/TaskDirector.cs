using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TaskDirector : MonoBehaviour
{
    
    public TaskManager manager;
    public Camera cam;
    public Transform origin;
    public ActiveIndicator indicator;
    public TaskManager.TaskType type;
    public float timeout;

    private bool active;

    void Start() {
        active = false;
        ResetTask();
    }

    public void Activate() {
        active = true;
        indicator.SetActive(true);
        // TODO: play sound
    }
    
    public bool IsActive() {
        return active;
    }
    
    public float GetTimeout() {
        return timeout;
    }
    
    public void Complete() {
        active = false;
        indicator.SetActive(false);
        // TODO: play sound
        cam.transform.position = new Vector3(origin.position.x, origin.position.y, cam.transform.position.z);
        ResetTask();
        manager.MarkComplete(type);
    }
    
    protected abstract void ResetTask();
    
}
