using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Piece : MonoBehaviour
{
    private Vector3 RightPos;
    public bool InRightPos;
    public bool Selected;
     LoadingScreen Load_Script;
    public GameObject Sparkle_efx;
    // Start is called before the first frame update
    void Start()
    {
        Load_Script = FindObjectOfType<LoadingScreen>();
        InitializePiece();
        
    }

    public void InitializePiece()
    {
        
        RightPos = transform.position;
        transform.position = new Vector3(Random.Range(-2f, 2f), Random.Range(-2.3f, -4f));
        InRightPos = false; 
        Sparkle_efx.SetActive(false); 
    }
    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, RightPos) < 0.5f)
        {
            if (!Selected)
            {
                if (!InRightPos)
                {
                    transform.position = RightPos;
                    InRightPos = true;

                    GetComponent<SortingGroup>().sortingOrder = 0;
                    Load_Script.audiosource.PlayOneShot(Load_Script.snap_Sfx);
                    ActivateParticleEffect();
                    LoadingScreen.Coin_score += 10;
                }
                
                
            }
            
        }
    }
    private void ActivateParticleEffect()
    {
        if (Sparkle_efx != null)
        {
            Sparkle_efx.SetActive(true);
        }
        ParticleSystem ps = Sparkle_efx.GetComponent<ParticleSystem>();
        if (ps != null)
        {
            ps.Play();
        }
    }
}
