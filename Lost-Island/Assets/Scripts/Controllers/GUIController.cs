using UnityEngine;
using System.Collections;

public class GUIController : MonoBehaviour
{

    private static MenuBehaviour menuBehaviour;

    void Start()
    {
        GetMenuBehaviour();
    }

    /// <summary>
    /// Gets reference to MenuBehaviour
    /// </summary>
    private void GetMenuBehaviour()
    {
        if (!menuBehaviour)
        {
            menuBehaviour = MenuBehaviour.menuBehaviour;
        }
        else
        {
            Debug.LogError("Can't find MenuBehaviour");
        }
    }

    /// <summary>
    /// Set menu active
    /// </summary>
    public static void SetMenu()
    {
        if (menuBehaviour)
        {
            if (menuBehaviour.Menu.activeSelf)
            {
                menuBehaviour.ShowMenu(false);
                PlayerController.SetActive(true);
                GameController.gameController.Pause = 1;
            }
            else
            {
                menuBehaviour.ShowMenu(true);
                PlayerController.SetActive(false);
                GameController.gameController.Pause = 0;
            }
        }
        else
        {
            Debug.LogError("Can't find MenuBehaviour");
        }
    }
}
