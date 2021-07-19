using System.Collections.Generic;
using UnityEngine;

public class MovementPath : MonoBehaviour
{
    public enum PathTypes
    {
        Linear,
        Loop
    }

    public PathTypes PathType;
    public int MovementDirection = 1;
    public int MovingTo = 0;
    public Transform[] PathElements;

    public void OnDrawGizmos()
    {
        if (PathElements == null || PathElements.Length < 2)
        {
            return;
        }

        for (int i = 1; i < PathElements.Length; i++)
        {
            Gizmos.DrawLine(PathElements[i-1].position, PathElements[i].position);
        }

        if (PathType == PathTypes.Loop)
        {
            Gizmos.DrawLine(PathElements[0].position, PathElements[PathElements.Length - 1].position);
        }
    }

    public IEnumerator<Transform> GetNextPathPosition()
    {
        if (PathElements == null || PathElements.Length < 1)
        {
            yield break;
        }

        while (true)
        {
            yield return PathElements[MovingTo];

            if (PathElements.Length == 1)
            {
                continue;
            }

            if (PathType == PathTypes.Linear)
            {
                if (MovingTo <= 0)
                {
                    MovementDirection = 1;
                }
                else if (MovingTo >= PathElements.Length - 1)
                {
                    MovementDirection = -1;
                }
            }

            MovingTo += MovementDirection;

            if (PathType == PathTypes.Loop)
            {
                if (MovingTo >= PathElements.Length)
                {
                    MovingTo = 0;
                }

                if (MovingTo < 0)
                {
                    MovingTo = PathElements.Length - 1;
                }
            }
        }
    }
}
