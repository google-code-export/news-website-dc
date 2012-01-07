using System;
using NewsVn.Impl.Entity;
using System.Web;
using System.Text.RegularExpressions;

namespace NewsVn.Impl.PostFetch.Models
{
    public class PostItemModel
    {
        public int ID { get; set; }

        public string Title { get; set; }

        public string Avatar { get; set; }

        public string Description { get; set; }

        public string Content { get; set; }

        public DateTime? PubDate { get; set; }

        public string Url { get; set; }

        public int TargetID { get; set; }

        /// <summary>
        /// Converts this model into Post Entity
        /// </summary>
        /// <returns>Post entity</returns>
        public Post ToPostEntity()
        {
            var post = new Post
            {
                Title = Title.Trim(),
                TitleAscii = RemoveUnicodeMarks(Title.Trim()).Replace("-", " "),
                Avatar = Avatar.Trim(),
                Description = Description.Trim(),
                Content = Content.Trim(),
                CategoryID = TargetID,
                CreatedBy = HttpContext.Current.User.Identity.Name,
                CreatedOn = DateTime.Now,
                PageView = 0,
                SeoUrl = string.Empty,
                CheckPageView = true,
                AllowComments = true,
                Actived = true,
                AutoFetch = true,
                AutoFetchUrl = Url.Trim().ToLower()
            };
            return post;
        }

        internal string RemoveUnicodeMarks(string accented)
        {
            if (!string.IsNullOrEmpty(accented))
            {
                accented = accented.Length > 50 ? accented.Substring(0, 50) : accented;

                string[] splitted = accented.Split("~!@#$%^&*:()_+ '\",.?/`“”-–".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                accented = string.Join("-", splitted).ToLower();

                Regex regex = new Regex(@"\p{IsCombiningDiacriticalMarks}+");
                string strFormD = accented.Normalize(System.Text.NormalizationForm.FormD);

                return regex.Replace(strFormD, String.Empty).Replace('\u0111', 'd').Replace('\u0110', 'D');
            }
            else return "";

        }
    }
}

