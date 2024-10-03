use mvcefcoreDb;

create table FirstTable(
	FirstTableId int Identity(1,1)primary key,
	TextColumn varchar(15) not null);
insert into FirstTable (TextColumn)
	values('TestColumn1');
insert into FirstTable (TextColumn)
	values('TestColumn2');

select * from FirstTable