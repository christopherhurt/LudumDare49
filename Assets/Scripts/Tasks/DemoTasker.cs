using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Test use only...
public class DemoTasker : Tasker
{
    
    void OnMouseUpAsButton() {
        director.UpdateProgress(1.0f);
    }
    
    public override void Reset() {
        // Do nothing
    }
    
}
