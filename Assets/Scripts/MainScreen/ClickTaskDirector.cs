using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickTaskDirector : TaskDirector
{
    
    public int clicksRequired;
    
    private int clickCount;
    
    void Start()
    {
        ResetTask();
    }

    void OnMouseUpAsButton() // TODO: left mouse bu8tton only??
    {
        Debug.Log("Press!!! " + Time.time); // TODO: remove
        if (IsActive()) {
            clickCount++;
            // TODO: play sound
            if (clickCount >= clicksRequired) {
                Complete();
            }
        }
    }
    
    protected override void ResetTask() {
        clickCount = 0;
    }
    
}
