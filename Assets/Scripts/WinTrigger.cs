using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinTrigger : MonoBehaviour
{
    public GameObject winTextObject;
    private void Start()
    {
        winTextObject.SetActive(false); // sets win screen to be inactive
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player") // checks to see if the player has colided with the box
        {
            winTextObject.SetActive(true); // Makes win screen appear
            Application.Quit(); // if it was an application it would close the game

            UnityEditor.EditorApplication.isPlaying = false; // closes the game if played trhough editior

        }
    }
}
