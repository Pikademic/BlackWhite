using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_script : Entity_script
{

    /// <summary>
    /// Algorithms that govern movement
    /// </summary>
    public enum algorithm { NORTH, EAST, SOUTH, WEST, SPIRAL, TEST}
    public algorithm alg;


    /// <summary>
    /// Time until next action
    /// </summary>
    public float nextMoveTime = 5;


    private void Update()
    {
        // Move
        if (nextMoveTime < 0)
            switch(alg)
            {
                case algorithm.NORTH:
                    Move(Vector3.up);
                    break;
                case algorithm.EAST:
                    Move(Vector3.right);
                    break;
                case algorithm.SOUTH:
                    Move(Vector3.down);
                    break;
                case algorithm.WEST:
                    Move(Vector3.left);
                    break;
                case algorithm.SPIRAL:
                    if (!Move(Vector3.left))
                        if (!Move(Vector3.down))
                            if (!Move(Vector3.right))
                                if (!Move(Vector3.up))
                                    break;
                    break;
                case algorithm.TEST:
                    Move(Vector3.left * 2);
                    break;
                default:
                    Debug.Log("No algorithm selected.");
                    break;
            }

        nextMoveTime -= Time.deltaTime;

    }

}
