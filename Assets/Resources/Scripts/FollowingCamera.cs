using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowingCamera : MonoBehaviour
{

    public Transform playerTransform;
    public Rigidbody rigid;
    private Player playerScript;
    public float Height = 5;

    // Start is called before the first frame update
    void Start()
    {
        playerScript = playerTransform.GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        rigid.MovePosition(playerTransform.position + new Vector3(0, Height + playerScript.targetSplit, 0) - (playerTransform.forward * 5));
        //transform.position = playerTransform.position + new Vector3(0, Height + playerScript.targetSplit, 0) - (playerTransform.forward * 5);
        rigid.MoveRotation(Quaternion.LookRotation(playerTransform.position, Vector3.up));
        //transform.LookAt(playerTransform);
    }
}
