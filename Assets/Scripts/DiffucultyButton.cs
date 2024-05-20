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

        // Maus týk olayý dinleme
        button.onClick.AddListener(SetDiffuculty);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Zorluk deðiþtirme
    void SetDiffuculty()
    {
        Debug.Log(button.gameObject.name + " butonuna basýldý");
        gameManager.StartGame(difficulty);
    }
}
