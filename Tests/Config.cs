using NUnit.Framework;

namespace Tests;

[SetUpFixture]
public class Config
{
    [OneTimeSetUp]  // [OneTimeSetUp] for NUnit 3.0 and up; see http://bartwullems.blogspot.com/2015/12/upgrading-to-nunit-30-onetimesetup.html
    public void SetUp()
    {
        WindowsFormsLibrary.Wait.WaitHandler.Register();
    }

}