using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

enum Typy {
    Noncalc,
    Lrovno,
    trubka,
};

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
    private String[] splitted;
    private double massWeight = 7850;

    public CalculatedProfile(string type) {
        patterns.Add(new Patterns("Lrovno", @"^[L]\d{2,3}\*\d{1,2}$"));
        patterns.Add(new Patterns("trubka", @"^[T]+[R]\d{1,3}\*\d+(\.\d{1,3})?$"));
        patterns.Add(new Patterns("plochac", @"^[P]+[L]\d{1,4}\*\d{1,4}$"));
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
                string removed = this.inputType.Remove(0,2);
                this.inputType = removed;
                stringTrimm();
                double d;
                Double.TryParse(splitted[0], out d);
                double t;
                Double.TryParse(splitted[1], out t);
                double dInner = d - 2 * t;
                double areaInner = Math.PI * Math.Pow(dInner, 2) / 4;
                double area = Math.PI * Math.Pow(d, 2) / 4 - areaInner;
                this._metterWeight = area / 1000000 * massWeight;
                break;
            case "Lrovno":
                stringTrimm();

                break;
            case "NONCALC":
                this._metterWeight = 0;
                break;
            default:
                this._metterWeight = 333;
                break;
        }
    }

    private void stringTrimm() {
        char delimiter = '*';
        this.splitted = this.inputType.Split(delimiter);
    }
}

