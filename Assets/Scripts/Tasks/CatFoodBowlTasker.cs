using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatFoodBowlTasker : Tasker
{
    
    public SpriteRenderer bowlImage;
    public Sprite[] bowlSprites;
    public int expectedFood;
    
    private int foodCount;
    
    public void AddFood() {
        foodCount++;
        UpdateFoodSprite();
        director.PlayActionSound();
        if (foodCount >= expectedFood) {
            director.UpdateProgress(1.0f);
        }
    }
    
    private void UpdateFoodSprite() {
        if (bowlSprites.Length > 0) {
            float lerp = Mathf.Max(0.0f, Mathf.Min(0.999f, (float)foodCount / expectedFood));
            int spriteIndex = (int)(lerp * bowlSprites.Length);
            bowlImage.sprite = bowlSprites[spriteIndex];
        }
    }
    
    public override void Reset() {
        foodCount = 0;
        UpdateFoodSprite();
    }
    
}
