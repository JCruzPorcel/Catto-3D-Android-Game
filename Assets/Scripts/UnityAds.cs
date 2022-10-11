using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.UI;

public class UnityAds : MonoBehaviour, IUnityAdsListener
{
    private string gameID = "3974853";
    private string bannerID = "banner";
    private string interstitialID = "interstitial";
    private string rewardedVideoID = "rewardedVideo";
    public bool TestMode;
    public Button showInterstitial;
    public Button watchRewardAd;
    public Text gemsAmt;

    public void Awake(){
        gemsAmt.text = "Gems: " + PlayerPrefs.GetInt("gems").ToString();
    }
    void Start()
    {
        Advertisement.Initialize(gameID, TestMode);
        showInterstitial.interactable = Advertisement.IsReady(interstitialID);
        watchRewardAd.interactable = Advertisement.IsReady(rewardedVideoID);
        Advertisement.AddListener(this);
      }

    public void ShowInterstitial()
    {
        if (Advertisement.IsReady(interstitialID))
        {
            Advertisement.Show(interstitialID);
        }
    }

    public void ShowRewardedVideo()
    {
        Advertisement.Show(rewardedVideoID);
    }

    public void HideBanner()
    {
        Advertisement.Banner.Hide();
    }

    public void OnUnityAdsReady(string placementID)
    {
        if (placementID == rewardedVideoID)
        {
            watchRewardAd.interactable = true;
        }

        if (placementID == interstitialID)
        {
            showInterstitial.interactable = true;
        }

        if (placementID == bannerID)
        {
            Advertisement.Banner.SetPosition(BannerPosition.BOTTOM_CENTER);
            Advertisement.Banner.Show(bannerID);
        }
    }

    public void OnUnityAdsDidFinish(string placementID, ShowResult showResult)
    {
        if (placementID == rewardedVideoID)
        {
            if (showResult == ShowResult.Finished)
            {
                GetReward();
            }
            else if (showResult == ShowResult.Skipped)
            {
                //Do nothing
            }
            else if (showResult == ShowResult.Failed)
            {
                //tell player ads failed
            }
        }
    }


    public void OnUnityAdsDidError(string message)
    {
        //Show or log the error here
    }

    public void OnUnityAdsDidStart(string placementID)
    {
        //Do this if ads starts
    }

    public void GetReward()
    {
        if (PlayerPrefs.HasKey("gems"))
        {
            int gemAmount = PlayerPrefs.GetInt("gems");
            PlayerPrefs.SetInt("gems", gemAmount + 5);
        }
        else
        {
            PlayerPrefs.SetInt("gems", 50);
        }

        gemsAmt.text = "Gems: " + PlayerPrefs.GetInt("gems").ToString();
    }
}