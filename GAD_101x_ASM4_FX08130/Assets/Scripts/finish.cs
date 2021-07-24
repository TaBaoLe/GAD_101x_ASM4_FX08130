using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;

public class finish : MonoBehaviour
{
    // Start is called before the first frame update
    private int count = 1;

    void Start()
    {
        AdManager.instance.RequestInterstitial();
        count = PlayerPrefs.GetInt("Dead") +1;
    }
    // Update is called once per frame
    void Update()
    {
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
      if(collision.CompareTag("Block"))
      {
        showAd();

        Debug.Log("count: " + count);
        Destroy(gameObject);
        BlockController.instance.ActiveWinPopUp();
    }

}
    void showAd()
    {
      PlayerPrefs.SetInt ("Dead", count);
      PlayerPrefs.Save();
      if(count != 0 && count % 2 == 0){
        AdManager.instance.ShowInterstitial();
      }
    }

}
