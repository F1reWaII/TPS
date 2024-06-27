using UnityEngine;
using UnityEngine.SceneManagement;

public class ReloadOnEscape : MonoBehaviour
{
    private void Start()
    {
        Vector3 pos1 = new Vector3(1, 3, 2);
         Vector3 pos2 = new Vector3(0, 5, 4);
        float result = Vector3.Distance(pos1, pos2);
        Debug.Log(result);
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
