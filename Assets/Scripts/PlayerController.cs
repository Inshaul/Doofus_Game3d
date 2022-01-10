using System.Collections;
using UnityEngine;
public class PlayerController : MonoBehaviour
{

    public float speed;
    JsonController jc = new JsonController();
    private GameObject jsonObject;
    //public GameObject GameOverUI;

    
    private void Awake()
    {
        jsonObject = GameObject.Find("JsonObj");
        jc = jsonObject.GetComponent<JsonController>();
        StartCoroutine(Wait());
    }

    private IEnumerator Wait()
    {
        Debug.Log("Waiting for the json data loading");
        yield return new WaitUntil(() => jc.isJsonLoaded == true);
        Debug.Log("Done");
        Debug.Log("JSON LOADED " + jc.isJsonLoaded);
        speed = jc.getSpeed();
    }
    private void Update()
    {
        MovePlayer();
        //GameOver();
    }
    private void MovePlayer()
    {
        float xValue = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        float zValue = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        transform.Translate(xValue, 0, zValue);
    }

}
