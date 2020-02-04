using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;
using System;

public class AdMobVideo : MonoBehaviour
{
        private readonly string unitID = "ca-app-pub-3940256099942544/8691691433";
        private readonly string test_unitID = "ca-app-pub-3940256099942544/8691691433";


        private readonly string test_deviceID;



        private RewardedAd screenAD;


        private void Start()
        {
                
                InitAd();
        }

        public void OnStartVideoAdMob()
        {
                Show();
        }


        private void InitAd()
        {
                string id = Debug.isDebugBuild ? test_unitID : unitID;


                MobileAds.Initialize(id);
                this.screenAD = new RewardedAd(id);

                this.screenAD.OnAdClosed += HandleRewardedAdClosed;

                screenAD.OnAdLoaded += (sender, e) => Debug.Log("광고가 로드됨");
                screenAD.OnUserEarnedReward += (sender, e) => Reward();
                screenAD.OnAdOpening += (sender, e) => Debug.Log("광고표시 시작");
                screenAD.OnAdFailedToShow += (sender, e) => Debug.Log("광고표시 실패");

                AdRequest request = new AdRequest.Builder().Build();
                this.screenAD.LoadAd(request);

                //콜백 함수
                
        }
        public void HandleRewardedAdClosed(object sender, EventArgs args)
        {
                this.InitAd();
        }
        public void Show()
        {
                if (this.screenAD.IsLoaded())
                {
                        this.screenAD.Show();
                }

                else
                {
                        InitAd();
                }
        }

      
        

        public void Reward()
        {

        }
}