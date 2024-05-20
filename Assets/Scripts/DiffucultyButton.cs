using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DiffucultyButton : MonoBehaviour
{
    private Button button;
    private GameManager gameManager;

    public int difficulty;
    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();

        // Maus t�k olay� dinleme
        button.onClick.AddListener(SetDiffuculty);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Zorluk de�i�tirme
    void SetDiffuculty()
    {
        Debug.Log(button.gameObject.name + " butonuna bas�ld�");
        gameManager.StartGame(difficulty);
    }
}
