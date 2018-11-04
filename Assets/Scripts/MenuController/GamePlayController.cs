using UnityEngine;
using System.Collections;

public class GamePlayController : MonoBehaviour {


	[SerializeField]
	private GameObject pausePanel;

	void Awake() {
		Debug.Log ("awake");
		pausePanel.SetActive(false);
	}

	public void PauseGame() {
		Time.timeScale = 0f;
		pausePanel.SetActive(true);
	}
	public void ResumeGame() {
		Time.timeScale = 1f;
		pausePanel.SetActive(false);
	}
	public void QuitGame() {
		Time.timeScale = 1f;
		Application.LoadLevel ("MainMenu");
	}
}
