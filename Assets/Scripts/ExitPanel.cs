using UnityEngine.SceneManagement;
using UnityEngine;

public class ExitPanel : MonoBehaviour {
	[SerializeField] private DataPersistenceManager Manager;
	// Start is called before the first frame update
	public void Close() { Application.Quit(); }

	public void Reset() { SceneManager.LoadScene(0); }
}
