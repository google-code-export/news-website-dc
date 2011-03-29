<%@ Control Language="C#" ClassName="RelatedPostList" %>

<script type="text/javascript">
    $(function () {
        $(".related-posts .post-item-list li:first-child").addClass("head");
    });
</script>

<div class="portlet related-posts">
    <h2>Các tin khác</h2>
    <ul class="post-item-list">
        <li>
            <a href="#" class="post-title inline">Mẹo tiết kiệm nhiên liệu cho thời "bão giá"</a>
            - <span class="post-info"><%= string.Format("{0:dddd, dd/MM/yyyy}", DateTime.Now) %></span>
        </li>
        <li>
            <a href="#" class="post-title inline">Mẹo tiết kiệm nhiên liệu cho thời "bão giá"</a>
            - <span class="post-info"><%= string.Format("{0:dddd, dd/MM/yyyy}", DateTime.Now) %></span>
        </li>
        <li>
            <a href="#" class="post-title inline">Mẹo tiết kiệm nhiên liệu cho thời "bão giá"</a>
            - <span class="post-info"><%= string.Format("{0:dddd, dd/MM/yyyy}", DateTime.Now) %></span>
        </li>
        <li>
            <a href="#" class="post-title inline">Mẹo tiết kiệm nhiên liệu cho thời "bão giá"</a>
            - <span class="post-info"><%= string.Format("{0:dddd, dd/MM/yyyy}", DateTime.Now) %></span>
        </li>
        <li>
            <a href="#" class="post-title inline">Mẹo tiết kiệm nhiên liệu cho thời "bão giá"</a>
            - <span class="post-info"><%= string.Format("{0:dddd, dd/MM/yyyy}", DateTime.Now) %></span>
        </li>
    </ul>
</div>
