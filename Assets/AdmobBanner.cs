using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;


public class AdmobBanner : MonoBehaviour
{
        private readonly string unitID = "ca-app-pub-3940256099942544/6300978111";
        private readonly string test_unitID = "ca-app-pub-3940256099942544/6300978111";
        private readonly string test_deviceID = "";

        private BannerView banner;

        public AdPosition position;


        private void Start()
        {
                InitAd();
                //MobileAds.Initialize((initStatus) => InitAd());

                /*
                MobileAds.Initialize(
                        (initStatus) =>
                        {
                                InitAD();

                                var statusMap = initStatus.getAdapterStatusMap();

                                foreach (var status in statusMap)
                                {
                                        Debug.Log($"{status.Key} : {status.Value}");
                                }
                        }
                );

                */
                        //앱 아이디 ""대신 콜백을 넣어줄수도있음
        }


        private void InitAd()
        {
                string id = Debug.isDebugBuild ? test_unitID : unitID;
                //디벌러먼트 빌드체크를 했다면 테스트 아이디, 아니라면  그냥 아이디

                //banner = new BannerView(id, AdSize.SmartBanner, AdPosition.Bottom);
                banner = new BannerView(id, AdSize.SmartBanner, position);

                AdRequest request = new AdRequest.Builder().AddTestDevice(test_deviceID).Build();

                banner.LoadAd(request);

        }

        public void ToggleAd(bool active)
        {
                if(active)
                {
                        banner.Show();
                }

                else
                {
                        banner.Hide();
                }

        }

        public void DestoryAd()
        {
                banner.Destroy();
        }


}
