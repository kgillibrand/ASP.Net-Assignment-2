drop table if exists products;

create table products
(
	productID bigint unsigned not null auto_increment,
		primary key (productID),
    
    categoryID bigint unsigned not null,
		foreign key (categoryID) references categories (categoryID)
        on update cascade
        on delete cascade,
    
    productName varchar (255) not null,
    productShortDescription varchar (255) not null,
    productLongDescription varchar (20000) not null,
    productPrice double (16,2) not null,
    productSalePrice double (16,2) not null,
    productOnSale bit not null,
    productAdded timestamp not null default current_timestamp
);