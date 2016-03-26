using UnityEngine;
using System.Collections;

public enum MarkerType{
	NONE,
	CIRCLE,
	EX
}

public enum PlayerType{
	NONE,
	NORMAL,
	MACHINA
}

public class GameController : MonoBehaviour {

	private static GameController instance;
	public static GameController Instance{
	
		get{
			return instance;
		}	
	}

	public Player player;
	public Player machina;
	public Player whosPlaying;
	public UI ui;
	private Animator anim;
	private bool turnSwitcher = true;
	public GameObject inputs;

	void Awake(){

		instance = this;
		anim = GetComponent<Animator> ();

	}

	public void SetPlayerMarker(int p_index){
	
		switch (p_index) {

		case 0:
			player.markerType = MarkerType.CIRCLE;
			machina.markerType = MarkerType.EX;
			break;
		case 1:
			player.markerType = MarkerType.EX;
			machina.markerType = MarkerType.CIRCLE;
			break;
		default:
			break;

		}

		SwitchTurn ();

		ui.EnableGameHUD ();
	
	}

	public void SwitchTurn(){

		turnSwitcher = !turnSwitcher;

		if (turnSwitcher) {
			anim.SetTrigger ("t_machinaTurn");
			ui.actualPlayer.text = "Player 2";
		} else {
			anim.SetTrigger ("t_playerTurn");
			ui.actualPlayer.text = "Player 1";
		}

	}

	public void EndGame(){
	
		ui.grid.Reset ();
	
	}

	public void InputsState(bool p_state = true){
	
		inputs.SetActive (p_state);
	
	}

}
