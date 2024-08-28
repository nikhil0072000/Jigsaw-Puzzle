using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class PuzzleSelect : MonoBehaviour
{
    public GameObject BG,main_Screen, level_panel,Pfx_Confitee,puzzle1,puzzle2,puzzle3,puzzle4;
    public GameObject Reference;
    private Piece[] pieces;
    public Text levelText;
    public bool Level_Completed=false;
    public LoadingScreen Load_Script;
    
    public void SetPuzzlePhoto(Image Photo)
    {
        Load_Script.audiosource.PlayOneShot(Load_Script.Btn_Sfx);
        
        Reference.GetComponent<SpriteRenderer>().sprite = Photo.sprite;
        
        for (int i = 0; i < 16; i++)
        {
            GameObject.Find("Piece(" + i + ")").transform.Find("House").GetComponent<SpriteRenderer>().sprite = Photo.sprite;
        }
        BG.SetActive(false);
        main_Screen.SetActive(true);
        main_Screen.transform.DOScale(1f, 1f);
        Reference.transform.DOScale(0.12f, 1f);
    }
    public void lEVEcHANGE(int Level_num)
    {
        levelText.GetComponent<Text>().text = "LEVEL" + Level_num;
    }
    // Start is called before the first frame update
    void Start()
    {
        // Find all game objects with the "Puzzle" tag and get their Piece components
        GameObject[] puzzleObjects = GameObject.FindGameObjectsWithTag("Puzzle");
        pieces = new Piece[puzzleObjects.Length];

        for (int i = 0; i < puzzleObjects.Length; i++)
        {
            pieces[i] = puzzleObjects[i].GetComponent<Piece>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!Level_Completed&&AllPiecesInRightPos())
        {
            Debug.Log("bovyptegeraga3");
            StartCoroutine(waitforVFX());
           
        }
    }
    bool AllPiecesInRightPos()
    {
        foreach (Piece piece in pieces)
        {
            if (!piece.InRightPos)
            {
                return false;
            }
        }
        return true;
    }
    IEnumerator waitforVFX()
    {
        Debug.Log("Level Completed");
        Level_Completed = true;
        Pfx_Confitee.SetActive(true);
        main_Screen.transform.DOScale(0f, 1f);
        Reference.transform.DOScale(0f, 1f);
        Load_Script.audiosource.PlayOneShot(Load_Script.Victory_sfx);
        
        yield return new WaitForSeconds(2.5f);
        
        level_panel.SetActive(true);
        
        yield return new WaitForSeconds(0.5f);
        Pfx_Confitee.SetActive(false);
       
    }
}
