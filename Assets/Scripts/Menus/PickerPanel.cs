using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickerPanel : MonoBehaviour
{
    
    public Camera cam;
    public Text panelText;
    public float offsetX;
    public float offsetY;
    
    void Start() {
        SetRendering(false);
    }
    
    void Update() {
        Vector2 rayPoint = cam.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(rayPoint, Vector2.zero);
        if (hit.rigidbody != null) {
            GameObject picked = hit.rigidbody.gameObject;
            if (picked.tag == "InstructionsPicker") {
                string instructionsText = (picked.GetComponent(typeof(InstructionsPicker)) as InstructionsPicker).GetInstructionsText();
                panelText.text = instructionsText;
                SetRendering(true);
            } else {
                SetRendering(false);
            }
        } else {
            SetRendering(false);
        }
        transform.position = new Vector3(rayPoint.x + offsetX, rayPoint.y + offsetY, transform.position.z);
    }
    
    private void SetRendering(bool rendering) {
        (GetComponent(typeof(Image)) as Image).enabled = rendering;
        panelText.enabled = rendering;
    }
    
}
