using System.Collections;
using UnityEngine;

public class Laser : MonoBehaviour
{
    Material _currentMaterial;
    CapsuleCollider _collider;
    bool _isActive;
    public Coroutine _currentCoroutine;
    void Start()
    {
        _currentMaterial = GetComponent<MeshRenderer>().material;
        _collider = GetComponent<CapsuleCollider>();
    }

    public void OnLaser(float duration)
    {
        _isActive = true;

        CancelInvoke();

        if (_currentCoroutine != null)
        {
            StopCoroutine(_currentCoroutine);
            _currentCoroutine = null;
        }

        _currentCoroutine = StartCoroutine(FillLaser(0f, 1f, duration));
        Invoke(nameof(ToggleCollider), duration * 0.5f);
    }

    public void OffLaser(float duration)
    {
        _isActive = false;

        CancelInvoke();

        if (_currentCoroutine != null)
        {
            StopCoroutine(_currentCoroutine);
            _currentCoroutine = null;
        }

        _currentCoroutine = StartCoroutine(FillLaser(1f, 0f, duration));
        Invoke(nameof(ToggleCollider), duration * 0.5f);
    }

    IEnumerator FillLaser(float start, float end, float duration)
    {
        float elapsed = 0f;

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            float t = elapsed / duration;
            float value = Mathf.Lerp(start, end, t);
            _currentMaterial.SetFloat("_FillValue", value);
            yield return null;
        }

        _currentMaterial.SetFloat("_FillValue", end);
    }

    void ToggleCollider()
    {
        _collider.enabled = _isActive;
    }

    private void OnTriggerEnter(Collider other)
    {
        GameManager.GameManagerInstance.GameOver();
        Debug.Log("GameOver");
    }
}
