using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iscaPopAlvaro.Model
{
    [Table("Foto")]
    public class Foto : Base.BaseModel
    {
        private int _id;
        [PrimaryKey, AutoIncrement]
        public int id { get { return _id; } set { SetProperty(ref _id, value); } }

        private string _nom;
        public string nom { get { return _nom; } set { SetProperty(ref _nom, value); } }

        private string _path;
        public string path { get { return _path; } set { SetProperty(ref _path, value); } }

        private byte[] _foto;
        public byte[] foto { get { return _foto; } set { SetProperty(ref _foto, value); } }

        [ForeignKey(typeof(Material))]
        public int materialId { get; set; }
        [ManyToOne(CascadeOperations = CascadeOperation.CascadeInsert | CascadeOperation.CascadeRead)]
        public Material material { get; set; }

        public Foto()
        {
        }
    }
}
