using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddButton : MonoBehaviour
{

    [SerializeField] private Transform PuzzleField;
    [SerializeField] private GameObject btn;

   private void Awake() 
   {
    for(int i = 0 ; i<8 ; i++)
    {
    GameObject button = Instantiate(btn);
    button.name = "" + i ;
    button.transform.SetParent(PuzzleField,false);

    }
   }
}
