using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;


public class AdMobVideo_Reward : MonoBehaviour
{
        private readonly string unitID = "ca-app-pub-3940256099942544/5224354917";
        private readonly string test_unitID = "ca-app-pub-3940256099942544/5224354917";


        private readonly string test_deviceID;


        //private InterstitialAd screenAD;
        private RewardBasedVideoAd screenAD;


        private void Start()
        {
                this.screenAD = RewardBasedVideoAd.Instance;
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
                

                

                //콜백 함수
                screenAD.OnAdClosed += (sender, e) => InitAd(); //광고닫음
                screenAD.OnAdLoaded += (sender, e) => Debug.Log("광고가 로드됨");
                screenAD.OnAdRewarded += (sender, e) => Reward();
                screenAD.OnAdOpening += (sender, e) => Debug.Log("광고표시 시작");
                screenAD.OnAdFailedToLoad+= (sender, e) => Debug.Log("광고표시 실패");

                AdRequest request = new AdRequest.Builder().Build();
                this.screenAD.LoadAd(request, id);

        }

        public void Show()
        {
                if (this.screenAD.IsLoaded())
                {
                        this.screenAD.Show();
                }
        }





        public void Reward()
        {
                
        }
}
