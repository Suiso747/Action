using UnityEngine;
using System.Collections;
using UnityEngine.Audio;
using UnityEngine.UI;

public class BattleMusic : MonoBehaviour
{

    public AudioMixer battle_mixer;

    private Object[] AudioArray_loops;

    public float fadeout_speed = 45.0f;
    public float fadein_speed = 65.0f;

    private AudioSource audio_loop1;
    private AudioSource audio_loop2;
    private AudioSource audio_loop3;

    private float audio_soft_vol;
    private float audio_med_vol;
    private float audio_forte_vol;

    public bool soft;
    public bool med;
    public bool forte;

    private bool first_run;



    // シーン上の特定タグのオブジェクト数を数えるためのタイマー
	GameObject[] tagObjects;
    float timer = 0.0f;
    float interval = 0.2f;

    // プレイヤーのHPを参照
    public GameObject HPSlider;
    public Slider hpSlider;
    float hp_rate;

    // BGMのピッチ
    public float exhighPitch;
    public float highPitch;
    public float normalPitch;

    // Use this for initialization
    void Start()
    {
        first_run = false;


        audio_loop1 = (AudioSource)gameObject.AddComponent<AudioSource>();
        audio_loop2 = (AudioSource)gameObject.AddComponent<AudioSource>();
        audio_loop3 = (AudioSource)gameObject.AddComponent<AudioSource>();

        audio_loop1.outputAudioMixerGroup = battle_mixer.FindMatchingGroups("soft")[0];
        audio_loop2.outputAudioMixerGroup = battle_mixer.FindMatchingGroups("med")[0];
        audio_loop3.outputAudioMixerGroup = battle_mixer.FindMatchingGroups("forte")[0];
        AudioArray_loops = Resources.LoadAll("Music", typeof(AudioClip));

        audio_loop1.clip = AudioArray_loops[0] as AudioClip;
        audio_loop2.clip = AudioArray_loops[1] as AudioClip;
        audio_loop3.clip = AudioArray_loops[2] as AudioClip;
        audio_loop1.loop = true;
        audio_loop2.loop = true;
        audio_loop3.loop = true;


        hpSlider = HPSlider.GetComponent<Slider>();
        hp_rate = hpSlider.value/hpSlider.maxValue;
    }

    // Update is called once per frame
    void Update()
    {

        // coung tag
		timer += Time.deltaTime;
        if(timer > interval){
            Check("Enemy");
            timer = 0;
        }

        // プレイヤーのHPが少ない時ピッチをあげる
        hp_rate = hpSlider.value / hpSlider.maxValue;
        if (hp_rate <= 0){
            changePitch(0.5f);   
        }else if (hp_rate <= 0.125f){
            changePitch(exhighPitch);
        }else if(hp_rate <= 0.25){
            changePitch(highPitch);
        }else{
            changePitch(normalPitch);
        }

        // music
        battle_mixer.SetFloat("soft", audio_soft_vol);
        battle_mixer.SetFloat("med", audio_med_vol);
        battle_mixer.SetFloat("forte", audio_forte_vol);

        if (!audio_loop1.isPlaying & !audio_loop2.isPlaying & !audio_loop3.isPlaying)
        {
            if (soft | med | forte)
            {
                if (soft)
                {
                    audio_soft_vol = 0.0f;
                    audio_med_vol = -80.0f;
                    audio_forte_vol = -80.0f;
                }
                if (med)
                {
                    audio_soft_vol = -80.0f;
                    audio_med_vol = 0.0f;
                    audio_forte_vol = -80.0f;
                }
                if (forte)
                {
                    audio_forte_vol = 0.0f;
                    audio_med_vol = -80.0f;
                    audio_soft_vol = -80.0f;
                }
                audio_loop1.Play();
                audio_loop2.Play();
                audio_loop3.Play();
            }
        }


        if (soft)
        {
            if (audio_soft_vol < 10.0f) //0.0fだと小さすぎる
            {
                audio_soft_vol += fadein_speed * Time.deltaTime;
            }
            if (audio_med_vol > -80.0f & audio_soft_vol > -20.0f)
            {
                audio_med_vol -= fadeout_speed * Time.deltaTime;
            }
            if (audio_forte_vol > -80.0f & audio_soft_vol > -20.0f)
            {
                audio_forte_vol -= fadeout_speed * Time.deltaTime;
            }
        }

        if (med)
        {
            if (audio_med_vol < 4.0f)
            {
                audio_med_vol += fadein_speed * Time.deltaTime;
            }
            if (audio_soft_vol > -80.0f & audio_med_vol > -20.0f)
            {
                audio_soft_vol -= fadeout_speed * Time.deltaTime;
            }
            if (audio_forte_vol > -80.0f & audio_med_vol > -20.0f)
            {
                audio_forte_vol -= fadeout_speed * Time.deltaTime;
            }
        }

        if (forte)
        {
            if (audio_forte_vol < -5.0f) //0.0fだと大音量すぎる
            {
                audio_forte_vol += fadein_speed * Time.deltaTime;
            }
            if (audio_med_vol > -80.0f & audio_forte_vol > -20.0f)
            {
                audio_med_vol -= fadeout_speed * Time.deltaTime;
            }
            if (audio_soft_vol > -80.0f & audio_forte_vol > -20.0f)
            {
                audio_soft_vol -= fadeout_speed * Time.deltaTime;
            }
        }

        if (!soft & !med & !forte)
        {
            if (audio_forte_vol > -80.0f)
            {
                audio_forte_vol -= fadeout_speed * Time.deltaTime;
            }
            if (audio_forte_vol < -70.0f)
            {
                audio_loop3.Stop();
                first_run = true;
            }
            if (audio_med_vol > -80.0f)
            {
                audio_med_vol -= fadeout_speed * Time.deltaTime;
            }
            if (audio_med_vol < -70.0f)
            {
                audio_loop2.Stop();
                first_run = true;
            }
            if (audio_soft_vol > -80.0f)
            {
                audio_soft_vol -= fadeout_speed * Time.deltaTime;
            }
            if (audio_soft_vol < -70.0f)
            {
                audio_loop1.Stop();
                first_run = true;
            }

        }

    }

	//シーン上のBlockタグが付いたオブジェクトを数える
    void Check(string tagname){
        tagObjects = GameObject.FindGameObjectsWithTag(tagname);

        int n_enemy = tagObjects.Length;

        Debug.Log(n_enemy); //tagObjects.Lengthはオブジェクトの数
        if(n_enemy == 0){
            Debug.Log(tagname + "タグがついたオブジェクトはありません");
        }

        if (n_enemy <= 1 ){
            soft = true;
            med = false;
            forte = false;                    
        }else if (n_enemy <= 3){
            soft = false;
            med = true;
            forte = false;
        }else{
            soft = false;
            med = false;
            forte = true;
        }

        if (first_run)
        {
            if (soft)
            {
                audio_soft_vol = 0.0f;
                audio_med_vol = -80.0f;
                audio_forte_vol = -80.0f;
            }
            if (med)
            {
                audio_soft_vol = -80.0f;
                audio_med_vol = 0.0f;
                audio_forte_vol = -80.0f;
            }
            if (forte)
            {
                audio_forte_vol = 0.0f;
                audio_med_vol = -80.0f;
                audio_soft_vol = -80.0f;
            }
            audio_loop1.Play();
            audio_loop2.Play();
            audio_loop3.Play();
            first_run = false;
        }


    }
     

    public void changePitch(float Pitch){
        if (audio_loop1.pitch < Pitch){
            audio_loop1.pitch += 0.005f;
            audio_loop2.pitch += 0.005f;
            audio_loop3.pitch += 0.005f;
        }else{
            audio_loop1.pitch = Pitch;
            audio_loop2.pitch = Pitch;
            audio_loop3.pitch = Pitch;
        }
       
    }

  
 
}
