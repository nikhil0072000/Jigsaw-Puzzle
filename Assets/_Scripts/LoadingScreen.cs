using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;


public class LoadingScreen : MonoBehaviour
{
    public static int Coin_score;
    public Text Coin_text;
    public GameObject load, Level_Mode, Menu, levelComplete_panel, Setting_Panel;
  float duration = 2f;
    public Image progressBar;
    public  AudioSource audiosource;
    public PuzzleSelect puzzle_Script;
    public   AudioClip Btn_Sfx, snap_Sfx,Victory_sfx;
    void Awake()
    {
       
        Coin_score = 0;
    }
    void Update()
    {
        Coin_text.text = ""+Coin_score;
    }
    // Start is called before the first frame update
    void Start()
    {
        progressBar.fillAmount = 0f;
        progressBar.DOFillAmount(1f, duration).OnComplete(() =>
        {
            load.SetActive(false);
            Menu.SetActive(true);
        });
    }
    public void Play_Btn()
    {
        audiosource.PlayOneShot(Btn_Sfx);
        Menu.SetActive(false);
        Level_Mode.SetActive(true);
        //progressBar.fillAmount = 0f;
        ////progressBar.DOFillAmount(1f, duration).OnComplete(() =>
        ////{
        ////    load.SetActive(false);
        ////    Level_Mode.SetActive(true);
        ////});
    }
    public void Next_Btn()
    {
        levelComplete_panel.SetActive(false);
        Level_Mode.SetActive(true);
        Piece[] piece_Scripts = FindObjectsOfType<Piece>();

        foreach (Piece piece in piece_Scripts)
        {
            piece.InitializePiece();
        }
        puzzle_Script.Level_Completed = false;
    }
    public void Exit_Btn()
    {
        Level_Mode.SetActive(false);
        Menu.SetActive(true);
        audiosource.PlayOneShot(Btn_Sfx);
    }
    // Update is called once per frame
    public void setting_Btn_open()
    {
        Setting_Panel.SetActive(true);
    }
    public void setting_Btn_Close()
    {
        Setting_Panel.SetActive(false);
    }
    
}
