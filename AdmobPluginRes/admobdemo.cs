﻿using UnityEngine;
using System.Collections;
using admob;
public class admobdemo : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Admob.Instance().bannerEventHandler += onBannerEvent;
        Admob.Instance().interstitialEventHandler += onInterstitialEvent;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnGUI(){
		if (GUI.Button (new Rect (0, 0, 100, 60), "initadmob")) {
            Admob ad = Admob.Instance();
             #if UNITY_IOS
            ad.initAdmob("ca-app-pub-27960454450664210/xxxxxxxxx", "ca-app-pub-279343530664210/xxxxxxxxxxx");
            #else 
            ad.initAdmob("ca-app-pub-27960454450664210/xxxxxxxxx", "ca-app-pub-279343530664210/xxxxxxxxxxx");
            #endif
         //   ad.setTesting(true);
		}
        if (GUI.Button(new Rect(120, 0, 100, 60), "showfull"))
        {
            Admob ad = Admob.Instance();
            if (ad.isInterstitialReady())
            {
                ad.showInterstitial();
            }
            else
            {
                ad.loadInterstitial();
            }
        }
        if (GUI.Button(new Rect(240, 100, 100, 60), "showbanner"))
        {
            Admob.Instance().showBannerRelative(AdSize.Banner, AdPosition.BOTTOM_CENTER, 0);
        }
        if (GUI.Button(new Rect(240, 200, 100, 60), "showbannerABS"))
        {
            Admob.Instance().showBannerAbsolute(AdSize.Banner, 0, 30);
        }
        if (GUI.Button(new Rect(240, 300, 100, 60), "hidebanner"))
        {
            Admob.Instance().removeBanner();
        }
	}
    void onInterstitialEvent(string eventName, string msg)
    {
        Debug.Log("handler onAdmobEvent---" + eventName + "   " + msg);
        if (eventName == AdmobEvent.onAdLoaded)
        {
            Admob.Instance().showInterstitial();
        }
    }
    void onBannerEvent(string eventName, string msg)
    {
        Debug.Log("handler onAdmobBannerEvent---" + eventName + "   " + msg);
    }
}
