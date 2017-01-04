using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;


class CalculatedWeight {
    public CalculatedWeight (string type) {
        this.type = type;
    }

    private string type;
    private string Lsame = @"[lL]\d{1,3}\*\d{1,3}";
    private string match() {
        Match match = Regex.Match(this.type, Lsame);
    }        
}

