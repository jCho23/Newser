using System;
using System.IO;
using System.Linq;
using System.Threading;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Android;
using Xamarin.UITest.Queries;

namespace Newser
{
	[TestFixture]
	public class Tests
	{
		AndroidApp app;

		[SetUp]
		public void BeforeEachTest()
		{
			// TODO: If the Android app being tested is included in the solution then open
			// the Unit Tests window, right click Test Apps, select Add App Project
			// and select the app projects that should be tested.
			app = ConfigureApp
				.Android
				// TODO: Update this path to point to your Android app and uncomment the
				// code if the app is not included in the solution.
				.ApkFile("/Users/junecho/Desktop/apkS/Newser.apk")
				.StartApp();
		}

		[Test]
		public void AppLaunches()
		{
			app.Flash(x => x.Id("txt"));
			app.Tap(x => x.Id("txt"));
			app.Tap(x => x.Text("Technology"));
			Thread.Sleep(TimeSpan.FromSeconds(4));
			app.Screenshot("Flashed and Tapped 'All' button, then Tapped 'Technology' button");

			app.Flash(x => x.Id("ab_refresh"));
			app.Tap(x => x.Id("ab_refresh"));
			app.Screenshot("Flashed and Tapped refresh button");

			app.Flash(x => x.Id("ab_search"));
			app.Tap(x => x.Id("ab_search"));
			app.EnterText("Microsoft");
			app.Screenshot("Entered Microsoft");

			Thread.Sleep(TimeSpan.FromSeconds(2));
			app.PressEnter();
			app.Screenshot("Searched for 'Microsoft' in the Search Bar");

			app.ScrollDown();
			Thread.Sleep(TimeSpan.FromSeconds(1));
			app.ScrollDown();
			Thread.Sleep(TimeSpan.FromSeconds(1));
			app.Screenshot("Swiped down a few times");

			app.WaitForElement(x => x.Marked("Facebook, Microsoft to Run Mega-Cable From Va. to Spain"));
			app.Flash(x => x.Marked("Facebook, Microsoft to Run Mega-Cable From Va. to Spain"));
			app.Screenshot("Flashed Microsoft News Article");

			Thread.Sleep(TimeSpan.FromSeconds(2));
			app.Tap(x => x.Marked("Facebook, Microsoft to Run Mega-Cable From Va. to Spain"));
			app.Screenshot("Tapped on Microsoft and Facebook Article'");

		}
	}
}

