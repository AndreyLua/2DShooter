using UnityEngine;

public class BagView : MonoBehaviour
{
    [SerializeField] private Bag _bag;

    private void Awake()
    {
        _bag.BagChanged += OnBagChanged;
    }

    private void OnBagChanged()
    {

    }
}
