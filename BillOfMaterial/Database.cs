using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

class DBprofile {
    public DBprofile(string type, double metterweight) {
        this._metterWeight = metterweight;
        this._type = type;
    }

    private double _metterWeight;
    private string _type;

    public string Type {
        get { return _type; }
    }
    public double Weight {
        get { return _metterWeight; }
    }
}

class profileDatabase {
    public profileDatabase() {
        readCSV();
    }

    public List<DBprofile> database = new List<DBprofile>();
    private string databasePath = "database.csv";

    private void readCSV() {
        var reader = new StreamReader(File.OpenRead(databasePath));
        while (!reader.EndOfStream) {
            var line = reader.ReadLine();
            var values = line.Split(';');
            var item = new DBprofile(values[0], Convert.ToDouble(values[1]));
            this.database.Add(item);
        }
        reader.Close();
    }

    public double findMetterweight(string type) {
        foreach (DBprofile item in database) {
            if (String.Compare(item.Type, type, true) == 0) {
                return item.Weight;
            }
        }
        return -1;
    }
}

