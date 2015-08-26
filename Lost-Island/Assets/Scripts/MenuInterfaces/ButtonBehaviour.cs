using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ButtonBehaviour : MonoBehaviour
{

    public bool showInMainMenu;
    public bool showInGame;


    protected virtual void Start()
    {
        SetButton();
    }

    protected virtual void OnGUI()
    {
        SetButton();
    }

    protected virtual void SetButton()
    {
        if (MenuBehaviour.menuBehaviour.Menu.activeSelf == true)
        {
            if (Application.loadedLevel == 1)
            {
                ShowButton(showInMainMenu);
            }
            else
            {
                ShowButton(showInGame);
            }
        }
    }

    protected virtual void ShowButton(bool show)
    {
        transform.GetChild(0).gameObject.SetActive(show);
        GetComponent<Button>().interactable = show;
    }
}
