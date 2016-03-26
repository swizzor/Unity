using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Grid : MonoBehaviour {

	public List<Slot> slotList = new List<Slot>();
	private Slot[,] slots = new Slot[3,3];

	public List<int> availableSlots = new List<int> ();

	void Awake(){
		FillArrayGrid ();
	}

	public void SelectSlot(int p_index){

		Slot element = GetSlotByIndex(p_index);

		if (!element.selected) {

			availableSlots.RemoveAt (availableSlots.IndexOf (p_index));
			element.Select ();

			StartCoroutine (WaitCheckVictory ());
		}	

		// DEBUG AVAILABLE SLOTS
		string temp = "";
		foreach (int i in availableSlots) {
			temp += " | " + i;
		}
		Debug.Log (temp);

	}

	IEnumerator WaitCheckVictory(){

		yield return new WaitForSeconds (0.1f);
		Player victoriousPlayer = CheckVictory ();
		if (victoriousPlayer != null) {
			victoriousPlayer.pontuacao.Pontuar ();
			GameController.Instance.EndGame ();
		}else
			if(AllElementsPlaced())
				GameController.Instance.EndGame ();
			else
				GameController.Instance.SwitchTurn ();

	}

	public void Reset(){
		
		GameController.Instance.SwitchTurn ();

		foreach (Slot s in slots) {
		
			s.Reset ();
		
		}

		FillArrayGrid ();
	
	}

	public bool AllElementsPlaced(){

		int placedCount = 0;

		for (int i = 0; i < slots.GetLength (1); i++) {
			for (int j = 0; j < slots.GetLength (1); j++) {
				if (slots [i, j].selected)
					placedCount++;
			}
		}

		if (placedCount == slots.Length)
			return true;
		else
			return false;

	}

	public bool CheckSlotPlaced(int p_index){
	
		if (GetSlotByIndex (p_index).selected)
			return true;
		else
			return false;
	
	}

	public Slot GetSlotByIndex(int p_index){
		if (p_index >= 0 && p_index <= 2)
			return slots [0, p_index];
		else if (p_index >= 3 && p_index <= 5)
			return slots [1, p_index - 3];
		else if (p_index >= 6 && p_index <= 8)
			return slots [2, p_index - 6];
		else
			return null;
	}

	public void FillArrayGrid(){

		availableSlots.Clear ();

		for (int i = 0; i < slotList.Count; i++) {

			availableSlots.Add (i);

			if(i >= 0 && i<= 2)
				slots [0, i] = slotList [i];
			else if(i >= 3 && i<= 5)
				slots [1, i-3] = slotList [i];
			else if(i >= 6 && i<= 8)
				slots [2, i-6] = slotList [i];
		
		}
	}

	public Player CheckVictory(){
		
		Player temp;

		temp = CheckColunas ();
		if (temp != null)
			return temp;
		temp = CheckLinhas ();
		if (temp != null)
			return temp;
		temp = CheckDiagonal ();
		if (temp != null)
			return temp;
		temp = CheckDiagonalSecundaria ();
		if (temp != null)
			return temp;

		return null;
	
	}

	private Player CheckColunas(){

		Player temp;
		//Checa colunas
		for (int j = 0; j < slots.GetLength(1); j++) {
			temp = slots [0, j].markedBy;
			if (temp != null) {
				if (slots [1, j].markedBy == temp && slots [2, j].markedBy == temp)
					return temp;
			} 
		}

		return null;

	}

	private Player CheckLinhas(){

		Player temp;

		//Checa linhas
		for (int i = 0; i < slots.GetLength(1); i++) {
			temp = slots [i, 0].markedBy;
			if (temp != null) {
				if (slots [i, 1].markedBy == temp && slots [i, 2].markedBy == temp)
					return temp;
			} 
		}

		return null;

	}

	private Player CheckDiagonal(){
		
		Player temp;

		//Diagonal principal
		if (slots [0, 0].markedBy != null) {
			temp = slots [0, 0].markedBy;
			if (slots [0, 0].markedBy == temp && slots [1, 1].markedBy == temp && slots [2, 2].markedBy == temp)
				return temp;
		}

		return null;

	}

	private Player CheckDiagonalSecundaria(){

		Player temp;

		//Diagonal secundaria
		if (slots [0, 2].markedBy != null) {
			temp = slots [0, 2].markedBy;
			if (slots [0, 2].markedBy == temp && slots [1, 1].markedBy == temp && slots [2, 0].markedBy == temp)
				return temp;
		}

		return null;

	}

}
