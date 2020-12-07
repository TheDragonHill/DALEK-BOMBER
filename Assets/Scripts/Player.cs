using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public Camera mainCamera;

    public NavMeshAgent agent;

    public int health = 100;
    public Text healthText;

    public static int grenadeNumber = 0;
    public Text grenadeText;

    public static int score = 0;
    public Text scoreText;

    void Update()
    {
		//Moves the player to the place indicated with the help of the mouse
		if (Input.GetMouseButton(0))
        {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                //Move the Agent
                agent.SetDestination(hit.point);
            }
        }

		if (health <= 0)
		{
			grenadeNumber = 0;
			score = 0;
			SceneManager.LoadScene("GameScene");
		}

        HandleHealth();
    }

	/// <summary>
	/// Add the important informations in the UI Text
	/// </summary>
    private void HandleHealth()
    {
        healthText.text = health + "%";
        grenadeText.text = "" + grenadeNumber;
        scoreText.text = "Score: " + score;
    }

	/// <summary>
	/// Search for the Enemy to take damage
	/// </summary>
	/// <param name="enemy"></param>
    private void OnTriggerStay(Collider enemy)
    {
        if (enemy.gameObject.tag == "Enemy")
        {
            health--;
        }
    }
	
	/// <summary>
	/// Search for the grenade to pick up
	/// </summary>
	/// <param name="grenade"></param>
    private void OnTriggerEnter(Collider grenade)
    {
        if (grenade.gameObject.tag == "Grenade")
        {
            grenadeNumber++;
            Destroy(grenade.gameObject);
        }
    }
}