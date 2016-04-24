drop table if exists comments;

create table comments
(
	commentID bigint unsigned not null auto_increment,
		primary key (commentID),
    
    productID bigint unsigned not null,
		foreign key (productID) references products (productID)
        on update cascade
		on delete cascade,
    
    commentName varchar (255) not null,
    commentRating tinyint not null,
    commentText varchar (20000) not null,
    commentPosted timestamp not null default current_timestamp ()
);