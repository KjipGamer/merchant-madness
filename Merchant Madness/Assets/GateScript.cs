﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateScript : MonoBehaviour
{
    Player player;

    bool isPlayerInRange;

    [Header("Assign Next Platform (If needed)")]
    [SerializeField] GameObject nextPlatform;

    GameObject gateClickText;

    private void Start() {
        player = FindObjectOfType<Player>();

        GameObject[] tempobjects = Resources.FindObjectsOfTypeAll<GameObject>();
        for (int i = 0; i < tempobjects.Length; i++)
        {
            if (tempobjects[i].name == "GateClickText")
            {
                gateClickText = tempobjects[i];
                break;
            }
        }
    }

    private void OnTriggerEnter(Collider other) {
        isPlayerInRange = true;
        gateClickText.SetActive(true);
    }
    private void OnTriggerExit(Collider other) {
        isPlayerInRange = false;
        gateClickText.SetActive(false);
    }

    private void Update() {
        if(Input.GetKeyDown(KeyCode.Space) && isPlayerInRange && player.inventory.Contains("key_1"))
        {
            gameObject.SetActive(false);
            nextPlatform.SetActive(true);
            gateClickText.SetActive(false);
        }
    }
}
