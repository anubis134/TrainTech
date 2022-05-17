using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AnomalyController : MonoBehaviour
{
    internal static AnomalyController Instance;
    [SerializeField]
    private List<Image> Probirki = new List<Image>();
    internal bool IsWin = false;
    internal int WinIndex;
    [SerializeField]
    internal TMP_Text WinText;
    async void Start()
    {
        Instance = this;
        await UpdateState();
    }

    private void GetWinIndex()
    {
        foreach (var item in Probirki)
        {
            item.color = Color.blue;
        }
        WinIndex = Random.Range(0, 3);
        Probirki[WinIndex].color = Color.red;
    }

    private async Task UpdateState()
    {
        while (this && !IsWin)
        {
            GetWinIndex();
            await Task.Delay(600);
        }
    }

    public void OpenStartScene()
    {
        SceneManager.LoadScene(0);
    }
}
