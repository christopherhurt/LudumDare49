using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveIndicator : MonoBehaviour
{
    
    void Start()
    {
        SetActive(false);
    }
    
    public virtual void SetActive(bool active) {
        Animator animator = GetComponent(typeof(Animator)) as Animator;
        animator.SetBool("isActive", active);
    }
    
}
