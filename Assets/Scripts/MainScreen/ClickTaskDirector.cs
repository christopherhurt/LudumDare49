using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickTaskDirector : TaskDirector
{
    
    public int clicksRequired;
    
    private int clickCount;

    void OnMouseUpAsButton()
    {
        if (IsActive()) {
            clickCount++;
            PlayActionSound();
            if (clickCount >= clicksRequired) {
                Complete();
            }
        }
    }
    
    protected override void ResetTask() {
        clickCount = 0;
    }
    
}
