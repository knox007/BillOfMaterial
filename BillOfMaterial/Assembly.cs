using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BOM {
    class Assembly {
        public Assembly() {
            _number = 0;
            _weigt = 0;
            _name = "Default Ass";
        }

        private List<Profile> _parts = new List<Profile>();
        private int _number;
        private double _weigt;
        private string _name;

        public int Number {
            get { return _number; }
            set {
                _number = value;
                AssemblyUpdate();
            }
        }

        public double Weight {
            get {
                AssemblyUpdate();
                return _weigt;
            }
        }

        public string Name {
            get { return _name; }
            set {
                _name = value;
                AssemblyUpdate();
            }
        }

        public void AssemblyUpdate() {
            this._weigt = 0;
            foreach (Profile profile in _parts) {
                this._weigt = this._weigt + profile.TotalWeight;
            }
            this._weigt = _number * this._weigt;
        }

        public List<Profile> Parts {
            get {
                AssemblyUpdate();
                return _parts;
            }
            set {
                AssemblyUpdate();
                _parts = value;
            }
        }
    }
}

