using UnityEngine;
using System.Collections;

public class BlockStart : MonoBehaviour {

  void OnMouseDown () {
    renderer.material.color = Color.blue;
  }

  void OnMouseUp () {
    renderer.material.color = Color.white;
  }
}
