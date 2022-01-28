using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathTest : MonoBehaviour
{
    
    public Transform target1;
    [Tooltip("only nessesery if split")]public Transform target2;
    //[Tooltip("only nessesery if merging")]public Transform target3;
    public enum behaviour { streight, split};

    [SerializeField] behaviour Behaviour;

    public List<Transform> Targets()
    {
        List<Transform> result = new List<Transform>();
        switch (Behaviour)
        {
            case behaviour.streight:
                result.Add(target1);
                break;
            case behaviour.split:
                result.Add(target1);
                result.Add(target2);
                break;
            
            default:
                result.Add(target1);
                break;
                
        }
        return result;

    }
    


}
