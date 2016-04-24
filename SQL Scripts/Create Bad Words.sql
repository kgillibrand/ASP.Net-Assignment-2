drop table if exists badWords;

create table badWords
(
	wordID bigint unsigned not null auto_increment,
    primary key (wordID),
    
    wordText varchar (255) not null,
	wordAdded timestamp not null default current_timestamp
);