using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    public Animator transitionAnim;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EndScene(string name)
    {
        StartCoroutine(End(name));
    }
    public void Dmaged()
    {
        transitionAnim.ResetTrigger("damaged");
        transitionAnim.SetTrigger("damaged");
    }
    IEnumerator End(string name)
    {
        transitionAnim.SetTrigger("end");
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(name);
        yield return null;
             
    }
}
