using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Pontuacao : MonoBehaviour {

	public int points = 0;
	private Text text;

	void Awake(){

		text = GetComponent<Text> ();
		text.text = points.ToString ();

	}

	public void Pontuar(){
	
		points++;
		text.text = points.ToString ();

	}

}
