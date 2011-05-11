using System;
using System.Linq;
using System.Web.UI.WebControls;
using System.Data;
using System.Xml.Linq;
using System.Collections;
using System.Collections.Generic;

namespace NewsVn.Web.Modules
{
    public class clsPost {
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
                this.GoToPage(1, 35);
                Load_GridShow(10);
            }
            
        }
        protected void Load_GridShow(int intTake)
        {
            DataTable dt = new DataTable();
            dt = Utils.clsCommon.ListToDataTable(Utils.clsPost.Load_Post_From_XML(intTake));
            grvShow.DataSource = dt;
            grvShow.DataBind();
            ViewState["dtTemp"] = dt;
            grvShow.Columns[2].Visible = false;
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
            GridView1.DataSource = _Posts.Select(p => new
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
            }).OrderByDescending(p => p.ApprovedOn).Skip((pageIndex - 1) * pageSize).Take(pageSize);
            GridView1.DataBind();
            GridView1.Columns[9].Visible = false;
            GridView1.Columns[8].Visible = false;
            GridView1.Columns[7].Visible = false;
            GridView1.Columns[6].Visible = false;
        }

        private void GenerateDataPager(int pageSize)
        {
            int numOfPages = (int)Math.Ceiling((decimal)_Posts.Count() / pageSize);
            ddlPageIndex.Items.Clear();
            for (int i = 1; i <= numOfPages; i++)
            {
                ddlPageIndex.Items.Add(new ListItem(i.ToString(), i.ToString()));
            }
        }

        protected void btnAddHot_Click(object sender, EventArgs e)
        {
            //so item the hien tren su kien noi bat, sau nay setting trong DB
            
            if (ViewState["dtTemp"]!=null)
            {
                int totalItemShow = 10;
                DataTable dt = ViewState["dtTemp"] as DataTable;
                int countItemToInsert = totalItemShow - dt.Rows.Count;
                //rptPostList.Items.OfType<RepeaterItem>().ToList().ForEach(ri => ((CheckBox)ri.FindControl("CheckBox1")).Checked = true);
                //var rowList = GridView1.Rows.OfType<GridViewRow>();
                string msgExist = "";
                foreach (GridViewRow row in GridView1.Rows)
                {
                    if (countItemToInsert == 0)
                    {
                        break;
                    }
                    bool ischecked = ((CheckBox)row.FindControl("chkItem")).Checked;
                    
                    if (ischecked)
                    {
                        bool existThisItem = false;
                        foreach (DataRow dtRow in dt.Rows)
                        {
                            if (dtRow["ID"].ToString() == row.Cells[8].Text)
                            {
                                existThisItem = true;
                                break;
                            }
                        }

                        if (existThisItem)
                        {
                            msgExist += row.Cells[2].Text + "\n";

                            continue;
                        }
                        DataRow r = dt.NewRow();
                        r["ID"] = row.Cells[8].Text;
                        r["Title"] = row.Cells[2].Text;
                        r["CateName"] = row.Cells[3].Text;
                        r["ApprovedBy"] = row.Cells[4].Text;
                        r["ApprovedOn"] = row.Cells[5].Text;
                        r["SeoUrl"] = row.Cells[7].Text;
                        r["Avatar"] = row.Cells[6].Text;
                        r["Description"] = row.Cells[9].Text;
                        dt.Rows.Add(r);
                        countItemToInsert = countItemToInsert - 1;
                    }
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
                                new XElement("SeoUrl", HostName + row["SeoUrl"].ToString()),
                                new XElement("Avatar", row["Avatar"].ToString()),
                                new XElement("Description", row["Description"].ToString())
                                )
                        );
                }
                loaded.Save(Server.MapPath(@"~/Resources/Xml/category.xml"));
                Load_GridShow(10);
                if (msgExist.Length >= 1)
                {
                    Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "js", "alert('Đã tồn tại những tin tức này trong danh mục tin Hot\n" + msgExist + "')", true);
                }   
            }
        }

        protected void grvShow_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowIndex>=0)
            {
                LinkButton lnkbtnDel = e.Row.FindControl("lnkbtnDel") as LinkButton;
                LinkButton lnkbtnF = e.Row.FindControl("lnkbtnF") as LinkButton;
                LinkButton lnkbtnU = e.Row.FindControl("lnkbtnU") as LinkButton;
                LinkButton lnkbtnD = e.Row.FindControl("lnkbtnD") as LinkButton;
                LinkButton lnkbtnL = e.Row.FindControl("lnkbtnL") as LinkButton;
            }
        }
    }
}