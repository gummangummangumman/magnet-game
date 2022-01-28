using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    
    public float movementSpeed = 1;

    private bool isSplit = false;
    private GameObject mainBall, leftBall, rightBall;

    // Start is called before the first frame update
    void Start()
    {
        mainBall = transform.GetChild(0).gameObject;
        leftBall = transform.GetChild(1).gameObject;
        rightBall = transform.GetChild(2).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        ListenForKeyboardInputs();
        Move();
    }

    private void Move()
    {
        transform.position += new Vector3(0, 0, movementSpeed) * Time.deltaTime;
    }

    void ListenForKeyboardInputs()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SplitMagnet();
        }
    }

    void SplitMagnet()
    {
        isSplit = !isSplit;
        if (isSplit)
        {
            mainBall.SetActive(false);
            leftBall.SetActive(true);
            rightBall.SetActive(true);
        }
        else
        {
            mainBall.SetActive(true);
            leftBall.SetActive(false);
            rightBall.SetActive(false);
        }
    }

}
