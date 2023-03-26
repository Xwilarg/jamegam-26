using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DungeonDraws.Character
{
    public abstract class ACharacter : MonoBehaviour
    {

        [SerializeField]
        public DungeonDraws.SO.CharacterInfo _info = null;

        public int _physique = 0;
        public int _agility = 0;
        public int _mind = 0;

        private int _hp = 0;
        private int _hpMax = 0;
        private int _mp = 0;
        private int _mpMax = 0;
        private int _init = 0;

        private int _status = 1;

        private void Awake()
        {
            Initialise();
        }

        private void Initialise()
        {
            if (_info != null)
            {
                _physique = _info._physique;
                _agility = _info._agility;
                _mind = _info._mind;
            }
            else
            {
                throw new System.ArgumentNullException();
            }
            _hp = 10 + _physique * 2;
            _hpMax = _hp;
            _mp = 5 + _mind * 2;
            _mpMax = _mp;
            _init = _agility * 2;
        }

        public void CheckStatus()
        {
            if (_hp > 0)
            {
                _status = 1;
            }
            else if (_hp > (_hpMax/2) * -1)
            {
                _status = 0;
            }
            else
            {
                _status = -1;
            }
        }

        public void Hurt(int dmg)
        {
            _hp = _hp - dmg;
            CheckStatus();
        }

        public void Attack(ACharacter target) 
        {
            int rollA = Random.Range(1, 21);
            int rollD = Random.Range(1, 21);

            if (rollA + _agility > rollD + target._agility)
            {
                target.Hurt(_physique);
            }
        }

        // Start is called before the first frame update
        void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {
            
        }
    }
}