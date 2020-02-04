using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;
public class AdMobScreenAD : MonoBehaviour
{
        private readonly string unitID = "ca-app-pub-3940256099942544/1033173712";
        private readonly string test_unitID = "ca-app-pub-3940256099942544/1033173712";


        private readonly string test_deviceID;


        private InterstitialAd screenAD;



        private void Start()
        {
                InitAd();

                Invoke("Show", 10f);
        }

        private void InitAd()
        {
                string id = Debug.isDebugBuild ? test_unitID : unitID;

                screenAD = new InterstitialAd(id);

                AdRequest request = new AdRequest.Builder().Build();

                screenAD.LoadAd(request);


                //콜백 함수
                screenAD.OnAdClosed += (sender, e) => Debug.Log("광고가 닫힘");
                screenAD.OnAdLoaded += (sender, e) => Debug.Log("광고가 로드됨");
                

        }

        public void Show()
        {
                StartCoroutine("ShowScreenAd");
        }

        private IEnumerator ShowScreenAd()
        {
                while(!screenAD.IsLoaded())
                {
                        yield return null;
                }

                screenAD.Show();
                
        }

}

