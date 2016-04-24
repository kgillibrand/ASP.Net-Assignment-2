drop table if exists categories;

create table categories
(
	categoryID bigint unsigned not null auto_increment,
    primary key (categoryID),
    
    categoryName varchar (255) not null,
    categoryAdded timestamp not null default current_timestamp
);