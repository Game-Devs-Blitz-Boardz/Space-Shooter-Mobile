using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.SceneManagement;

public class RewardedAds : MonoBehaviour, IUnityAdsLoadListener, IUnityAdsShowListener
{
    public int adNum = 1;
    [SerializeField] string _androidAdUnitId = "Rewarded_Android";
    [SerializeField] string _iOSAdUnitId = "Rewarded_iOS";
    string _adUnitId = null; // This will remain null for unsupported platforms

    [SerializeField] GameObject player;
    [SerializeField] BannerAd bannerAd;

    WinCondition winCondition;
    [SerializeField] GameObject winConObj;

    void Start() {
        EndGameManager.endManager.RegisterRewardedAds(this);
        winCondition = FindObjectOfType<WinCondition>();
    }
 
    void Awake()
    {   
        // Get the Ad Unit ID for the current platform:
#if UNITY_IOS
        _adUnitId = _iOSAdUnitId;
#elif UNITY_ANDROID
        _adUnitId = _androidAdUnitId;
#endif

        LoadAd();

    }

    public void LoadAd() {
        if (Advertisement.isInitialized) {
            Advertisement.Load(_adUnitId, this);
        }
    }

    public void ShowAd() {
        Advertisement.Show(_adUnitId, this);
    }

    ////////////////////////////////////////////////////////////////

    public void OnUnityAdsAdLoaded(string placementId) {

    }

    public void OnUnityAdsFailedToLoad(string placementId, UnityAdsLoadError error, string message) {

    }

    public void OnUnityAdsShowClick(string placementId) {
        
    }

    public void OnUnityAdsShowComplete(string placementId, UnityAdsShowCompletionState showCompletionState) {
        if (placementId.Equals(_adUnitId) && showCompletionState.Equals(UnityAdsShowCompletionState.COMPLETED)) {
            Time.timeScale = 1;
            player.SetActive(true);
            winCondition.ActivateSpawners(); //
            EndGameManager.endManager.gameOver = false;//
            EndGameManager.endManager.possibleWin = true;//
            winCondition.hasWatchedAd = true;//
            winConObj.SetActive(true); //
            bannerAd.LoadBannerAd();

            LoadAd();
        }
    }

    public void OnUnityAdsShowFailure(string placementId, UnityAdsShowError error, string message) {

    }

    public void OnUnityAdsShowStart(string placementId) {
        EndGameManager.endManager.score = PlayerPrefs.GetInt("Score"+SceneManager.GetActiveScene().name);
        Advertisement.Banner.Hide();
        Time.timeScale = 0;
    }
}
