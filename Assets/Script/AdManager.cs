using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdManager : MonoBehaviour,IUnityAdsListener
{
    string placement = "rewardedVideo";
    void Start() 
    {
        Advertisement.AddListener(this);
        Advertisement.Initialize("4042653", true);
    }
    
    public void adsshow ()
    {
        Advertisement.Show(placement);
    }
    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        if (showResult == ShowResult.Finished)
        {
            Debug.Log("price!");
            //giveprice
        }
        else if (showResult == ShowResult.Failed) 
        {
            //fail
        }

    }
    public void OnUnityAdsDidStart(string placementId)
    {
    }
    public void OnUnityAdsReady(string placementId)
    { 
    }
    public void OnUnityAdsDidError(string message)
    {
    }
}
