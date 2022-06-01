using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingScenes : MonoBehaviour{

    //Load any scene that is inputted
    public void LoadScene(string scene){
        SceneManager.LoadScene(scene);
    }


}
