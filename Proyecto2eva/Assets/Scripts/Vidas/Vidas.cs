using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Vidas : MonoBehaviour
{
    [SerializeField] Image lifeImage;
    [SerializeField] Sprite[] lifeSprites;
    public int life;

    private void Update()
    {
        if (life <= 0) life = 0;
        LifeUIHandler();
    }

    void LifeUIHandler()
    {
        lifeImage.sprite = lifeSprites[life];
    }




}
