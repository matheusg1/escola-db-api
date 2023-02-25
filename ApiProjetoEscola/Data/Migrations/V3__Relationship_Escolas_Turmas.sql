Alter table
	Turmas
Add
	EscolaId int not null foreign key references [dbo].[Escolas](EscolaId) on delete cascade on update cascade