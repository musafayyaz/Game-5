using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Target : MonoBehaviour
{
    private GameManager gameManager;
    private Rigidbody targetrb;
    private float minSpeed = 10;
    private float maxSpeed = 12;
    private float maxRange = 4;
    private float xPos = 4;
    private float yPos = 2;
    public int pointValue;
    public ParticleSystem explosion;
    // Start is called before the first frame update
    void Start()
    {
        gameManager =GameObject.Find("Game Manager").GetComponent<GameManager>();
        targetrb = GetComponent<Rigidbody>();
        targetrb.AddForce(RandomForce(), ForceMode.Impulse);
        targetrb.AddTorque(RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse);
        transform.position = RandomPos();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    Vector3 RandomForce()
    {
        return Vector3.up * Random.Range(minSpeed, maxSpeed);
    }
    float RandomTorque()
    {
        return Random.Range(-maxRange, maxRange);
    }
    Vector3 RandomPos()
    {
        return new Vector3(Random.Range(-xPos, xPos), yPos);
    }
    public void OnMouseDown()
    {
        if (gameManager.isGameActive)
        {
            Destroy(gameObject);
            gameManager.ScoreUpdate(pointValue);
            Instantiate(explosion, transform.position, explosion.transform.rotation);
        }
    }
    public void OnTriggerEnter(Collider Other)
    {
        Destroy(gameObject);
        if(!Other.CompareTag("Bad"))
        {
            gameManager.GameOver();
        }
    }
}
