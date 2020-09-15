using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuUI : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        EventManager.Subscribe("game_started", Hide);
        EventManager.Subscribe("game_ended", Show);
        EventManager.Subscribe("game_paused", Show);
    }
    
    // C#에선 한 줄 짜리 메소드를 아래와 같이 표현 가능
    private void Show(object obj) => gameObject.SetActive(true);

    private void Hide(object obj) => gameObject.SetActive(false);
}
