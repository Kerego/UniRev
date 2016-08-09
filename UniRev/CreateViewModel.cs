using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using UniRev.Domain.Models;
using UniRev.Repositories.Interfaces;

namespace UniRev
{
	public class CreateViewModel : BindableBase, IDisposable
	{
		private string _password;

		public string Password
		{
			get { return _password; }
			set { SetProperty(ref _password, value); }
		}

		private string _name;

		public string Name
		{
			get { return _name; }
			set { SetProperty(ref _name, value); }
		}

		public ICommand CreateCommand { get; }


		private readonly IRepository<User> _userRepository;

		public CreateViewModel(IRepository<User> userRepository)
		{
			_userRepository = userRepository;
			CreateCommand = new DelegateCommand(Create,
												() => !(String.IsNullOrWhiteSpace(Name) || String.IsNullOrWhiteSpace(Password)))
								.ObservesProperty(() => Name)
								.ObservesProperty(() => Password);
		}

		public void Create()
		{
			//var user = new Student(Name, Password);
			//_userRepository.Create(user);
			//Name = Password = string.Empty;
		}

		public void Dispose()
		{
			_userRepository.Dispose();
		}
	}
}
