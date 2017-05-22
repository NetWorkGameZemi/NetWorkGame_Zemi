using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Rotation : MonoBehaviour {

	string left;
	string right;
	string up;
	string down;

	bool[] rot_vctl=new bool[4];

	const int LEFT = 0;
	const int RIGHT = 1;
	const int UP = 2;
	const int DOWN = 3;

	const int STOP =4;
	int rot_dirc;//true=時計回り,false=反時計回り

	Vector3 rot_root=new Vector3(0,0,0);

	Move MV;
	void Start(){
		MV = this.GetComponent<Move> ();
		left = MV.left;
		right = MV.right;
		up = MV.up;
		down = MV.down;
	}
	void Update(){
		if (Input.GetKey (left)) {
			rot_vctl [LEFT] = true;
		} else {
			rot_vctl [LEFT] = false;
		}
		//右
		if (Input.GetKey (right)) {
			rot_vctl[RIGHT] = true;
		} else {
			rot_vctl [RIGHT] = false;
		}
		//上
		if (Input.GetKey (up)) {
			rot_vctl[UP] = true;
		} else {
			rot_vctl [UP] = false;
		}
		//下
		if (Input.GetKey (down)) {
			rot_vctl[DOWN] = true;
		} else {
			rot_vctl [DOWN] = false;
		}
		Rot ();
	}
	void Rot(){
		if (rot_vctl [UP] == true) {
			rot_root = new Vector3 (0, 0, 0);
		}
		if (rot_vctl [DOWN] == true) {
			rot_root = new Vector3 (0, 180, 0);

		}
		if (rot_vctl [LEFT] == true) {
				rot_root = new Vector3 (0, 270, 0);
			if (rot_vctl [UP] == true) {
				rot_root = new Vector3 (0, 315, 0);
			}
			if (rot_vctl [DOWN] == true) {
				rot_root = new Vector3 (0, 225, 0);
			}
		}
		if (rot_vctl [RIGHT] == true) {
			rot_root = new Vector3 (0, 90, 0);
			if (rot_vctl [UP] == true) {
				rot_root = new Vector3 (0, 45, 0);
			}
			if (rot_vctl [DOWN] == true) {
				rot_root = new Vector3 (0, 135, 0);
			}
		}

		aa();			
		switch(rot_dirc){
		case LEFT:
			this.transform.Rotate (0f, -10f, 0f);
			break;
		case RIGHT:
			this.transform.Rotate (0f, 10f, 0f);
			break;
		default:
			break;
		}
	}
	void aa(){
		Debug.Log ("A : " + (this.transform.rotation.eulerAngles.y - rot_root.y) + " B : " + ((360 - this.transform.rotation.eulerAngles.y) + rot_root.y));
		if ( this.transform.rotation.eulerAngles.y - rot_root.y > (360 - this.transform.rotation.eulerAngles.y) + rot_root.y ){
			rot_dirc = RIGHT;
		}else{
			//		if (this.transform.rotation.eulerAngles.y - rot_root.y<180) {
			rot_dirc = LEFT;
		}
		if (10 > this.transform.rotation.eulerAngles.y - rot_root.y && this.transform.rotation.eulerAngles.y - rot_root.y > -10) {
			rot_dirc=STOP;
		}
	}
}
