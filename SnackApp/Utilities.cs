﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace SnackApp
{
    public class Utilities
    {
        public bool checkIfUserExists(string username)
        {
            string conStr = ConfigurationManager.ConnectionStrings["conStr"].ConnectionString;
            using (SqlConnection con = new SqlConnection(conStr))
            {
                SqlCommand sqlCheckIfUserExists = new SqlCommand(@"SELECT COUNT(*) FROM users WHERE user_name = @username", con);
                sqlCheckIfUserExists.Parameters.AddWithValue("@username", username);
                con.Open();
                Int32 count = (Int32)sqlCheckIfUserExists.ExecuteScalar();

                if (count == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        public static string getHashSha256(string text)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(text);
            SHA256Managed hashstring = new SHA256Managed();
            byte[] hash = hashstring.ComputeHash(bytes);
            string hashString = string.Empty;
            foreach (byte x in hash)
            {
                hashString += String.Format("{0:x2}", x);
            }
            return hashString;
        }

        public int getUserSalt(string username)
        {
            string conStr = ConfigurationManager.ConnectionStrings["conStr"].ConnectionString;
            using (SqlConnection con = new SqlConnection(conStr))
            {
                SqlCommand sqlGetUserSalt = new SqlCommand(@"SELECT salt FROM [dbo].[users] WHERE user_name = @username", con);
                sqlGetUserSalt.Parameters.AddWithValue("@username", username);
                con.Open();

                Int32 salt = (Int32)sqlGetUserSalt.ExecuteScalar();

                return salt;
            }
        }

        public bool checkIfUserIsAdmin(string username)
        {
            string conStr = ConfigurationManager.ConnectionStrings["conStr"].ConnectionString;
            using (SqlConnection con = new SqlConnection(conStr))
            {
                SqlCommand sqlCheckIfUserIsAdmin = new SqlCommand(@"SELECT is_admin FROM [dbo].[users] WHERE user_name = @username", con);
                sqlCheckIfUserIsAdmin.Parameters.AddWithValue("@username", username);
                con.Open();
                bool is_admin = (bool)sqlCheckIfUserIsAdmin.ExecuteScalar();

                if (is_admin == true)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public string getUserLanguage(string username)
        {
            int userid = getUserÌD(username);

            string conStr = ConfigurationManager.ConnectionStrings["conStr"].ConnectionString;
            using (SqlConnection con = new SqlConnection(conStr))
            {
                SqlCommand sqlCheckIfUserIsVerified = new SqlCommand(@"SELECT language FROM users WHERE userID = @userid", con);
                sqlCheckIfUserIsVerified.Parameters.AddWithValue("@userid", userid);
                con.Open();
                string language = sqlCheckIfUserIsVerified.ExecuteScalar().ToString();
                return language;
            }
        }

        public bool checkIfUserIsVerified(string username)
        {
            string conStr = ConfigurationManager.ConnectionStrings["conStr"].ConnectionString;
            using (SqlConnection con = new SqlConnection(conStr))
            {
                SqlCommand sqlCheckIfUserIsVerified = new SqlCommand(@"SELECT verified FROM [dbo].[users] WHERE user_name = @username", con);
                sqlCheckIfUserIsVerified.Parameters.AddWithValue("@username", username);
                con.Open();
                bool is_verified = (bool)sqlCheckIfUserIsVerified.ExecuteScalar();

                if (is_verified == true)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        internal int getItemID(string itemname)
        {
            string conStr = ConfigurationManager.ConnectionStrings["conStr"].ConnectionString;
            using (SqlConnection con = new SqlConnection(conStr))
            {
                SqlCommand sqlGetItemID = new SqlCommand(@"SELECT itemID FROM items WHERE item_name = @itemname", con);
                sqlGetItemID.Parameters.AddWithValue("@itemname", itemname);
                con.Open();
                Int32 itemID = (Int32)sqlGetItemID.ExecuteScalar();

                return itemID;
            }
        }

        public int getUserÌD(string username)
        {
            string conStr = ConfigurationManager.ConnectionStrings["conStr"].ConnectionString;
            using (SqlConnection con = new SqlConnection(conStr))
            {
                SqlCommand sqlGetUserÌD = new SqlCommand(@"SELECT userID FROM [dbo].[users] WHERE user_name = @username", con);
                sqlGetUserÌD.Parameters.AddWithValue("@username", username);
                con.Open();
                Int32 userID = (Int32)sqlGetUserÌD.ExecuteScalar();

                return userID;
            }
        }

        public void updateUserLanguage(string username, string language)
        {
            int userID = getUserÌD(username);
            string conStr = ConfigurationManager.ConnectionStrings["conStr"].ConnectionString;
            using (SqlConnection con = new SqlConnection(conStr))
            {
                SqlCommand sqlUpdateUserLanguage = new SqlCommand(@"UPDATE users SET language = @language WHERE userID = @userID", con);
                sqlUpdateUserLanguage.Parameters.AddWithValue("@language", language);
                sqlUpdateUserLanguage.Parameters.AddWithValue("@userID", userID);
                con.Open();
                sqlUpdateUserLanguage.ExecuteNonQuery();
            }
        }

        public List<int> getUserIDsInList()
        {
            List<int> useridList = new List<int>();

            string conStr = ConfigurationManager.ConnectionStrings["conStr"].ConnectionString;
            using (SqlConnection con = new SqlConnection(conStr))
            {
                SqlCommand sqlUpdateUserLanguage = new SqlCommand(@"SELECT userID FROM users WHERE is_admin = 0", con);
                con.Open();
                using (SqlDataReader sdr = sqlUpdateUserLanguage.ExecuteReader())
                {
                    while (sdr.Read())
                    {
                        useridList.Add((int)sdr[0]);
                    }
                }
            }
            return useridList;
        }

        public List<int> getItemIds()
        {
            List<int> itemidsList = new List<int>();

            string conStr = ConfigurationManager.ConnectionStrings["conStr"].ConnectionString;
            using (SqlConnection con = new SqlConnection(conStr))
            {
                SqlCommand sqlUpdateUserLanguage = new SqlCommand(@"SELECT itemID FROM items", con);
                con.Open();
                using (SqlDataReader sdr = sqlUpdateUserLanguage.ExecuteReader())
                {
                    while (sdr.Read())
                    {
                        itemidsList.Add((int)sdr[0]);
                    }
                }
            }
            return itemidsList;
        }
    }
}