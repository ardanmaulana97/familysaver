using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class restartGame : MonoBehaviour {

	public float restartTime;

	//HUD
	public Text gameOverScreen1;
	Animator gameOverAnimator;
	public Text winGameScreen1;
	Animator winGameScreen;
		
	// Use this for initialization
	void Start () {
		gameOverAnimator = gameOverScreen1.GetComponent<Animator> ();
		winGameScreen = winGameScreen1.GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		
		if (gameOverAnimator.GetBool("restartTime")) {
			//StopCoroutine ("Example");
			StartCoroutine ("Example");
		}

		if (winGameScreen.GetBool("restartTime")) {
			//StopCoroutine ("Example");
			StartCoroutine ("Example1");
		}
	}

	IEnumerator Example(){
		yield return new WaitForSeconds (restartTime);
		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);
	}

	IEnumerator Example1(){
		yield return new WaitForSeconds (restartTime);
		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);
	}
}
