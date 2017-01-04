using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Profile {
    public Profile() { }

    private int _number;
    private double _weight;
    private double _totalWeight;

    public int Number {
        get { return _number; }
        set { _number = value; calculateTotals(); }
    }
    public double Weight {
        get { return _weight; }
        set { _weight = value; calculateTotals(); }
    }
    public double TotalWeight {
        get { return _totalWeight; }
    }
    
    private void calculateTotals() {
        this._totalWeight = this.Number * this._weight;
    }

}

