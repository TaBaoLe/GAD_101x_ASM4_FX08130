using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockController : MonoBehaviour
{
  public int blockCount = 0;
  public static BlockController instance = null;
  public GameObject WinPopUp;
    // Start is called before the first frame update
    void Start()
    {
        if(instance == null)
        {
          instance = this;
        }
        blockCount = gameObject.transform.childCount;
    }

    // Update is called once per frame
  public void ActiveWinPopUp()
  {
    Time.timeScale = 0;
    WinPopUp.SetActive(true);
  }


}
