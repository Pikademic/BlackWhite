using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_script : Entity_script
{

    /// <summary>
    /// Entity sprite states
    /// </summary>
    public enum algorithm { NORTH, EAST, SOUTH, WEST, SPIRAL, TEST}
    public algorithm alg;


    private void Update()
    {
        // Move
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
                Debug.Log("Spiral not implimented.");
                break;
            case algorithm.TEST:
                Move(Vector3.left * 2);
                break;
            default:
                Debug.Log("No algorithm selected.");
                break;
        }
        

    }

}
