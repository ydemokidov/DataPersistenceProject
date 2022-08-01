using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuUIHandler : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI playerNameInput;
    public void StartGame()
    {
        SceneManager.LoadScene(1);
        PlayerSession.Instance.playerName = playerNameInput.text;
    }

}
