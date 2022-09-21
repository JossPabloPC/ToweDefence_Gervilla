using System.Collections;
using System.Collections.Generic;
using UnityEngine;

interface MoveToTarget_IE
{
    /// <summary>
    /// Moves the game object to a position
    /// </summary>
    /// <param name="target"></param>
    public void moveToTarget(Vector3 target);
    
    /// <summary>
    /// Gets the distace from the Game Object to the target
    /// </summary>
    /// <param name="target"></param>
    /// <returns></returns>
    public float GetDistanceToTarget(Vector3 target);
    
    /// <summary>
    /// When the game objects get to the designated target, it moves to the next one
    /// </summary>
    /// <param name="Target_point"></param>
    /// <returns></returns>
    public PathPoint ChangeTarget(PathPoint Target_point);
    
    /// <summary>
    /// Tells an object to follow an array of Path Points
    /// </summary>
    /// <param name="FirstTarget"></param>
    /// <returns></returns>
    public void CheckTarget();
}
