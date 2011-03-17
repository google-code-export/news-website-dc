USE [NewsVn]

GO

-- [Categories] --
INSERT INTO [Categories] VALUES(N'Kinh tế',N'','kinh-te','',GETDATE(),NULL,1,NULL)
INSERT INTO [Categories] VALUES(N'Xã hội',N'','xa-hoi','',GETDATE(),NULL,1,NULL)
INSERT INTO [Categories] VALUES(N'Văn hóa',N'','van-hoa','',GETDATE(),NULL,1,NULL)
INSERT INTO [Categories] VALUES(N'Thể thao',N'','the-thao','',GETDATE(),NULL,1,NULL)
INSERT INTO [Categories] VALUES(N'Góc Teen',N'','goc-teen','',GETDATE(),NULL,1,NULL)
INSERT INTO [Categories] VALUES(N'Khoa học',N'','khoa-hoc','',GETDATE(),NULL,1,NULL)
INSERT INTO [Categories] VALUES(N'Du lịch - Ẩm thực',N'','du-lich-am-thuc','',GETDATE(),NULL,1,NULL)
INSERT INTO [Categories] VALUES(N'Tình yêu - Gia đình',N'','tinh-yeu-gia-dinh','',GETDATE(),NULL,1,NULL)
INSERT INTO [Categories] VALUES(N'Thư giãn',N'','thu-gian','',GETDATE(),NULL,1,NULL)
DECLARE @ParentID int
SELECT @ParentID = [ID] from [Categories] where [SeoName] = 'kinh-te'
INSERT INTO [Categories] VALUES(N'Chứng khoán',N'','kinh-te/chung-khoan','',GETDATE(),NULL,1,@ParentID)
INSERT INTO [Categories] VALUES(N'Bất động sản',N'','kinh-te/bat-dong-san','',GETDATE(),NULL,1,@ParentID)
INSERT INTO [Categories] VALUES(N'Doanh nhân',N'','kinh-te/doanh-nhan','',GETDATE(),NULL,1,@ParentID)
INSERT INTO [Categories] VALUES(N'Quốc tế',N'','kinh-te/quoc-te','',GETDATE(),NULL,1,@ParentID)
INSERT INTO [Categories] VALUES(N'Mua sắm',N'','kinh-te/mua-sam','',GETDATE(),NULL,1,@ParentID)
SELECT @ParentID = [ID] from [Categories] where [SeoName] = 'xa-hoi'
INSERT INTO [Categories] VALUES(N'Giáo dục',N'','giao-duc','',GETDATE(),NULL,1,@ParentID)
INSERT INTO [Categories] VALUES(N'Du học',N'','du-hoc','',GETDATE(),NULL,1,@ParentID)
INSERT INTO [Categories] VALUES(N'Thế giới',N'','the-gioi','',GETDATE(),NULL,1,@ParentID)
SELECT @ParentID = [ID] from [Categories] where [SeoName] = 'van-hoa'
INSERT INTO [Categories] VALUES(N'Hoa hậu',N'','hoa-hau','',GETDATE(),NULL,1,@ParentID)
INSERT INTO [Categories] VALUES(N'Nghệ sỹ',N'','nghe-sy','',GETDATE(),NULL,1,@ParentID)
INSERT INTO [Categories] VALUES(N'Âm nhạc',N'','am-nhac','',GETDATE(),NULL,1,@ParentID)
INSERT INTO [Categories] VALUES(N'Thời trang',N'','thoi-trang','',GETDATE(),NULL,1,@ParentID)
INSERT INTO [Categories] VALUES(N'Điện ảnh',N'','dien-anh','',GETDATE(),NULL,1,@ParentID)
INSERT INTO [Categories] VALUES(N'Mỹ thuật',N'','my-thuat','',GETDATE(),NULL,1,@ParentID)
INSERT INTO [Categories] VALUES(N'Văn học',N'','van-hoc','',GETDATE(),NULL,1,@ParentID)
SELECT @ParentID = [ID] from [Categories] where [SeoName] = 'the-thao'
INSERT INTO [Categories] VALUES(N'Bóng đá',N'','bong-da','',GETDATE(),NULL,1,@ParentID)
INSERT INTO [Categories] VALUES(N'Tennis',N'','tennis','',GETDATE(),NULL,1,@ParentID)
INSERT INTO [Categories] VALUES(N'Chân dung',N'','chan-dung','',GETDATE(),NULL,1,@ParentID)
INSERT INTO [Categories] VALUES(N'Ảnh - Video',N'','anh-video','',GETDATE(),NULL,1,@ParentID)
SELECT @ParentID = [ID] from [Categories] where [SeoName] = 'khoa-hoc'
INSERT INTO [Categories] VALUES(N'Môi trường',N'','moi-truong','',GETDATE(),NULL,1,@ParentID)
INSERT INTO [Categories] VALUES(N'Thiên nhiên',N'','thien-nhien','',GETDATE(),NULL,1,@ParentID)
INSERT INTO [Categories] VALUES(N'Ảnh',N'','anh','',GETDATE(),NULL,1,@ParentID)
INSERT INTO [Categories] VALUES(N'Công nghệ mới',N'','cong-nghe-moi','',GETDATE(),NULL,1,@ParentID)
--INSERT INTO [Categories] VALUES(N'Name',N'Description','SeoName','SeoUrl',GETDATE(),NULL,1,NULL)

GO

-- [Posts] --
DECLARE @CategoryID int
SELECT @CategoryID = [ID] from [Categories] where [SeoName] = 'kinh-te'
INSERT INTO [Posts] VALUES(N'Title','Avatar','Description',N'Content','SeoUrl',N'Tag',0,1,GETDATE(),'siteadmin',NULL,NULL,1,1,GETDATE(),'siteadmin',1,@CategoryID)
--INSERT INTO [Posts] VALUES(N'Title','Avatar','Description',N'Content','SeoUrl',N'Tag',0,1,GETDATE(),'siteadmin',NULL,NULL,1,1,GETDATE(),'siteadmin',1,@CategoryID)