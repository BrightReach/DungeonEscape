using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdsManager : MonoBehaviour
{
    private Player m_Player;
    public void ShowRewardAd()
    {
        //Debug.Log("Player Rewarded");
        if (Advertisement.IsReady("rewardedVideo"))
        {
            var options = new ShowOptions
            {
                resultCallback = HandleShowResult
            };

            Advertisement.Show("rewardedVideo", options);
        }
        
    }
    
    void HandleShowResult(ShowResult result)
    {
        switch(result)
        {
            case ShowResult.Finished:
            m_Player.CollectGems(100);
            UIManager.m_Instance.OpenShop(m_Player.m_Diamond);
            break;
            case ShowResult.Skipped:
            //No Gems
            break;
            case ShowResult.Failed:
            //Error
            break;
        }
    }


}
