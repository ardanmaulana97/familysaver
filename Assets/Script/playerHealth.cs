using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class playerHealth : MonoBehaviour {

	public float fullHealth;
	public GameObject deathFX;
	public AudioClip playerHurt;

	public restartGame theGameManager;


	float currentHealth;

	playerController controlMovement;

	public AudioClip playerDeathSound;
	AudioSource PlayerAS;

	//HUD Variable
	public Slider healthSlider;
	public Image damageScreen;
	public Text gameOverScreen;
	public Text winGameScreen;

	bool damaged = false;
	Color damagedColour = new Color(0f,0f,0f,0.5f);
	float smoothColour = 5f;

	//public float restartTime;
	// Use this for initialization
	void Start () {
		currentHealth = fullHealth;
		controlMovement = GetComponent<playerController> ();

		//HUD Initialization
		healthSlider.maxValue=fullHealth;
		healthSlider.value = fullHealth;

		damaged = false;

		PlayerAS = GetComponent<AudioSource> ();

	}
	
	// Update is called once per frame

	public bool restartKey = false;
	void Update () {

		if (damaged) {
			damageScreen.color = damagedColour;
		} else {
			damageScreen.color = Color.Lerp (damageScreen.color, Color.clear, smoothColour * Time.deltaTime);
		}
		damaged = false;

	}

	public void addDamage(float damage){
		if (damage <= 0) return;
		currentHealth-=damage;

		//PlayerAS.clip = playerHurt;
		//PlayerAS.Play ();
		PlayerAS.PlayOneShot (playerHurt);

		healthSlider.value = currentHealth;
		damaged = true;


		if (currentHealth <= 0) {
			makeDead();
		}
	}

	public void addHealth(float health){
		currentHealth += health;
		if (currentHealth > fullHealth)
			currentHealth = fullHealth;
		healthSlider.value = currentHealth;
	}

	public void RestartTheGame(){
		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);
	}

	public void makeDead(){
		Instantiate (deathFX, transform.position, transform.rotation);
		Destroy (gameObject);
		AudioSource.PlayClipAtPoint (playerDeathSound, transform.position);
		damageScreen.color = damagedColour;

		Animator gameOverAnimator = gameOverScreen.GetComponent<Animator> ();
		gameOverAnimator.SetTrigger ("gameOver");
		gameOverAnimator.SetBool ("restartTime", true);
	}

	public void winGame(){
		Destroy (gameObject);
		Animator winGameAnimator = winGameScreen.GetComponent<Animator> ();
		winGameAnimator.SetTrigger ("gameOver");
		winGameAnimator.SetBool ("restartTime", true);
	}
		
}
