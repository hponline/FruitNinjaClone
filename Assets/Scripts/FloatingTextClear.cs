using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingTextClear : MonoBehaviour
{
    [SerializeField] public float destroyTime = 0.1f;
    
    public void Start()
    {
        Destroy(gameObject,destroyTime);
    }
}
