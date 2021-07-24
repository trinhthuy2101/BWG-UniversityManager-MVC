use DB05
go
create table Student
(
	Id varchar(100),
	Name nvarchar(100),
	Class varchar(100),
	Idc varchar(100),
	Email varchar(100),
	constraint PK_Student primary key(Id)
)
go
create table Class
( 
	Id varchar(100),
	Dep varchar(100),
	constraint PK_Class primary key(Id)
)
go
create table Department
(
	Id varchar(100),
	Uni varchar(100),
	Name nvarchar(100),
	constraint PK_Dep primary key(Id)
)
go
create table University
(
	Id varchar(100),
	Name nvarchar(100),
	constraint PK_Uni primary key(Id)
)
go
----------------
create table Account
(
	Id varchar(100),
	Password varchar(100),
	constraint PK_Account primary key(Id)
)
create table Teacher
( 
	Id varchar(100),
	Name nvarchar(100),
	Idc varchar(100),
	Email varchar(100),
	constraint PK_Teacher primary key(Id)
)
create table Course
( 
	Id varchar(100),
	Subject varchar(100),
	Teacher varchar(100),
	Room varchar(100),
	StartDate date,
	EndDate date,
	Time varchar(100),
	constraint PK_Course primary key(Id)
)
create table Room
(	
	Id varchar(100),
	constraint PK_Room primary key(Id)
)
create table RegisteredCourse
(
	Course varchar(100),
	Student varchar(100),
	Point int,
	constraint PK_RCourse primary key(Course,Student)
)
create table Subject 
(
	Id varchar(100),
	Name varchar(100),
	Credits int,
	constraint PK_Subject primary key(Id)
)
----------------
alter table Student add CONSTRAINT PK_Student_Class foreign key(Class) references Class(Id)
go
alter table Class add CONSTRAINT PK_Class_Dep foreign key(Dep) references Department(Id)
go
alter table Department add  CONSTRAINT PK_Dep_Uni foreign key(Uni) references University(Id)
go
go
alter table Course add foreign key(Teacher) references Teacher(Id)
go
alter table Course add foreign key(Room) references Room(Id)
go
alter table Course add foreign key(Subject) references Subject(Id)
go
alter table RegisteredCourse add foreign key(Course) references Course(Id)
go
alter table RegisteredCourse add foreign key(Student) references Student(Id)
go

---------------
insert into University values('KHTN',N'KHOA HỌC TỰ NHIÊN') 
go
insert into University values('HNED',N'ĐẠI HỌC SƯ PHẠM HÀ NỘI')
go
insert into University values('USSH',N'KHOA HỌC XÃ HỘI VÀ NHÂN VĂN')
-----------
go
insert into Department values('CNTT','KHTN',N'Công nghệ thông tin')
go
insert into Department values('CNSH','KHTN',N'Công nghệ sinh học')
go
insert into Department values('SPLS','HNED',N'Sư phạm Sử')
go
insert into Department values('DTVT','HNED',N'Điện tử viễn thông')
go
insert into Department values('BCTT','USSH',N'Báo chí truyền thông')
go
insert into Department values('NDPH','USSH','Đông phương học')
go
-----------
go
insert into Class values('19CTT2','CNTT')
go
insert into Class values('19CNTN','CNTT')
go
insert into Class values('19CTT1','CNTT')
go
insert into Class values('19CSH1','CNSH')
go
insert into Class values('19BC01','BCTT')
go
insert into Class values('19TT01','BCTT')
go
insert into Class values('19DL01','NDPH')
go
insert into Class values('19HQ01','NDPH')
go
insert into Class values('19KHMT','CNTT')
go
insert into Class values('19ATTT','CNTT')
go
insert into Class values('19HTTT','SPLS')
go
insert into Class values('19KTPM','SPLS')
go
--------------
insert into Student values('ST01',N'Trịnh Thị Thùy','19CTT2','241847274','st01@Student.edu.com')
go
insert into Student values('ST02',N'Nguyễn Đoan Phúc','19CTT2','916016257','st02@Student.edu.com')
go
insert into Student values('ST03',N'Nguyễn Lê Bảo Thi','19CNTN','167458303','st03@Student.edu.com')
go
insert into Student values('ST04',N'Lê Đức Minh','19CNTN','640067413','st04@Student.edu.com')
go
insert into Student values('ST05',N'Trịnh Xuân Thiện','19CTT1','196713758','st05@Student.edu.com')
go
insert into Student values('ST06',N'Trịnh Thị Minh Thư','19CTT1','657896835','st06@Student.edu.com')
go
insert into Student values('ST07',N'Nguyễn Xuân Nhi','19BC01','492807967','st07@Student.edu.com')
go
insert into Student values('ST08',N'Trần Yến Phương','19DL01','090973630','st08@Student.edu.com')
go
insert into Student values('ST09',N'Nguyễn Ngọc Bảo Hân','19TT01','338690462','st09@Student.edu.com')
go
insert into Student values('ST10',N'Huỳnh Lê Khánh Huyền','19HQ01','769064308','st10@Student.edu.com')
go
insert into Student values('ST11',N'Huỳnh Lê Ánh Huyền','19HQ01','095121702','st11@Student.edu.com')
go
insert into Student values('ST12',N'Nguyễn Thu Hảo','19DL01','269843912','st12@Student.edu.com')
go
insert into Student values('ST13',N'Bùi Hoàng Hưng','19BC01','219339843','st13@Student.edu.com')
go
insert into Student values('ST14',N'Nguyễn Quốc Huy','19TT01','296871623','st14@Student.edu.com')
go
insert into Student values('ST15',N'Nguyễn Công Đức','19KHMT','294623997','st15@Student.edu.com')
go
insert into Student values('ST16',N'Nguyễn Trần Khả Ái','19KHMT','248535223','st16@Student.edu.com')
go
insert into Student values('ST17',N'Nguyễn Bình','19ATTT','022472370','st17@Student.edu.com')
go
insert into Student values('ST18',N'Trịnh Văn Minh','19ATTT','341783658','st18@Student.edu.com')
go
insert into Student values('ST19',N'Phan Trịnh Thanh Hà','19KTPM','273115248','st20@Student.edu.com')
go
insert into Student values('ST20',N'Trần Văn Trường An','19HTTT','272313287','st21@Student.edu.com')
go
----------------------------------------------------------------------------------------------------------
insert into Teacher values('GV01',N'ĐINH HUỲNH TIẾN PHÚ','222163585','gv01@Teacher.edu.com')
go
insert into Teacher values('GV02',N'Đặng Đức Thắng','447180359','gv02@Teacher.edu.com')
go
insert into Teacher values('GV03',N'Trần Văn Nam','269783912','gv03@Teacher.edu.com')
go
insert into Teacher values('GV04',N'Bùi Hoàng','219339893','gv04@Teacher.edu.com')
go
insert into Teacher values('GV05',N'Nguyễn Huy','298881623','gv05@Teacher.edu.com')
go
insert into Teacher values('GV06',N'Nguyễn Đức','29499997','gv06@Teacher.edu.com')
go
insert into Teacher values('GV07',N'Nguyễn Khả Ái','248530023','gv07@Teacher.edu.com')
go
insert into Teacher values('GV08',N'Nguyễn Nam','022000370','gv08@Teacher.edu.com')
---------------------------------------------------------------------------------------------------------
insert into Account values('ADMIN','12345')
go
insert into Account values('GV01','02468')
go
insert into Account values('GV02','02468')
go
insert into Account values('GV03','02468')
go
insert into Account values('GV04','02468')
go
insert into Account values('GV05','02468')
go
insert into Account values('GV06','02468')
go
insert into Account values('GV07','02468')
go
insert into Account values('GV08','02468')
go
insert into Account values('ST01','13579')
go
insert into Account values('ST02','13579')
go
insert into Account values('ST03','13579')
go
insert into Account values('ST04','13579')
go
insert into Account values('ST05','13579')
go
insert into Account values('ST06','13579')
go
insert into Account values('ST07','13579')
go
insert into Account values('ST08','13579')
go
insert into Account values('ST09','13579')
go
insert into Account values('ST10','13579')
go
insert into Account values('ST11','13579')
go
insert into Account values('ST12','13579')
go
insert into Account values('ST13','13579')
go
insert into Account values('ST14','13579')
go
insert into Account values('ST15','13579')
go
insert into Account values('ST16','13579')
go
insert into Account values('ST17','13579')
go
insert into Account values('ST18','13579')
go
insert into Account values('ST19','13579')
go
insert into Account values('ST20','13579')
go
insert into Room values('R01')
go
insert into Room values('R02')
go
insert into Room values('R03')
go
insert into Room values('R04')
go
insert into Subject values('CSDL',N'Cơ Sở Dữ Liệu',4)
go
insert into Subject values('HTMT',N'Hệ Thống Máy Tính',3)
go
insert into Subject values('MMT',N'Mạng Máy Tính',4)
go
insert into Subject values('LTHDT',N'Lập Trình Hướng Đối Tượng',4)
go
insert into Subject values('THTH',N'Toán Học Tổ Hợp',4)
go
insert into Course Values('C01','CSDL','GV01','R01','3/1/2021','7/1/2021','AM')
go
insert into Course Values('C02','LTHDT','GV02','R03','3/2/2021','7/1/2021','AM')
go
insert into Course Values('C03','THTH','GV03','R04','3/3/2021','7/1/2021','PM')
go
insert into Course Values('C04','HTMT','GV05','R02','3/4/2021','7/1/2021','PM')
go

------------------------------------------------STORE PROCEDURE-------------------------------------------
create proc USP_PRINT_Student_FULL
as
begin
	print 'Table is already full';
end
go
create proc USP_PRINT_Student
	@Id char(8),
	@Name nvarchar(100)
as
begin
	print @Id+':' +@Name;
end
go

------------------------------------------------TRIGGER ROCEDURE-----------------------------------------
------------PREVENT Student INSERTION IF COUNT >30-----------
create trigger UTG_Student_INSERT_PREVENT on Student for insert
as
begin
	declare @count int
	select @count=count(*)
	from Student
	if(@count=30)
	begin
	exec USP_PRINT_Student_FULL
	rollback tran
	end
end
go
-------------PRINT NEAREST DELETED Student------------------------------
create trigger UTG_Student_DELETE on Student after delete, update
as
	declare @sl_Id varchar(100)
	declare @sl_Name nvarchar(100)
begin
	select @sl_Id=D.Id,@sl_Name=D.Name
	from deleted D
	EXEC USP_PRINT_Student @sl_Id,@sl_Name;
end
go
-------------PRINT NEAREST INSERTED Student----------------------------
create trigger UTG_Student_INSERT on Student after insert
as
	declare @sl_Id varchar(100)
	declare @sl_Name nvarchar(100)
begin
	select @sl_Id=I.Id,@sl_Name=I.Name
	from inserted I
	EXEC USP_PRINT_Student @sl_Id,@sl_Name;
end
go


