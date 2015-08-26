using UnityEngine;
using System.Collections;

public class InputController : MonoBehaviour
{

    void Awake()
    {

    }

    // Use this for initialization
    void Start()
    {

    }

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
