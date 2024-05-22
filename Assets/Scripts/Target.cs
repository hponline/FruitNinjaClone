using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private Rigidbody targetRb;
    private GameManager gameManager;
    private float minSpeed = 12;
    private float maxSpeed = 16;
    private float maxTorque = 10;
    private float xRange = 4;
    private float ySpawnPos = -2;

    public int pointValue;
    public ParticleSystem exlosionParticle;

   
    void Start()
    {
        targetRb = GetComponent<Rigidbody>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();

        targetRb.AddForce(RandomForce(), ForceMode.Impulse);
        targetRb.AddTorque(RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse);
        
        transform.position = RandomSpawnPos();
    }

    
    void Update()
    {
        
    }

    // A�a�� S�n�r
    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
        if (!gameObject.CompareTag("Bad") && gameManager.isGameActive)
        {
            gameManager.UpdateLives(-1);
        }
        
    }

    // Maus ile yok etme & Score tablosu g�ncelleme
    private void OnMouseDown()
    {
        if (gameManager.isGameActive)
        {
            Destroy(gameObject);
            Instantiate(exlosionParticle, transform.position, exlosionParticle.transform.rotation);
            gameManager.UpdateScore(pointValue);
        }
        
    }

    // Yukar� F�rlat�lan objeler
    Vector3 RandomForce()
    {
        return Vector3.up * Random.Range(minSpeed, maxSpeed);
    }

    // X ekseni spawn s�n�r
    Vector3 RandomSpawnPos()
    {
        return new Vector3(Random.Range(-xRange, xRange), ySpawnPos);
    }

    // Random D�nme hareketleri
    float RandomTorque()
    {
        return Random.Range(-maxTorque, maxTorque);
    }

    public void DestroyTarget()
    {
        if (gameManager.isGameActive)
        {
            Destroy(gameObject);
            Instantiate(exlosionParticle, transform.position, exlosionParticle.transform.rotation);
            gameManager.UpdateScore(pointValue);
        }
    }
}
