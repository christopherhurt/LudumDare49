using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatFoodDraggableTasker : Tasker
{
    
    public Camera cam;
    public CatFoodBowlTasker bowl;
    
    void Update() {
        Vector3 worldPos = cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0.0f));
        transform.position = new Vector3(worldPos.x, worldPos.y, transform.position.z);
        
        if (Input.GetMouseButtonUp(0)) {
            Destroy(gameObject);
            Vector2 rayPoint = cam.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(rayPoint, Vector2.zero);
            if (hit.rigidbody != null) {
                if (hit.rigidbody.gameObject == bowl.gameObject) {
                    bowl.AddFood();
                }
            }
        }
    }
    
    public override void Reset() {
        // Do nothing
    }
    
}
