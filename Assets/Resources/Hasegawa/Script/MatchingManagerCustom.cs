using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Networking.Match;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class MatchingManagerCustom : MonoBehaviour
{
	private const int
	Menu = 0,Main = 1;
	private uint maxNumberOfPeople = 4U;
	private bool onLoaded = false;
	[SerializeField] private string matchName = "default";

	void Start(){onLoaded = true;}

	void FixedUpdate(){
		// シーンがロードされた時
		SceneManager.sceneLoaded += delegate {
			OnLoaded();
		};
		// シーンロードされた時の処理の実行
		if (onLoaded)CallWhenTheSceneIsLoaded ();
	}
	// シーンロード判定処理
	void OnLoaded(){onLoaded = true;}
	// シーンロード実行処理
	void CallWhenTheSceneIsLoaded(){
		// Scene indexの取得し各処理を実行
		switch (SceneManager.GetActiveScene ().buildIndex) {
		case Menu:
			MenuSceneSetup ();
			break;
		case Main:
			MainSceneSetup ();
			break;
		default:
			Debug.Log ("The scene load index is overflowing");
			break;
		}
		onLoaded = false;
	}
	// メニューシーンのセットアップ
	void MenuSceneSetup(){
		// マッチング設定のボタンに処理を割り当て
		GameObject.Find ("SetupMatch").GetComponent<Button> ().onClick.AddListener (SetMatchMaker);
		// ホスト設定ボタンに処理を割り当て
		GameObject.Find("StartMatchHost").GetComponent<Button>().onClick.AddListener(CreateMatch);
		// 参加ボタンに処理を割り当て
		GameObject.Find("JoinMatchGame").GetComponent<Button>().onClick.AddListener(FindMatch);
	}
	// メインシーンのセットアップ
	void MainSceneSetup(){
		// マッチング解除ボタンに処理を割り当て
	}

	// <<
	//マッチング動作の最初に実行
	public void SetMatchMaker(){
		// マッチメーカーをスタート
		NetworkManager.singleton.StartMatchMaker();
	}

	// <<
	// ホストとしての動作 サーバー生成リクエスト
	public void CreateMatch(){
		// マッチの作成をする
		// これを呼ぶクライアントがホストとして扱われる
		NetworkManager.singleton.matchMaker.CreateMatch (matchName, maxNumberOfPeople, true, "", "", "", 0, 0, OnMatchCreate);
	}
	// サーバー生成メソッドを実行した後の返信として呼ばれる
	private void OnMatchCreate(bool success,string extendedInfo,MatchInfo matchInfo){
		if (success) {
			MatchInfo hostInfo = matchInfo;
			// ポート番号設定
			NetworkServer.Listen (hostInfo, 7777);
			// ホストとして稼働を始める
			NetworkManager.singleton.StartHost (hostInfo);
		} else {
			Debug.LogError ("Create match failed");
		}
	}

	// <<
	// マッチングする所を探す
	public void FindMatch(){
		// マッチングリスト取得
		NetworkManager.singleton.matchMaker.ListMatches (0, 20, matchName, false, 0, 0, OnMatchList);
	}
	// マッチングリスト取得のメソッドを実行後の返信として呼ばれる
	private void OnMatchList(bool success,string extendedInfo,List<MatchInfoSnapshot> matches){
		// 取得成功
		if (success) {
			if (matches.Count != 0) {
				//Debug.Log("A list of matches was returned");
				// 一番最初に取得した部屋に参加する
				NetworkManager.singleton.matchMaker.JoinMatch (matches [matches.Count - 1].networkId, "", "", "", 0, 0, OnMatchJoined);
			} else {
				Debug.Log ("No matches in requested room!");
			}
		} else {
			Debug.LogError ("Couldn't connect to match maker");
		}
	}
	// マッチに参加するメソッドを実行後の返信として呼ばれる
	private void OnMatchJoined(bool success,string extendedInfo,MatchInfo matchInfo){
		if (success) {
			//Debug.Log("Able to join a match");
			MatchInfo hostInfo = matchInfo;
			// クライアントとして稼働を始める
			NetworkManager.singleton.StartClient (hostInfo);
		} else {
			Debug.LogError ("Join match failed");
		}
	}
}