using System.Collections.Generic;
using System.Threading.Tasks;
using UniRev.Domain.Models;

namespace UniRev.Repositories.Interfaces
{
	public interface IRepository<T> where T : Entity
	{
		Task<T> GetByIdAsync(int id);
		IEnumerable<T> Read();
		Task CreateAsync(T review);
		Task UpdateAsync(T review);
		Task DeleteAsync(T review);
	}
}