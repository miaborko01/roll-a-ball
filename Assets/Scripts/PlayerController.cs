using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    public float speed = 0;
    public TextMeshProUGUI countText;
    public GameObject winTextObject;
    public TextMeshProUGUI timerText;     
    public float enemySpeedUp = 0.3f;     
    public NavMeshAgent enemyAgent;



    private Rigidbody rb;
    private int count;
    private float movementX;
    private float movementY;
    private float elapsed;                
    private bool timerRunning = true;     

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0; 
        SetCountText();
        winTextObject.SetActive(false);


    }

    void Update()  // new function to update the timer
    {
        if (!timerRunning) return;
        elapsed += Time.deltaTime;
        timerText.text = "Time: " + elapsed.ToString("F1");
    }

    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();
        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    void SetCountText() 
    {
        countText.text = "Count: " + count.ToString();
        if (count >= 12)
        {
            timerRunning = false;                                          
            float best = PlayerPrefs.GetFloat("BestTime", float.MaxValue); 
            if (elapsed < best)                                            
            {
                best = elapsed;
                PlayerPrefs.SetFloat("BestTime", best);
            }
            winTextObject.SetActive(true);
            winTextObject.GetComponent<TextMeshProUGUI>().text =           
                "You Win!\nTime: " + elapsed.ToString("F1") + "  Best: " + best.ToString("F1");
            Destroy(GameObject.FindGameObjectWithTag("Enemy"));
        }
    }


    void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);
        rb.AddForce(movement * speed);
    }

    private void OnCollisionEnter(Collision collision)
    {
    if (collision.gameObject.CompareTag("Enemy"))
    {
        timerRunning = false;    
        // Destroy the current object
        Destroy(gameObject); 
        // Update the winText to display "You Lose!"
        winTextObject.gameObject.SetActive(true);
        winTextObject.GetComponent<TextMeshProUGUI>().text = "You Lose!";
    }
    }
    
    void OnTriggerEnter(Collider other) 
    {

        if (other.gameObject.CompareTag("PickUp")) 
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            if (enemyAgent != null) enemyAgent.speed += enemySpeedUp;
            SetCountText();


        }        

    }
}


