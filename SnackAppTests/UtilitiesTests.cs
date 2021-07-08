using Microsoft.VisualStudio.TestTools.UnitTesting;
using SnackApp;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnackApp.Tests
{
    [TestClass()]
    public class UtilitiesTests
    {
        [TestMethod()]
        public void checkIfUserExistsTestWithActualUser()
        {
            string conStr = ConfigurationManager.ConnectionStrings["conStr"].ConnectionString;
            using (SqlConnection con = new SqlConnection(conStr))
            {
                // arrange
                Utilities utils = new Utilities();
                string username = "admin";

                // act
                bool actual = utils.checkIfUserExists(username);

                // assert
                Assert.AreEqual(true, actual);
            }
        }

        [TestMethod()]
        public void checkIfUserExistsTestWithoutActualUser()
        {
            string conStr = ConfigurationManager.ConnectionStrings["conStr"].ConnectionString;
            using (SqlConnection con = new SqlConnection(conStr))
            {
                // arrange
                Utilities utils = new Utilities();
                string username = "blub";

                // act
                bool actual = utils.checkIfUserExists(username);

                // assert
                Assert.AreEqual(false, actual);
            }
        }
    }
}