using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;


class Patterns {
    public Patterns(string type, string pattern) {
        this.type = type;
        this.pattern = pattern;
    }
    public string type { get; set; }
    public string pattern { get; set; }
}

class CalculatedProfile {
    private List<Patterns> patterns = new List<Patterns>();
    private string inputType;
    private string _type { get; set; }
    public string Type { get { return inputType; } }
    private double _metterWeight { get; set; }
    public double MetterWeight { get { return _metterWeight; } }

    public CalculatedProfile(string type) {
        patterns.Add(new Patterns("Lrovno", @"^[L]\d{2,3}\*\d{1,2}$"));
        patterns.Add(new Patterns("trubka", @"^[T]+[R]\d{1,3}\*\d+(\.\d{1,3})?$"));
        this.inputType = type;
        findPattern();
        calculateWeight();
    }

    private void findPattern() {
        this._type = "NONCALC";
        foreach (Patterns item in patterns) {
            Match match = Regex.Match(this.inputType, item.pattern);
            if (match.Success) {
                this._type = item.type;
            }
        }
    }

    private void calculateWeight() {
        switch (this._type) {
            case "trubka":
                this._metterWeight = 666;
                break;
            case "Lrovno":
                this._metterWeight = 999;
                break;
            case "NONCALC":
                this._metterWeight = 0;
                break;
            default:
                this._metterWeight = 333;
                break;
        }
    }
}

