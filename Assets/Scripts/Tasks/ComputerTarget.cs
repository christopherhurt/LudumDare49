using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputerTarget : MonoBehaviour
{
    
    public ComputerTasker tasker;
    public TaskDirector director;
    public TaskManager manager;
    public float opacityDegreeOdd;
    
    void Update() {
        float remaining = manager.GetTimeRemaining(TaskManager.TaskType.COMPUTER) / director.GetTimeout();
        remaining = Mathf.Pow(remaining - 1.0f, opacityDegreeOdd) + 1.0f;
        SpriteRenderer renderer = GetComponent(typeof(SpriteRenderer)) as SpriteRenderer;
        renderer.color = new Color(renderer.color.r, renderer.color.g, renderer.color.b, remaining);
    }
    
    void OnMouseUpAsButton() {
        Destroy(gameObject);
        tasker.ReportTargetClicked();
    }
    
}
