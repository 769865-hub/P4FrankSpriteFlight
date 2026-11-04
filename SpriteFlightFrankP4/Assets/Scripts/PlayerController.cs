using UnityEngine.InputSystem;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
   
    private float elapsedTime = 0f;
    private float score = 0f;
    public float scoreMultiplier = 10f;

    public GameObject BoosterFlame;

    public float thrustForce = 1.0f;
    Rigidbody2D rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        elapsedTime += Time.deltaTime;
        score = Mathf.FloorToInt(elapsedTime *  scoreMultiplier);
        Debug.Log("Score: " + score);

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
        Destroy(gameObject);
    }

}
  
  