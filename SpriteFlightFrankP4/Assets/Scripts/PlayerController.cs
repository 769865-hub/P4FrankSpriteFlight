using UnityEngine.InputSystem;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;
public class PlayerController : MonoBehaviour
{
    private Button restartButton;
    private Label scoreText;
    private float elapsedTime = 0f;
    private float score = 0f;
    public float scoreMultiplier = 10f;
    public UIDocument uiDocument;
    public GameObject BoosterFlame;
    public GameObject explosionEffect;
    public float thrustForce = 1.0f;
    Rigidbody2D rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        scoreText = uiDocument.rootVisualElement.Q<Label>("ScoreLabel");
        restartButton = uiDocument.rootVisualElement.Q<Button>("RestartButton");
        restartButton.style.display = DisplayStyle.None;
        restartButton.clicked += ReloadScene;
    }

    // Update is called once per frame
    void Update()
    {

        elapsedTime += Time.deltaTime;
        score = Mathf.FloorToInt(elapsedTime *  scoreMultiplier);
        Debug.Log("Score: " + score);
        scoreText.text = "Score: " + score;

        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
        BoosterFlame.SetActive(true);
        }
        else if (Mouse.current.leftButton.wasPressedThisFrame)
        {
        BoosterFlame.SetActive(false);
        }

        if (Mouse.current.leftButton.isPressed)
        {
           //Calculate mouse direction
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Mouse.current.position.value);
            Vector2 direction = (mousePos - transform.position).normalized;
            transform.up = direction;
            rb.AddForce(direction * thrustForce);
         
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Instantiate(explosionEffect, transform.position, transform.rotation);
        restartButton.style.display = DisplayStyle.Flex;
        Destroy(gameObject);
    }

    void ReloadScene()
    {
    SceneManager.LoadScene(SceneManager.GetActiveScene().name);


    }
}
  
  