using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class Information : MonoBehaviour
{
    [FormerlySerializedAs("playerBehaviour")] [FormerlySerializedAs("player")] [SerializeField] private PlayerActions playerActions;
    [SerializeField] private GameObject infoPanel;
    [SerializeField] private GameObject finishPanel;

    private void Awake()
    {
        playerActions.WaypointClear += ShowInfo;
        playerActions.StartRun += HideInfo;
        playerActions.OnFinish += ShowFinishInfo;
        playerActions.GetFinish += Restart;
    }

    private void OnDestroy()
    {
        playerActions.WaypointClear -= ShowInfo;
        playerActions.StartRun -= HideInfo;
        playerActions.OnFinish -= ShowFinishInfo;
        playerActions.GetFinish -= Restart;
    }

    private void ShowInfo()
    {
        infoPanel.SetActive(true);
    }
    
    private void HideInfo()
    {
        infoPanel.SetActive(false);
    }
    
    private void ShowFinishInfo()
    {
        finishPanel.SetActive(true);
    }
    
    private void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
