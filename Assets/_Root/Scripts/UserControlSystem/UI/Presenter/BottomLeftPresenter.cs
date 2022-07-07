using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BottomLeftPresenter : MonoBehaviour
{
    [SerializeField] private Image _selectedImage;
    [SerializeField] private Slider _healthSlider;
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private Image _sliderBackground;
    [SerializeField] private Image _sliderFillImage;
    [SerializeField] private SelectableValue _selectedValue;
    [SerializeField] private Material _selectedMaterial;
    [SerializeField] private Material _unselectedMaterial;
    private void Start()
    {
        _selectedValue.OnNewValue += onSelected;
        onSelected(_selectedValue.CurrentValue);
    }
    private void onSelected(ISelectable selected)
    {
        _selectedImage.enabled = selected != null;
        _healthSlider.gameObject.SetActive(selected != null);
        _text.enabled = selected != null;
        if (selected != null)
        {
            _selectedImage.sprite = selected.Icon;
            _text.text = $"{selected.Health}/{selected.MaxHealth}";
            _healthSlider.minValue = 0;
            _healthSlider.maxValue = selected.MaxHealth;
            _healthSlider.value = selected.Health;
            var sliderColor = Color.Lerp(Color.red, Color.green, selected.Health /
                (float)selected.MaxHealth);
            _sliderBackground.color = sliderColor * 0.5f;
            _sliderFillImage.color = sliderColor;
        }
        
    }
}
