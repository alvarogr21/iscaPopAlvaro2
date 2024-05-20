using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace iscaPopAlvaro.Model
{
    [Table("Material")]
    public class Material : Base.BaseModel
    {
        
        private int _id;
        [PrimaryKey, AutoIncrement]
        public int id { get { return _id; } set { SetProperty(ref _id, value); } }
        
        private string _nom;
        public string nom { get { return _nom; } set { SetProperty(ref _nom, value);  } }

        private string _uso;
        public string uso { get { return _uso; } set { SetProperty(ref _uso, value); } }

        private EnumEstadoMaterial _estat;
        public EnumEstadoMaterial estat { get { return _estat; } set { SetProperty(ref _estat, value); } }

        private string _descripcio;
        public string descripcio { get { return _descripcio; } set { SetProperty(ref _descripcio, value); } }

        private List<Foto> _fotos;
        [OneToMany(CascadeOperations = CascadeOperation.CascadeInsert | CascadeOperation.CascadeRead)]
        public List<Foto> fotos
        {
            get { return _fotos; }
            set
            {
                SetProperty(ref _fotos, value);
                fotosCollection = new ObservableCollection<Foto>(value);
            }
        }

        private ObservableCollection<Foto> _fotosCollection;
        [Ignore]
        public ObservableCollection<Foto> fotosCollection
        {
            get { return _fotosCollection; }
            set { SetProperty(ref _fotosCollection, value); }
        }

        [ForeignKey(typeof(Organisme))]
        public int organismeId { get; set; }
        [ManyToOne(CascadeOperations = CascadeOperation.CascadeRead | CascadeOperation.CascadeDelete)]
        public Organisme organisme { get; set; }
    }
}
