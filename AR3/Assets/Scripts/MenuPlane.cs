using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR.ARFoundation;

public class MenuPlane : MonoBehaviour
{
    [SerializeField] private GameObject _indicator = null;
    // Start is called before the first frame update

public void startImage()
    {
        SceneManager.LoadScene("image");
     }

    public void addCharacter()
    {
       _indicator.GetComponent<ARTapToPlaceObject>().PlaceObject();
    }

    public void delCharacter()
    {
        GameObject [] player = GameObject.FindGameObjectsWithTag("Player");
        for (int i = 0; i < player.Length; i++) Destroy(player[i]);
    }
}
