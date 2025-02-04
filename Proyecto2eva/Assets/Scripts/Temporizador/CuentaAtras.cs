using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CuentaAtras : MonoBehaviour
{

    public float totalTime = 120f;
    public Text timerText;

    void Start()
    {
        StartCoroutine(StartCountdown());
    }

    IEnumerator StartCountdown()
    {
        float timeLeft = totalTime;

        while (timeLeft > 0)
        {
            timerText.text = "Tiempo Restante: " + Mathf.Ceil(timeLeft).ToString();
            yield return new WaitForSeconds(1f);
            timeLeft--;
        }

        timerText.text = "¡Se ha acabado el tiempo!";
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("Muerte");
    }
   
}
