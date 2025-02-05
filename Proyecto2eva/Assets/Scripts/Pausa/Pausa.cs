using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pausa : MonoBehaviour
{

    public GameObject menuPausa;

    public bool pausa = false;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if(pausa == false)
            {
                menuPausa.SetActive(true);
                pausa = true;

                Time.timeScale = 0;
            }
            else if(pausa == true)
            {
                Reanudar();
            }
        }
    }


    public void Reanudar()
    {
        menuPausa.SetActive(false);
        pausa = false;
        Time.timeScale = 1;
    }

}
