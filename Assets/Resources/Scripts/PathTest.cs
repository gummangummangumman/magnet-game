using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathTest : MonoBehaviour
{
    
    [SerializeField] private Transform target;
    

    [Tooltip("keep at 0 for no split")] [SerializeField] public float splitAmount;

    public Vector3 GetDirections(out float targetSplit, out bool split)
    {
        Vector3 direction = new Vector3(0, 1, 0);
        if (target != null)
        {
            direction = target.position;
        }
        split = 0 < splitAmount;

        targetSplit = target.GetComponent<PathTest>().splitAmount;

        return direction;
    }

    



    private void OnDrawGizmos()
    {
        /*
        if (target == null)
        {
            foreach (var pathTest in GameObject.FindObjectsOfType<PathTest>())
            {
                if (pathTest.target == null && pathTest != this)
                {
                    target = pathTest.transform;
                }
            } 
        }
        */

        Gizmos.DrawSphere(transform.position, .3f);
        if (target != null)
        {
            Gizmos.DrawLine(transform.position, target.position);
        }

        transform.LookAt(target);

        if (splitAmount > 0)
        {
            Gizmos.DrawCube(transform.position + (transform.right * splitAmount), new Vector3(.6f, .6f, .6f));
            Gizmos.DrawCube(transform.position - (transform.right * splitAmount), new Vector3(.6f, .6f, .6f));
        }
        
    }




}
