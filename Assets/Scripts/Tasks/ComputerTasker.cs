using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputerTasker : Tasker
{
    
    public ComputerTarget baseTarget;
    public int spawnCount;
    public float spawnCenterX;
    public float spawnCenterY;
    public float spawnWidth;
    public float spawnHeight;
    
    private bool started;
    private int remaining;
    
    void Update() {
        if (director.IsActive() && !started) {
            for (int i = 0; i < spawnCount; i++) {
                SpawnTarget();
            }
            started = true;
            remaining = spawnCount;
        }
    }
    
    public void ReportTargetClicked() {
        remaining--;
        director.PlayActionSound();
        if (remaining <= 0) {
            started = false;
            director.UpdateProgress(1.0f);
        }
    }
    
    private void SpawnTarget() {
        Transform thisTransform = GetComponent(typeof(Transform)) as Transform;
        ComputerTarget target = Instantiate(baseTarget, thisTransform, false);
        float x = thisTransform.position.x + Random.Range(spawnCenterX - spawnWidth / 2.0f, spawnCenterX + spawnWidth / 2.0f);
        float y = thisTransform.position.y + Random.Range(spawnCenterY - spawnHeight / 2.0f, spawnCenterY + spawnHeight / 2.0f);
        float z = (baseTarget.GetComponent(typeof(Transform)) as Transform).position.z;
        (target.GetComponent(typeof(Transform)) as Transform).position = new Vector3(x, y, z);
        (target.GetComponent(typeof(SpriteRenderer)) as SpriteRenderer).enabled = true;
    }
    
    public override void Reset() {
        started = false;
        remaining = 0;
    }
    
}
