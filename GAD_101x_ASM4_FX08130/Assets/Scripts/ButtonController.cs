using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ButtonController : MonoBehaviour
{
    // Start is called before the first frame update
  public void PlayAgainButton()
  {
    //StartCoroutine(Wait3secs());
    Time.timeScale = 1;
    Application.LoadLevel(Application.loadedLevel);
  }
}
