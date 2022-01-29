using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    
    public float movementSpeed = 1;
    public float minimumSplit = .3f;
    public float splitSpeed = 1;

    public Score score;
    public GameOverUI gameOverUI;

    private bool isSplit = false;
    private bool doSplit = false;
    public float targetSplit;
    private GameObject mainBall, leftBall, rightBall;

    private Vector3 target;

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
        PartsPosition();
    }

    private void Move()
    {
        //transform.position += new Vector3(0, 0, movementSpeed) * Time.deltaTime;
        if (target != Vector3.zero)
        {
            transform.LookAt(target);
            transform.position = Vector3.MoveTowards(transform.position, target, movementSpeed * Time.deltaTime);
        }
        
    }

    void ListenForKeyboardInputs()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SplitMagnet();
        }
    }

    void PartsPosition()
    {
        if (isSplit)
        {
           
            leftBall.transform.localPosition = Vector3.MoveTowards(leftBall.transform.localPosition, new Vector3(targetSplit > 0 ? -targetSplit : -minimumSplit, 0, 0), splitSpeed * Time.deltaTime);
            rightBall.transform.localPosition = Vector3.MoveTowards(rightBall.transform.localPosition, new Vector3(targetSplit > 0 ? targetSplit : minimumSplit, 0, 0), splitSpeed * Time.deltaTime);
        }
        else if (leftBall.transform.localPosition == new Vector3(0, 0, 0))
        {
            mainBall.SetActive(true);
            leftBall.SetActive(false);
            rightBall.SetActive(false);
        }
        else
        {
            leftBall.transform.localPosition = Vector3.MoveTowards(leftBall.transform.localPosition, new Vector3(0, 0, 0), splitSpeed * Time.deltaTime);
            rightBall.transform.localPosition = Vector3.MoveTowards(rightBall.transform.localPosition, new Vector3(0, 0, 0), splitSpeed * Time.deltaTime);
        }
        
        

    }

    void SplitMagnet()
    {
        isSplit = !isSplit;
        if (isSplit)
        {
            leftBall.transform.localPosition = new Vector3(0, 0, 0);
            rightBall.transform.localPosition = new Vector3(0, 0, 0);

            mainBall.SetActive(false);
            leftBall.SetActive(true);
            
            rightBall.SetActive(true);
            
        }
        
    }

    public void Die()
    {
        movementSpeed = 0;
        print("you died");
        SceneManager.LoadScene(2);
    }

    private void OnTriggerEnter(Collider other)
    {
        /*
        if (other.name.Contains("DeathTrap"))
        {
            if (other.GetComponent<DeathTrap>().split && !isSplit)
            {
                Die();
            }
            else if (!other.GetComponent<DeathTrap>().split && isSplit)
            {
                Die();
            }
        }
        */

        float _targetSplit = 0;

        print("Entered");
        if (other.name.Contains("PathPoint"))
        {
            target = other.GetComponent<PathTest>().GetDirections(out _targetSplit, out doSplit);
            print(target);
        }
        if (minimumSplit < _targetSplit)
        {
            targetSplit = _targetSplit;
        }
        PartsPosition();

        if (doSplit && !isSplit)
        {
            Die();
        }
        else if (!doSplit && isSplit)
        {
            Die();
        }

    }

}
