using UnityEngine;
using System.Collections;

public class InputController : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        EscButton();
    }

    private void EscButton()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            GUIController.SetMenu();
        }
    }
}
