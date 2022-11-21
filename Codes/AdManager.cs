using System.Collections;
using UnityEngine;
using TapsellPlusSDK;
using System.Net;
using System.IO;

public class AdManager : MonoBehaviour
{
    [SerializeField] public static AdManager instance;
    [SerializeField] GameObject adErrorObject;
    [SerializeField] GameObject adLoadingObject;

    #region Singleton
    private void OnEnable()
    {
        if (AdManager.instance == null)
        {
            AdManager.instance = this;
        }
        else
        {
            if (AdManager.instance != this)
            {
                Destroy(this.gameObject);
            }
        }
        DontDestroyOnLoad(this.gameObject);
    }
    #endregion

    #region StandardAd

    [SerializeField] string ZoneID = "633545e319ac407bb9fcbba9";
    [SerializeField] string _responseId;

    public void Request()
    {
        TapsellPlus.RequestStandardBannerAd(ZoneID, BannerType.Banner320X50,

            tapsellPlusAdModel =>
            {
                Debug.Log("on response " + tapsellPlusAdModel.responseId);
                _responseId = tapsellPlusAdModel.responseId;
                Show();
            },
            error =>
            {
                adErrorObject.SetActive(true);
                Debug.Log("Error " + error.message);
                StartCoroutine(TurnOffObjectAtTime(adErrorObject, 2f));
            }
        );
    }

    public void Show()
    {
        TapsellPlus.ShowStandardBannerAd(_responseId, Gravity.Bottom, Gravity.Center,

            tapsellPlusAdModel =>
            {
                Debug.Log("onOpenAd " + tapsellPlusAdModel.zoneId);
            },
            error =>
            {
                Debug.Log("onError " + error.errorMessage);
            }
        );
    }

    public void Hide()
    {
        TapsellPlus.HideStandardBannerAd();
    }

    public void Display()
    {
        TapsellPlus.DisplayStandardBannerAd();
    }

    public void Destroy()
    {
        TapsellPlus.DestroyStandardBannerAd(_responseId);
    }
    #endregion

    #region RewardAd

    [SerializeField] string RZoneID = "633545b739b8bd750e49e44c";
    [SerializeField] string _RresponseId;

    public void RequestReward(int whichOne)
    {
        adLoadingObject.SetActive(true);
        TapsellPlus.RequestRewardedVideoAd(RZoneID,

            tapsellPlusAdModel => {
                Debug.Log("on response " + tapsellPlusAdModel.responseId);
                _RresponseId = tapsellPlusAdModel.responseId;
                adLoadingObject.SetActive(false);
                ShowReward(whichOne);
            },
            error => {
                adErrorObject.SetActive(true);
                Debug.Log("Error " + error.message);
                StartCoroutine(TurnOffObjectAtTime(adLoadingObject, 0.25f));
                StartCoroutine(TurnOffObjectAtTime(adErrorObject, 2f));
            }
        );
    }

    public void ShowReward(int whichOne)
    {
        TapsellPlus.ShowRewardedVideoAd(_RresponseId,

            tapsellPlusAdModel => {
                Debug.Log("onOpenAd " + tapsellPlusAdModel.zoneId);
            },
            tapsellPlusAdModel => {
                Debug.Log("onReward " + tapsellPlusAdModel.zoneId);
                if (whichOne == 0)
                {
                    PlayerMotor motor = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMotor>();
                    motor.AddLife(1);
                    motor.ChangeState(motor.GetComponentInParent<RunningState>());
                }
                else
                {
                    SaveManager.Instance.UpdateAddCoin(whichOne);
                    UIManager uIManager = GameObject.FindObjectOfType<UIManager>();
                    uIManager.UpdateCoin(SaveManager.Instance.allCoins);
                }
            },
            tapsellPlusAdModel => {
                Debug.Log("onCloseAd " + tapsellPlusAdModel.zoneId);
            },
            error => {
                Debug.Log("onError " + error.errorMessage);
            }
        );
    }
    #endregion

    #region InternetConnection
    public string GetHtmlFromUri(string resource)
    {
        string html = string.Empty;
        HttpWebRequest req = (HttpWebRequest)WebRequest.Create(resource);
        try
        {
            using (HttpWebResponse resp = (HttpWebResponse)req.GetResponse())
            {
                bool isSuccess = (int)resp.StatusCode < 299 && (int)resp.StatusCode >= 200;
                if (isSuccess)
                {
                    using (StreamReader reader = new StreamReader(resp.GetResponseStream()))
                    {
                        //We are limiting the array to 80 so we don't have
                        //to parse the entire html document feel free to 
                        //adjust (probably stay under 300)
                        char[] cs = new char[80];
                        reader.Read(cs, 0, cs.Length);
                        foreach (char ch in cs)
                        {
                            html += ch;
                        }
                    }
                }
            }
        }
        catch
        {
            return "";
        }
        return html;
    }
    public bool IsTapsellAvailable()
    {
        string HtmlText = GetHtmlFromUri("http://google.com");
        if (HtmlText == "")
        {
            return false;
        }
        else
        {
            return true;
        }
    }
    #endregion
}