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
            StopCoroutine(currentNotification);

        currentNotification = StartCoroutine(
            ShowText($"You picked up {key.Name}", 3f)
        );
    }

    IEnumerator ShowText(string message, float duration)
    {
        notificationText.gameObject.SetActive(true);
        notificationText.text = message;

        yield return new WaitForSeconds(duration);

        notificationText.gameObject.SetActive(false);
    }
}