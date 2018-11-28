using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parameter : MonoBehaviour {

    // データ

    //重要なもの
    public static int[] STAGE_CLEARED = new int[31]; // ステージをクリアしたかのフラグ
    public static int[] HIGHSCORE = new int[31]; // ステージのハイスコア
    public static int SCORE; // 現在のスコアを格納
    public static int MONEY; // お金
    public static int STAGE_MONEY; // 今のステージで手に入れたお金

    //装備に関するもの
    public static int[] HAS_MAIN_WEAPON; // 所持しているか
    public static int[] HAS_SUB_WEAPON;
    public static int[] HAS_SPECIAL;
    public static int[] HAS_EQUIPMENT;

    public static int MAIN_WEAPON;
    public static int SUB_WEAPON;
    public static int SPECIAL;
    public static int EQUIPMENT;





    // 案:全国ハイスコアを入れてもいいかも WebGLなら可能か

    //プレイヤーの強さに関するもの
    public static int CHILD; // ステージ開始時の子機の数


	// Use this for initialization
	void Start () {

   
        DontDestroyOnLoad(this); // シーンが変わってもオブジェクトが破棄されないようにする
	}


    // セーブ
    public static void SaveHighScore(int stage, int score)
    {
        string key = "HIGHSCORE" + stage;
        PlayerPrefs.SetInt(key, score);
        PlayerPrefs.Save();
    }

    public static void SaveChild(int child)
    {
        string key = "CHILD";
        PlayerPrefs.SetInt(key, child);
        PlayerPrefs.Save();
    }

    public static void SaveStageClear(int stage, int flag)
    {
        string key = "STAGE" + stage;
        PlayerPrefs.SetInt(key, flag);
        PlayerPrefs.Save();
    }


    // ロード <キーにデータがないときは0を返す>
    public static int LoadHighScore(int stage)
    {
        string key = "HIGHSCORE" + stage;
        return PlayerPrefs.GetInt(key, 0);
    }

    public static int LoadChild()
    {
        string key = "CHILD";
        return PlayerPrefs.GetInt(key, 0);
    }

    public static int LoadStageClear(int stage)
    {
        string key = "STAGE" + stage;
        return PlayerPrefs.GetInt(key, 0);
    }

}
