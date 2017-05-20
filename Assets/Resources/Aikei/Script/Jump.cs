using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour {

	public string jump;
	public string mini;

	public float jumpPow;

	bool floorFlg=false;

	Move MV;
	void Start(){
		MV = this.GetComponent<Move> ();
	}
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (jump)) {
			if (Input.GetKey (mini)) {
				Jmp (jumpPow / 1.5f);
			} else {
				Jmp (jumpPow);
			}
		}
	}
	public void Jmp(float pow){
		if(floorFlg==true&&MV.enabled==true) {
			Vector3 trans;
			trans = new Vector3 (0f, pow, 0f);
			//相手の反対側へ,相手との距離＊power倍の力で押し出す
			this.GetComponent<Rigidbody> ().AddForce (trans);
		}
	}
	void OnCollisionEnter(Collision col){
		if (col.transform.name == "floor") {
			floorFlg = true;			
		}
	}
	void OnCollisionExit(Collision col){
		if (col.transform.name == "floor") {
			floorFlg = false;
		}
	}

}
