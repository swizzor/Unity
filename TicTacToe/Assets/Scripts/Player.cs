using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player : MonoBehaviour {

	public MarkerType markerType;
	public PlayerType playerType;

	public Pontuacao pontuacao;

	public void MakeGuess(){
	
		StartCoroutine (Guess ());
	
	}

	IEnumerator Guess(){
		List<int> temp = GameController.Instance.ui.grid.availableSlots;
		yield return new WaitForSeconds (1f);
		int rand = Random.Range (0, (temp.Count-1));
		if (GameController.Instance.ui.grid.CheckSlotPlaced(temp[rand]))
			StartCoroutine (Guess ());
		else
			GameController.Instance.ui.grid.SelectSlot (temp[rand]);
	}

}
