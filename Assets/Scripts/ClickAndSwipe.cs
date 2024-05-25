using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// TrailRenderer ve BoxCollider kullanýmýný zorunlu kýlar
[RequireComponent(typeof(TrailRenderer), typeof(BoxCollider))]
public class ClickAndSwipe : MonoBehaviour
{
    private GameManager gameManager;
    private Camera cam;
    private Vector3 mausePos;
    private TrailRenderer trail;
    private BoxCollider col;
    private bool swiping = false;


    void Update()
    {
        if (gameManager.isGameActive)
        {
            // Mausun sol týkýna basýlýrsa swiping true
            if (Input.GetMouseButtonDown(0))
            {
                swiping = true;
                UpdateComponents();
            }
            // Mausun sol týký býrakýlýrsa swiping false
            else if (Input.GetMouseButtonUp(0))
            {
                swiping = false;
                UpdateComponents();
            }

            if (swiping)
            {
                UpdateMausePosition();
            }
        }
    }

    // bir defa çalýþýr
    void Awake()
    {
        cam = Camera.main;
        trail = GetComponent<TrailRenderer>();
        col = GetComponent<BoxCollider>();
        trail.enabled = false;
        col.enabled = false;

        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // ScreenToWorldPoint, Unity'de ekrandaki bir piksel koordinatýný oyun dünyasýndaki bir koordinata dönüþtürmek için kullanýlýr
    void UpdateMausePosition()
    {
        mausePos = cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10.0f));
        transform.position = mausePos;
    }

    // Eðer swiping true ise, trail ve col bileþenleri etkinleþtirilir.
    void UpdateComponents()
    {
        trail.enabled = swiping;
        col.enabled = swiping;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Target>())
        {
            collision.gameObject.GetComponent<Target>().DestroyTarget();
        }
    }
}
