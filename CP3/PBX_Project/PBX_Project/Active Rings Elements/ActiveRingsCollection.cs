using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PBX_Project
{
    public class ActiveRingsCollection : ICollection<ActiveRing>
    {
        private ICollection<ActiveRing> _activeRings = new List<ActiveRing>();

        // InterfaceMethods
        #region InterfaceMethods
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
        #endregion

        // Methods
        #region UsersMethods
        public void DeleteByPhoneNumber(PhoneNumberStruct item)
        {
            _activeRings = _activeRings.Where(x => !x.IsContainsPhoneNumber(item)).ToList();
        }

        public PhoneNumberStruct GetSecondNumberByNumber(PhoneNumberStruct item)
        {
            var ringsBuff = _activeRings.FirstOrDefault(x => x.IsContainsPhoneNumber(item));

            if (ringsBuff != null)
            {
                return ringsBuff.GetSecondValueIfExist(item);
            }
            else
            {
                return new PhoneNumberStruct();
            }
        }

        public ActiveRing GetActiveTalkByNumber(PhoneNumberStruct number)
        {
            return _activeRings.FirstOrDefault(x => x.IsContainsPhoneNumber(number) && x.State == ActiveRingState.Talk);
        }
        #endregion
    }
}
