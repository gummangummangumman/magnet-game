using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ListenForKeyboardInputs();
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
        //TODO actually split
        gameObject.transform.localScale = new Vector3(Random.value, Random.value, Random.value);
    }

}
