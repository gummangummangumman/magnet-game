using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    
    public float movementSpeed = 1;
    public float movementIncreaseOnLap = 1;
    public float minimumSplit = .3f;
    public float splitSpeed = 1;

    public Score score;

    private bool isSplit = false;
    private bool doSplit = false;
    public float targetSplit;
    private float lastSplit;
    private float distanceToTarget;
    private float utilizedSplit;
    private GameObject mainBall, leftBall, rightBall;

    private Vector3 target;

    public SfxPlayer sfxPlayer;

    

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
        //calculate % to target
        float percentage = Vector3.Distance(transform.position, target) / (distanceToTarget);

        
        // animate split and merger
        if (isSplit)
        {

            //leftBall.transform.localPosition = Vector3.MoveTowards(leftBall.transform.localPosition, new Vector3(targetSplit > 0 ? -targetSplit : -minimumSplit, 0, 0), splitSpeed * Time.deltaTime);
            //rightBall.transform.localPosition = Vector3.MoveTowards(rightBall.transform.localPosition, new Vector3(targetSplit > 0 ? targetSplit : minimumSplit, 0, 0), splitSpeed * Time.deltaTime);
            leftBall.transform.localPosition = new Vector3(percentage * ((targetSplit > 0 ? -targetSplit : -minimumSplit)+lastSplit), 0, 0);
            rightBall.transform.localPosition = new Vector3(percentage * ((utilizedSplit = (targetSplit > 0 ? targetSplit : minimumSplit))- lastSplit), 0, 0);
        }
        else if (leftBall.transform.localPosition == new Vector3(0, 0, 0))
        {
            mainBall.SetActive(true);
            leftBall.SetActive(false);
            rightBall.SetActive(false);
        }
        else if(leftBall.transform.localPosition != new Vector3(0, 0, 0))
        {
            //leftBall.transform.localPosition = Vector3.MoveTowards(leftBall.transform.localPosition, new Vector3(0, 0, 0), splitSpeed * Time.deltaTime);
            //rightBall.transform.localPosition = Vector3.MoveTowards(rightBall.transform.localPosition,  new Vector3(0, 0, 0), splitSpeed * Time.deltaTime);
            leftBall.transform.localPosition = new Vector3(-(1 - percentage * (utilizedSplit + lastSplit)), 0, 0);
            rightBall.transform.localPosition = new Vector3(1 - percentage * (utilizedSplit + lastSplit), 0, 0);

        }
        
        

    }

    void SplitMagnet()
    {
        //calculate length of path to split point
        distanceToTarget = Vector3.Distance(transform.position, target);

        //split n merge
        isSplit = !isSplit;
        if (isSplit)
        {
            leftBall.transform.localPosition = new Vector3(0, 0, 0);
            rightBall.transform.localPosition = new Vector3(0, 0, 0);

            mainBall.SetActive(false);
            leftBall.SetActive(true);
            
            rightBall.SetActive(true);
        }

        sfxPlayer.PlaySound(isSplit ? "split" : "merge");
    }

    public void Die()
    {
        score.StopTheCount();
        movementSpeed = 0;
        print("you died");
        SceneManager.LoadScene(2);
    }

    private void OnTriggerEnter(Collider other)
    {
        float _targetSplit = 0;

        print("Entered");
        if (other.name.Contains("PathPoint"))
        {
            target = other.GetComponent<PathTest>().GetDirections(out _targetSplit, out doSplit);
            print(target);
            if (other.name.Equals("PathPoint1"))
            {
                score.IncreaseLaps();
                movementSpeed += movementIncreaseOnLap;
            }
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
