using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class VR_Collect : MonoBehaviour
{

    public Image imgGaze;
    public float totalTime = 2;
    bool gvrStatus;
    float gvrTimer;
    public GameObject ObjectLoadMenu;
    public GameObject ObjectHide;


    public int distanceOfRay = 200;
    private RaycastHit _hit;



    // Update is called once per frame
    void Update()
    {
        if (gvrStatus)
        {
            gvrTimer += Time.deltaTime;
            imgGaze.fillAmount = gvrTimer / totalTime;
        }

        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));

        if (Physics.Raycast(ray, out _hit, distanceOfRay))
        {
            if (imgGaze.fillAmount == 1 && _hit.transform.CompareTag("ObjectForMenu"))
            {
                ObjectLoadMenu.SetActive(true);
                ObjectHide.SetActive(false);
                gvrStatus = false;
                gvrTimer = 0;
                imgGaze.fillAmount = 0;
            }
        }
    }

    public void GVROn()
    {
        gvrStatus = true;
    }

    public void GVROff()
    {
        gvrStatus = false;
        gvrTimer = 0;
        imgGaze.fillAmount = 0;
    }
}