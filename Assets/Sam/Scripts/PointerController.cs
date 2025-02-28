using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class PointerController : MonoBehaviour
{
    public ChampagneController champagneScript; 

    public Transform pointA; // Reference to the starting point
    public Transform pointB; // Reference to the ending point
    public RectTransform safeZone; // Reference to the safe zone RectTransform
    public float moveSpeed = 100f; // Speed of the pointer movement

    private float direction = 1f; // 1 for moving towards B, -1 for moving towards A
    private RectTransform pointerTransform;
    private Vector3 targetPosition;

    private bool isGameOver;
    public Text toastTextPrompt;

    private Timer timer;


    void Start()
    {
        pointerTransform = GetComponent<RectTransform>();
        targetPosition = pointB.position;

        if (champagneScript == null)
        {
            champagneScript = FindObjectOfType<ChampagneController>();
        }


        if (toastTextPrompt != null)
        {
            toastTextPrompt.gameObject.SetActive(true);
        }

        timer = Timer.instance;
        if (timer != null)
        {
            timer.ResetTimer();
            timer.OnTimerEnd += OnTimeEnd;
        }
    }

    void Update()
    {
        if (isGameOver)
        {
            return;
        }

        if (!isGameOver)
        {
            // Move the pointer towards the target position
            pointerTransform.position = Vector3.MoveTowards(pointerTransform.position, targetPosition, moveSpeed * Time.deltaTime);

            // Change direction if the pointer reaches one of the points
            if (Vector3.Distance(pointerTransform.position, pointA.position) < 0.1f)
            {
                targetPosition = pointB.position;
                direction = 1f;
            }
            else if (Vector3.Distance(pointerTransform.position, pointB.position) < 0.1f)
            {
                targetPosition = pointA.position;
                direction = -1f;
            }

            // Check for input
            if (Input.GetKeyDown(KeyCode.Space))
            {
                CheckSuccess();
            }
        }
    }

     void CheckSuccess()
    {
        isGameOver = true;

        if (toastTextPrompt != null)
        {
            toastTextPrompt.gameObject.SetActive(false);
        }

        // Check if the pointer is within the safe zone
        if (RectTransformUtility.RectangleContainsScreenPoint(safeZone, pointerTransform.position, null))
        {
            Debug.Log("Win");
            champagneScript.ToastWin();
            StartCoroutine(DelaySceneTransition());
        }
        else
        {
            Debug.Log("Fail!");
            HealthManager.instance.LoseHealth();
            champagneScript.ToastLose();
            StartCoroutine(DelaySceneTransition());
        }

        if (timer != null)
        {
            timer.StopTimer();
        }
    }

    void OnTimeEnd()
    {
        isGameOver = true;
        champagneScript.ToastLose();
        HealthManager.instance.LoseHealth();
        StartCoroutine(DelaySceneTransition());
    }

    void LoadRandomScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int randomSceneIndex;

        do
        {
            randomSceneIndex = Random.Range(1, SceneManager.sceneCountInBuildSettings);
        }
        while (randomSceneIndex == currentSceneIndex || randomSceneIndex == 0 || randomSceneIndex == 2);

        SceneManager.LoadScene(randomSceneIndex);
    }

    IEnumerator DelaySceneTransition()
    {
        yield return new WaitForSeconds(1.5f);

        LoadRandomScene();
    }
}