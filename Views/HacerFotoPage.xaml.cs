using iscaPopAlvaro.Model;
using iscaPopAlvaro.ViewModel;

namespace iscaPopAlvaro.Views;

[QueryProperty(nameof(Material), "Material")]
public partial class HacerFotoPage : Base.BasePage
{
	private FotoVM vm;

	private Material _material;

	public Material Material
    {
        get { return _material; }
        set { SetProperty(ref _material, value); vm.assignDadesMaterial(Material); }
    }

    private Foto _foto;

    public Foto Foto
    {
        get { return _foto; }
        set { SetProperty(ref _foto, value); vm.assignDades(Foto); }
    }


    public HacerFotoPage()
	{
		InitializeComponent();
		BindingContext = vm = new FotoVM();
        vm.assignDadesMaterial(Material);
	}

    public async void HacerFotoClick(object sender, EventArgs e)
    {
        if (MediaPicker.Default.IsCaptureSupported)
        {
            FileResult photo = await MediaPicker.Default.CapturePhotoAsync();

            if (photo != null)
            {
                Foto foto = new Foto();
                // save the file into local storage
                // construir el nombre del fichero con su path
                string localFilePath = Path.Combine(FileSystem.AppDataDirectory, photo.FileName);
                //obtener el stream de la foto
                using Stream sourceStream = await photo.OpenReadAsync();
                //abre para escritura el fichero
                using FileStream localFileStream = File.OpenWrite(localFilePath);
                //copia del stream de la foto al fichero
                await sourceStream.CopyToAsync(localFileStream);
                //asigno al Source de la Image (del xaml) el fichero
                fotoRealizada.Source = localFilePath;
                MemoryStream memoryStream = new MemoryStream();
                await sourceStream.CopyToAsync(memoryStream);
                foto.foto = memoryStream.ToArray();
                foto.nom = "Foto";
                foto.path = localFilePath;
                foto.material = Material;
                Foto = foto;
                Material.fotos.Add(Foto);
                vm.insertarFoto(Foto);
            }
        }
    }
}