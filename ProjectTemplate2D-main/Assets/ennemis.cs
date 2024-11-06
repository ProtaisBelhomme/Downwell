using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LifeSystem))]
public class ennemis : MonoBehaviour
{
    [SerializeField]
    private LifeSystem lifeSystem;


    void Start()
    {
        lifeSystem.onDie.AddListener(DealWithDeath);
    }

    private void DealWithDeath()
    {
        Destroy(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
