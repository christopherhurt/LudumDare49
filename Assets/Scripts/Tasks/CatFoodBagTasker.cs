using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatFoodBagTasker : Tasker
{
    
    public CatFoodDraggableTasker spawnable;
    
    void OnMouseDown() {
        CatFoodDraggableTasker draggable = Instantiate(spawnable, transform.parent, false);
        draggable.gameObject.SetActive(true);
    }
    
    public override void Reset() {
        // Do nothing
    }
    
}
