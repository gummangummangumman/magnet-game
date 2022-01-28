using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowingCamera : MonoBehaviour
{

    public Transform playerTransform;
    public float distanceFromPlayer = 5;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = playerTransform.position - new Vector3(0, -1.5f, distanceFromPlayer);
    }
}
