using Examen_Mvvm.ViewModel;

namespace Examen_Mvvm.View;

public partial class DespensaView : ContentPage
{

	DespensaViewModel viewModel; 
	public DespensaView()
	{
		InitializeComponent();
		viewModel = new DespensaViewModel();
		BindingContext = viewModel;
	}
}