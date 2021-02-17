
using UnityEngine;
using UnityEngine.SceneManagement;

public class caricamento : MonoBehaviour
{
    public Animator anim;
    private int levelToLoad;
    void Update()
    {

        
    }

    public void FadeToLevel(int levelIndex)
    {
        levelToLoad = levelIndex;
        Create(true);
    }

    void Create(bool state)
    {
        anim.SetBool("slide", state);

    }

    public void OnFadeComplete()
    {
        SceneManager.LoadScene(levelToLoad);
    }

}
