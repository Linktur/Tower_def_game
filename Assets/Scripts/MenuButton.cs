using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuButton : MonoBehaviour
{
    public void ExitToMenu()
    {
        Application.LoadLevel(0);
    }
}
