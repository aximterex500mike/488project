﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletScript : MonoBehaviour
{
     
  public int damage = 1;


  public bool isEnemyShot = false;

  void Start()
  {
    // 2 - Limited time to live to avoid any leak
    Destroy(gameObject, 2); // 2sec
  }
}
