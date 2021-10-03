using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemoActiveIndicator : ActiveIndicator
{
    
    public Color defaultColor;
    public Sprite defaultSprite;
    public Color activeColor;
    public Sprite activeSprite;

    public override void SetActive(bool active) {
        SpriteRenderer renderer = GetComponent(typeof(SpriteRenderer)) as SpriteRenderer;
        if (active) {
            renderer.sprite = activeSprite;
            renderer.color = activeColor;
        } else {
            renderer.sprite = defaultSprite;
            renderer.color = defaultColor;
        }
    }

}
