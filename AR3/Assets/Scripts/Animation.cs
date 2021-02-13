using UnityEngine;

public class Animation : MonoBehaviour
{
    private Animator _anim = null;
    // Start is called before the first frame update

    private void Awake()
    {
        _anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            _anim.SetTrigger("startAnim");
        }
    }

    void endAnim()
    {
        _anim.SetTrigger("endAnim");
    }
}
