using UnityEngine.SceneManagement;
using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class ExitPanel : MonoBehaviour {
    // Start is called before the first frame update
    public void Close() { Application.Quit(); }

    public void Reset() {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }
}
