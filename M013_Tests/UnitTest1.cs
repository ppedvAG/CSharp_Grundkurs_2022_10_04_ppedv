using M013;

namespace M013_Tests
{
	[TestClass]
	public class UnitTest1
	{
		Rechner r;

		[TestInitialize] //Vor den Tests dieses Stück Code ausführen
		public void Init() => r = new();

		[TestCleanup]
		public void Cleanup() => r = null;

		[TestMethod]
		[TestCategory("AddiereTest")]
		public void TestAddiere()
		{
			double ergebnis = r.Addiere(4, 9);
			Assert.AreEqual(13, ergebnis);
		}

		[TestMethod]
		[TestCategory("SubtrahiereTest")] //Kategorie im TestExplorer hinzufügen
		public void TestSubtrahiere()
		{
			double ergebnis = r.Subtrahiere(4, 9);
			Assert.AreEqual(-5, ergebnis);
		}
	}
}