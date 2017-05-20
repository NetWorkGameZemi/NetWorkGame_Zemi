using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

	/*iki~*/
	//参加人数を表す
	const int party = 2;

	/// <summary>
	/// 配列　０＝Player１,　１＝Player２　・・・true＝生存　false=死　
	/// </summary>
	bool[] ReviveState = new bool[party];
	string[] P_player = new string[party];

	int live_count;
	/*~iki*/

	//移動速度
	public float speed;
	public float dashspd;

	[Range (100, 300)]
	public float power;

	//復帰する時間,10~20間で調整
	public float ReviveTime;

	//移動するクラスを格納する配列
	Move[] MV=new Move[4];

	//衝突した時間を保持する変数
	float GetTime=0;

	//操作不能を解除する関数
	[Range (0.1f, 0.5f)]
	public float OpenTime;

	//未使用
	//プレイヤーのアクションステータスを管理する変数 0=normal,1=repellenc,2=catch
	public static int[] status={0,0};


	void Start(){
		/*iki~*/
		live_count = party;
		//各プレイヤーのstate変数をTrue;
		for (int i=1; i<=party; i++){
			ReviveState [i - 1] = true;
			P_player [i-1] = "Sphere"+ i.ToString();


		}
		/*~iki*/
	}

	// Update is called once per frame
	void Update () {
		//OpenTime分の時間が立ったら
		if (GetTime + OpenTime < Time.time) {

			//操作不能を解除する関数を呼び出し
			MoveRevive ();
		}
	}

	//操作不能を解除する関数
	void MoveRevive(){
		for (int i = 0; i < MV.Length; i++) {

			//格納されたスクリプトが無くなったら終了
			if (MV [i] == null)break;

			//格納されたスクリプトをTrueへ
			MV [i].enabled = true;
		}
	}

	//操作不能時間を管理するタイマー関数(引数：不能にするクラスの型)
	public void Timer(Move move){

//		if (move.gameObject.name == "Sphere1") {
			//移動するScriptの状態をFalseへ
			move.enabled = false;
//		} else {
//		}

		for(int i=0;i<MV.Length;i++){
			if (MV [i] == null) {

				//移動するクラスを格納
				MV [i]=move;
				break;
			}
		}

		//衝突した時間を取得
		GetTime = Time.time;

	}
	/*iki~*/
	//生き残っているplayerをカウントして勝敗を判定する
	public void Judge(string P_name){
		for(int i=0; i<party; i++){
			if (P_player[i] == P_name) {
				ReviveState [i] = false;
				live_count --;
			}
		}

		if(live_count <= 1){
			for(int i=0; i<party; i++){
				if(ReviveState[i] == true){
					Debug.Log (i+1 + "Pの勝利");
					return;
				}
			}


		}


	}
	/*~iki*/

}
