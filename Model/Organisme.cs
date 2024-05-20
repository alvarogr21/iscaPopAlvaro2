using SQLite;
using SQLiteNetExtensions.Attributes;
using System.Collections.ObjectModel;

namespace iscaPopAlvaro.Model
{
    [Table("Organisme")]
    public class Organisme : Base.BaseModel
    {

        private int _id;
        [PrimaryKey, AutoIncrement]
        public int id { get { return _id; } set { SetProperty(ref _id, value); } }

        private string _codi;
        public string codi { get { return _codi; } set { SetProperty(ref _codi, value); } }

        private string _password;
        public string password { get { return _password; } set { SetProperty(ref _password, value); } }

        private string _nom;
        public string nom { get { return _nom; } set { SetProperty(ref _nom, value); } }

        private string _email;
        [Unique]
        public string email { get { return _email; } set { SetProperty(ref _email, value); } }

        private DateTime _momento;
        public DateTime momento { get { return _momento; } set { SetProperty(ref _momento, value); } }

        private List<Material> _materials;
        [OneToMany(CascadeOperations = CascadeOperation.CascadeInsert | CascadeOperation.CascadeRead)]
        public List<Material> materials
        {
            get { return _materials; }
            set
            {
                SetProperty(ref _materials, value);
                materialsCollection = new ObservableCollection<Material>(value);
            }
        }

        private ObservableCollection<Material> _materialsCollection;


        [Ignore]
        public ObservableCollection<Material> materialsCollection
        {
            get { return _materialsCollection; }
            set { SetProperty(ref _materialsCollection, value); }
        }
    }
}
