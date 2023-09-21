using System;

namespace Features
{
    public class Health
    {
        private float _value = 0;
        private float _maxValue = 100;
        public float Value => this._value;
        public float MaxValue => this._maxValue;

        public Health(float value)
        {
            _maxValue = value;
            _value = value;
        }
        public Health(float value, float mValue)
        {
            _maxValue = mValue;
            _value = value;
        }
        public void TakeDamage(float value)
        {
            if (value < 0)
                throw new Exception("Damage can not be less zero: " + value.ToString());

            _value -= value;
        }
        public void Heal(float value)
        {
            if (value < 0)
                throw new Exception("Heal can not be less zero: " + value.ToString());

            _value += value;
            if (_value > _maxValue)
            {
                _value = _maxValue;
            }
        }
    }
}
