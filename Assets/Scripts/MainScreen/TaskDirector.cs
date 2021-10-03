using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TaskDirector : MonoBehaviour
{
    
    public TaskManager manager;
    public Camera cam;
    public Transform origin;
    public ActiveIndicator indicator;
    public TaskManager.TaskType type;
    public float timeout;
    
    public AudioSource audioSource;
    public AudioClip activateSound;
    public float activateSoundVolume;
    public AudioClip completeSound;
    public float completeSoundVolume;
    public AudioClip actionSound;
    public float actionSoundVolume;

    private bool active;

    void Start() {
        active = false;
        ResetTask();
    }

    public void Activate() {
        active = true;
        indicator.SetActive(true);
        if (activateSound != null) {
            float volume = activateSoundVolume > 0.0f ? activateSoundVolume : 1.0f;
            audioSource.PlayOneShot(activateSound, volume);
        }
    }
    
    public bool IsActive() {
        return active;
    }
    
    public float GetTimeout() {
        return timeout;
    }
    
    public void Complete() {
        active = false;
        indicator.SetActive(false);
        if (completeSound != null) {
            float volume = completeSoundVolume > 0.0f ? completeSoundVolume : 1.0f;
            audioSource.PlayOneShot(completeSound, volume);
        }
        cam.transform.position = new Vector3(origin.position.x, origin.position.y, cam.transform.position.z);
        ResetTask();
        manager.MarkComplete(type);
    }
    
    public void PlayActionSound() {
        if (actionSound != null) {
            float volume = actionSoundVolume > 0.0f ? actionSoundVolume : 1.0f;
            audioSource.PlayOneShot(actionSound, volume);
        }
    }
    
    protected abstract void ResetTask();
    
}
