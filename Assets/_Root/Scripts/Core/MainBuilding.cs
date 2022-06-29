using UnityEngine;

    public class MainBuilding : MonoBehaviour, IUnitProducer, ISelectable
    {
        [SerializeField] private float _maxHealth = 1000;
        [SerializeField] private Sprite _icon;
        [SerializeField] private Material _material;
        private float _health = 1000;
        public float Health => _health;
        public float MaxHealth => _maxHealth;
        public Sprite Icon => _icon;
        public Material Material => _material;
        [SerializeField] private GameObject _unitPrefab;
        [SerializeField] private Transform _unitsParent;
        public void ProduceUnit()
        {
            Instantiate(_unitPrefab, new Vector3(Random.Range(-10, 10), 0,
            Random.Range(-10, 10)), Quaternion.identity, _unitsParent);
        }

    public void ChangeColour()
    {
        GetComponent<Renderer>().material.color = _material.color;
        _material.color = Color.white;
    }


    }

