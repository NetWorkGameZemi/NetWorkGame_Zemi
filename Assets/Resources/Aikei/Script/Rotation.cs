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

	bool doOnce = false;

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
			Rot_temple (LEFT, true);
		} else {
			Rot_temple (LEFT, false);
		}
		//右
		if (Input.GetKey (right)) {
			Rot_temple (RIGHT, true);
		} else {
			Rot_temple (RIGHT, false);
		}
		//上
		if (Input.GetKey (up)) {
			Rot_temple (UP, true);
		} else {
			Rot_temple (UP, false);
		}
		//下
		if (Input.GetKey (down)) {
			Rot_temple (DOWN, true);
		} else {
			Rot_temple (DOWN, false);
		}
		Rot ();
	}

	void Rot_temple(int vctl,bool flg){
		rot_vctl [vctl] =flg;
//		aa ();
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
			//Debug.Log ("-10");
			break;
		case RIGHT:
			this.transform.Rotate (0f, 10f, 0f);
			//Debug.Log ("10");
			break;
		default:
			break;
		}
		//Debug.Log (transform.rotation.eulerAngles);
	}
	void aa(){
		bool back=false;

		float Akaku=this.transform.rotation.eulerAngles.y - rot_root.y;
		if (Akaku <= 0) {
			back = true;
			Akaku*=-1;
		}
		float Bkaku=360 - Akaku;
		Debug.Log (Bkaku + ":" + Akaku + ":" + rot_root.y + ":" + transform.rotation.eulerAngles.y);
		if ( Akaku > Bkaku){
			if (back == true) {
				rot_dirc = LEFT;
			} else {
				rot_dirc = RIGHT;
			}
		}else{
			if (back == true) {
				rot_dirc = RIGHT;
			} else {
				rot_dirc = LEFT;
			}
		}
		if (10 > this.transform.rotation.eulerAngles.y - rot_root.y && this.transform.rotation.eulerAngles.y - rot_root.y > -10) {
			rot_dirc=STOP;
		}
	}
}
