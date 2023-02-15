Alter table Aluno 
Add Turma int not null foreign key references [dbo].[Turma] on delete cascade on update cascade