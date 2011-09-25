using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NewsVn.Impl.Context;
using NewsVn.Impl.Entity;
using System.Text.RegularExpressions;

namespace NewsVn.Test
{
    class Program
    {

        private static string RemoveUnicodeMarks(string accented)
        {
            accented = accented.Length > 50 ? accented.Substring(0, 50) : accented;

            string[] splitted = accented.Split("~!@#$%^&*:()_+ '\",.?/`“”-–".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            accented = string.Join("-", splitted).ToLower();

            Regex regex = new Regex(@"\p{IsCombiningDiacriticalMarks}+");
            string strFormD = accented.Normalize(System.Text.NormalizationForm.FormD);

            return regex.Replace(strFormD, String.Empty).Replace('\u0111', 'd').Replace('\u0110', 'D');
        }

        private static string RemoveDangerousMarks(string accented)
        {
            accented = accented.Length > 50 ? accented.Substring(0, 50) : accented;

            string[] splitted = accented.Split("~!@#$%^&*:()_+ '\",.?/`“”-–".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            accented = string.Join(" ", splitted).ToLower();
            return accented;
        }

        static void Main(string[] args)
        {
            string _connectionString = Connection.ConnectionString;


            //cap nhat TitleAscii cho Post
            /*using (var ctx = new NewsVnContext(_connectionString))
            {
                var allPost = ctx.PostRepo.Getter.getEnumerable() ;
                
                foreach (Post item in allPost)
                {
                    string strTitleAscii = RemoveUnicodeMarks(RemoveDangerousMarks(item.Title));
                    strTitleAscii = strTitleAscii.Replace("-", " ");
                    item.TitleAscii = strTitleAscii;
                    ctx.SubmitChanges();
                }                
            } */

            //cap nhat TitleAscii cho AdPost
            //using (var ctx = new NewsVnContext(_connectionString))
            //{
            //    var adPost = ctx.AdPostRepo.Getter.getEnumerable() ;
                
            //    foreach (AdPost item in adPost)
            //    {
            //        string strTitleAscii = RemoveUnicodeMarks(RemoveDangerousMarks(item.Title));
            //        strTitleAscii = strTitleAscii.Replace("-", " ");
            //        item.TitleAscii = strTitleAscii;
            //        ctx.SubmitChanges();
            //    }
            //    Console.Write("success");
            //}

            //AddNewProfileComment() ;


        }

        private static void AddNewProfileComment()
        {
            try
            {
                using (var ctx = new NewsVnContext(Connection.ConnectionString))
                {
                    var profileComment = new Impl.Entity.UserProfileComment
                    {
                        Title = "test comment",
                        UpdatedBy = "123",
                        UpdatedOn = DateTime.Now,
                        ForAccount = "999",
                        Content = "test comment"
                    };

                    ctx.UserProfileCommentRepo.Setter.addOne(profileComment);

                    ctx.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
