using System;
using System.Data;
using System.Linq;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using NewsVn.Impl.Context;
using NewsVn.Web.Utils;
using System.Linq.Expressions;
using NewsVn.Impl.Model;
using System.Text;

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
        const string OrderBySK = "siteadmin.post.hot.sort.orderBy";
        const string OrderColumnSK = "siteadmin.post.hot.sort.orderColumn";
        const string OrderDirectionSK = "siteadmin.post.hot.sort.orderDirection";
        const string FilterExpressionSK = "siteadmin.post.hot.filter.expression";
        const string FilterModelSK = "siteadmin.post.hot.filter.model";

        public string OrderBy
        {
            get
            {
                if (Session[OrderBySK] != null)
                {
                    _orderBy = Session[OrderBySK] as string;
                }
                return _orderBy;
            }
            set
            {
                _orderBy = value;
                if (string.IsNullOrEmpty(_orderBy))
                {
                    Session.Remove(OrderBySK);
                }
                else
                {
                    Session[OrderBySK] = _orderBy;
                }
            }
        }
        private string _orderBy = string.Empty;

        protected string OrderColumn
        {
            get
            {
                if (Session[OrderColumnSK] != null)
                {
                    _orderColumn = Session[OrderColumnSK] as string;
                }
                return _orderColumn;
            }
            set
            {
                _orderColumn = value;
                if (string.IsNullOrEmpty(_orderColumn))
                {
                    Session.Remove(OrderColumnSK);
                }
                else
                {
                    Session[OrderColumnSK] = _orderColumn;
                }
            }
        }
        private string _orderColumn = string.Empty;

        protected string OrderDirection
        {
            get
            {
                if (Session[OrderDirectionSK] != null)
                {
                    _orderDirection = Session[OrderDirectionSK] as string;
                }
                return _orderDirection.ToLower();
            }
            set
            {
                _orderDirection = value;
                if (string.IsNullOrEmpty(_orderDirection))
                {
                    Session.Remove(OrderDirectionSK);
                }
                else
                {
                    Session[OrderDirectionSK] = _orderDirection;
                }
            }
        }
        private string _orderDirection = string.Empty;

        public Expression<Func<Impl.Entity.Post, bool>> FilterExpression
        {
            get
            {
                if (Session[FilterExpressionSK] != null)
                {
                    _filterExpression = Session[FilterExpressionSK] as Expression<Func<Impl.Entity.Post, bool>>;
                }
                return _filterExpression;
            }
            set
            {
                _filterExpression = value;
                if (_filterExpression == null)
                {
                    Session.Remove(FilterExpressionSK);
                }
                else
                {
                    Session[FilterExpressionSK] = _filterExpression;
                }

            }
        }
        private Expression<Func<Impl.Entity.Post, bool>> _filterExpression = null;

        public FilterModel FilterModel
        {
            get
            {
                if (Session[FilterModelSK] != null)
                {
                    _filterModel = Session[FilterModelSK] as FilterModel;
                }
                return _filterModel;
            }
            set
            {
                _filterModel = value;
                if (_filterModel == null)
                {
                    Session.Remove(FilterModelSK);
                }
                else
                {
                    Session[FilterModelSK] = _filterModel;
                }
            }
        }
        private FilterModel _filterModel = null;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ViewState["dt_HotTemp"] = null;
                this.GoToFirstPage();
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

        protected void Sorter_SelectedIndexChanged(object sender, EventArgs e)
        {
            OrderColumn = ddlSortColumn.SelectedValue;
            OrderDirection = ddlSortDirection.SelectedValue;
            OrderBy = string.Format("{0} {1}", OrderColumn, OrderDirection);
            this.GoToFirstPage();
        }

        protected void Pager_SelectedIndexChanged(object sender, EventArgs e)
        {
            int pageIndex = int.Parse(ddlPageIndex.SelectedValue);
            int pageSize = int.Parse(ddlPageSize.SelectedValue);
            this.GoToPage(pageIndex, pageSize);
        }

        protected void btnClearFilter_Click(object sender, EventArgs e)
        {
            FilterExpression = null;
            FilterModel = null;
            this.GoToFirstPage();
        }

        protected void btnClearSort_Click(object sender, EventArgs e)
        {
            OrderBy = string.Empty;
            OrderColumn = string.Empty;
            OrderDirection = string.Empty;

            ddlSortColumn.SelectedIndex = 0;
            ddlSortDirection.SelectedIndex = 0;

            this.GoToFirstPage();
        }

        private void GoToFirstPage()
        {
            int pageSize = int.Parse(ddlPageSize.SelectedValue);
            GoToPage(1, pageSize);
        }

        private void GoToPage(int pageIndex, int pageSize)
        {
            this.GenerateDataPager(pageSize);
            this.CheckSortingAndFiltering();
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
            string[] strKeyName = new string[] { "Id", "Title"};
            using (var ctx = new NewsVnContext(ApplicationManager.ConnectionString))
            {
                Expression<Func<Impl.Entity.Post, bool>> expression = p => true;

                if (FilterExpression != null)
                {
                    expression = FilterExpression;
                }

                // Combine with other expression
                expression = expression.And(p => p.Actived == true && p.Approved == true);
                
                var posts = ctx.PostRepo.Getter.getQueryable(expression)
                    .OrderByDescending(p => p.ApprovedOn).AsQueryable();

                posts = ctx.PostRepo.Getter.getSortedList(posts, OrderBy);

                GridView1.DataSource = ctx.PostRepo.Getter.getPagedList(posts, pageIndex, pageSize).Select(p => new
                    {
                        p.ID,
                        p.Title,
                        p.Description,
                        p.SeoUrl,
                        p.Approved,
                        p.ApprovedOn,
                        p.ApprovedBy,
                        p.Actived,
                        CategoryName = p.Category.Parent == null ? p.Category.Name : p.Category.Parent.Name + "/" + p.Category.Name,
                    });
                GridView1.DataKeyNames = strKeyName;
                GridView1.DataBind();
            }
        }

        private void GenerateDataPager(int pageSize)
        {
            using (var ctx = new NewsVnContext(ApplicationManager.ConnectionString))
            {
                Expression<Func<Impl.Entity.Post, bool>> expression = p => true;

                if (FilterExpression != null)
                {
                    expression = FilterExpression;
                }

                // Combine with other expression
                expression = expression.And(p => p.Actived == true && p.Approved == true);

                int numOfRecords = ctx.PostRepo.Getter.getQueryable(expression).Count();
                int numOfPages = (int)Math.Ceiling((decimal)numOfRecords / pageSize);
              
                ddlPageIndex.Items.Clear();

                if (numOfPages > 0)
                {
                    for (int i = 1; i <= numOfPages; i++)
                    {
                        ddlPageIndex.Items.Add(new ListItem(i.ToString(), i.ToString()));
                    }
                }
                else
                {
                    ddlPageIndex.Items.Add("1");
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
                                if (dtRow["ID"].ToString() == GridView1.DataKeys[row.RowIndex]["Id"].ToString())
                                {
                                    existThisItem = true;
                                }
                            }

                            if (existThisItem)
                            {
                                msgExist += "+ [ID:" + GridView1.DataKeys[row.RowIndex]["Id"].ToString() + "] -" + GridView1.DataKeys[row.RowIndex]["Title"].ToString() + "\\n";

                                continue;
                            }
                            int pID = int.Parse(GridView1.DataKeys[row.RowIndex]["Id"].ToString());

                            using (var ctx = new NewsVnContext(ApplicationManager.ConnectionString))
                            {
                                var post = ctx.PostRepo.Getter.getOne(p => p.ID == pID);
                                DataRow r = dt.NewRow();
                                r["ID"] = GridView1.DataKeys[row.RowIndex]["Id"].ToString();
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

        protected void fpViewPost_Filtered(object sender, Expression<Func<Impl.Entity.Post, bool>> expression, FilterModel model)
        {
            FilterExpression = expression;
            FilterModel = model;
            this.GoToFirstPage();
        }

        protected void grvShow_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowIndex >= 0)
            {
                LinkButton lnkbtnDel = e.Row.FindControl("lnkbtnDel") as LinkButton;
                lnkbtnDel.Attributes.Add("onClick", "return confirmDelete('" + System.Web.UI.DataBinder.Eval(e.Row.DataItem, "ID").ToString() + "');");
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
                ltrError.Text = string.Format(InfoBar, ex);
                Utils.clsCommon.Excute_Javascript("alert('Xóa thất bại - xem lỗi: \\n" + ex.Message.ToString() + "')", this.Page, true);
            }
        }

        private void CheckSortingAndFiltering()
        {
            btnClearSort.Visible = !string.IsNullOrEmpty(OrderBy);
            btnClearFilter.Visible = FilterExpression != null;

            var sb = new StringBuilder();

            if (!string.IsNullOrEmpty(OrderBy))
            {
                sb.AppendFormat("Đang sắp xếp theo: <b>{0}</b>", ddlSortColumn.SelectedItem.Text);
                sb.AppendFormat(", chiều: <b>{0}</b>", ddlSortDirection.SelectedItem.Text);
            }

            if (FilterExpression != null)
            {
                sb.Append(string.IsNullOrEmpty(OrderBy) ? "" : " | ");
                sb.Append("Đang lọc theo: ");

                var token = FilterModel.Token as Impl.Entity.Post;

                if (!string.IsNullOrEmpty(token.Title))
                {
                    sb.AppendFormat("Tiêu đề: <b>{0}</b>, ", token.Title);
                }
                if (!string.IsNullOrEmpty(token.Category.Name))
                {
                    sb.AppendFormat("Danh mục: <b>{0}</b>, ", token.Category.Name);
                }
                if (!string.IsNullOrEmpty(token.UpdatedBy))
                {
                    sb.AppendFormat("Người sửa: <b>{0}</b>, ", token.UpdatedBy);
                }
                if (token.UpdatedOn != null)
                {
                    sb.AppendFormat("Ngày sửa: <b>{0:dd/MM/yyyy}</b>, ", token.UpdatedOn);
                }
                if (!string.IsNullOrEmpty(token.ApprovedBy))
                {
                    sb.AppendFormat("Người duyệt: <b>{0}</b>, ", token.ApprovedBy);
                }
                if (token.ApprovedOn != null)
                {
                    sb.AppendFormat("Ngày duyệt: <b>{0:dd/MM/yyyy}</b>, ", token.ApprovedOn);
                }

                if (FilterModel.Data.Keys.Contains("ManagePost_FilterMethod"))
                {
                    sb.AppendFormat("Phương pháp: <b>{0}</b>, ",
                        FilterModel.Data["ManagePost_FilterMethod"].ToString());
                }

                if (FilterModel.Data.Keys.Contains("ManagePost_FilterChain"))
                {
                    sb.AppendFormat("Kết điều kiện: <b>{0}</b>",
                        FilterModel.Data["ManagePost_FilterChain"].ToString());
                }
            }

            string infoText = sb.ToString();

            if (!string.IsNullOrEmpty(infoText))
            {
                ltrInfo.Text = string.Format(InfoBar, infoText);
            }
            else
            {
                ltrInfo.Text = string.Empty;
            }
        }
    }
}