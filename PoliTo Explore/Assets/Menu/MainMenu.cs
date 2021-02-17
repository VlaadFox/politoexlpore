using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    //public Animator animator;
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
      //  Create(true);
       // StartCoroutine("Wait");


    }



public void QuitGame()
    {
        Debug.Log("QUIT!!");
        Application.Quit();
    }

/*IEnumerator Wait()
{
    yield return new WaitForSeconds(2f);
    //uIObject.SetActive(false);
    //Destroy(uIObject);
    Destroy(gameObject);

}
void Create(bool state)
    {
        animator.SetBool("slide", state);

    }*/
}
