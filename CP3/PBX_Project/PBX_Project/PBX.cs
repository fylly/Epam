using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PBX_Project
{
    public class PBX : ICollection<PBXPort>
    {
        private ICollection<PBXPort> _pbxPorts = new List <PBXPort> ();

        public void Add(PBXPort item)
        {
            _pbxPorts.Add(item);
        }

        public void Clear()
        {
            _pbxPorts.Clear();
        }

        public bool Contains(PBXPort item)
        {
            return _pbxPorts.Contains(item);
        }

        public void CopyTo(PBXPort[] array, int arrayIndex)
        {
            _pbxPorts.CopyTo(array, arrayIndex);
        }

        public int Count
        {
            get { return _pbxPorts.Count; }
        }

        public bool IsReadOnly
        {
            get { return _pbxPorts.IsReadOnly; }
        }

        public bool Remove(PBXPort item)
        {
            return _pbxPorts.Remove(item);
        }

        public IEnumerator<PBXPort> GetEnumerator()
        {
            return _pbxPorts.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
