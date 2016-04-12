using System;
using UnityEngine;
using GoogleMobileAds;
using GoogleMobileAds.Api;

public class ADMob : MonoBehaviour {

	[HideInInspector] public InterstitialAd interstitial;
	[HideInInspector] public RewardBasedVideoAd rewardBasedVideo;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void RequestInterstitial()
	{
		#if UNITY_EDITOR
		string adUnitId = "unused";
		#elif UNITY_ANDROID
		string adUnitId = "INSERT_ANDROID_INTERSTITIAL_AD_UNIT_ID_HERE";
		#elif UNITY_IPHONE
		string adUnitId = "INSERT_IOS_INTERSTITIAL_AD_UNIT_ID_HERE";
		#else
		string adUnitId = "unexpected_platform";
		#endif

		// Create an interstitial.
		interstitial = new InterstitialAd(adUnitId);
		// Register for ad events.
		interstitial.OnAdLoaded += HandleInterstitialLoaded;
		interstitial.OnAdFailedToLoad += HandleInterstitialFailedToLoad;
		interstitial.OnAdOpening += HandleInterstitialOpened;
		interstitial.OnAdClosed += HandleInterstitialClosed;
		interstitial.OnAdLeavingApplication += HandleInterstitialLeftApplication;
		// Load an interstitial ad.
		interstitial.LoadAd(createAdRequest());
	}

		public AdRequest createAdRequest()
		{
		return new AdRequest.Builder()
		.AddTestDevice(AdRequest.TestDeviceSimulator)
		//.AddTestDevice("0123456789ABCDEF0123456789ABCDEF")
		.AddKeyword("game")
		.SetGender(Gender.Male)
		.SetBirthday(new DateTime(1985, 1, 1))
		.TagForChildDirectedTreatment(false)
		.AddExtra("color_bg", "9B30FF")
		.Build();
		}

		public void RequestRewardBasedVideo()
		{
		#if UNITY_EDITOR
		string adUnitId = "unused";
		#elif UNITY_ANDROID
		string adUnitId = "INSERT_ANDROID_INTERSTITIAL_AD_UNIT_ID_HERE";
		#elif UNITY_IPHONE
		string adUnitId = "INSERT_IOS_REWARD_BASED_VIDEO_AD_UNIT_ID_HERE";
		#else
		string adUnitId = "unexpected_platform";
		#endif
		rewardBasedVideo.LoadAd(createAdRequest(), adUnitId);
		}

		private void ShowInterstitial(){

		if (interstitial.IsLoaded()){
				interstitial.Show();
			}
		else{
				print("Interstitial is not ready yet.");
			}
		}

		public void ShowRewardBasedVideo(){

		if (rewardBasedVideo.IsLoaded()){
			rewardBasedVideo.Show();
		} else{
				print("Reward based video ad is not ready yet.");
			}
		}

		#region Banner callback handlers

		public void HandleAdLoaded(object sender, EventArgs args)
		{
		print("HandleAdLoaded event received.");
		}

		public void HandleAdFailedToLoad(object sender, AdFailedToLoadEventArgs args)
		{
		print("HandleFailedToReceiveAd event received with message: " + args.Message);
		}

		public void HandleAdOpened(object sender, EventArgs args)
		{
		print("HandleAdOpened event received");
		}

		void HandleAdClosing(object sender, EventArgs args)
		{
		print("HandleAdClosing event received");
		}

		public void HandleAdClosed(object sender, EventArgs args)
		{
		print("HandleAdClosed event received");
		}

		public void HandleAdLeftApplication(object sender, EventArgs args)
		{
		print("HandleAdLeftApplication event received");
		}

		#endregion

		#region Interstitial callback handlers

		public void HandleInterstitialLoaded(object sender, EventArgs args)
		{
		print("HandleInterstitialLoaded event received.");
		}

		public void HandleInterstitialFailedToLoad(object sender, AdFailedToLoadEventArgs args)
		{
		print("HandleInterstitialFailedToLoad event received with message: " + args.Message);
		}

		public void HandleInterstitialOpened(object sender, EventArgs args)
		{
		print("HandleInterstitialOpened event received");
		}

		void HandleInterstitialClosing(object sender, EventArgs args)
		{
		print("HandleInterstitialClosing event received");
		}

		public void HandleInterstitialClosed(object sender, EventArgs args)
		{
		print("HandleInterstitialClosed event received");
		}

		public void HandleInterstitialLeftApplication(object sender, EventArgs args)
		{
		print("HandleInterstitialLeftApplication event received");
		}

		#endregion

		#region RewardBasedVideo callback handlers

		public void HandleRewardBasedVideoLoaded(object sender, EventArgs args)
		{
		print("HandleRewardBasedVideoLoaded event received.");
		}

		public void HandleRewardBasedVideoFailedToLoad(object sender, AdFailedToLoadEventArgs args)
		{
		print("HandleRewardBasedVideoFailedToLoad event received with message: " + args.Message);
		}

		public void HandleRewardBasedVideoOpened(object sender, EventArgs args)
		{
		print("HandleRewardBasedVideoOpened event received");
		}

		public void HandleRewardBasedVideoStarted(object sender, EventArgs args)
		{
		print("HandleRewardBasedVideoStarted event received");
		}

		public void HandleRewardBasedVideoClosed(object sender, EventArgs args)
		{
		print("HandleRewardBasedVideoClosed event received");
		}

		public void HandleRewardBasedVideoRewarded(object sender, Reward args)
		{
		string type = args.Type;
		double amount = args.Amount;
		print("HandleRewardBasedVideoRewarded event received for " + amount.ToString() + " " +
		type);
		}

		public void HandleRewardBasedVideoLeftApplication(object sender, EventArgs args)
		{
		print("HandleRewardBasedVideoLeftApplication event received");
		}

		#endregion
}
