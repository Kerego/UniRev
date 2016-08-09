using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using UniRev.Domain.Models;
using UniRev.Repositories.Interfaces;

namespace UniRev
{
	public class ReadViewModel : BindableBase, IDisposable
	{
		public ObservableCollection<User> Users { get; } = new ObservableCollection<User>();
		public ICommand ReadCommand { get; }

		private readonly IRepository<User> _userRepository;

		public ReadViewModel(IRepository<User> userRepository)
		{
			_userRepository = userRepository;
			ReadCommand = new DelegateCommand(Refresh); 
		}

		public void Refresh()
		{
			Users.Clear();
			foreach (var user in _userRepository.Read())
			{
				Users.Add(user);
			}
		}

		public void Dispose()
		{
			_userRepository.Dispose();
		}
	}
}
