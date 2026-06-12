using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class KeyHolder : MonoBehaviour
{
    public int maxKeys;
    public List<Key> keysHolding = new();

    public TMP_Text notificationText;

    Coroutine currentNotification;
    public float notificationTime = 2.2f;

    public bool HasAllKeys(out int numberOfKeysLeft)
    {
        bool toReturn = keysHolding.Count == maxKeys;
        numberOfKeysLeft = maxKeys - keysHolding.Count;
        return toReturn;
    }
    public void AddKey(Key key)
    {
        keysHolding.Add(key);

        if (currentNotification != null)
            return;

        currentNotification = StartCoroutine(
            ShowText($"You picked up {key.Name}", notificationTime)
        );
    }

    public void CheckDoor(Door door)
    {
        if (currentNotification != null)
            return;

        if (!HasAllKeys(out int numberOfKeysLeft))
        {
            currentNotification = StartCoroutine(
                ShowText($"You need to find {numberOfKeysLeft} more keys", notificationTime)
            );
        }
        else
        {
            currentNotification = StartCoroutine(
                ShowText($"Door open!", 3f)
            );
            door.gameObject.SetActive(false);
        }
    }

    IEnumerator ShowText(string message, float duration)
    {
        notificationText.gameObject.SetActive(true);
        notificationText.text = message;

        yield return new WaitForSeconds(duration);

        notificationText.gameObject.SetActive(false);

        currentNotification = null;
    }
}