using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace iscaPopAlvaro.Model
{
    public class Centre : Base.BaseModel
    {
        private int _id;
        public int id { get { return _id; } set { SetProperty(ref _id, value); } }

        private string _codigo;
        public string codigo { get { return _codigo; } set { SetProperty(ref _codigo, value); } }

        private string _denominacionGenericaES;
        public string denominacionGenericaES { get { return _denominacionGenericaES; } set { SetProperty(ref _denominacionGenericaES, value); } }

        private string _denominacionGenericaVAL;
        public string denominacionGenericaVAL { get { return _denominacionGenericaVAL; } set { SetProperty(ref _denominacionGenericaVAL, value); } }

        private string _denominacionEspecifica;
        public string denominacionEspecifica { get { return _denominacionEspecifica; } set { SetProperty(ref _denominacionEspecifica, value); } }

        private string _denominacion;
        public string denominacion { get { return _denominacion; } set { SetProperty(ref _denominacion, value); } }

        private string _regimen;
        public string regimen { get { return _regimen; } set { SetProperty(ref _regimen, value); } }

        private string _tipoVia;
        public string tipoVia { get { return _tipoVia; } set { SetProperty(ref _tipoVia, value); } }

        private string _direccion;
        public string direccion { get { return _direccion; } set { SetProperty(ref _direccion, value); } }

        private string _numero;
        public string numero { get { return _numero; } set { SetProperty(ref _numero, value); } }

        private string _codigoPostal;
        public string codigoPostal { get { return _codigoPostal; } set { SetProperty(ref _codigoPostal, value); } }

        private string _localidad;
        public string localidad { get { return _localidad; } set { SetProperty(ref _localidad, value); } }

        private string _provincia;
        public string provincia { get { return _provincia; } set { SetProperty(ref _provincia, value); } }

        private string _telefono;
        public string telefono { get { return _telefono; } set { SetProperty(ref _telefono, value); } }

        private string _fax;
        public string fax { get { return _fax; } set { SetProperty(ref _fax, value); } }

        private string _codEdificacion;
        public string codEdificacion { get { return _codEdificacion; } set { SetProperty(ref _codEdificacion, value); } }

        private double _longitud;
        public double longitud { get { return _longitud; } set { SetProperty(ref _longitud, value); } }

        private double _latitud;
        public double latitud { get { return _latitud; } set { SetProperty(ref _latitud, value); } }

        private string _titularidad;
        public string titularidad { get { return _titularidad; } set { SetProperty(ref _titularidad, value); } }

        private string _cif;
        public string cif { get { return _cif; } set { SetProperty(ref _cif, value); } }

        private string _comarca;
        public string comarca { get { return _comarca; } set { SetProperty(ref _comarca, value); } }

        public Centre() {}


    }
}
