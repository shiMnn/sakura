using UnityEngine;

public class GameMain : MonoBehaviour {
	void Start () {
        TaskManager.Create();
        PlayerManager.Create();
        GameRandom.Create();

        TaskManager.Instance.AddFront(new TaskSetup());
	}

	void Update () {
        TaskManager.Instance.Update();
    }
}
