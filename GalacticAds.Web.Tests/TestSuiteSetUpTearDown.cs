using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MbUnit.Framework;

namespace GalacticAds.Web.Tests
{
[AssemblyFixture]
    public class TestSuiteSetUpTearDown
    {
        [FixtureSetUp]
        public void SuiteSetUp()
        {
            ActiveRecordConfig.Setup(new System.Configuration.ConnectionStringSettings(
                "GalacticAds", 
                @"data source=.\SQLEXPRESS;Integrated Security=SSPI;Initial Catalog=GalacticAds",
                "System.Data.SqlClient"));
        }
    }
}
