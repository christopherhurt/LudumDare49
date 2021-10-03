using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TaskManager : MonoBehaviour
{
    public enum TaskType {
        MOM,
        BROTHER,
        ROUTER,
        CAT,
        GENERATOR,
        COMPUTER
    }
  
    public TaskDirector momDirector;
    public TaskDirector brotherDirector;
    public TaskDirector routerDirector;
    public TaskDirector catDirector;
    public TaskDirector generatorDirector;
    public TaskDirector computerDirector;
    
    public Text scoreText;
    public int scoreInc;
    
    public float timerDecay;
    public float initialTimerFactor;
    public float initialTimerRadius;
    public float taskStartFailFactor;
    public float initialWaitTime;
  
    private Hashtable timeouts;
    private float startTime;
    private float nextTime;
    private int score;
  
    void Start()
    {
        timeouts = new Hashtable();
        startTime = Time.time;
        nextTime = startTime + initialWaitTime;
        score = 0;
        IncScore(0);
    }

    void Update()
    {
        // Check for timed out tasks
        foreach (TaskType task in TaskType.GetValues(typeof(TaskType))) {
            if (timeouts.ContainsKey(task) && (float)timeouts[task] <= Time.time) {
                GameOver();
            }
        }
        // Start a new task, reset task timer
        if (Time.time >= nextTime) {
            bool success = StartTask();
            float factor = Random.value * (2 * initialTimerRadius) + (initialTimerFactor - initialTimerRadius);
            if (!success) { // If no task can be started, cut the next time by a factor
                factor *= taskStartFailFactor;
            }
            nextTime = Time.time + (factor * timerDecay) / ((Time.time - startTime) + timerDecay);
        }
    }
    
    private bool StartTask() {
        // Check if all tasks are already assigned
        System.Array types = TaskType.GetValues(typeof(TaskType));
        int numTasks = types.Length;
        if (timeouts.Count >= numTasks) {
            return false;
        }
        
        // Pick and start a new task timer
        TaskType startType = (TaskType)types.GetValue((int)Random.Range(0.0f, types.Length));
        while (timeouts.ContainsKey(startType)) {
            startType = (TaskType)types.GetValue((int)Random.Range(0.0f, types.Length));
        }
        TaskDirector director = GetDirector(startType);
        timeouts.Add(startType, Time.time + director.timeout);
        director.Activate();
        return true;
    }
    
    private TaskDirector GetDirector(TaskType type) {
        TaskDirector result;
        switch (type) {
            case TaskType.MOM:
                result = momDirector;
                break;
            case TaskType.BROTHER:
                result = brotherDirector;
                break;
            case TaskType.ROUTER:
                result = routerDirector;
                break;
            case TaskType.CAT:
                result = catDirector;
                break;
            case TaskType.GENERATOR:
                result = generatorDirector;
                break;
            case TaskType.COMPUTER:
            default:
                result = computerDirector;
                break;
        }
        return result;
    }
    
    public void MarkComplete(TaskType type) {
        bool removed = timeouts.ContainsKey(type);
        timeouts.Remove(type);
        if (removed) {
            IncScore(scoreInc);
        }
    }
    
    private void IncScore(int amount) {
        score += amount;
        scoreText.text = "Score: " + score;
    }
    
    public float GetTimeRemaining(TaskType type) {
        if (timeouts.ContainsKey(type)) {
            return (float)timeouts[type] - Time.time;
        } else {
            return 0.0f;
        }
    }
    
    void GameOver() {
        // TODO: transition to game over screen, report score
        Debug.Log("GAME OVER!!");
    }
    
}
