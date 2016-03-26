using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UI : MonoBehaviour {

	public Text actualPlayer;
	public Grid grid;
	public GameObject game;
	public GameObject markerSelection;

	public void EnableMarkerSelection(){

		game.SetActive (false);
		markerSelection.SetActive (true);

	}

	public void EnableGameHUD(){

		game.SetActive (true);
		markerSelection.SetActive (false);
	
	}

}
