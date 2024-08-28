using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Drag : MonoBehaviour
{
    int Order_Layer = 1;
    public GameObject SelectedPiece;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (hit.transform.CompareTag("Puzzle"))
            {
                if (!hit.transform.GetComponent<Piece>().InRightPos)
                {
                    SelectedPiece = hit.transform.gameObject;
                    SelectedPiece.GetComponent<Piece>().Selected = true;
                    SelectedPiece.GetComponent<SortingGroup>().sortingOrder = Order_Layer;
                    Order_Layer++;
                }
                
            }
           
        }
        if (Input.GetMouseButtonUp(0))
        {
            if (SelectedPiece != null)
            {
                SelectedPiece.GetComponent<Piece>().Selected = false;
                SelectedPiece = null;
            }
                
            
        }
        
            if (SelectedPiece!= null)
            {
             Vector3 mousePoint= Camera.main.ScreenToWorldPoint(Input.mousePosition);
             SelectedPiece.transform.position = new Vector3(mousePoint.x, mousePoint.y, 0);
            }
    }
}
