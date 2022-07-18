using UnityEngine;
using Abstractions;

namespace Core
{
    public class FactionMember : MonoBehaviour, IFactionMember
    {
        public int FactionId => _factionId;
        [SerializeField] private int _factionId;

        public void SetFaction(int factionId)
        {
            _factionId = factionId;
        }
    }
}