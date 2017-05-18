using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump_Ai : MonoBehaviour {

	Jump JMP;
	void Start(){
		JMP = this.GetComponent<Jump> ();
		StartCoroutine ("Jump");
	}
	// Update is called once per frame
	void Update () {
	}
	IEnumerator Jump(){
		while (true) {
			JMP.Jmp (JMP.jumpPow);
			yield return new WaitForSeconds (2f);
		}
	}
}
