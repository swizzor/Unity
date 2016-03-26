using UnityEngine;
using System.Collections;

public class Slot : MonoBehaviour {

	public GameObject circle;
	public GameObject ex;
	public bool selected = false;
	public Player markedBy;

	public void Select(){

		Player whosPlaying = GameController.Instance.whosPlaying;

		switch (whosPlaying.markerType) {

		case MarkerType.CIRCLE:
			circle.SetActive (true);
			markedBy = whosPlaying;
			break;
		case MarkerType.EX:
			ex.SetActive (true);
			markedBy = whosPlaying;
			break;

		}

		selected = true;
	}

	public void Reset(){

		selected = false;
		circle.SetActive (false);
		ex.SetActive (false);
		markedBy = null;
	
	}
}
