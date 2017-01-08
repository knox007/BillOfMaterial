using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Profile {
    public Profile() {
        this._metterWeight = 0;
        this._type = "";
    }

    private string _type;
    private int _number;
    private double _length;
    private double _totalLength;
    private double _metterWeight;
    private double _totalWeight;


    public string Type {
        get { return this._type; }
        set {
            _type = value;
            calculateTotals();
        }
    }


    public double Length {
        get { return _length; }
        set {
            _length = value;
            calculateTotals();
        }
    }

    public double TotalLength {
        get { return _totalLength; }
    }

    public int Number {
        get { return _number; }
        set { _number = value; calculateTotals(); }
    }
    public double MetterWeight {
        get { return _metterWeight; }
    }
    public double TotalWeight {
        get { return _totalWeight; }
    }

    private void calculateTotals() {
        calculateMetterweight();
        this._totalWeight = this._number * this._metterWeight * this._length / 1000;
        this._totalLength = this._number * this._length/1000;
    }

    private void calculateMetterweight() {
        profileDatabase db = new profileDatabase();
        this._metterWeight = db.findMetterweight(this.Type);
        if (this._metterWeight < 0) {
            CalculatedProfile match = new CalculatedProfile(this.Type);
            this._metterWeight = match.MetterWeight;
        }
    }

}

