using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;
using System;

public class AdManager : MonoBehaviour
{
    // Start is called before the first frame update
    private BannerView bannerAd;
    private InterstitialAd interstitial;
    public static AdManager instance;
    // Start is called before the first frame update
    private void Awake()
    {
      if(instance == null)
      {
        instance = this;
      }else
      {
        Destroy(gameObject);
        return;
      }
      }
    void Start()
    {
      MobileAds.Initialize(InitializationStatus => {});
      //this.RequestBanner();
    }
    private AdRequest CreateAdRequest()
    {
      return new AdRequest.Builder().Build();
    }
    private void RequestBanner()
    {
      string adUnitId = "ca-app-pub-3940256099942544/6300978111";
      this.bannerAd = new BannerView(adUnitId,AdSize.SmartBanner,AdPosition.Bottom);
      this.bannerAd .LoadAd(this.CreateAdRequest());
    }

    public void RequestInterstitial()
    {
        string adUnitId = "ca-app-pub-3940256099942544/1033173712";
        if(this.interstitial != null)
        this.interstitial.Destroy();

        this.interstitial = new InterstitialAd(adUnitId);
        this.interstitial.LoadAd(this.CreateAdRequest());

    }
    public void ShowInterstitial()
    {
      if(this.interstitial.IsLoaded())
      {
        interstitial.Show();
      }
      else
      {
        Debug.Log("interstitial not ready yet");
      }
    }
    // Update is called once per frame
    void Update()
    {

    }
}
