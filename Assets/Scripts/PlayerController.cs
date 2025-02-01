using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using Unity.VisualScripting;
using System;

public class PlayerController : MonoBehaviour
{

    private Rigidbody rb;
    private int health;
    private float movementX;
    private float movementY;
    public float speed = 0;
    public TextMeshProUGUI healthText;
    public TextMeshProUGUI timeText;
    public GameObject loseTextObject;
    bool timerActive = false;
    float currentTime;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        health = 100;
        SetHealthText();
        loseTextObject.SetActive(false); // sets lose screen to be inactive
        currentTime = 0;
        StartTimer();
    }

    void Update()
    {
        if (timerActive == true)
        {
            currentTime = currentTime + Time.deltaTime;
        }
        TimeSpan time = TimeSpan.FromSeconds(currentTime);
        timeText.text = time.ToString(@"mm\:ss\:fff");
    }

    private void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);
        rb.AddForce(movement * speed);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp")) // checks to see if the pickup item is there
        {
            other.gameObject.SetActive(false);
            if (health < 100)
            {
                health = health + 10;
                SetHealthText();
            }
        
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Wall") // checking to see if the player collided with a wall
        {
            health -= 10;
            SetHealthText();
        }
    }

    void SetHealthText() // creates the health text in game and also tracks when the player loses for going to zero health
    {
        healthText.text = "Health: " + health.ToString();
        if (health <= 0)
        {
            loseTextObject.SetActive(true);
            StopTimer();
            Application.Quit();

            UnityEditor.EditorApplication.isPlaying = false; // closes out of the game
        }
    }

    public void StartTimer()
    {
        timerActive = true;
    }

    public void StopTimer()
    {
        timerActive = false;
        Debug.Log("Your time was: " + currentTime.ToString());
    }

    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();
        movementX = movementVector.x;
        movementY = movementVector.y;
    }

}
