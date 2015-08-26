using UnityEngine;
using System.Collections;
using UnityStandardAssets.Characters.FirstPerson;

public class PlayerController : MonoBehaviour
{
    private static FirstPersonController fpsController;

    void Awake()
    {
        fpsController = GetComponent<FirstPersonController>();
    }

    public static void SetActive(bool value)
    {
        fpsController.enabled = value;
    }
}
