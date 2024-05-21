using SQLite;
using SQLiteNetExtensions.Attributes;

namespace iscaPopAlvaro.Model
{
    [Table("Solicitud")]
    public class Solicitud : Base.BaseModel
    {
        private int _id;
        [PrimaryKey, AutoIncrement]
        public int id { get { return _id; } set { SetProperty(ref _id, value); } }

        private DateTime _momento;
        public DateTime momento { get { return _momento; } set { SetProperty(ref _momento, value); } }

        private int _cantidad;
        public int cantidad { get { return _cantidad; } set { SetProperty(ref _cantidad, value); } }

        [ForeignKey(typeof(Organisme))]
        public int organismeId { get; set; }
        [ManyToOne(CascadeOperations = CascadeOperation.CascadeInsert | CascadeOperation.CascadeRead)]
        public Organisme organisme { get; set; }

        [ForeignKey(typeof(Material))]
        public int materialId { get; set; }
        [ManyToOne(CascadeOperations = CascadeOperation.CascadeInsert | CascadeOperation.CascadeRead)]
        public Material material { get; set; }

        public Solicitud()
        {
        }
    }
}
