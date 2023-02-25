Alter table
	Alunos
Add
	TurmaId int not null foreign key references [dbo].[Turmas](TurmaId) on delete cascade on update cascade