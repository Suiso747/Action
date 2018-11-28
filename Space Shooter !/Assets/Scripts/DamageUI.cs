using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DamageUI : MonoBehaviour
{

    private Text damageText; //テキストの透明度
    private float alpha; //フェードアウトするスピード
    public float fadeOutSpeed = 1f; //移動値

    [SerializeField] public float moveValue = 0.4f;

    void Start()
    {
        damageText = GetComponentInChildren<Text>(); //不透明度は最初は1.0f

        alpha = 1f;
       // Destroy(gameObject, 4f);
    }

    void LateUpdate()
    {
        //　少しづつ透明にしていく
        alpha -= fadeOutSpeed * Time.deltaTime;
        //　テキストのcolorを設定
        damageText.color = new Color(damageText.color.r, damageText.color.g, damageText.color.b, alpha);

        damageText.transform.position += Vector3.up * moveValue * Time.deltaTime;

        if (alpha < 0f)
        {
            Destroy(gameObject);
        }
    }
}