using TMPro;
using UnityEngine;

public class UIKilledZombiesText : MonoBehaviour
{
    private TextMeshProUGUI tmProText;

    private void Awake()
    {
        tmProText = GetComponent<TMPro.TextMeshProUGUI>();
        Zombie.OnZombieDead += ChangeValueOfKilledZombies;
    }

    private void ChangeValueOfKilledZombies(int currentlyDeadZombies)
    {
        tmProText.text = currentlyDeadZombies.ToString();
    }
}
