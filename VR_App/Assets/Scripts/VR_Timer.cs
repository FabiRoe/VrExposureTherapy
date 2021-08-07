using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Neben den Standard Unity Anforderungen werden UI und Event Funktionen benötigt
using UnityEngine.UI;
using UnityEngine.Events;


public class VR_Timer : MonoBehaviour
{

    //Public erlaubt eine Bearbeitung im Inspektor von Unity. 
    //Die Werte können dort verändert werden, ohne dass sich
    //das C# Script ändert.
    public Image imgGaze;
    public GameObject myObject;
    public float totalTime = 2;

    //Ein Bool Datentyp kann die Werte true und false annehmen.
    bool gvrStatus;

    //Ein Float Datentyp kann Gleitkommazahlen annehmen.
    float gvrTimer;

    public int distanceOfRay = 10;
    private RaycastHit _hit;


  
    // Update is called once per frame
    void Update()
    {
        //Wenn gvrStatus den Wert true einnimmt, wird die Funktion ausgeführt.
        //Der Bool Wert wird durch die Funktion GVROn() verändert.
        //Die Funktion füllt den fillAmount von imgGaze innerhalb der festgelegten totalTime.
        if (gvrStatus)
        {
            gvrTimer += Time.deltaTime;
            imgGaze.fillAmount = gvrTimer / totalTime;
        }

        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));

        //Wenn sich ein Objekt innerhalb der festgelegten Distance, wird die Funktion ausgeführt.
        if(Physics.Raycast(ray, out _hit, distanceOfRay))
        {

            //Wenn das Bild imgGaze den Füllwert 1 hat und auf ein Objekt mit dem Tag Teleport gerichtet
            //ist, der Spieler zu dem Object teleportiert und ein festgelegtes Objekt sichtbar
            if(imgGaze.fillAmount == 1 && _hit.transform.CompareTag("Teleport"))
            {
                _hit.transform.gameObject.GetComponent<Teleport>().TeleportPlayer();
                myObject.SetActive(true);
            }
        }
    }

    //Wenn die Funktion GVROn aufgerufen wird, nimmt der Bool Datentyp für 
    //gvrStatus den Wert true an.
    //Public er möglicht einen Zugriff im Inspektor. Dort wird die Funktion 
    //über einen Eventtrigger aufgerufen.
    public void GVROn()
    {
        gvrStatus = true;
    }

    //Die Funktion GVROff setzt den Bool Wert auf false und float auf 0.
    //Der fillAmount des Bildes ist eine Funktion im Inspektor, die den 
    //Füllgrad des Bildes bestimmt. Dieser wird ebenfalls auf 0 gesetzt.
    //Die Funktion wird ebenfalls über einen Eventtrigger aufgerufen.
    public void GVROff()
    {
        gvrStatus = false;
        gvrTimer = 0;
        imgGaze.fillAmount = 0;
    }


}
