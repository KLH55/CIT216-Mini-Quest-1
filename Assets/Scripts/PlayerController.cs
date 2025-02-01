using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using Unity.VisualScripting;

public class PlayerController : MonoBehaviour
{

    private Rigidbody rb;
    private int health;
    private float movementX;
    private float movementY;
    public float speed = 0;
    public TextMeshProUGUI healthText;
    public GameObject winTextObject;
    public GameObject loseTextObject;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        health = 100;
        SetHealthText();
        winTextObject.SetActive(false);
        loseTextObject.SetActive(false);
    }

    private void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);
        rb.AddForce(movement * speed);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
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
        if (collision.gameObject.tag == "Wall")
        {
            health -= 10;
            SetHealthText();
        }
    }

    void SetHealthText()
    {
        healthText.text = "Health: " + health.ToString();
        if (health <= 0)
        {
            loseTextObject.SetActive(true);
            Application.Quit();

            UnityEditor.EditorApplication.isPlaying = false;
        }
    }

    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();
        movementX = movementVector.x;
        movementY = movementVector.y;
    }

}
