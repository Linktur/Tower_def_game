using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneFader : MonoBehaviour
{
    public Image img;
    public AnimationCurve curve;

    private void Start()
    {
        StartCoroutine(FadeIn());
    }

    public void FadeTo(string scene)
    {
        Debug.Log("он ъуй!");

        StartCoroutine(FadeOut(scene));
    }

    IEnumerator FadeIn()
    {
        float t = 1f; //1 to 0 
        while (t > 0f)
        {
            t -= Time.deltaTime * 1f;//speed for duration
            float a = curve.Evaluate(t);
            img.color = new Color(0f, 0f, 0, a);
            yield return 0;
        }
    }
    
    IEnumerator FadeOut(string scene)
    {
        float t = 0f; //1 to 0 
        while (t < 1f)
        {
            Debug.Log("я работаю!");
            t += Time.deltaTime * 1f;//speed for duration
            float a = curve.Evaluate(t);
            img.color = new Color(0f, 0f, 0, a);
            yield return 0;
        }
        
        SceneManager.LoadScene(scene);
    }
}