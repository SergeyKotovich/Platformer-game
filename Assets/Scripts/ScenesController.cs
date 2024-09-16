using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesController : MonoBehaviour
{
    [UsedImplicitly]
    public void LoadGameScene()
    {
        SceneManager.LoadScene(GlobalConstants.GAME_SCENE);
    }
}