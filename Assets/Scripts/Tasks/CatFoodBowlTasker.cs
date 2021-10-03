using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatFoodBowlTasker : Tasker
{
    
    public int expectedFood;
    
    private int foodCount;
    
    void Start() {
        foodCount = 0;
    }
    
    public void AddFood() {
        foodCount++;
        // TODO: update image
        if (foodCount >= expectedFood) {
            director.UpdateProgress(1.0f);
        }
    }
    
    public override void Reset() {
        foodCount = 0;
        // TODO: reset image
    }
    
}
