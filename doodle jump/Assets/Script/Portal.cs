using System.Collections;
using System.Collections.Generic;
using System.Xml.Schema;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Portal : MonoBehaviour
{
    float xValue = 0;
    public float timeRemaining = 10;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        xValue += 0.3f;
        transform.localEulerAngles = new Vector3(0, 0, xValue);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            StartCoroutine(SceneCountdown());
        }
       
    }
    IEnumerator SceneCountdown() {
        yield return new WaitForSecondsRealtime(5f);
        SceneManager.LoadScene("BossScene");
    }
}
