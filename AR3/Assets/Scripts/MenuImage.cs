using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR.ARFoundation;

public class MenuImage : MonoBehaviour
{
    // Start is called before the first frame update
    public void startPlane()
    {
        SceneManager.LoadScene("plane");   
    }
}