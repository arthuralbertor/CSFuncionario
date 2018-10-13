CREATE DATABASE CSF
GO
USE CSF
GO
CREATE TABLE func(
codFuncionario INT NOT NULL IDENTITY (1,1) PRIMARY KEY,
nome varchar(400) NOT NULL,
dataNascimento datetime NOT NULL,
salario numeric(18,2) NOT NULL,
atividades varchar(MAX) NOT NULL
);
GO
SELECT * FROM func
GO
INSERT INTO func (nome,dataNascimento,salario,atividades) VALUES('Joao', '2018/10/11', 2000, 'tester')
GO
INSERT INTO func (nome,dataNascimento,salario,atividades) VALUES('Maria', '2018/10/12', 2000, 'developer')
GO
INSERT INTO func (nome,dataNascimento,salario,atividades) VALUES('Jose', '2018/10/12', 2000, 'Realiza o desenvolvimento técnico e visual de páginas da internet e manutenção de sites, definindo linguagens, bancos de dados, armazenamento e atualização de informações, a fim de atender o volume de internautas e seu correto funcionamento.')