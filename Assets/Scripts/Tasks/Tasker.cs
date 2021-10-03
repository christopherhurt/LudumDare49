using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Tasker : MonoBehaviour
{
    
    public TransitionTaskDirector director;
    
    void Start() {
        Reset();
    }
    
    public abstract void Reset();
    
}
