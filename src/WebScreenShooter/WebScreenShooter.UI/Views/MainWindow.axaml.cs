using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using ReactiveUI;
using System.Reactive;
using WebScreenShooter.Logic.Models;

namespace WebScreenShooter.Views
{
	public class MainWindow : Window
	{
		Button AddButton;
		ListBox Platforms;
		public MainWindow()
		{
			InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif
		}



		private void InitializeComponent()
		{
			AvaloniaXamlLoader.Load(this);
			AddButton = this.FindControl<Button>("addButton");
			Platforms = this.FindControl<ListBox>("platforms");
			Platforms.PropertyChanged += Platforms_PropertyChanged;
		}

		private void Platforms_PropertyChanged(object sender, AvaloniaPropertyChangedEventArgs e)
		{
			System.Console.WriteLine(e);
		}

		private void Platforms_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			System.Console.WriteLine(e);
			Platforms.SelectedItem = new PlatformItem() { Name = "TEXT", IsSelected = false };
			Platforms.SetValue(ComboBox.SelectedIndexProperty, 0);
		}
	}
}