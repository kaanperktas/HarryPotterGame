using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject levelFinishParent;
    // Update is called once per frame
    void Update()
    {
        
    }
    public void restartLevel()
    {
        SceneManager.LoadScene(0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Harry")
        {
            levelFinishParent.SetActive(true);
            Destroy(other.gameObject);
        }
        else
        {
            levelFinishParent.SetActive(false);
        }
    }
}
