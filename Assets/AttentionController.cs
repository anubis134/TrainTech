using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AttentionController : MonoBehaviour
{
   void OnMouseDown()
   {
       SceneManager.LoadScene("Wires");
   }
}
