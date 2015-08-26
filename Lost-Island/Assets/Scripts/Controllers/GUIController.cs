using UnityEngine;
using System.Collections;

public class GUIController : MonoBehaviour
{

    private static MenuBehaviour menuBehaviour;

    void Awake()
    {
        GetMenuBehaviour();
    }

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

    public static void SetMenu()
    {
        if (menuBehaviour)
        {
            if (menuBehaviour.Menu.activeSelf)
            {
                menuBehaviour.ShowMenu(false);
            }
            else
            {
                menuBehaviour.ShowMenu(true);
            }
        }
        else
        {
            Debug.LogError("Can't find MenuBehaviour");
        }
    }
}
