using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private Rigidbody targetRb;
    private GameManager gameManager;
    public GameObject floatingTextPrefabs;
    public ParticleSystem exlosionParticle;
    

    private float minSpeed = 12;
    private float maxSpeed = 16;
    private float maxTorque = 10;
    private float xRange = 4;
    private float ySpawnPos = -2;

    
    public int pointValue;
    

    void Start()
    {
        
        targetRb = GetComponent<Rigidbody>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();

        targetRb.AddForce(RandomForce(), ForceMode.Impulse);
        targetRb.AddTorque(RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse);

        transform.position = RandomSpawnPos();
    }
 

    // Aþaðý Sýnýr
    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
        if (!gameObject.CompareTag("Bad") && gameManager.isGameActive)
        {
            gameManager.UpdateLives(-1);
        }

    }    

    // Maus ile yok etme & Score tablosu güncelleme
    private void OnMouseDown()
    {
        if (gameManager.isGameActive)
        {
            if (gameObject.CompareTag("Bad"))
            {
                gameManager.UpdateLives(-1);
            }
            Destroy(gameObject);
            gameManager.Fire();
            ShowFloatingText();
            Instantiate(exlosionParticle, transform.position, exlosionParticle.transform.rotation);
            gameManager.UpdateScore(pointValue);
            
        }

    }

    // Yukarý Fýrlatýlan objeler
    Vector3 RandomForce()
    {
        return Vector3.up * Random.Range(minSpeed, maxSpeed);
    }

    // X ekseni spawn sýnýr
    Vector3 RandomSpawnPos()
    {
        return new Vector3(Random.Range(-xRange, xRange), ySpawnPos);
    }

    // Random Dönme hareketleri
    float RandomTorque()
    {
        return Random.Range(-maxTorque, maxTorque);
    }

    public void DestroyTarget()
    {
        if (gameManager.isGameActive)
        {
            if (gameObject.CompareTag("Bad"))
            {
                gameManager.UpdateLives(-1);
            }
            gameManager.Fire();
            Destroy(gameObject);
            ShowFloatingText();
            Instantiate(exlosionParticle, transform.position, exlosionParticle.transform.rotation);
            gameManager.UpdateScore(pointValue);            
        }
    }

    // Kayan yazýlar
    public void ShowFloatingText()
    {        
        var floatingText = Instantiate(floatingTextPrefabs, transform.position, Quaternion.identity);
        TextMesh textMesh = floatingText.GetComponent<TextMesh>();

        if (textMesh != null)
        {
            if (pointValue > 0)
            {
                // Puan deðerini floating text'in metnine ekle
                textMesh.text = "+" + pointValue.ToString();
                textMesh.color = Color.green;
            }
            else
            {
                textMesh.text = pointValue.ToString();
                
            }            
        }
        else
        {
            // Eðer TextMesh bileþeni yoksa uyarý ver
            Debug.LogWarning("TextMesh hatasý");
        }
        
    }
}