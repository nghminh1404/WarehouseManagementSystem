Insert into [Status] (StatusType)
values ('Active'),
 ('Inactive'),
('On Progress'),
('Completed'),
('Cancel')
Select * from [Status]

Insert into [Role] (RoleName)values
('Administrator'),('Project Manager'),('Storekeeper'),('Accountant')
Select * from [Role]

insert into ActionType (ActionId,[Action]) values (1,N'Nhập hàng')
insert into ActionType (ActionId,[Action]) values (2,N'Xuất hàng')
insert into ActionType (ActionId,[Action]) values (3,N'Sửa hàng')
insert into ActionType (ActionId,[Action]) values (4,N'Khởi tạo')
insert into ActionType (ActionId,[Action]) values (5,N'Kiểm hàng')
insert into ActionType (ActionId,[Action]) values (6,N'Trả hàng')
insert into ActionType (ActionId,[Action]) values (7,N'Nhập hàng trả')
Select * from [ActionType]
