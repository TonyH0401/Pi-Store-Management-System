--create database NET_MIDTERM
--use NET_MIDTERM

create table __Employee(
	employee_ID varchar(10),
	employee_name nvarchar(255),
	employee_email varchar(255),
	employee_phone varchar(10),
	employee_address nvarchar(255),
	employee_salary int,
	hired_date date,

	constraint PK_Employee primary key (employee_ID)
)

create table __Client(
	client_ID varchar(10),
	client_name nvarchar(255),
	client_email varchar(255),
	client_phone varchar(10),
	client_address nvarchar(255),

	constraint PK_Client primary key (client_ID)
)

create table __Product(
	product_ID varchar(10),
	product_name nvarchar(255),
	product_desp nvarchar(255),
	product_price float,
	product_quantity int,

	constraint PK_Product primary key(product_ID)
)

create table __Order(
	order_ID varchar(10),
	client_ID varchar(10),
	employee_ID varchar(10),
	order_data date,
	total_price float,

	constraint PK_Order primary key (order_ID),
	constraint FK_Order_Client foreign key (client_ID) references __Client (client_ID),
	constraint FK_Order_Employee foreign key (employee_ID) references __Employee (employee_ID),
)

create table __OrderItem(
	order_item_ID varchar(10),
	order_ID varchar(10),
	product_ID varchar(10),
	product_quantity int,

	constraint PK_OrderItem primary key (order_item_ID, order_ID),
	constraint FK_OrderItem_Order foreign key (order_ID) references __Order(order_ID),
	constraint FK_OrderItem_Product foreign key (product_ID) references __Product(product_ID)
)

create table __Bill(
	bill_ID varchar(10),
	order_ID varchar(10),
	client_ID varchar(10),
	employee_ID varchar(10),
	bill_date date,
	total_price float,

	constraint PK_Bill primary key (bill_ID),
	constraint FK_Bill_Order foreign key (order_ID) references __Order(order_ID),
	constraint FK_Bill_Client foreign key (client_ID) references __Client(client_ID),
	constraint FK_Bill_Employee foreign key (employee_ID) references __Employee(employee_ID)
)

-----------------------------------------------------------------------------------------------

insert into __Employee values ('admin', N'admin', 'admin@admin.com', '0000000000', N'1 Trường Chinh', 0, '2015-05-12')
insert into __Employee values ('ES00000001', N'Lê Văn Lương', 'levanluong@staff.com', '111222333', N'1 Nguyễn Bỉnh Khiêm', 25, '2020-12-12')
insert into __Employee values ('ES00000002', N'Nguyễn Lê Hoàng', 'nguyenlehoang@staff.com', '222333444', N'1 Nguyễn Thị Minh Khai', 25, '2020-11-10')
insert into __Employee values ('EM00000001', N'Hoàng Văn Thụ', 'hoangvanthu@staff.com', '333444555', N'1 Nguyễn Đình Chiểu', 50, '2019-01-23')
select * from __Employee

insert into __Client values ('C000000001', N'Hồ Văn quyết', 'hovanquyet@client.com', '0101010101', N'1 Tân Phong')
insert into __Client values ('C000000002', N'Hồ Quý Ly', 'hoquyly@client.com', '0202020202', N'1 Bình Dương')
insert into __Client values ('VIP0000001', N'Hồ Ngang Hội', 'honganghoi@cient.com', '0303030303', N'1 Hồ Chí Minh')
select * from __Client

insert into __Product values ('P000000001', N'iPhone New Year', 'This is a new iPhone from Apple', 20, 200)
insert into __Product values ('P000000002', N'Samsung Note FE', 'Samsung phone for fans', 15, 200)
insert into __Product values ('P000000003', N'Xiao Mi Express', 'A faster Xiaomi phone', 10, 100)
select * from __Product

--select * from __Order
--select * from __OrderItem
--delete from __OrderItem
--delete from __Order

