using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hide_Show : MonoBehaviour
{

    // Das Gameobject, das das Script als Componente zugewiesen bekommt, wird beim starten der Szene deaktiviert
    private void Start()
    {
        gameObject.SetActive(false);
    }
}
