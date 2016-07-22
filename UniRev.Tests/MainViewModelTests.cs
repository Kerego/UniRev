using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UniRev;
using System.Threading.Tasks;

namespace UniRev.Tests
{
	[TestClass]
    public class MainViewModelTests
    {
		[TestMethod]
		public void MyTestMethod()
		{
			MainViewModel vm = new MainViewModel();
			var sum = vm.Sum(2, 3);
			Assert.AreEqual(5, sum);
		}
	}
}
