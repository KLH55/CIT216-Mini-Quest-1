using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class WinTrigger : MonoBehaviour
{
    public GameObject winTextObject;
    bool timerActive = false;
    float currentTime;
    private void Start()
    {
        winTextObject.SetActive(false); // sets win screen to be inactive
    }

    private void Update()
    {
        if (timerActive == true)
        {
            currentTime = currentTime + Time.deltaTime;
        }
        TimeSpan time = TimeSpan.FromSeconds(currentTime);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player") // checks to see if the player has colided with the box
        {
            winTextObject.SetActive(true); // Makes win screen appear
            StopTimer();
            Application.Quit(); // if it was an application it would close the game

            UnityEditor.EditorApplication.isPlaying = false; // closes the game if played trhough editior

        }
    }
    public void StopTimer()
    {
        timerActive = false;
        Debug.Log("Your time was: " + currentTime.ToString());
    }

}
