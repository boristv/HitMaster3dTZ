using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerMovement : MonoBehaviour
{
    public MovementPath MyPath;
    public float speed = 1f;
    public float maxDistance = 0.1f;
    
    private IEnumerator<Transform> pointInPath;
    
    [SerializeField] private Transform finish;
    
    public bool IsFinish;

    private IEnumerator running;

    public UnityAction ReachPoint;
    
    private void Awake()
    {
        pointInPath = MyPath.GetNextPathPosition();
        
        pointInPath.MoveNext();
        
        transform.position = pointInPath.Current.position;
    }
    
    public void StartRun()
    {
        running = Run();
        StartCoroutine(running);
    }

    public void StopRun()
    {
        if(running != null) 
            StopCoroutine(running);
    }
    
    private IEnumerator Run()
    {
        if (pointInPath == null || pointInPath.Current == null)
        {
            yield break;
        }

        while (true)
        {
            transform.LookAt(pointInPath.Current.position);
            transform.position =
                Vector3.MoveTowards(transform.position, pointInPath.Current.position, Time.deltaTime * speed);
            if (ReachedPoint())
            {
                ReachPoint?.Invoke();
            }
            yield return null;
        }
    }
    

    public void MoveToNextPoint()
    {
        pointInPath.MoveNext();
    }

    public bool OnFinish()
    {
        return pointInPath.Current == finish;
    }

    public bool CheckEnemyAtPosition()
    {
        return pointInPath.Current.childCount == 0;
    }

    private bool ReachedPoint()
    {
        var distanceSquare = (transform.position - pointInPath.Current.position).sqrMagnitude;
        return distanceSquare < maxDistance * maxDistance;
    }
}
