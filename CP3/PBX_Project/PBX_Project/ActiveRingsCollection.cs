using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PBX_Project
{
    public class ActiveRingsCollection : ICollection<ActiveRing>
    {
        private ICollection<ActiveRing> _activeRings = new List<ActiveRing>();

        public void Add(ActiveRing item)
        {
            _activeRings.Add(item);
        }

        public void Clear()
        {
            _activeRings.Clear();
        }

        public bool Contains(ActiveRing item)
        {
            return _activeRings.Contains(item);
        }

        public void CopyTo(ActiveRing[] array, int arrayIndex)
        {
             _activeRings.CopyTo(array, arrayIndex);
        }

        public int Count
        {
            get { return _activeRings.Count; }
        }

        public bool IsReadOnly
        {
            get { return _activeRings.IsReadOnly; }
        }

        public bool Remove(ActiveRing item)
        {
            return _activeRings.Remove(item);
        }

        public IEnumerator<ActiveRing> GetEnumerator()
        {
            return _activeRings.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        // Methods
        public void DeleteByPhoneNumber(PhoneNumber item)
        {
            _activeRings.Where(x => !x.IsContainsPhoneNumber(item));
        }

        public PhoneNumber GetSecondNumber (PhoneNumber item)
        {
            var ringsBuff = _activeRings.Where(x => x.IsContainsPhoneNumber(item)).ToList();

            if (ringsBuff.Count > 0)
            {
                return ringsBuff.Select(x => x.GetSecondValueIfExist(item)).First();
            }
            else
            {
                return new PhoneNumber();
            }
        }
    }
}
