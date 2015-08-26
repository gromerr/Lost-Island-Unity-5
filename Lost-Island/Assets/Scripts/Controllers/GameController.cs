using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameController : MonoBehaviour
{

    public static GameController gameController;

    private SettingsFileManager settingsManager;
    private int levelToLoad;

    public int LevelToLoad
    {
        get
        {
            return levelToLoad;
        }
    }

    public float Pause
    {
        get
        {
            return Time.timeScale;
        }
        set
        {
            if (value < 0)
            {
                Time.timeScale = 1;
            }
            else
            {
                Time.timeScale = value;
            }
        }
    }

    void Awake()
    {

        HoldGameControllerInEveryScene();
        settingsManager = new SettingsFileManager();
        GlobalSettings.SetGraphicsSettings();
        GlobalSettings.SetLanguage();
        GlobalSettings.HoldLanguageManager();
    }


    /// <summary>
    /// Holds this game controller in every scene.
    /// </summary>
    private void HoldGameControllerInEveryScene()
    {

        if (gameController == null)
        {
            DontDestroyOnLoad(gameObject);
            gameController = this;
        }
        else if (gameController != this)
        {
            Destroy(gameObject);
        }

    }

    /// <summary>
    /// Saves the settings to file.
    /// </summary>
    public void SaveSettings()
    {
        GlobalSettings.SetPostProcessingEffect();
        GlobalSettings.SetGraphicsSettings();
        GlobalSettings.SetLanguage();
        settingsManager.Save();
    }

    /// <summary>
    /// Loads level with loading screen.
    /// </summary>
    public void LoadLoadingScreen()
    {
        Application.LoadLevel("LoadingScreen");
    }

    /// <summary>
    /// Loads the level.
    /// </summary>
    /// <param name="id">Identifier.</param>
    public void LoadLevel(int id)
    {

        levelToLoad = id;
    }

}
