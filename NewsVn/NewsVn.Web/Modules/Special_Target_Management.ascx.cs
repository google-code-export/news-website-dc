using System;
using System.Linq;
using System.Web.UI.WebControls;
using System.Data;
using System.Xml.Linq;
using System.Xml.XPath;
using System.Collections;
using System.Collections.Generic;
using NewsVn.Impl.Context;
using NewsVn.Web.Utils;

namespace NewsVn.Web.Modules
{
    public class clsPost
    {
        public int PostID { get; set; }
        public string Title { get; set; }
        public string Avatar { get; set; }
        public string SeoUrl { get; set; }
        public DateTime ApprovedOn { get; set; }
    }
    public partial class Special_Target_Management : BaseUI.BaseModule
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ViewState["dt_HotTemp"] = null;
                this.GoToPage(1, 50);
                Load_GridShow(10);
            }
        }
        protected void Load_GridShow(int intTake)
        {
            DataTable dt = new DataTable();
            dt = Utils.clsCommon.ListToDataTable(Utils.clsPost.Load_Post_From_XML(intTake));
            string[] arrkey = { "ID" };
            grvShow.DataKeyNames = arrkey;
            grvShow.DataSource = dt;
            grvShow.DataBind();
            ViewState["dtTemp"] = dt;
            grvShow.Columns[1].Visible = false;
        }
        protected void Pager_SelectedIndexChanged(object sender, EventArgs e)
        {
            int pageIndex = int.Parse(ddlPageIndex.SelectedValue);
            int pageSize = int.Parse(ddlPageSize.SelectedValue);
            this.GoToPage(pageIndex, pageSize);
        }

        private void GoToPage(int pageIndex, int pageSize)
        {
            this.GenerateDataPager(pageSize);
            try
            {
                ddlPageSize.Text = pageSize.ToString();
                ddlPageIndex.Text = pageIndex.ToString();
            }
            catch (Exception)
            {
                ddlPageIndex.SelectedIndex = ddlPageIndex.Items.Count - 1;
                pageIndex = int.Parse(ddlPageIndex.SelectedValue);
            }
            this.LoadPostList(pageIndex, pageSize);
        }

        private void LoadPostList(int pageIndex, int pageSize)
        {
            using (var ctx = new NewsVnContext(ApplicationManager.ConnectionString))
            {
                var posts = ctx.PostRespo.Getter.getQueryable(p => p.Actived == true && p.Approved == true).OrderByDescending(p => p.ApprovedOn).AsEnumerable();
                GridView1.DataSource = ctx.PostRespo.Getter.getPagedList(posts, pageIndex, pageSize).Select(p => new
                    {
                        p.ID,
                        p.Avatar,
                        p.Title,
                        p.Description,
                        p.SeoUrl,
                        p.Approved,
                        p.ApprovedOn,
                        p.ApprovedBy,
                        p.Actived,
                        CategoryName = p.Category.Parent == null ? p.Category.Name : p.Category.Parent.Name + "/" + p.Category.Name,
                    });
                GridView1.DataBind();
                GridView1.Columns[8].Visible = false;
                GridView1.Columns[7].Visible = true;
                GridView1.Columns[6].Visible = false;
            }
        }

        private void GenerateDataPager(int pageSize)
        {
            using (var ctx = new NewsVnContext(ApplicationManager.ConnectionString))
            {
                int numOfPages = (int)Math.Ceiling((decimal)ctx.PostRespo.Getter.getTable().Count() / pageSize);
                ddlPageIndex.Items.Clear();
                for (int i = 1; i <= numOfPages; i++)
                {
                    ddlPageIndex.Items.Add(new ListItem(i.ToString(), i.ToString()));
                }
            }
        }

        protected void btnAddHot_Click(object sender, EventArgs e)
        {
            //so item the hien tren su kien noi bat, sau nay setting trong DB
            try
            {

                if (ViewState["dtTemp"] != null)
                {
                    int totalItemShow = 10;
                    DataTable dt = ViewState["dtTemp"] as DataTable;
                    int countItemToInsert = totalItemShow - dt.Rows.Count;
                    //rptPostList.Items.OfType<RepeaterItem>().ToList().ForEach(ri => ((CheckBox)ri.FindControl("CheckBox1")).Checked = true);
                    //var rowList = GridView1.Rows.OfType<GridViewRow>();
                    string msgExist = "";
                    bool nocheck = true;
                    foreach (GridViewRow row in GridView1.Rows)
                    {
                        if (countItemToInsert == 0)
                        {
                            break;
                        }
                        bool ischecked = ((CheckBox)row.FindControl("chkItem")).Checked;

                        if (ischecked)
                        {
                            nocheck = false;
                            bool existThisItem = false;
                            foreach (DataRow dtRow in dt.Rows)
                            {
                                if (dtRow["ID"].ToString() == row.Cells[1].Text)
                                {
                                    existThisItem = true;
                                }
                            }

                            if (existThisItem)
                            {
                                msgExist += "+ [ID:" + row.Cells[1].Text + "] -" + row.Cells[2].Text + "\\n";

                                continue;
                            }
                            int pID = int.Parse(row.Cells[1].Text);

                            using (var ctx = new NewsVnContext(ApplicationManager.ConnectionString))
                            {
                                var post = ctx.PostRespo.Getter.getOne(p => p.ID == pID);
                                DataRow r = dt.NewRow();
                                r["ID"] = row.Cells[1].Text;
                                r["Title"] = post.Title;
                                r["CateName"] = post.Category.Name;
                                r["ApprovedBy"] = post.ApprovedBy;
                                r["ApprovedOn"] = string.Format("{0:dd/mm/yyyy HH:MM}", post.ApprovedOn);
                                r["SeoUrl"] = post.SeoUrl;
                                r["Avatar"] = post.Avatar;
                                r["Description"] = post.Description;
                                dt.Rows.Add(r);
                                countItemToInsert = countItemToInsert - 1;
                            }
                        }
                    }
                    if (nocheck)
                    {
                        Utils.clsCommon.Excute_Javascript("alert('Chưa chọn tin cần đưa vào danh sách Tin Sự Kiện Nổi Bật!')", this.Page, true);
                        return;
                    }
                    XElement loaded = XElement.Load(Server.MapPath(@"~/Resources/Xml/category.xml"));
                    loaded.Element("Posts").RemoveAll();
                    foreach (DataRow row in dt.Rows)
                    {
                        loaded.Element("Posts").Add(
                                new XElement("Post",
                                    new XAttribute("ID", row["ID"].ToString()),
                                    new XElement("Title", row["Title"].ToString()),
                                    new XElement("CateName", row["CateName"].ToString()),
                                    new XElement("ApprovedBy", row["ApprovedBy"].ToString()),
                                    new XElement("ApprovedOn", row["ApprovedOn"].ToString()),
                                    new XElement("SeoUrl", row["SeoUrl"].ToString()),
                                    new XElement("Avatar", row["Avatar"].ToString()),
                                    new XElement("Description", row["Description"].ToString())
                                    )
                            );
                    }

                    if (msgExist.Length >= 1)
                    {
                        Utils.clsCommon.Excute_Javascript("alert('Đã tồn tại những tin tức này:\\n" + msgExist + "\\ntrong danh mục sự kiện nổi bật')", this.Page, true);
                    }
                    else
                    {
                        loaded.Save(Server.MapPath(@"~/Resources/Xml/category.xml"));
                        Load_GridShow(10);
                    }
                }
            }
            catch (Exception ex)
            {

                Utils.clsCommon.Excute_Javascript("alert('Thêm Sự kiện nổi bật thất bại - xem lỗi: \\n" + ex.Message.ToString() + "')", this.Page, true);
            }
        }

        protected void grvShow_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowIndex >= 0)
            {
                LinkButton lnkbtnDel = e.Row.FindControl("lnkbtnDel") as LinkButton;
                lnkbtnDel.Attributes.Add("onClick", "return confirmDelete(" + System.Web.UI.DataBinder.Eval(e.Row.DataItem, "ID").ToString() + ");");
            }
        }

        protected void lnkbtnDel_Click(object sender, EventArgs e)
        {
            try
            {
                //c1: linq
                XElement loaded = XElement.Load(Server.MapPath(@"~/Resources/Xml/category.xml"));
                loaded.Elements("Posts").Elements("Post")
                    .Where(p => p.Attribute("ID").Value == hidID.Value)
                    .ToList()
                    .ForEach(i => i.Remove());
                loaded.Save(Server.MapPath(@"~/Resources/Xml/category.xml"));
                Load_GridShow(10);
                //c2: extension xpath
                //XElement loaded = XElement.Load(Server.MapPath(@"~/Resources/Xml/category.xml"));
                //loaded.XPathSelectElement("Posts/Post[@ID = '" + hidID.Value + "']").Remove();
            }
            catch (Exception ex)
            {
                Utils.clsCommon.Excute_Javascript("alert('Xóa thất bại - xem lỗi: \\n" + ex.Message.ToString() + "')", this.Page, true);
            }
        }
    }
}