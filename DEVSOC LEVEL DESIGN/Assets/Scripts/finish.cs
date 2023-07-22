using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class finish : MonoBehaviour
{
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if(collision.gameObject.name == "Player")
		{
			completeLevel();
		}
	}
	
	private void completeLevel()
	{
		if(SceneManager.GetActiveScene().buildIndex==2)
		{
			SceneManager.LoadScene(0);
		}
		else
		{
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
		}	
	}
}
