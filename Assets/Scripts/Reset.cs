using UnityEngine;
using UnityEngine.SceneManagement;

public class Reset : MonoBehaviour
{
	public void resetScene()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
		GameObject.FindGameObjectWithTag("Music").GetComponent<MusicPlayer>().StopMusic();
	}
}
